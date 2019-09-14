﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    public class SalaryPayDetails
    {
        public int Id { get; set; }

        
        public int Pay_Id { get; set; }
        [ForeignKey("Pay_Id")]
        public virtual Pay Pay { get; set; }

        public int Employee_Id { get; set; }

        [VerboseName("نام کارمند")]
        [ForeignKey("Employee_Id")]
        public virtual Employee Employee { get ; set; }
        
        [VerboseName("پایه روزانه")]
        public decimal DailyRate { get; set; }

        [VerboseName("روز کارکرد")]
        public byte DaysOfWork { get; set; }

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
        public byte WorkOvertimeHr { get; set; }

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

        [VerboseName("وضعیت نوبنکاری")]
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

        [VerboseName("معاف از بیمه")]
        public bool InsuranceExempt { get; set; }

        [VerboseName("مشمول بیمه")]
        public decimal InsuranceIncluded { get; set; }

        [VerboseName("مبلغ بیمه کارمند")]
        public decimal EmployeeIncurance { get; set; }

        [VerboseName("مبلغ بیمه کارفرما")]
        public decimal EmployeerIncurance { get; set; }

        [VerboseName("مبلغ معاف از مالیات")]
        public bool TaxExempt { get; set; }

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
