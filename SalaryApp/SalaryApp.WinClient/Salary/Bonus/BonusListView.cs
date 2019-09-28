using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;
using SalaryApp.WinClient.Salary.SalaryDetailsViews;

namespace SalaryApp.WinClient.Salary.Bonus
{
    public partial class BonusListView :ViewsBase
    {
        private GridControl<BonusPayDetails> grid;
        public Pay Pay { get; set; }
        public BonusListView()
        {
            InitializeComponent();
            ViewTitle = @"لیست پاداش بهره وری";
        }


        protected override void OnLoad(EventArgs e)
        {
            grid = new GridControl<BonusPayDetails>(this);

            grid.AddTextBoxColumn(sd => new BonusPayDetails().Employee.Person.Firstname, "نام");
            grid.AddTextBoxColumn(sd => new BonusPayDetails().Employee.Person.Lastname, "نام خانوادگی");
            grid.AddTextBoxColumn(sd => new BonusPayDetails().DailyRate, "پایه روزانه");
            grid.AddTextBoxColumn(sd => new BonusPayDetails().DaysOfWork, "کارکرد-مفید");
            grid.AddTextBoxColumn(sd => new BonusPayDetails().GrossAmount, "مبلغ ناخالص");
            grid.AddTextBoxColumn(sd => new BonusPayDetails().InPartPayment, "علی الحساب   ");
            grid.AddTextBoxColumn(sd => new BonusPayDetails().OtherDeduction, "سایر کسورات");
            grid.AddTextBoxColumn(sd => new BonusPayDetails().OtherDeduction1, "1 سایر کسورات");
            grid.AddTextBoxColumn(sd => new BonusPayDetails().NetAmount, "خالص پرداختی");

            grid.EnableHrScrollBar();
            grid.PopulateDataGridView(
                unitOfWork.BonusPayDetails.Find(payDitalis => payDitalis.Pay.Id == Pay.Id).ToList());


            AddAction("+جدید", button => { });

            AddAction("ویرایش", button =>
            {
                var entity = unitOfWork.BonusPayDetails.Find(sd => sd.Id == grid.GetCurrentItem.Id).FirstOrDefault();
                var salarDetailsEditor = ViewEngin.ViewInForm<BonusEditorView>(ed => ed.Entity = entity, true);

                if (salarDetailsEditor.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Complete();
            });

            AddAction("-حذف", button =>
            {
                if (
                    MessageBox.Show(MessagesClass.DeleteConfirm, MessagesClass.CriticalCaption, MessageBoxButtons.YesNo) !=
                    DialogResult.Yes)
                    return;

                unitOfWork.BonusPayDetails.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.RemoveCurrentItem();
            });


            base.OnLoad(e);
        }
    }
}
