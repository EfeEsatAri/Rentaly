using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.DtoLayer.ReservationDtos
{
    public class GetByIdReservationDto
    {
        public int ReservationId { get; set; }
        public int CarId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string VerificationCode { get; set; }
        public bool IsEmailVerified { get; set; }
        public string Status { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.Now;
    }
}
