using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.EmployeeViews
{
    public partial class EmployeeList : ViewBase
    {
        UnitOfWork unitOfWork;
        GridControl<Employee> grid;
        int buttonTop = 0;


        public EmployeeList():base()
        {
            
            InitializeComponent();
            Load += EmployeeList_Load;
            Load += AddActions;
            Load += PopulateGrid;
            FormClosed += EmployeeList_FormClosed;
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

            unitOfWork = new UnitOfWork(new SalaryContext());

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
        
        private void EmployeeList_FormClosed(object sender, FormClosedEventArgs e)
        {
            unitOfWork.Dispose();
        }
    }
}
