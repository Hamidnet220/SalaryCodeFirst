using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryApp.DataLayer.Core.Domain;

namespace SalaryApp.DataLayer.Core
{
    public class SalaryClaculatorEngin:IPayDetails
    {
        SalaryPayDetails salaryDetails;

        public SalaryClaculatorEngin(SalaryPayDetails salaryDetials)
        {
            this.salaryDetails = salaryDetials;

            CalaculateSalary();
        }

        private void CalaculateSalary()
        {
            var rate = salaryDetails.Employee.Workgroup.Rate ;

            salaryDetails.MonthlyWage = salaryDetails.DaysOfWork * rate;

            salaryDetails.Bon = salaryDetails.Employee.Workgroup.Bon;

            salaryDetails.Maskan = salaryDetails.Employee.Workgroup.Maskan;

            salaryDetails.Karobar = 0;

            salaryDetails.WorkInHolidayAmount = salaryDetails.WorkInHoliday * rate * (decimal)1.4;

            salaryDetails.WrokInFridayAmoutn = salaryDetails.WorkInFriday * rate * (decimal)0.4;

            salaryDetails.WorkAsStandbyAmount = salaryDetails.Employee.Workgroup.StandbayAmount;

            salaryDetails.ChildrenBenefit = salaryDetails.Employee.Workgroup.ChildrenBenefit * salaryDetails.ChildrenCount;

            salaryDetails.CommuteBenefit = (decimal)salaryDetails.CommuteBenefiRatio * salaryDetails.DaysOfWork;

            salaryDetails.GrossAmount = salaryDetails.BadConditionAmount + salaryDetails.Bon +
                                        salaryDetails.ChildrenBenefit + salaryDetails.CommuteBenefit +
                                        salaryDetails.FoodBenefit + salaryDetails.HygieneAmount + salaryDetails.InstructionBenefit +
                                        salaryDetails.Karobar + salaryDetails.Maskan + salaryDetails.MonthlyWage +
                                        salaryDetails.WorkAsStandbyAmount + salaryDetails.WorkInHolidayAmount +
                                        salaryDetails.WorkOvertimeAmount + salaryDetails.WrokInFridayAmoutn;

            salaryDetails.TaxIncluded = salaryDetails.GrossAmount;

            salaryDetails.NetAmount = salaryDetails.GrossAmount;


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

    }
}
