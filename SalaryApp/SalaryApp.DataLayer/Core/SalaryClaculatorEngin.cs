using System;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;

namespace SalaryApp.DataLayer.Core
{
    public class SalaryClaculatorEngin
    {
        private readonly SalaryPayDetails salaryDetails;

        public SalaryClaculatorEngin(SalaryPayDetails salaryDetials)
        {
            salaryDetails = salaryDetials;

            CalaculateSalary();
        }


        private void CalaculateSalary()
        {
            var rate = salaryDetails.DailyRate;

            var daysInMonht = GetDaysInMonth(salaryDetails.Pay);

            var netDaysOfwork = salaryDetails.DaysOfWork - salaryDetails.AbsentDays;

            var workRatio = netDaysOfwork / daysInMonht;

            var effectiveDaysOfWork = netDaysOfwork - salaryDetails.LeaveDays;

            salaryDetails.MonthlyWage = netDaysOfwork * rate;

            salaryDetails.Bon = salaryDetails.Employee.Workgroup.Bon;

            salaryDetails.Maskan = salaryDetails.Employee.Workgroup.Maskan;

            salaryDetails.Karobar = 0;

            salaryDetails.WorkInHolidayAmount = salaryDetails.WorkInHoliday * rate * (decimal) 1.4;

            salaryDetails.WrokInFridayAmoutn = salaryDetails.WorkInFriday * rate * (decimal) 0.4;

            salaryDetails.WorkAsStandbyAmount = salaryDetails.Employee.Workgroup.StandbayAmount *
                                                salaryDetails.WorkAsStandbyDays;

            salaryDetails.WorkOvertimeAmount = (decimal) (salaryDetails.WorkOvertimeHr / 7.33 * 1.4) * rate;

            salaryDetails.ChildrenBenefit = salaryDetails.Employee.Workgroup.ChildrenBenefit *
                                            salaryDetails.ChildrenCount;

            salaryDetails.CommuteBenefit = (decimal) salaryDetails.CommuteBenefiRatio * netDaysOfwork * rate;

            salaryDetails.BadConditionAmount = (decimal) salaryDetails.BadConditionRatio * netDaysOfwork * rate;

            salaryDetails.FoodBenefit = salaryDetails.DaysFood * salaryDetails.Employee.Workgroup.FoodBenefitAmount;

            salaryDetails.ShiftAmount = (decimal) salaryDetails.Employee.Workgroup.ShiftRation * effectiveDaysOfWork *
                                        rate;

            salaryDetails.HygieneAmount = salaryDetails.Employee.Workgroup.HygieneAmount * workRatio;

            salaryDetails.GrossAmount= GetGrossAmount(salaryDetails);

            salaryDetails.TaxIncluded = salaryDetails.GrossAmount;

            salaryDetails.TaxAmount = TaxCalculator(salaryDetails);

            salaryDetails.InsuranceIncluded = salaryDetails.GrossAmount - salaryDetails.ChildrenBenefit;

            salaryDetails.EmployeeIncurance = salaryDetails.InsuranceIncluded * (decimal) 0.07;

            salaryDetails.EmployeerIncurance = salaryDetails.InsuranceIncluded * (decimal) 0.23;


            salaryDetails.NetAmount = salaryDetails.GrossAmount -
                                      salaryDetails.EmployeeIncurance -
                                      salaryDetails.TaxAmount - salaryDetails.Loan -
                                      salaryDetails.PayInAdvance -
                                      salaryDetails.OtherDeduction - salaryDetails.OtherDeduction1;
        }

        private decimal GetGrossAmount(SalaryPayDetails payDetails)
        {
            return payDetails.BadConditionAmount +
                                        payDetails.Bon +
                                        payDetails.ChildrenBenefit +
                                        payDetails.CommuteBenefit +
                                        payDetails.FoodBenefit +
                                        payDetails.HygieneAmount +
                                        payDetails.InstructionBenefit +
                                        payDetails.Karobar +
                                        payDetails.Maskan +
                                        payDetails.MonthlyWage +
                                        payDetails.WorkAsStandbyAmount +
                                        payDetails.WorkInHolidayAmount +
                                        payDetails.WorkOvertimeAmount +
                                        payDetails.ShiftAmount +
                                        payDetails.WrokInFridayAmoutn;
        }

        private decimal TaxCalculator(SalaryPayDetails payDetails)
        {
            if (payDetails.IsTaxExempt)
                return 0;

            if (payDetails.TaxIncluded <= payDetails.Employee.Workgroup.TaxExeptAmount)
                return 0;

            return (payDetails.TaxIncluded - payDetails.Employee.Workgroup.TaxExeptAmount) *
                   (decimal) payDetails.Employee.Workgroup.TaxRatio;
        }

        private int GetDaysInMonth(Pay pay)
        {
            var year = new SalaryContext().FinancialYears.Find(pay.FinancialYear_Id).Year;
            var month = pay.MonthId;
            var daysOfMonth = DateTime.DaysInMonth(year, month);

            return daysOfMonth;
        }
    }
}