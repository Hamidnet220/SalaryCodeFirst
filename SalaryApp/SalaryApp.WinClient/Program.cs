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
                var workgroup = new Workgroup
                {
                    Title = "6-A",
                    Rate = 600000,
                    Bon = 1900000,
                    Maskan = 1000000,
                    ChildrenBenefit = 1150000,
                    IsShift = true,
                    ShiftRation = 0.15f,
                    TaxExept = 2750000,
                    Workshop=workshop,
                    




                };

                unitOfWork.Workgroups.Add(workgroup);
                unitOfWork.Complete();

            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
