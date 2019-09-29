using System;
using SalaryApp.DataLayer.Core.Domain;

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


        public decimal GetGrossAmount()
        {
            throw new NotImplementedException();
        }

        public decimal GetTaxAmount()
        {
            throw new NotImplementedException();
        }

        public decimal GetInsuranceAmount()
        {
            throw new NotImplementedException();
        }

        public decimal GetNetAmount()
        {
            throw new NotImplementedException();
        }

        private void CalaculateSalary()
        {
            var rate = salaryDetails.DailyRate;

            var netDaysOfwork = salaryDetails.DaysOfWork - salaryDetails.AbsentDays;

            var effectiveDaysOfWork = netDaysOfwork - salaryDetails.LeaveDays;

            salaryDetails.MonthlyWage = netDaysOfwork * rate;

            salaryDetails.Bon = salaryDetails.Employee.Workgroup.Bon;

            salaryDetails.Maskan = salaryDetails.Employee.Workgroup.Maskan;

            salaryDetails.Karobar = 0;

            salaryDetails.WorkInHolidayAmount = salaryDetails.WorkInHoliday * rate * (decimal) 1.4;

            salaryDetails.WrokInFridayAmoutn = salaryDetails.WorkInFriday * rate * (decimal) 0.4;

            salaryDetails.WorkAsStandbyAmount = salaryDetails.Employee.Workgroup.StandbayAmount;

            salaryDetails.WorkOvertimeAmount = (decimal) (salaryDetails.WorkOvertimeHr / 7.33 * 1.4) * rate;

            salaryDetails.ChildrenBenefit = salaryDetails.Employee.Workgroup.ChildrenBenefit *
                                            salaryDetails.ChildrenCount;

            salaryDetails.CommuteBenefit = (decimal) salaryDetails.CommuteBenefiRatio * netDaysOfwork * rate;

            salaryDetails.BadConditionAmount = (decimal) salaryDetails.BadConditionRatio * netDaysOfwork * rate;

            salaryDetails.FoodBenefit = salaryDetails.DaysFood * salaryDetails.Employee.Workgroup.Rate;

            salaryDetails.GrossAmount = salaryDetails.BadConditionAmount +
                                        salaryDetails.Bon +
                                        salaryDetails.ChildrenBenefit +
                                        salaryDetails.CommuteBenefit +
                                        salaryDetails.FoodBenefit +
                                        salaryDetails.HygieneAmount +
                                        salaryDetails.InstructionBenefit +
                                        salaryDetails.Karobar +
                                        salaryDetails.Maskan +
                                        salaryDetails.MonthlyWage +
                                        salaryDetails.WorkAsStandbyAmount +
                                        salaryDetails.WorkInHolidayAmount +
                                        salaryDetails.WorkOvertimeAmount +
                                        salaryDetails.WrokInFridayAmoutn;

            salaryDetails.TaxIncluded = salaryDetails.GrossAmount;

            if (salaryDetails.IsTaxExempt)
            {
                salaryDetails.TaxAmount = 0;
            }
            else
            {
                if (salaryDetails.TaxIncluded <= salaryDetails.Employee.Workgroup.TaxExept)
                    salaryDetails.TaxAmount = 0;
                else
                    salaryDetails.TaxAmount = (salaryDetails.TaxIncluded - salaryDetails.Employee.Workgroup.TaxExept) *
                                              (decimal) 0.05;
            }

            salaryDetails.InsuranceIncluded = salaryDetails.GrossAmount - salaryDetails.ChildrenBenefit;

            salaryDetails.EmployeeIncurance = salaryDetails.InsuranceIncluded * (decimal) 0.07;

            salaryDetails.EmployeerIncurance = salaryDetails.InsuranceIncluded * (decimal) 0.23;


            salaryDetails.NetAmount = salaryDetails.GrossAmount -
                                      salaryDetails.EmployeeIncurance -
                                      salaryDetails.TaxAmount - salaryDetails.Loan -
                                      salaryDetails.PayInAdvance -
                                      salaryDetails.OtherDeduction - salaryDetails.OtherDeduction1;
        }
    }
}