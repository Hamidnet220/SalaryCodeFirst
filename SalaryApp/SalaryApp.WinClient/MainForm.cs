using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.DataLayer.Persistence.Repositories;
using SalaryApp.WinClient.BaseInfoForms;
using SalaryApp.WinClient.BaseInfoForms.PersonViews;
using SalaryApp.WinClient.BaseInfoForms.PayViews;
using SalaryApp.WinClient.BaseInfoForms.WorkshopViews;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SalaryApp.WinClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AppStatus.ActiceFinancialYearId = 1;
            AppStatus.ActiveWorkShopId = 3;
            AppStatus.ActiveUserId = 1;
        }
            

        private void EmployeeInfoMenu_Click(object sender, EventArgs e)
        {
           
        }

        private void ManageWorkshopButton_Click(object sender, EventArgs e)
        {
            var workshopForm = new WorkshopList();
            workshopForm.ShowDialog();
        }

        private void PayButton_Click(object sender, EventArgs e)
        {
            var payListForm = new PayList();
            payListForm.ShowDialog();
        }

        private void EmployeeListButton_Click(object sender, EventArgs e)
        {
            var employeeListForm = new PersonList();
            employeeListForm.ShowDialog();
        }
    }
}
