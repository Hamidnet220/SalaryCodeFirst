using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.WinClient.CustomeControls;

namespace SalaryApp.WinClient.BaseInfoForms.EmployeeViews
{
    public class EmployeeList : ViewsBase
    {
        private GridControl<Employee> grid;
        public  Workshop workshop { get; set; }

        public EmployeeList()
        {
            ViewTitle = "لیست کارکنان کارگاه";
        }

        protected override void OnLoad(EventArgs e)
        {

            grid = new GridControl<Employee>(this);
            grid.AddTextBoxColumn(emp => emp.Person.Firstname, "نام");
            grid.AddTextBoxColumn(emp => emp.Person.Lastname, "نام خانوادگی");
            grid.AddTextBoxColumn(emp => emp.Person.FatherName, "نام پدر");

            grid.PopulateDataGridView(
                unitOfWork.Employees.Find(emps => emps.Workgroup.Workshop_Id == workshop.Id).ToList());

            AddAction("+جدید", button =>
            {
                var employeeEditor = ViewEngin.ViewInForm<EmployeeEditor>(ed => ed.Entity = new Employee(),true);

                if (employeeEditor.DialogResult != DialogResult.OK)
                    return;

                unitOfWork.Employees.Add(employeeEditor.Entity);
                unitOfWork.Complete();
                grid.ResetBindings();
                
                var contxt =new SalaryContext();
                contxt.Employees.Include(em => em.Person);
                var employee = contxt.Employees.Find(employeeEditor.Entity.Id);
                grid.AddItem(employee);
            });

            AddAction("ویرایش", button =>
            {
                var entity = unitOfWork.Employees.Get(grid.GetCurrentItem.Id);
                var employeeEditro = ViewEngin.ViewInForm<EmployeeEditor>(ed => ed.Entity = entity);

                if (employeeEditro.DialogResult == DialogResult.Cancel)
                    return;
                unitOfWork.Complete();
            });

            AddAction("-حذف", button =>
            {
                unitOfWork.Employees.Remove(grid.GetCurrentItem);
                grid.RemoveCurrentItem();
            });



            base.OnLoad(e);
        }

    }
}