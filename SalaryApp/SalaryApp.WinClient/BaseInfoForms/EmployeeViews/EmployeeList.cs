using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;
using System;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.EmployeeViews
{
    public partial class EmployeeList : ListBase
    {
        GridControl<Employee> grid;

        public EmployeeList()
        {
            
            InitializeComponent();
            Load += EmployeeList_Load;
            Load += AddActions;
            Load += PopulateGrid;
        }


        private void EmployeeList_Load(object sender, EventArgs e)
        {
            this.Text = "لیست کارکنان";
            this.WindowState = FormWindowState.Maximized;
            
        }

        private void PopulateGrid(object sender, EventArgs e)
        {
            grid = new GridControl<Employee>(gridPanel);
            grid.AddTextBoxColumn(emp => new Employee().Firstname, "نام");
            grid.AddTextBoxColumn(emp => new Employee().Lastname, "نام خانوادگی");
            grid.AddTextBoxColumn(emp => new Employee().FatherName, "نام پدر");
            grid.AddTextBoxColumn(emp => new Employee().NationalCode, "کد ملی");
            grid.AddTextBoxColumn(emp => new Employee().IdNumber, "شماره شناسنامه");
            grid.AddTextBoxColumn(emp => new Employee().BankAccount, "شماره حساب");

            grid.PopulateDataGridView(unitOfWork.Employees.GetAll());
        }

        private void AddActions(object sender, EventArgs e)
        {
            AddAction("+جدید", button =>
            {
                var employeeForm = new EmployeeForm(" ");
                employeeForm.ShowDialog();
            });

            AddAction("ویرایش", button =>
            {
                MessageBox.Show("Edit employeee");
            });

            AddAction("-حذف", button =>
            {
                if (MessageBox.Show(MessagesClass.DeleteConfirm, MessagesClass.CriticalCaption, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                unitOfWork.Employees.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.RemoveCurrentItem();
            });
        }
        
        
    }
}
