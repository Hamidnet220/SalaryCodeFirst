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
                var workshop = unitOfWork.Workshops.Get(3);
                var workplace = new Workplace
                {
                    Title = "دارخوین",
                    Workshop = workshop,

                };

                unitOfWork.Workplaces.Add(workplace);
                unitOfWork.Complete();

            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
