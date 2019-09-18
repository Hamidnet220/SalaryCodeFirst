using System;
using System.Windows.Forms;

namespace SalaryApp.WinClient
{
    static class Program
    {

        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Cultures.InitializePersianCulture();

            var mainForm = new MainForm();
            mainForm.ShowDialog();

            ////Test education

            //using (var unitOfWork=new UnitOfWork(new SalaryContext()))
            //{
            //    var ed = new Education
            //    {
            //        Title = "دیپلم"
            //    };

            //    unitOfWork.Educations.Add(ed);
            //    var res=unitOfWork.Complete();
            //    MessageBox.Show(res.ToString());


            //}


            //// Test AnnualPayDetails

            //using (var unitOfWork = new UnitOfWork(new SalaryContext()))
            //{
            //    var emp = unitOfWork.Employees.Find(e => e.IdNumber == "1459").FirstOrDefault();
            //    var pay = unitOfWork.Pays.Find(p => p.Id == 1).FirstOrDefault();
            //    var wg = unitOfWork.Workgroups.Find(w => w.Title == "6-A").FirstOrDefault();
            //    var annualPayDetail = new AnnualPayDetails
            //    {
            //        BackpayAmount = 100,
            //        BackpayExempt = 0,
            //        DailyRate = 653000,
            //        Employee = emp,
            //        EmployeeIncurance = 122362,
            //        EmployeerIncurance = 26266,
            //        GrossAmount = 35000000,
            //        InPartPayment = 15000000,
            //        InsuranceIncluded = 30000000,
            //        Loan = 1500000,
            //        NetAmount = 25000000,
            //        OtherDeduction = 0,
            //        OtherDeduction1 = 0,
            //        PayInAdvance = 4000000,
            //        TaxAmount = 152322,
            //        IsTaxExempt = false,
            //        TaxIncluded = 2502322,
            //        Pay = pay,
            //        WorkGroup = wg,
            //        EadiAmount=2000000,
            //        IsInsuranceExempt=false,
            //        LeaveAmount=800000,
            //        SanavatAmount=20000000,
            //        TotalAbsentDays=17,
            //        TotalDaysOfWork=360,
            //        TotalLeaveDays=25

            //    };

            //    unitOfWork.AnnualDetails.Add(annualPayDetail);
            //    unitOfWork.Complete();

            //}

            //// Test SalaryPayDetails

            //using (var unitOfWork = new UnitOfWork(new SalaryContext()))
            //{
            //    var emp = unitOfWork.Employees.Find(e => e.IdNumber == "1459").FirstOrDefault();
            //    var pay = unitOfWork.Pays.Find(p => p.Id == 1).FirstOrDefault();
            //    var wg = unitOfWork.Workgroups.Find(w => w.Title == "6-A").FirstOrDefault();
            //    var salayPayDetail = new SalaryPayDetails
            //    {
            //        AbsentDays = 1,
            //        BackpayAmount = 100,
            //        BackpayExempt = 0,
            //        BadConditionAmount = 12725253,
            //        BadConditionRatio = 0.15f,
            //        Bon = 1000000,
            //        ChildrenBenefit = 1536236,
            //        ChildrenCount = 3,
            //        CommuteBenefiRatio = 0.15f,
            //        CommuteBenefit = 18536256,
            //        DailyRate = 653000,
            //        DaysOfWork = 31,
            //        Employee = emp,
            //        EmployeeIncurance = 122362,
            //        EmployeerIncurance = 26266,
            //        FoodBenefit = 2550000,
            //        GrossAmount = 35000000,
            //        HygieneAmount = 1232533,
            //        InPartPayment = 15000000,
            //        InstructionBenefit = 500000,
            //        InsuranceExempt = false,
            //        InsuranceIncluded = 30000000,
            //        Karobar = 800,
            //        LeaveDays = 3,
            //        Loan = 1500000,
            //        Maskan = 1900000,
            //        MissionDays = 3,
            //        MonthlyWage = 12000000,
            //        NetAmount = 25000000,
            //        OtherDeduction = 0,
            //        OtherDeduction1 = 0,
            //        PayInAdvance = 4000000,
            //        ShifStatus = true,
            //        TaxAmount = 152322,
            //        TaxExempt = false,
            //        WorkInHoliday = 2,
            //        WorkAsStandbyDays = 2,
            //        TaxIncluded = 2502322,
            //        WorkAsStandbyAmount = 1400000,
            //        WorkInHolidayAmount = 13334344,
            //        WorkOvertimeAmount = 34343434,
            //        WorkOvertimeHr = 120,
            //        WorkInFriday = 3,
            //        WrokInFridayAmoutn = 1750000,
            //        Pay = pay,
            //        WorkGroup = wg

            //    };

            //    unitOfWork.SalaryDetails.Add(salayPayDetail);
            //    unitOfWork.Complete();

            //}



            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
        }
    }
}
