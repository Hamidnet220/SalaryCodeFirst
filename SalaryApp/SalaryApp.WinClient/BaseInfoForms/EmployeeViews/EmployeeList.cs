using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.WinClient.CustomeControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.EmployeeViews
{
    public class EmployeeList:ListBase
    {
        Workshop workshop=null;
        GridControl<Employee> grid;

        public EmployeeList(Workshop workshop)
        {
            this.workshop = workshop;
            Load += PopulateGrid;
            Load += AddActions;
        }

        private void PopulateGrid(object sender, EventArgs e)
        {
            grid = new GridControl<Employee>(gridPanel);
            grid.AddTextBoxColumn(emp =>emp.Person.Firstname, "نام");
            grid.AddTextBoxColumn(emp =>emp.Person.Lastname, "نام خانوادگی");
            grid.AddTextBoxColumn(emp =>emp.Person.FatherName, "نام پدر");

            grid.PopulateDataGridView(unitOfWork.Employees.Find(emps=>emps.Workshop.Id==this.workshop.Id).ToList());
        }

        private void AddActions(object sender, EventArgs e)
        {
            AddAction("+جدید", button =>
            {
                var employeeEditor = new EmployeeEditor(new Employee());
                employeeEditor.ShowDialog();

                if (employeeEditor.DialogResult != DialogResult.OK)
                    return;

                unitOfWork.Employees.Add(employeeEditor.entity);
                unitOfWork.Complete();
                grid.ResetBindings();
            });

            AddAction("ویرایش", button =>
            {
                var entity = unitOfWork.Employees.Get(grid.GetCurrentItem.Id);
                var employeeEditro = new EmployeeEditor(entity);
                employeeEditro.ShowDialog();

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
