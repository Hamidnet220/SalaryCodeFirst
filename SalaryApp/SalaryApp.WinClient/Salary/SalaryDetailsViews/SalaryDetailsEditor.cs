using SalaryApp.DataLayer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.Salary.SalaryDetails
{
    public class SalaryDetailsEditor:EditorBase
    {
        public SalaryPayDetails entity { get; private set; }

        public SalaryDetailsEditor(SalaryPayDetails entity)
        {
            this.entity = entity;
            Load += SalaryDetailsEditor_Load;
        }

        private void SalaryDetailsEditor_Load(object sender, EventArgs e)
        {
            AddTextFields<SalaryPayDetails>();

            foreach (var textbox in this.Controls.OfType<TextBox>())
            {
                textbox.DataBindings.Add("Text", entity, textbox.Name);
            }
        }


       
    }
}
