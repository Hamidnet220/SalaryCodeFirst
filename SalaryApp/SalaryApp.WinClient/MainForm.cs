using SalaryApp.WinClient.BaseInfoForms;
using SalaryApp.WinClient.BaseInfoForms.WorkshopViews;
using System;
using System.Windows.Forms;

namespace SalaryApp.WinClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

       

        private void EmployeeInfoMenu_Click(object sender, EventArgs e)
        {
            var employeeForm = new EmployeeForm("ایجاد/ویرایش کارکنان");
            employeeForm.ShowDialog();
        }

        private void ManageWorkshopButton_Click(object sender, EventArgs e)
        {
            var workshopForm = new WorkshopList();
            workshopForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
