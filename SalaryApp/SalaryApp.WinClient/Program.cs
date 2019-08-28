using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using System;
using System.Linq;
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

            using (var unitOfWork = new UnitOfWork(new SalaryContext()))
            {
                var finanYear = unitOfWork.FinancialYears.Find(y => y.Year == 1398).FirstOrDefault();
                var workshop = unitOfWork.Workshops.Find(w => w.Id == 3).FirstOrDefault();

                var pay = new Pay
                {
                    EmployeesCount=443,
                    FinancialYear=finanYear,
                    Title="حقوق مرداد ماه 1398",
                    Workshop=workshop,
                    TotalGrossAmount=100,
                    TotalInsuraceAmount=100,
                    TotalNetAmount=100,
                    TotalTaxAmount=100
                                        
                };

                unitOfWork.Pays.Add(pay);
                unitOfWork.Complete();


            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
