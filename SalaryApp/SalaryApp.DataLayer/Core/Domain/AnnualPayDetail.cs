namespace SalaryApp.DataLayer.Core.Domain
{
    public class AnnualPayDetails
    {
        public int Id { get; set; }
        public Pay Pay { get; set; }
        public virtual Employee Employee { get; set; }
        public Workgroup WorkGroup { get; set; }

        [VerboseName("پایه روزانه")]
        public decimal DailyRate { get; set; }

        [VerboseName("پایه روزانه")]
        public int TotalDaysOfWork { get; set; }

        [VerboseName("جمع کل مرخصی")]
        public int TotalLeaveDays { get; set; }

        [VerboseName("جمع روزهای غیبت")]
        public int TotalAbsentDays { get; set; }

        [VerboseName("مبلغ عیدی")]
        public decimal EadiAmount { get; set; }

        [VerboseName("مبلغ سنوات")]
        public decimal SanavatAmount { get; set; }

        [VerboseName("مبلغ مرخصی")]
        public decimal LeaveAmount { get; set; }

        [VerboseName("مبلغ معوق")]
        public decimal BackpayAmount { get; set; }

        [VerboseName("مبلغ معوق معاف")]
        public decimal BackpayExempt { get; set; }

        [VerboseName("مبلغ ناخالص")]
        public decimal GrossAmount { get; set; }

        [VerboseName("معاف از بیمه")]
        public bool IsInsuranceExempt { get; set; }

        [VerboseName("مشمول بیمه")]
        public decimal InsuranceIncluded { get; set; }

        [VerboseName("بیمه کارمند")]
        public decimal EmployeeIncurance { get; set; }

        [VerboseName("بیمه کارفرما")]
        public decimal EmployeerIncurance { get; set; }

        [VerboseName("معاف از مالیات")]
        public bool IsTaxExempt { get; set; }

        [VerboseName("مشمول مالیات")]
        public decimal TaxIncluded { get; set; }

        [VerboseName("مبلغ مالیات")]
        public decimal TaxAmount { get; set; }

        [VerboseName("مساعده")]
        public decimal PayInAdvance { get; set; }

        [VerboseName("وام")]
        public decimal Loan { get; set; }

        [VerboseName("علی الحساب")]
        public decimal InPartPayment { get; set; }

        [VerboseName("سایر کسورات")]
        public decimal OtherDeduction { get; set; }

        [VerboseName("سایر کسورات 1")]
        public decimal OtherDeduction1 { get; set; }

        [VerboseName("خالص پرداختی")]
        public decimal NetAmount { get; set; }

        [VerboseName("توضیحات")]
        public string Description { get; set; }
    }
}
