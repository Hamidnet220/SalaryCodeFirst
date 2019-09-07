using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.PayViews
{
    public class PayList: ListBase
    {
        GridControl<Pay> grid;

        public PayList()
        {
            Load += PayList_Load;
            Load += AddActions;
            Load += PopulateGrid;
        }


        private void PayList_Load(object sender, EventArgs e)
        {
            this.Text = "لیست پرداخت ها";
            this.WindowState = FormWindowState.Maximized;

        }

        private void PopulateGrid(object sender, EventArgs e)
        {
            grid = new GridControl<Pay>(gridPanel);

            grid.AddTextBoxColumn(py => new Pay().MonthId, "شناسه ماه");
            grid.AddTextBoxColumn(py => new Pay().EmployeesCount, "تعداد کارکنان");
            grid.AddTextBoxColumn(py => new Pay().Title, "عنوان پرداخت");
            grid.AddTextBoxColumn(py => new Pay().TotalGrossAmount, "جمع مبلغ ناخالص");

            grid.PopulateDataGridView(unitOfWork.Pays.GetAll());
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

                unitOfWork.Pays.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.RemoveCurrentItem();
            });
        }
    }
}
