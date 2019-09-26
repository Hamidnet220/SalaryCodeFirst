using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;

namespace SalaryApp.WinClient.BaseInfoForms.WorkplaceViews
{
    public partial class WorkplaceEditor : EditorBase<Workplace>
    {
        public WorkplaceEditor()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            AddTextFields<Workplace>();
            AddComboBox(unitOfWork.Workshops.GetAll().ToList(), workshop => workshop.Title, workshop => workshop.Id,
                "کارگاه", Entity, place => place.WorkshopId);

            foreach (var textbox in Controls.OfType<TextBox>())
                textbox.DataBindings.Add("Text", Entity, textbox.Name);

            base.OnLoad(e);
        }
    }
}
