using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.Salary.AnnualpayDetails
{
    public class AnnualDetailsList : ListBase
    {
        GridControl<AnnualPayDetails> grid;
        Pay paylist;

        public AnnualDetailsList(Pay paylist)
        {
            this.FormTitle = "لیست عیدی ،سنوات و مرخصی ";
            this.paylist = paylist;
            Load += AnnualDetailsList_Load;
            Load += AddActions;
            Load += PopulateGrid;
        }


        private void AnnualDetailsList_Load(object sender, EventArgs e)
        {
            
        }

        private void PopulateGrid(object sender, EventArgs e)
        {
            grid = new GridControl<AnnualPayDetails>(gridPanel);

            grid.AddTextBoxColumn(sd => new AnnualPayDetails().Employee.Firstname, "نام");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().Employee.Lastname, "نام خانوادگی");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().DailyRate, "پایه روزانه");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().TotalDaysOfWork, "کارکرد-مفید");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().TotalAbsentDays, "تعداد غیبت");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().TotalLeaveDays, "تعداد مرخصی");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().InPartPayment, "علی الحساب   ");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().OtherDeduction, "سایر کسورات");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().OtherDeduction1, "1 سایر کسورات");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().NetAmount, "خالص پرداختی");

            grid.EnableHrScrollBar();
            grid.PopulateDataGridView(unitOfWork.AnnualDetails.Find(payDitalis => payDitalis.Pay.Id == paylist.Id).ToList());
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

                unitOfWork.AnnualDetails.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.RemoveCurrentItem();
            });
        }

    }
}