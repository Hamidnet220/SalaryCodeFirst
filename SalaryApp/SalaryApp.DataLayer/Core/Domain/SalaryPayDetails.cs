using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class SalaryPayDetails: IPayDetails
    {
        public int Id { get; set; }


        public int PayId { get; set; }

        [ForeignKey("PayId")]
        public virtual Pay Pay { get; set; }

        public int EmployeeId { get; set; }

        [VerboseName("نام کارمند")]
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [VerboseName("پایه روزانه")]
        public decimal DailyRate { get; set; }

        [VerboseName("روز کارکرد")]
        public int DaysOfWork { get; set; }

        [VerboseName("تعداد فرزند")]
        public byte ChildrenCount { get; set; }

        [VerboseName("تعطیل کاری")]
        public byte WorkInHoliday { get; set; }

        [VerboseName("جمعه کاری")]
        public byte WorkInFriday { get; set; }

        [VerboseName("تعداد مرخصی")]
        public byte LeaveDays { get; set; }

        [VerboseName("تعداد روز ماموریت")]
        public byte MissionDays { get; set; }

        [VerboseName("ساعات اضافه کاری")]
        public int WorkOvertimeHr { get; set; }

        [VerboseName("تعداد روز جایگزین")]
        public byte WorkAsStandbyDays { get; set; }

        [VerboseName("تعداد روز غیبت")]
        public byte AbsentDays { get; set; }

        [VerboseName("حقوق ماهانه")]
        public decimal MonthlyWage { get; set; }

        [VerboseName("بن")]
        public decimal Bon { get; set; }

        [VerboseName("مسکن")]
        public decimal Maskan { get; set; }

        [VerboseName("خوروبار")]
        public decimal Karobar { get; set; }

        [VerboseName("مبلغ حق اولاد")]
        public decimal ChildrenBenefit { get; set; }

        [YesNoComboBox("نوبنکار")]
        public bool ShifStatus { get; set; }

        [VerboseName("مبلغ تعطیل کاری")]
        public decimal WorkInHolidayAmount { get; set; }

        [VerboseName("مبلغ جمعه کاری")]
        public decimal WrokInFridayAmoutn { get; set; }

        [VerboseName("مبلغ اضافه کاری")]
        public decimal WorkOvertimeAmount { get; set; }

        [VerboseName("مبلغ جایگزینی")]
        public decimal WorkAsStandbyAmount { get; set; }

        [VerboseName("نرخ بدی آب و هوا")]
        public float BadConditionRatio { get; set; }

        [VerboseName("مبلغ بدی آب و هوا ")]
        public decimal BadConditionAmount { get; set; }

        [VerboseName("درصد ایاب و ذهاب ")]
        public float CommuteBenefiRatio { get; set; }

        [VerboseName("مبلغ ایاب و ذهاب ")]
        public decimal CommuteBenefit { get; set; }

        [VerboseName("مبلغ سرانه بهداشت")]
        public decimal HygieneAmount { get; set; }

        [VerboseName("مبلغ حق غذا")]
        public decimal FoodBenefit { get; set; }

        [VerboseName("مبلغ آموزش")]
        public decimal InstructionBenefit { get; set; }

        [VerboseName("مبلغ معوق")]
        public decimal BackpayAmount { get; set; }

        [VerboseName("مبلغ معوق معاف")]
        public decimal BackpayExempt { get; set; }

        [VerboseName("مبلغ ناخالص")]
        public decimal GrossAmount { get; set; }

        [YesNoComboBox("معاف از بیمه")]
        public bool IsInsuranceExempt { get; set; }

        [VerboseName("مشمول بیمه")]
        public decimal InsuranceIncluded { get; set; }

        [VerboseName("مبلغ بیمه کارمند")]
        public decimal EmployeeIncurance { get; set; }

        [VerboseName("مبلغ بیمه کارفرما")]
        public decimal EmployeerIncurance { get; set; }

        [YesNoComboBox("معاف از مالیات")]
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

        [VerboseName("سایر کسوارت")]
        public decimal OtherDeduction1 { get; set; }

        [VerboseName("خالص پرداختی")]
        public decimal NetAmount { get; set; }

        
    }
}