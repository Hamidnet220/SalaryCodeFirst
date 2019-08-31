using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.WinClient.CustomeControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.EmployeeViews
{
    public partial class EmployeeList : BaseForm
    {
        public EmployeeList()
        {
            InitializeComponent();
            Load += EmployeeList_Load;
        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
            this.Text = "لیست کارکنان";
            this.WindowState = FormWindowState.Maximized;
            var gridPanel = new Panel();
            var oprationPanel = new Panel();
            oprationPanel.Dock = DockStyle.Right;
            gridPanel.Dock = DockStyle.Fill;
            var AddButton = new Button();
            AddButton.Text = "+ جدید";
            AddButton.Left = 25;
            AddButton.Click += AddButton_Click;
            var DeleteButton = new Button();
            DeleteButton.Text = "- حذف";
            DeleteButton.Left = 25;
            DeleteButton.Top = AddButton.Height + 8;
            DeleteButton.Click += DeleteButton_Click;

            var EditButton = new Button();
            EditButton.Text = "[X] ویرایش";
            EditButton.Left = 25;
            EditButton.Top = AddButton.Height *2 + 15;
            EditButton.Click += EditButton_Click;

            this.Controls.Add(gridPanel);
            this.Controls.Add(oprationPanel);
            oprationPanel.Controls.Add(AddButton);
            oprationPanel.Controls.Add(DeleteButton);
            oprationPanel.Controls.Add(EditButton);


            var grid = new GridControl<Employee>(gridPanel);
            grid.AddTextBoxColumn(emp => new Employee().Firstname,"نام");
            grid.AddTextBoxColumn(emp => new Employee().Lastname,"نام خانوادگی");
            grid.AddTextBoxColumn(emp => new Employee().FatherName,"نام پدر");
            grid.AddTextBoxColumn(emp => new Employee().NationalCode,"کد ملی");
            grid.AddTextBoxColumn(emp => new Employee().IdNumber,"شماره شناسنامه");

            var unitOfWork = new UnitOfWork(new SalaryContext());

            grid.PopulateDataGridView(unitOfWork.Employees.GetAll());
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit employeee");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("delete employeee");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var employeeForm = new EmployeeForm(" ");
            employeeForm.ShowDialog();
        }
    }
}
