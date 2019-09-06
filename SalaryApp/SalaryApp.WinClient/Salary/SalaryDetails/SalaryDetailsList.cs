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
    public class SalaryDetailsList:ListBase
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

            grid.AddTextBoxColumn(sd => new SalaryPayDetails().Employee.Firstname, "نام");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().Employee.Lastname, "نام خانوادگی");
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
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().Bon,"بن");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().Maskan, "مسکن");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().Karobar, "خواروبار");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().ChildrenBenefit, "حق اولاد");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().ShifStatus, "وضعیت نوبنکاری");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().WorkInHolidayAmount, "مبلغ تعطیل کاری");
            grid.AddTextBoxColumn(sd => new SalaryPayDetails().WrokInFridayAmoutn, "مبلغ جمعه کاری");

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
