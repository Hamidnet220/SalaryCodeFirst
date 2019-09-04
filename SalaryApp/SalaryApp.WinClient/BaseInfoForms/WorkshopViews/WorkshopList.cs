using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;
using System;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.WorkshopViews
{
    public class WorkshopList:ViewBase
    {
        
        GridControl<Workshop> grid;

        public WorkshopList()
        {
            Load += WorkshopList_Load;
            Load += AddActions;
            Load += PopulateGrid;
        }

        private void WorkshopList_Load(object sender, EventArgs e)
        {
            this.Text = "لیست کارکنان";
            this.WindowState = FormWindowState.Maximized;

        }

        private void PopulateGrid(object sender, EventArgs e)
        {
            grid = new GridControl<Workshop>(gridPanel);
            grid.AddTextBoxColumn(w=>w.Title, "نام کارگاه");
            grid.AddTextBoxColumn(w=>w.Tel, "تلفن");
            grid.AddTextBoxColumn(w=>w.Address, "آدرس");

            grid.PopulateDataGridView(unitOfWork.Workshops.GetAll());
        }

        private void AddActions(object sender, EventArgs e)
        {
            AddAction("+جدید", button =>
            {
                var employeeForm = new EmployeeForm(" ");
                employeeForm.ShowDialog();
            });

            AddAction("ویرایش", button =>
            {
                MessageBox.Show("Edit employeee");
            });

            AddAction("-حذف", button =>
            {
                if (MessageBox.Show(MessagesClass.DeleteConfirm, MessagesClass.CriticalCaption, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                unitOfWork.Workshops.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.RemoveCurrentItem();
            });
        }

       
    }
}
