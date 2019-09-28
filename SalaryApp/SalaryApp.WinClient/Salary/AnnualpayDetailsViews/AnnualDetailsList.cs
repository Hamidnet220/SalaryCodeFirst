using System;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;

namespace SalaryApp.WinClient.Salary.AnnualpayDetailsViews
{
    public class AnnualDetailsList : ViewsBase
    {
        private GridControl<AnnualPayDetails> grid;
        public Pay Pay { get; set; }

        public AnnualDetailsList()
        {
          ViewTitle = "لیست عیدی ،سنوات و مرخصی ";
        }


        protected override void OnLoad(EventArgs e)
        {

            grid = new GridControl<AnnualPayDetails>(this);

            grid.AddTextBoxColumn(sd => new AnnualPayDetails().Employee.Person.Firstname, "نام");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().Employee.Person.Lastname, "نام خانوادگی");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().DailyRate, "پایه روزانه");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().DaysOfWork, "کارکرد-مفید");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().TotalAbsentDays, "تعداد غیبت");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().TotalLeaveDays, "تعداد مرخصی");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().InPartPayment, "علی الحساب   ");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().OtherDeduction, "سایر کسورات");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().OtherDeduction1, "1 سایر کسورات");
            grid.AddTextBoxColumn(sd => new AnnualPayDetails().NetAmount, "خالص پرداختی");

            grid.EnableHrScrollBar();
            grid.PopulateDataGridView(
                unitOfWork.AnnualDetails.Find(payDitalis => payDitalis.Pay.Id == Pay.Id).ToList());


            AddAction("+جدید", button => { });

            AddAction("ویرایش", button => { });

            AddAction("-حذف", button =>
            {
                if (
                    MessageBox.Show(MessagesClass.DeleteConfirm, MessagesClass.CriticalCaption, MessageBoxButtons.YesNo) !=
                    DialogResult.Yes)
                    return;

                unitOfWork.AnnualDetails.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.RemoveCurrentItem();
            });

            base.OnLoad(e);
        }

        
    }
}