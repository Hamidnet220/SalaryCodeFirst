using System;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;

namespace SalaryApp.WinClient.Salary.SalaryDetailsViews
{
    public class SalaryDetailsEditor : EditorBase<SalaryPayDetails>
    {
        public SalaryDetailsEditor()
        {
            Load += SalaryDetailsEditor_Load;
        }


        private void SalaryDetailsEditor_Load(object sender, EventArgs e)
        {
            AddTextFields<SalaryPayDetails>();

            foreach (var textbox in Controls.OfType<TextBox>())
                textbox.DataBindings.Add("Text", Entity, textbox.Name);
        }
    }
}