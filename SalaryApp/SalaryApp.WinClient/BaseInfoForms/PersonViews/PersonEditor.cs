using System;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;

namespace SalaryApp.WinClient.BaseInfoForms.PersonViews
{
    public class PersonEditor : EditorBase<Person>
    {
        public PersonEditor()
        {
            Load += EmployeeEditor_Load;
        }

       

        private void EmployeeEditor_Load(object sender, EventArgs e)
        {
            AddTextFields<Person>();
            foreach (var textbox in Controls.OfType<TextBox>())
                textbox.DataBindings.Add("Text", Entity, textbox.Name);
        }

        public override string ViewTitle
        {
            get
            {
                if (Entity.Id == 0)
                   return "ثبت مشخصات هویتی جدید";
                return  "ویرایش مشخصات هویتی";
            }

            
        }
    }
}