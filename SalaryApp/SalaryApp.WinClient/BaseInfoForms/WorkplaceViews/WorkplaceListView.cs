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
using SalaryApp.WinClient.BaseInfoForms.WorkgroupViews;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;

namespace SalaryApp.WinClient.BaseInfoForms.WorkplaceViews
{
    public partial class WorkplaceListView : ViewsBase
    {
        private GridControl<Workplace> grid;
        public Workshop workshop { get; set; }

        public WorkplaceListView()
        {
            InitializeComponent();
            this.ViewTitle = "لیست موقعیت های کاری کارگاه";
        }

        protected override void OnLoad(EventArgs e)
        {
            grid = new GridControl<Workplace>(this);

            grid.AddTextBoxColumn(py => new Workplace().Title, "عنوان");
            grid.PopulateDataGridView(unitOfWork.Workplaces.Find(wp => wp.Workshop.Id == workshop.Id).ToList());

            AddAction("+جدید", button =>
            {
                var workplaceEditor = ViewEngin.ViewInForm<WorkplaceEditor>(ed => ed.Entity = new Workplace(), true);
                if (workplaceEditor.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Workplaces.Add(workplaceEditor.Entity);
                unitOfWork.Complete();
                grid.AddItem(workplaceEditor.Entity);
            });

            AddAction("ویرایش", button =>
            {
                var entity = unitOfWork.Workplaces.Get(grid.GetCurrentItem.Id);
                var workplaceEditor = ViewEngin.ViewInForm<WorkplaceEditor>(ed => ed.Entity = entity, true);

                if (workplaceEditor.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Complete();
            });

            AddAction("-حذف", button =>
            {
                if (
                    MessageBox.Show(MessagesClass.DeleteConfirm, MessagesClass.CriticalCaption, MessageBoxButtons.YesNo) !=
                    DialogResult.Yes)
                    return;

                unitOfWork.Workplaces.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.RemoveCurrentItem();
            });

            base.OnLoad(e);
        }
    }
}
