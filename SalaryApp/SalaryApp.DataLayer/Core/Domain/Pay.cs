namespace SalaryApp.DataLayer.Core.Domain
{
    public class Pay
    {
        public int Id { get; set; }
        [VerboseName("عنوان پرداخت:")]
        public string Title { get; set; }
        [VerboseName("نام کارگاه:")]
        public Workshop Workshop { get; set; }
        public FincancialYear FinancialYear { get; set; }
        [VerboseName("شناسه ماه:")]
        public int MonthId { get; set; }
        [VerboseName("تعداد کارکنان:")]
        public int EmployeesCount { get; set; }
        public decimal TotalGrossAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal TotalInsuraceAmount { get; set; }
        public decimal TotalNetAmount { get; set; }
        public byte Status { get; set; }
        public bool IsDeleted { get; set; }
        [VerboseName("نوع پرداخت")]
        public virtual PayType PayType { get; set; }

    }

    
}
