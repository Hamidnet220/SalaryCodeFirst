using SalaryApp.DataLayer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.WorkgroupViews
{
    public class WorkgroupEditor:EditorBase
    {
        public Workgroup entity { get; private set; }

        public WorkgroupEditor(Workgroup entity)
        {
            this.entity = entity;
            Load += WorkgroupEditor_Load;
           
        }

       
        private void WorkgroupEditor_Load(object sender, EventArgs e)
        {

            AddTextFields<Workgroup>();
            AddComboBox(unitOfWork.Workshops.GetAll().ToList(), workshop => workshop.Title, workshop => workshop.Id, "کارگاه", entity, workgroup=>workgroup.Workshop_Id);

            foreach (var textbox in this.Controls.OfType<TextBox>())
            {
                textbox.DataBindings.Add("Text", entity, textbox.Name);
            }



        }
    }
}
