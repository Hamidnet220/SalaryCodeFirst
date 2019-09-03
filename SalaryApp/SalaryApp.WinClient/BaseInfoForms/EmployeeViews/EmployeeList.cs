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
    public partial class EmployeeList : BaseForm
    {
        UnitOfWork unitOfWork;
        GridControl<Employee> grid;
        Panel oprationPanel;
        int buttonTop = 0;


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
            oprationPanel = new Panel();
            oprationPanel.Dock = DockStyle.Right;
            gridPanel.Dock = DockStyle.Fill;
            this.Controls.Add(gridPanel);
            this.Controls.Add(oprationPanel);


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



            grid = new GridControl<Employee>(gridPanel);
            grid.AddTextBoxColumn(emp => new Employee().Firstname,"نام");
            grid.AddTextBoxColumn(emp => new Employee().Lastname,"نام خانوادگی");
            grid.AddTextBoxColumn(emp => new Employee().FatherName,"نام پدر");
            grid.AddTextBoxColumn(emp => new Employee().NationalCode,"کد ملی");
            grid.AddTextBoxColumn(emp => new Employee().IdNumber,"شماره شناسنامه");
            grid.AddTextBoxColumn(emp => new Employee().BankAccount,"شماره حساب");

            unitOfWork = new UnitOfWork(new SalaryContext());

            grid.PopulateDataGridView(unitOfWork.Employees.GetAll());
        }

        private void AddAction(string title,Action<Button> onClick)
        {
            var btn = new Button();
            btn.Text = title;
            btn.Click += (obj, e) =>
            {
                onClick(btn);
            };
            buttonTop += 25;
            btn.Top = buttonTop;
            btn.Left = 25;
            oprationPanel.Controls.Add(btn);
            
        }
    }
}
