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
        }

        protected override void OnLoad(EventArgs e)
        {
            AddTextFields<SalaryPayDetails>();

            foreach (var textbox in Controls.OfType<TextBox>())
                textbox.DataBindings.Add("Text", Entity, textbox.Name);
            base.OnLoad(e);
        }

        
    }
}