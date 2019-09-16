using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence.Repositories;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;
using SalaryApp.WinClient.Salary.SalaryDetails;
using System;
using SalaryApp.DataLayer.Persistence;
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
            grid.AddTextBoxColumn(py => new Pay().Status, "وضعیت");
            var activeworkshop = AppStatus.ActiveWorkShopId;
            grid.PopulateDataGridView(unitOfWork.Pays.Find(p=>p.Workshop_Id== activeworkshop).ToList());
        }

        private void UpdateGrid(object e,Pay pay)
        {
            grid.AddItem(pay);
            grid.ResetBindings();
        }

        private void AddActions(object sender, EventArgs e)
        {
            AddAction("+جدید", button =>
            {
                var payForm = new PayEditor();
                payForm.AddEntity += UpdateGrid;
                payForm.ShowDialog();

                
            });

            AddAction("ویرایش", button =>
            {
            });

            AddAction("جزئیات پرداخت", button =>
             {
                 var paylist = grid.GetCurrentItem;
                 if (unitOfWork.SalaryDetails.Find(sd => sd.Pay.Id == paylist.Id).Count() == 0)
                 {
                     var result = MessageBox.Show("برای این لیست جزئیاتی تعریف نشده است.میخواهید از لیست پرسنل استفاده کنید ؟", "هشدار", MessageBoxButtons.YesNoCancel);
                     if (result == DialogResult.Yes)
                     {
                         var employees = unitOfWork.Employees.Find(emp => emp.Workgroup.Workshop_Id == grid.GetCurrentItem.Workshop_Id).ToList();
                         foreach (var emp in employees)
                         {
                             unitOfWork.SalaryDetails.Add(new SalaryPayDetails
                             {
                                 Employee_Id=emp.Id,
                                 Pay_Id=grid.GetCurrentItem.Id

                             });

                             unitOfWork.Complete();
                         }

                         MessageBox.Show("عملیات انقال موفق بود");


                     }
                 }



                 
                 var payDetails = new SalaryDetailsList(paylist);
                 payDetails.ShowDialog();
                 
             });

            AddAction("-حذف", button =>
            {
                if (MessageBox.Show(MessagesClass.DeleteConfirm, MessagesClass.CriticalCaption, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                unitOfWork.Pays.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.RemoveCurrentItem();
            });

            AddAction("محاسبه", button =>
             {
                 if (grid.GetCurrentItem.Status == Pay.PayStatus.Locked)
                     return;

                 var un =new  UnitOfWork(new SalaryContext());
                 var salaryDetailCount = un.SalaryDetails.Find(sd => sd.Pay_Id == grid.GetCurrentItem.Id).Count();

                 if (salaryDetailCount == 0)
                     return;
                 var salaryList = un.SalaryDetails.Find(sd => sd.Pay_Id == grid.GetCurrentItem.Id).ToList();

                 foreach (var item in salaryList)
                 {
                     var entity = un.SalaryDetails.Find(sd => sd.Employee_Id == item.Employee_Id).FirstOrDefault();
                     entity.MonthlyWage = entity.DaysOfWork * entity.DailyRate;
                     entity.Bon = entity.Employee.Workgroup.Bon;
                     entity.ChildrenBenefit = entity.Employee.Workgroup.ChildrenBenefit * entity.ChildrenCount;
                     entity.CommuteBenefit = (decimal)entity.CommuteBenefiRatio * entity.DaysOfWork;
                     entity.GrossAmount = entity.BadConditionAmount + entity.Bon + entity.ChildrenBenefit + entity.CommuteBenefit + entity.FoodBenefit +
                               entity.HygieneAmount + entity.InstructionBenefit + entity.Karobar + entity.Maskan + entity.MonthlyWage +
                               entity.WorkAsStandbyAmount + entity.WorkInHolidayAmount + entity.WorkOvertimeAmount + entity.WrokInFridayAmoutn;
                     entity.TaxIncluded = entity.GrossAmount;
                     un.Complete();

                 }

                 un.Dispose();

             });
        }
    }
}
