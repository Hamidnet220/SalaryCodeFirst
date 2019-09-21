using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;

namespace SalaryApp.WinClient.BaseInfoForms.EmployeeViews
{
    public class EmployeeEditor : EditorBase<Employee>
    {
        public EmployeeEditor()
        {
           
        }

        protected override void OnLoad(EventArgs e)
        {
            var context = new SalaryContext();
            AddTextFields<Employee>();

            if (Entity.Id == 0)
            {
                var personIdAdded =
                    context.Employees.Where(p => p.Workgroup.Workshop_Id == AppSetting.AppStatus.ActiveWorkShopId)
                        .Select(p => p.Person_Id)
                        .ToList();
                var persons = context.People.Where(p => !personIdAdded.Contains(p.Id)).ToList();
                AddComboBox(persons, person => person.Lastname, person => person.Id, "انتخاب کارمند", Entity,
                    emp => emp.Person_Id);
            }
            else
            {
                AddComboBox(context.People.Where(p => p.Id == Entity.Person_Id).ToList(), person => person.Lastname,
                    person => person.Id, "انتخاب کارمند", Entity, emp => emp.Person_Id);
            }


            AddComboBox(unitOfWork.Workgroups.Find(w => w.Workshop_Id == AppSetting.AppStatus.ActiveWorkShopId).ToList(),
                w => w.Title, w => w.Id, "انتخاب گروه کاری", Entity, emp => emp.Workgroup_Id);

            AddComboBox(unitOfWork.Workplaces.Find(w => w.Workshop.Id == AppSetting.AppStatus.ActiveWorkShopId).ToList(),
                w => w.Title, w => w.Id, "انتخاب محل کار", Entity, emp => emp.Workplace_Id);

            foreach (var textbox in Controls.OfType<TextBox>())
                textbox.DataBindings.Add("Text", Entity, textbox.Name);



            base.OnLoad(e);
        }

        public override string ViewTitle
        {
            get
            {
                if (Entity.Id == 0)
                    return "ایجاد کارمند جدید";
                return "ویرایش کارمند";

            }
        }
    }
}