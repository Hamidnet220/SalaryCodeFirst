using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.EmployeeViews
{
    public class EmployeeEditor : EditorBase
    {
        public Employee entity { get; private set; }

        public EmployeeEditor(Employee entity)
        {
            this.entity = entity;
            Load += EmployeeEditor_Load;
            Accept.Click += Accept_Click;
            Cancel.Click += Cancel_Click;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void EmployeeEditor_Load(object sender, EventArgs e)
        {
            var context = new SalaryContext();
            AddTextFields<Employee>();

            if (entity.Id == 0)
            {
                var personIdAdded = context.Employees.Where(p => p.Workgroup.Workshop_Id == AppStatus.ActiveWorkShopId).Select(p => p.Person_Id).ToList();
                var persons = context.People.Where(p => !personIdAdded.Contains(p.Id)).ToList();
                AddComboBox(persons, person => person.Lastname, person => person.Id, "انتخاب کارمند", entity, emp => emp.Person_Id);
            }
            else
            {
                AddComboBox(context.People.Where(p=>p.Id==entity.Person_Id).ToList(), person => person.Lastname,person=>person.Id, "انتخاب کارمند", entity, emp => emp.Person_Id);
            }


            AddComboBox(unitOfWork.Workgroups.Find(w=>w.Workshop_Id==AppStatus.ActiveWorkShopId).ToList(),w => w.Title,w=>w.Id, "انتخاب گروه کاری", entity, emp => emp.Workgroup_Id);

            AddComboBox(unitOfWork.Workplaces.Find(w=>w.Workshop.Id==AppStatus.ActiveWorkShopId).ToList(),w => w.Title,w=>w.Id, "انتخاب محل کار", entity, emp => emp.Workplace_Id);

            foreach (var textbox in this.Controls.OfType<TextBox>())
            {
                textbox.DataBindings.Add("Text", entity, textbox.Name);
            }
        }
    }
}
