using System;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;

namespace SalaryApp.WinClient.BaseInfoForms.WorkshopViews
{
    public class WorkshopEditor : EditorBase<Workshop>
    {
        public WorkshopEditor()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            AddTextFields<Workshop>();

            foreach (var textbox in Controls.OfType<TextBox>())
                textbox.DataBindings.Add("Text", Entity, textbox.Name);
            base.OnLoad(e);
        }

        private void WorkshopEditor_Load(object sender, EventArgs e)
        {
            
        }
    }
}