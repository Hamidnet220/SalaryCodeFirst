using System;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.WinClient.CustomeControls;

namespace SalaryApp.WinClient.BaseInfoForms.EmployeeViews
{
    public class EmployeeList : ViewsBase
    {
        private GridControl<Employee> grid;
        private readonly Workshop workshop;

        public EmployeeList(Workshop workshop)
        {
            this.workshop = workshop;
            Load += PopulateGrid;
            Load += AddActions;
        }

        private void PopulateGrid(object sender, EventArgs e)
        {
            grid = new GridControl<Employee>(this);
            grid.AddTextBoxColumn(emp => emp.Person.Firstname, "نام");
            grid.AddTextBoxColumn(emp => emp.Person.Lastname, "نام خانوادگی");
            grid.AddTextBoxColumn(emp => emp.Person.FatherName, "نام پدر");

            grid.PopulateDataGridView(
                unitOfWork.Employees.Find(emps => emps.Workgroup.Workshop_Id == workshop.Id).ToList());
        }

        private void AddActions(object sender, EventArgs e)
        {
            AddAction("+جدید", button =>
            {
                var employeeEditor = ViewEngin.ViewInForm<EmployeeEditor>(ed=>ed.Entity=new Employee());

                if (employeeEditor.DialogResult != DialogResult.OK)
                    return;

                unitOfWork.Employees.Add(employeeEditor.Entity);
                unitOfWork.Complete();
                grid.ResetBindings();
            });

            AddAction("ویرایش", button =>
            {
                var entity = unitOfWork.Employees.Get(grid.GetCurrentItem.Id);
                var employeeEditro =ViewEngin.ViewInForm<EmployeeEditor>(ed=>ed.Entity=entity);

                if (employeeEditro.DialogResult == DialogResult.Cancel)
                    return;
                unitOfWork.Complete();
            });

            AddAction("-حذف", button =>
            {
                unitOfWork.Employees.Remove(grid.GetCurrentItem);
                grid.RemoveCurrentItem();
            });
        }
    }
}