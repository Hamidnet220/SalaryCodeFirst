using SalaryApp.DataLayer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.PersonViews
{
    public class PersonEditor:EditorBase
    {
        public Person entity { get; private set; }

        public PersonEditor(Person entity):base()
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
            AddTextFields<DataLayer.Core.Domain.Person>();
            foreach (var textbox in this.Controls.OfType<TextBox>())
            {
                textbox.DataBindings.Add("Text", entity, textbox.Name);
            }

            
        }
    }
}
