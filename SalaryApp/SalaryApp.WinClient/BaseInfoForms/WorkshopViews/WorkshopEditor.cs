using SalaryApp.DataLayer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.WorkshopViews
{
    public class WorkshopEditor:EditorBase
    {
        public Workshop entity { get; private set; }
        
        public WorkshopEditor(Workshop entity)
        {
            this.entity = entity;
            Load += WorkshopEditor_Load;
        }

        private void WorkshopEditor_Load(object sender, EventArgs e)
        {
            AddTextFields<Workshop>();

            foreach (var textbox in this.Controls.OfType<TextBox>())
            {
                textbox.DataBindings.Add("Text", entity, textbox.Name);
            }
        }
    }
}
