using System;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;

namespace SalaryApp.WinClient.BaseInfoForms.WorkgroupViews
{
    public class WorkgroupList : ViewsBase
    {
        private GridControl<Workgroup> grid;
        public Workshop workshop { get; set; }

        public WorkgroupList()
        {
            this.ViewTitle = "لیست گروهای کاری کارگاه";
        }

        protected override void OnLoad(EventArgs e)
        {
            grid = new GridControl<Workgroup>(this);

            grid.AddTextBoxColumn(py => new Workgroup().Title, "عنوان");
            grid.AddTextBoxColumn(py => new Workgroup().Rate, "پایه روزانه");
            grid.AddTextBoxColumn(py => new Workgroup().ChildrenBenefit, "مبلغ حق اولاد");
            grid.AddTextBoxColumn(py => new Workgroup().Bon, "بن");
            grid.AddTextBoxColumn(py => new Workgroup().Maskan, "مسکن");
            grid.AddTextBoxColumn(py => new Workgroup().ShiftRation, "درصد شیفت");
            grid.AddTextBoxColumn(py => new Workgroup().Description, "توضیحات");

            grid.PopulateDataGridView(unitOfWork.Workgroups.Find(wg => wg.Workshop_Id == workshop.Id).ToList());


            AddAction("+جدید", button =>
            {
                var workgroupEditor = ViewEngin.ViewInForm<WorkgroupEditor>(ed => ed.Entity = new Workgroup(),true);
                if (workgroupEditor.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Workgroups.Add(workgroupEditor.Entity);
                unitOfWork.Complete();
                grid.AddItem(workgroupEditor.Entity);
            });

            AddAction("ویرایش", button =>
            {
                var entity = unitOfWork.Workgroups.Get(grid.GetCurrentItem.Id);
                var workgroupEditor = ViewEngin.ViewInForm<WorkgroupEditor>(ed => ed.Entity = entity,true);

                if (workgroupEditor.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Complete();
            });

            AddAction("کپی", button =>
            {
                var context=new SalaryContext();
                context.Configuration.ProxyCreationEnabled = false;
                var entity = context.Workgroups.Find(grid.GetCurrentItem.Id);
                var container =new StructureMap.Container();
                var newEntity = container.GetInstance(entity.GetType());

                foreach (var property in entity.GetType().GetProperties())
                {
                    if(property.Name=="Id")
                        continue;

                    property.SetValue(newEntity, property.GetValue(entity));
                }
                var workgroupEditor = ViewEngin.ViewInForm<WorkgroupEditor>(ed => ed.Entity = (Workgroup)newEntity,true);

                if (workgroupEditor.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Workgroups.Add(workgroupEditor.Entity);
                unitOfWork.Complete();
                grid.AddItem(workgroupEditor.Entity);
                context.Dispose();
            });


            AddAction("-حذف", button =>
            {
                if (
                    MessageBox.Show(MessagesClass.DeleteConfirm, MessagesClass.CriticalCaption, MessageBoxButtons.YesNo) !=
                    DialogResult.Yes)
                    return;

                unitOfWork.Workgroups.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.RemoveCurrentItem();
            });


            base.OnLoad(e);
        }

     
    }
}