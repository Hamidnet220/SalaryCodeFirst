using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.WorkgroupViews
{
    public class WorkgroupList:ListBase
    {
        GridControl<Workgroup> grid;
        Workshop workshop;

        public WorkgroupList(Workshop workshop)
        {
            this.workshop = workshop;
            Load += WorkgroupList_Load;
            Load += AddActions;
            Load += PopulateGrid;

        }

        private void WorkgroupList_Load(object sender, EventArgs e)
        {
            this.Text = "لیست پرداخت ها";
            this.WindowState = FormWindowState.Maximized;
        }

        private void PopulateGrid(object sender, EventArgs e)
        {
            grid = new GridControl<Workgroup>(gridPanel);

            grid.AddTextBoxColumn(py => new Workgroup().Title, "عنوان");
            grid.AddTextBoxColumn(py => new Workgroup().Rate, "پایه روزانه");
            grid.AddTextBoxColumn(py => new Workgroup().ChildrenBenefit, "مبلغ حق اولاد");
            grid.AddTextBoxColumn(py => new Workgroup().Bon, "بن");
            grid.AddTextBoxColumn(py => new Workgroup().Maskan, "مسکن");
            grid.AddTextBoxColumn(py => new Workgroup().ShiftRation, "درصد شیفت");
            grid.AddTextBoxColumn(py => new Workgroup().Description, "توضیحات");

            grid.PopulateDataGridView(unitOfWork.Workgroups.Find(wg=>wg.Workshop_Id==this.workshop.Id).ToList());
        }

        private void AddActions(object sender, EventArgs e)
        {
            AddAction("+جدید", button =>
            {
                var workgroupEditor = new WorkgroupEditor(new Workgroup());
                workgroupEditor.ShowDialog();

                if (workgroupEditor.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Workgroups.Add(workgroupEditor.entity);
                unitOfWork.Complete();
                grid.AddItem(workgroupEditor.entity);

            });

            AddAction("ویرایش", button =>
            {
                var entity = unitOfWork.Workgroups.Get(grid.GetCurrentItem.Id);
                var workgroupEditor = new WorkgroupEditor(entity);
                workgroupEditor.ShowDialog();

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
                {
                    property.SetValue(newEntity, property.GetValue(entity));
                }

                var workgroupEditor = new WorkgroupEditor((Workgroup)newEntity);
                workgroupEditor.ShowDialog();

                if (workgroupEditor.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Workgroups.Add(workgroupEditor.entity);
                unitOfWork.Complete();
                grid.AddItem(workgroupEditor.entity);
            });


            AddAction("-حذف", button =>
            {
                if (MessageBox.Show(MessagesClass.DeleteConfirm, MessagesClass.CriticalCaption, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                unitOfWork.Workgroups.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.RemoveCurrentItem();
            });
        }
    }

}
