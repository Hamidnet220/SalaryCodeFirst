using System;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;

namespace SalaryApp.WinClient.BaseInfoForms.WorkgroupViews
{
    public class WorkgroupList : ViewsBase
    {
        private GridControl<Workgroup> grid;
        private readonly Workshop workshop;

        public WorkgroupList(Workshop workshop)
        {
            this.workshop = workshop;
            Load += WorkgroupList_Load;
            Load += AddActions;
            Load += PopulateGrid;
        }

        private void WorkgroupList_Load(object sender, EventArgs e)
        {
            this.ViewTitle = "لیست پرداخت ها";
        }

        private void PopulateGrid(object sender, EventArgs e)
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
        }

        private void AddActions(object sender, EventArgs e)
        {
            AddAction("+جدید", button =>
            {
                var workgroupEditor = ViewEngin.ViewInForm<WorkgroupEditor>(ed => ed.Entity = new Workgroup());
                if (workgroupEditor.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Workgroups.Add(workgroupEditor.Entity);
                unitOfWork.Complete();
                grid.AddItem(workgroupEditor.Entity);
            });

            AddAction("ویرایش", button =>
            {
                var entity = unitOfWork.Workgroups.Get(grid.GetCurrentItem.Id);
                var workgroupEditor = ViewEngin.ViewInForm<WorkgroupEditor>(ed => ed.Entity =entity);

                if (workgroupEditor.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Complete();
            });

            AddAction("کپی", button =>
            {
                var entity = unitOfWork.Workgroups.Get(grid.GetCurrentItem.Id);
                Type typeSource = entity.GetType();
                var newEntity = Activator.CreateInstance(typeSource);

                foreach (var property in entity.GetType().GetProperties())
                    property.SetValue(newEntity, property.GetValue(entity));

                var workgroupEditor = ViewEngin.ViewInForm<WorkgroupEditor>(ed => ed.Entity =(Workgroup) newEntity);

                if (workgroupEditor.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Workgroups.Add(workgroupEditor.Entity);
                unitOfWork.Complete();
                grid.AddItem(workgroupEditor.Entity);
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
        }
    }
}