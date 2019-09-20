using System;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;

namespace SalaryApp.WinClient.Salary.SalaryDetailsViews
{
    public class SalaryDetailsList : ViewsBase
    {
        private GridControl<SalaryPayDetails> grid;
        private readonly Pay paylist;

        public SalaryDetailsList(Pay paylist)
        {
            this.paylist = paylist;
            Load += SalaryDetailsList_Load;
            Load += AddActions;
            Load += PopulateGrid;
        }


        private void SalaryDetailsList_Load(object sender, EventArgs e)
        {
            this.ViewTitle = @"لیست کارکنان";
        }

        private void PopulateGrid(object sender, EventArgs e)
        {
            grid = new GridControl<SalaryPayDetails>(this);

            grid.AddTextBoxColumn(sd => new SalaryPayDetails().Employee.Person.Firstname, "نام");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().Employee.Person.Lastname, "نام خانوادگی");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().DailyRate, "پایه روزانه");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().DaysOfWork, "روز-کارکرد");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().ChildrenCount, "تعداد فرزند");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().WorkInHoliday, "تعطیل کاری-روز");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().WorkInFriday, "جمعه کاری -روز");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().LeaveDays, "مرخصی-روز");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().MissionDays, "ماموریت-روز");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().WorkOvertimeHr, "اضافه کاری-ساعت");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().WorkAsStandbyDays, "جایگزینی-روز");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().AbsentDays, "غیبت-روز");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().MonthlyWage, "حقوق ماهانه");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().Bon, "بن");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().Maskan, "مسکن");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().Karobar, "خواروبار");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().ChildrenBenefit, "حق اولاد");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().ShifStatus, "وضعیت نوبنکاری");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().WorkInHolidayAmount, "مبلغ تعطیل کاری");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().WrokInFridayAmoutn, "مبلغ جمعه کاری");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().WorkOvertimeAmount, "مبلغ اضافه کاری");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().WorkAsStandbyAmount, "مبلغ جایگزینی");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().BadConditionRatio, "درصد بدی آب وهوا");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().BadConditionAmount, "مبلغ بدی آب و هوا");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().CommuteBenefiRatio, "درصد ایاب و ذهاب");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().CommuteBenefit, "مبلغ ایاب و ذهاب");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().HygieneAmount, "مبلغ سرانه بهداشت");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().FoodBenefit, "مبلغ غذا");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().InstructionBenefit, "مبلغ آموزش");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().BackpayAmount, "مبلغ معوق");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().BackpayExempt, "مبلغ معوق معاف");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().GrossAmount, "مبلغ ناخالص");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().InsuranceExempt, "معاف از بیمه");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().InsuranceIncluded, "مشمول بیمه");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().EmployeerIncurance, "بیمه کارفرما");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().TaxExempt, "معاف از مالیات");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().TaxIncluded, "مشمول مالیات");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().TaxAmount, "مبلغ مالیات");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().PayInAdvance, "مساعده");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().InPartPayment, "علی الحساب   ");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().OtherDeduction, "سایر کسورات");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().OtherDeduction1, "1 سایر کسورات");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().NetAmount, "خالص پرداختی");

            grid.EnableHrScrollBar();
            grid.PopulateDataGridView(
                unitOfWork.SalaryDetails.Find(payDitalis => payDitalis.Pay.Id == paylist.Id).ToList());
        }

        private void AddActions(object sender, EventArgs e)
        {
            AddAction("+جدید", button => { });

            AddAction("ویرایش", button =>
            {
                var entity = unitOfWork.SalaryDetails.Find(sd => sd.Id == grid.GetCurrentItem.Id).FirstOrDefault();
                var salarDetailsEditor = ViewEngin.ViewInForm<SalaryDetailsEditor>(ed => ed.Entity = entity);

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

                unitOfWork.SalaryDetails.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.ResetBindings();
            });
        }
    }
}