using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;
using SalaryApp.WinClient.Salary.SalaryDetails;
using System;
using SalaryApp.DataLayer.Persistence;
using System.Linq;
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
            this.Text = @"لیست پرداخت ها";
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
                 if (!unitOfWork.SalaryDetails.Find(sd => sd.Pay.Id == paylist.Id).Any())
                 {
                     var result = MessageBox.Show(@"برای این لیست جزئیاتی تعریف نشده است.میخواهید از لیست پرسنل استفاده کنید ؟", @"هشدار", MessageBoxButtons.YesNoCancel);
                     if (result == DialogResult.Yes)
                     {
                         var employees = unitOfWork.Employees.Find(emp => emp.Workgroup.Workshop_Id == grid.GetCurrentItem.Workshop_Id).ToList();
                         foreach (var emp in employees)
                         {
                             unitOfWork.SalaryDetails.Add(new SalaryPayDetails
                             {
                                 EmployeeId=emp.Id,
                                 PayId=grid.GetCurrentItem.Id

                             });

                             unitOfWork.Complete();
                         }

                         MessageBox.Show(@"عملیات انقال موفق بود");


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


            AddAction("بروزرسانی کارکرد", button =>
            {
                var un = new UnitOfWork(new SalaryContext());

                var attendances = un.Logsheets.Find(l=>l.PayId==grid.GetCurrentItem.Id).ToList();



            });


            AddAction("محاسبه", button =>
            {
                var currentPay = grid.GetCurrentItem;

                 if (currentPay.Status == Pay.PayStatus.Locked)
                 {
                     MessageBox.Show(@"حقوق این ماه قفل شده و امکان محاسبه دوباره وجود ندارد ",@"خطا");
                     return;
                 }

                 using (var un = new UnitOfWork(new SalaryContext()))
                 {
                     if (!un.SalaryDetails.Find(sd => sd.PayId == currentPay.Id).Any())
                     {
                         MessageBox.Show(@"برای این ماه جزئیاتی تعریف نشده.", @"خطا");
                         return;
                     }

                     var salaryList = un.SalaryDetails.Find(sd => sd.PayId == currentPay.Id).ToList();

                     foreach (var entity in salaryList)
                     {
                         IPayDetails payDetail = new DataLayer.Core.SalaryClaculatorEngin(entity);

                         un.Complete();
                     }


                     un.Pays.Get(currentPay.Id).EmployeesCount = salaryList.Count();

                     un.Complete();

                     MessageBox.Show(@"محاسبه حقوق با موفقیت انجام شد.", @"پیام سیستم");

                 }
                
                 grid.ResetBindings();
             });
        }
    }
}
