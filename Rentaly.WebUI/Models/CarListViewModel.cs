namespace Rentaly.WebUI.Models
{
    public class CarListViewModel
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string ImageUrl { get; set; }
        public int SeatCount { get; set; }
        public int LuggageCount { get; set; }
        public string FuelType { get; set; }
        public string CategoryName { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal DepositAmount { get; set; }
        public bool IsAutomatic { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
