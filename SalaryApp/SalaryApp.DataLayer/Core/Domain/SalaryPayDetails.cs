using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class SalaryPayDetails
    {
        public int Id { get; set; }
        public Pay Pay { get; set; }
        public Employee Employee { get; set; }
        public Workgroup WorkGroup { get; set; }
        public decimal DailyRate { get; set; }
        public byte DaysOfWork { get; set; }
        public byte ChildrenCount { get; set; }
        public byte WorkInHoliday { get; set; }
        public byte WorkInFriday { get; set; }
        public byte LeaveDays { get; set; }
        public byte MissionDays { get; set; }
        public byte WorkOvertimeHr { get; set; }
        public byte WorkAsStandbyDays { get; set; }
        public byte AbsentDays { get; set; }
        public decimal MonthlyWage { get; set; }
        public decimal Bon { get; set; }
        public decimal Maskan { get; set; }
        public decimal Karobar { get; set; }
        public decimal ChildrenBenefit { get; set; }
        public bool ShifStatus { get; set; }
        public decimal WorkInHolidayAmount { get; set; }
        public decimal WrokInFridayAmoutn { get; set; }
        public decimal WorkOvertimeAmount { get; set; }
        public decimal WorkAsStandbyAmount { get; set; }
        public float BadConditionRatio { get; set; }
        public decimal BadConditionAmount { get; set; }
        public float CommuteBenefiRatio { get; set; }
        public decimal CommuteBenefit { get; set; }
        public decimal HygieneAmount { get; set; }
        public decimal FoodBenefit { get; set; }
        public decimal InstructionBenefit { get; set; }
        public decimal BackpayAmount { get; set; }
        public decimal BackpayExempt { get; set; }
        public decimal GrossAmount { get; set; }
        public bool InsuranceExempt { get; set; }
        public decimal InsuranceIncluded { get; set; }
        public decimal EmployeeIncurance { get; set; }
        public decimal EmployeerIncurance { get; set; }
        public bool TaxExempt { get; set; }
        public decimal TaxIncluded { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal PayInAdvance { get; set; }
        public decimal Loan { get; set; }
        public decimal InPartPayment { get; set; }
        public decimal OtherDeduction { get; set; } 
        public decimal OtherDeduction1 { get; set; }
        public decimal NetAmount { get; set; }


    }
}
