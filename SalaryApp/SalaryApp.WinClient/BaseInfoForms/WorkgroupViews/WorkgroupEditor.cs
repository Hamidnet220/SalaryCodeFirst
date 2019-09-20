using System;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;

namespace SalaryApp.WinClient.BaseInfoForms.WorkgroupViews
{
    public class WorkgroupEditor : EditorBase<Workgroup>
    {
        public WorkgroupEditor()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            AddTextFields<Workgroup>();
            AddComboBox(unitOfWork.Workshops.GetAll().ToList(), workshop => workshop.Title, workshop => workshop.Id,
                "کارگاه", Entity, workgroup => workgroup.Workshop_Id);

            foreach (var textbox in Controls.OfType<TextBox>())
                textbox.DataBindings.Add("Text", Entity, textbox.Name);
            base.OnLoad(e);
        }


        private void WorkgroupEditor_Load(object sender, EventArgs e)
        {
           
        }
    }
}