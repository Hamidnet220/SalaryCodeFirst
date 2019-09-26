using System;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.WinClient.BaseInfoForms.EmployeeViews;
using SalaryApp.WinClient.BaseInfoForms.WorkgroupViews;
using SalaryApp.WinClient.BaseInfoForms.WorkplaceViews;
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

            AddAction("فعال سازی", button =>
            {
                AppSetting.AppStatus.ActiveWorkShopId = grid.GetCurrentItem.Id;
                var context=new SalaryContext();
                var appstatus=context.AppStatuse.FirstOrDefault();
                appstatus.ActiveWorkShopId = AppSetting.AppStatus.ActiveWorkShopId;
                context.SaveChanges();
                context.Dispose();
                
            });

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
                ViewEngin.ViewInTab<WorkgroupList>(w=>w.workshop=grid.GetCurrentItem,
                    sideButtonBar:true);

            });

            AddAction(" موقعیت ها", button =>
            {
                ViewEngin.ViewInTab<WorkplaceListView>(w => w.workshop = grid.GetCurrentItem,
                    sideButtonBar: true);

            });


            AddAction(" لیست کارکنان", button =>
            {
                ViewEngin.ViewInTab<EmployeeList>(view => view.workshop = grid.GetCurrentItem);
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