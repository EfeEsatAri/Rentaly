using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Concrete;
using Rentaly.EntityLayer.Entities;
using Rentaly.WebUI.Models;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class _LayoutController : Controller
    {
        private readonly RentalyContext _context;

        public _LayoutController(RentalyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Brands = await _context.Brands.ToListAsync();
            ViewBag.Branches = await _context.Branches.ToListAsync();
            return View();
        }
        public async Task<IActionResult> CarList(int? brandId, int? branchId, string fuelType, bool? transmission, int? minPrice, int? maxPrice, int page = 1)
        {
            const int pageSize = 6;
            ViewBag.Brands = await _context.Brands.ToListAsync();
            ViewBag.Branches = await _context.Branches.ToListAsync();
            var query = _context.Cars
                .Include(x => x.Brand)
                .Include(x => x.CarModel)
                .Include(x => x.Category)
                .Where(x => x.IsActive && x.IsAvailable && !string.IsNullOrEmpty(x.ImageUrl))
            .AsQueryable();

            if (brandId.HasValue)
                query = query.Where(x => x.BrandId == brandId);

            // Yakıt Tipi Filtresi
            if (!string.IsNullOrEmpty(fuelType))
                query = query.Where(x => x.FuelType == fuelType);

            // Vites Filtresi (True: Otomatik, False: Manuel)
            if (transmission.HasValue)
                query = query.Where(x => x.IsAvailable == transmission.Value);

            if (branchId.HasValue)
                query = query.Where(x => x.BranchId == branchId);

            // Fiyat Filtresi
            if (minPrice.HasValue)
                query = query.Where(x => x.DailyPrice >= minPrice.Value);
            if (maxPrice.HasValue)
                query = query.Where(x => x.DailyPrice <= maxPrice.Value);

            int totalItems = await query.CountAsync();

            var values = await query
                .OrderByDescending(x => x.CarId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new CarListViewModel
                {
                    CarId = x.CarId,
                    BrandName = x.Brand.BrandName,
                    ModelName = x.CarModel.ModelName,
                    ImageUrl = x.ImageUrl,
                    SeatCount = x.SeatCount,
                    LuggageCount = x.LuggageCount,
                    FuelType = x.FuelType,
                    CategoryName = x.Category.CategoryName,
                    DailyPrice = x.DailyPrice,
                    DepositAmount = x.DepositAmount,
                    IsAutomatic = x.IsAvailable
                }).ToListAsync();

            ViewBag.SelectedBrand = brandId;
            ViewBag.SelectedFuel = fuelType;
            ViewBag.SelectedTransmission = transmission;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            ViewBag.SelectedBranch = branchId;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            return View(values);
        }
        [HttpGet]
        public IActionResult CarDetails(int id)
        {
            Random rnd = new Random();
            string code = rnd.Next(100000, 999999).ToString();
            var value = _context.Cars
                .Include(x => x.Brand)
                .Include(x => x.CarModel)
                .Include(x => x.Category)
                .Include(x => x.Branch)
                .FirstOrDefault(x => x.CarId == id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> BookReservation(Reservation reservation)
        {
            // 1. Kod Üretimi
            Random rnd = new Random();
            string verificationCode = rnd.Next(100000, 999999).ToString();

            reservation.VerificationCode = verificationCode;
            reservation.Status = "Beklemede";
            reservation.IsEmailVerified = false;

            // 2. Veritabanına Kayıt
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            // 3. Mail İçeriği Hazırlama
            var subject = "Rezervasyon Doğrulama Kodu";
            var mailBody = $@"
<div style='font-family: Arial; border: 1px solid #eee; padding: 20px; text-align: center;'>
    <h2 style='color: #f30;'>Rentaly Araç Kiralama</h2>
    <p>Merhaba <b>{reservation.Name} {reservation.Surname}</b>,</p>
    <p>Rezervasyonunuzu doğrulamak için aşağıdaki kodu kullanın:</p>
    <div style='font-size: 32px; font-weight: bold; letter-spacing: 5px; padding: 10px; background: #f9f9f9; display: inline-block;'>
        {verificationCode}
    </div>
    <p style='color: #666;'>Bu kod doğrulama işlemi için gereklidir. Lütfen kimseyle paylaşmayın.</p>
</div>";

            try
            {
                SendEmail(reservation.Email, subject, mailBody);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Mail gönderilirken bir hata oluştu: " + ex.Message });
            }
            return Json(new { success = true, reservationId = reservation.ReservationId });
        }

        private void SendEmail(string receiverEmail, string subject, string body)
        {
            var message = new MimeMessage();

            // Gönderen Bilgisi
            message.From.Add(new MailboxAddress("Rentaly Araç Kiralama", "efeesat00@gmail.com"));

            // Alıcı Bilgisi
            message.To.Add(new MailboxAddress("", receiverEmail));

            // Konu
            message.Subject = subject;

            // İçerik (HTML formatında)
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = body;
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                // Gmail için smtp.gmail.com kullanıyoruz
                // 587 portu ve StartTls güvenliği en sağlıklı olanıdır
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                // Uygulama Şifreni (16 haneli kod) buraya yazmalısın
                client.Authenticate("efeesat00@gmail.com", "pnfs nkto epin tkxs");

                client.Send(message);
                client.Disconnect(true);
            }
        }
        [HttpPost]
        public IActionResult ConfirmCode(int reservationId, string code)
        {
            var reservation = _context.Reservations.FirstOrDefault(x => x.ReservationId == reservationId);

            if (reservation != null && reservation.VerificationCode == code)
            {
                // 1. Rezervasyonu Onayla
                reservation.IsEmailVerified = true;
                reservation.Status = "Müşteri Tarafından Onaylandı";

                // 2. ARABAYI KİRADA DURUMUNA GETİR (Eksik olan kısım burasıydı)
                var car = _context.Cars.FirstOrDefault(x => x.CarId == reservation.CarId);
                if (car != null)
                {
                    car.IsAvailable = false; // Artık başkası kiralayamaz
                }

                _context.SaveChanges();

                return Json(new { success = true, message = "Kod doğrulandı ve rezervasyonunuz kesinleşti. Araç şu an sizin için ayrıldı." });
            }

            return Json(new { success = false, message = "Girdiğiniz kod hatalı, lütfen tekrar deneyiniz." });
        }
        public IActionResult AdminTestOnay(int id)
        {
            // Rezervasyonu ve bağlı olduğu Arabayı (Marka ve Model dahil) çekiyoruz
            var reservation = _context.Reservations
                .Include(x => x.Car)
                .ThenInclude(c => c.Brand)
              .Include(x => x.Car)
                .ThenInclude(c => c.CarModel)
                .FirstOrDefault(x => x.ReservationId == id);

            if (reservation != null)
            {
                // 1. Rezervasyon Durumunu Güncelle
                reservation.Status = "Onaylandı";
                _context.SaveChanges();

                // 2. Araba bilgilerine erişim (Hata almamak için kontrol ediyoruz)
                var car = reservation.Car;
                if (car == null) return Content("Araba bilgisi bulunamadı.");

                // 3. İndirim Kuponu Üretimi (Rastgele 4 hane)
                string discountCode = "RENT" + Guid.NewGuid().ToString().Substring(0, 4).ToUpper();

                // 4. Mail Konusu
                var mailSubject = "Rezervasyonunuz Onaylandı! Size Bir Hediyemiz Var 🎁";

                // 5. Şık Tasarımlı Mail Gövdesi (Hediye ve Bilgilendirme bir arada)
                var mailBody = $@"
<div style='font-family: ""Segoe UI"", Tahoma, Geneva, Verdana, sans-serif; max-width: 600px; margin: auto; border: 1px solid #e0e0e0; border-radius: 15px; overflow: hidden; box-shadow: 0 4px 15px rgba(0,0,0,0.1);'>
    
    <div style='background-color: #28a745; padding: 30px; text-align: center; color: white;'>
        <h1 style='margin: 0; font-size: 28px;'>Tebrikler! 🎉</h1>
        <p style='font-size: 16px; opacity: 0.9;'>Rezervasyonunuz Onaylandı.</p>
    </div>

    <div style='padding: 30px; background-color: #ffffff; text-align: center;'>
        <p style='color: #444; font-size: 18px;'>Merhaba <b>{reservation.Name} {reservation.Surname}</b>,</p>
        <p style='color: #666; line-height: 1.6;'>Rezervasyonunuz sistemimiz tarafından onaylanmıştır. Size özel hazırladığımız indirim kuponunu aşağıda bulabilirsiniz:</p>
        
        <div style='margin: 30px 0; padding: 20px; border: 2px dashed #28a745; border-radius: 10px; background-color: #f9fff9; display: inline-block; min-width: 80%'>
            <span style='color: #28a745; font-size: 14px; text-transform: uppercase; font-weight: bold;'>Sonraki Kiralamada Geçerli</span>
            <h2 style='color: #333; margin: 10px 0; font-size: 32px;'>%15 İNDİRİM</h2>
            <div style='background-color: #28a745; color: white; padding: 10px 20px; display: inline-block; font-family: monospace; font-size: 24px; letter-spacing: 3px; border-radius: 5px;'>
                {discountCode}
            </div>
            <p style='color: #999; font-size: 12px; margin-top: 15px;'>*Rezervasyon No: #REC{reservation.ReservationId}</p>
        </div>

        <div style='text-align: left; background-color: #f4f4f4; padding: 15px; border-radius: 8px;'>
            <p style='margin: 0; font-size: 14px; color: #555;'><b>Araç:</b> {car.Brand.BrandName} {car.CarModel.ModelName}</p>
            <p style='margin: 5px 0; font-size: 14px; color: #555;'><b>Plaka:</b> {car.PlateNumber}</p>
        </div>

        <p style='margin-top: 25px; color: #666;'>Keyifli sürüşler dileriz!<br><b>Rentaly Ekibi</b></p>
    </div>

    <div style='background-color: #333; color: #aaa; padding: 15px; text-align: center; font-size: 12px;'>
        © 2026 Rentaly Araç Kiralama. Tüm hakları saklıdır.
    </div>
</div>";

                // Maili gönderiyoruz
                try
                {
                    SendEmail(reservation.Email, mailSubject, mailBody);
                    return Content($"{id} numaralı rezervasyon onaylandı ve indirim kodlu mail gönderildi.");
                }
                catch (Exception ex)
                {
                    return Content("Rezervasyon onaylandı ancak mail gönderilemedi: " + ex.Message);
                }
            }

            return Content("Rezervasyon bulunamadı.");
        }
    }
}
