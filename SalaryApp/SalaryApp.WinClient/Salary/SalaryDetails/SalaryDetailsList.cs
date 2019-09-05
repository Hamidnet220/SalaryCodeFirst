using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.Salary.SalaryDetails
{
    public class SalaryDetailsList:ViewBase
    {
        GridControl<SalaryPayDetails> grid;
        int buttonTop = 0;


        public SalaryDetailsList()
        {
            Load += SalaryDetailsList_Load;
            Load += AddActions;
            Load += PopulateGrid;
        }


        private void SalaryDetailsList_Load(object sender, EventArgs e)
        {
            this.Text = "لیست کارکنان";
            this.WindowState = FormWindowState.Maximized;

        }

        private void PopulateGrid(object sender, EventArgs e)
        {
            grid = new GridControl<SalaryPayDetails>(gridPanel);

            grid.PopulateDataGridView(unitOfWork.SalaryDetails.GetAll());
        }

        private void AddActions(object sender, EventArgs e)
        {
            AddAction("+جدید", button =>
            {
               
            });

            AddAction("ویرایش", button =>
            {
            });

            AddAction("-حذف", button =>
            {
                if (MessageBox.Show(MessagesClass.DeleteConfirm, MessagesClass.CriticalCaption, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                unitOfWork.SalaryDetails.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.RemoveCurrentItem();
            });
        }

    }
}
