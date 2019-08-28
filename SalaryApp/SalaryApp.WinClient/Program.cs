using SalaryApp.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                var workshop = unitOfWork.Workshops.Get(3);

                var finanYear = new FincancialYear
                {
                    Year = 1396,
                    Workshop = workshop
                };

                unitOfWork.FinancialYears.Add(finanYear);
                unitOfWork.Complete();

            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
