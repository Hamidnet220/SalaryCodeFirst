namespace SalaryApp.DataLayer.Core.Domain
{
    public class PayType
    {
        public int Id { get; set; }
        public string PayTitle { get; set; }
        public PayDiscription PayDiscription { get; set; }
        public string Description { get; set; }
        
    }

    public enum PayDiscription
    {
        MonthlyWage,
        AnnualPay,
        Bonus,
        InPartPyment,

    }
}