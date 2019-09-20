using System;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.WinClient.BaseInfoForms.EmployeeViews;
using SalaryApp.WinClient.BaseInfoForms.WorkgroupViews;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;

namespace SalaryApp.WinClient.BaseInfoForms.WorkshopViews
{
    public class WorkshopList : ViewsBase
    {
        private GridControl<Workshop> grid;

        public WorkshopList()
        {
            ViewTitle = "لیست کارگاه ها";
            
        }

        protected override void OnLoad(EventArgs e)
        {
            AddAction("+جدید", button =>
            {
                var workshopEditor = ViewEngin.ViewInForm<WorkshopEditor>(ed => ed.Entity = new Workshop());

                if (workshopEditor.DialogResult == DialogResult.Cancel)
                    return;
                unitOfWork.Workshops.Add(workshopEditor.Entity);
                unitOfWork.Complete();
                grid.AddItem(workshopEditor.Entity);
            });

            AddAction("ویرایش", button =>
            {
                var entity = unitOfWork.Workshops.Get(grid.GetCurrentItem.Id);
                var workshopEditor = ViewEngin.ViewInForm<WorkshopEditor>(ed => ed.Entity = entity);

                if (workshopEditor.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Complete();
                grid.ResetBindings();
            });

            AddAction("-حذف", button =>
            {
                if (
                    MessageBox.Show(MessagesClass.DeleteConfirm, MessagesClass.CriticalCaption, MessageBoxButtons.YesNo) !=
                    DialogResult.Yes)
                    return;
                unitOfWork.Workshops.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.RemoveCurrentItem();
            });


            AddAction(" گروهای کاری", button =>
            {
                var workgroupForm = new WorkgroupList(grid.GetCurrentItem);
            });

            AddAction(" لیست کارکنان", button =>
            {
                var employeeList = new EmployeeList(grid.GetCurrentItem);
            });


            grid = new GridControl<Workshop>(this);
            grid.AddTextBoxColumn(w => w.Title, "نام کارگاه");
            grid.AddTextBoxColumn(w => w.Tel, "تلفن");
            grid.AddTextBoxColumn(w => w.Address, "آدرس");

            grid.PopulateDataGridView(unitOfWork.Workshops.GetAll());

            base.OnLoad(e); 
        }

       
    }
}