using SalaryApp.WinClient.BaseInfoForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BaseInfoWorkshopMenu_Click(object sender, EventArgs e)
        {
            var workshopForm = new WorkshopForm("تعریف کارگاه جدید");
            workshopForm.ShowDialog();
            

        }

        private void EmployeeInfoMenu_Click(object sender, EventArgs e)
        {
            var employeeForm = new EmployeeForm("ایجاد/ویرایش کارکنان");
            employeeForm.ShowDialog();
        }
    }
}
