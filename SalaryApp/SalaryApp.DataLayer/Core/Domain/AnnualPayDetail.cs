namespace SalaryApp.DataLayer.Core.Domain
{
    public class AnnualPayDetails
    {
        public int Id { get; set; }
        public Pay Pay { get; set; }
        public Employee Employee { get; set; }
        public Workgroup WorkGroup { get; set; }
        public decimal DailyRate { get; set; }
        public int TotalDaysOfWork { get; set; }
        public int TotalLeaveDays { get; set; }
        public int TotalAbsentDays { get; set; }
        public decimal EadiAmount { get; set; }
        public decimal SanavatAmount { get; set; }
        public decimal LeaveAmount { get; set; }
        public decimal BackpayAmount { get; set; }
        public decimal BackpayExempt { get; set; }
        public decimal GrossAmount { get; set; }
        public bool IsInsuranceExempt { get; set; }
        public decimal InsuranceIncluded { get; set; }
        public decimal EmployeeIncurance { get; set; }
        public decimal EmployeerIncurance { get; set; }
        public bool IsTaxExempt { get; set; }
        public decimal TaxIncluded { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal PayInAdvance { get; set; }
        public decimal Loan { get; set; }
        public decimal InPartPayment { get; set; }
        public decimal OtherDeduction { get; set; }
        public decimal OtherDeduction1 { get; set; }
        public decimal NetAmount { get; set; }
        public string Description { get; set; }
    }
}
