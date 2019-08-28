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
                var emp = unitOfWork.Employees.Find(e => e.Lastname == "کیانی بخش").FirstOrDefault();

                if (emp != null)
                {
                    MessageBox.Show(emp.Firstname+" "+emp.Lastname+""+emp.NationalCode);
                }

            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
