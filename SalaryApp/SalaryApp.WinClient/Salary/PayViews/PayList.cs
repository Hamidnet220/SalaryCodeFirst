using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;
using SalaryApp.WinClient.Salary.SalaryDetailsViews;

namespace SalaryApp.WinClient.Salary.PayViews
{
    public class PayList : ViewsBase
    {
        private GridControl<Pay> _grid;


        public PayList()
        {
            
            ViewTitle = @"لیست پرداخت ها";
        }

        protected override void OnLoad(EventArgs e)
        {
            _grid = new GridControl<Pay>(this);
            _grid.AddTextBoxColumn(py => new Pay().MonthId, "شناسه ماه");
            _grid.AddTextBoxColumn(py => new Pay().EmployeesCount, "تعداد کارکنان");
            _grid.AddTextBoxColumn(py => new Pay().Title, "عنوان پرداخت");
            _grid.AddTextBoxColumn(py => new Pay().TotalGrossAmount, "جمع مبلغ ناخالص");
            _grid.AddTextBoxColumn(py => new Pay().Status, "وضعیت");
            var activeworkshop = AppStatus.ActiveWorkShopId;
            _grid.PopulateDataGridView(unitOfWork.Pays.Find(p => p.Workshop_Id == activeworkshop).ToList());

            AddAction("+جدید", button =>
            {
                var editor = ViewEngin.ViewInForm<PayEditor>(ed => ed.Entity = new Pay());
                if (editor.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Pays.Add(editor.Entity);
                unitOfWork.Complete();
            });

            AddAction("ویرایش", button =>
            {
                var entity = unitOfWork.Pays.Get(_grid.GetCurrentItem.Id);

                var editor = ViewEngin.ViewInForm<PayEditor>(ed=>ed.Entity=entity);

                if (editor.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Complete();
            });

            AddAction("جزئیات پرداخت", button =>
            {
                var paylist = _grid.GetCurrentItem;
                if (!unitOfWork.SalaryDetails.Find(sd => sd.Pay.Id == paylist.Id).Any())
                {
                    var result =
                        MessageBox.Show(@"برای این لیست جزئیاتی تعریف نشده است.میخواهید از لیست پرسنل استفاده کنید ؟",
                            @"هشدار", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        var employees =
                            unitOfWork.Employees.Find(
                                emp => emp.Workgroup.Workshop_Id == _grid.GetCurrentItem.Workshop_Id).ToList();
                        foreach (var emp in employees)
                        {
                            unitOfWork.SalaryDetails.Add(new SalaryPayDetails
                            {
                                EmployeeId = emp.Id,
                                PayId = _grid.GetCurrentItem.Id
                            });

                            unitOfWork.Complete();
                        }

                        MessageBox.Show(@"عملیات انقال موفق بود");
                    }
                }


                var payDetails = ViewEngin.ViewInForm<SalaryDetailsList>(null);


            });

            AddAction("-حذف", button =>
            {
                if (
                    MessageBox.Show(MessagesClass.DeleteConfirm, MessagesClass.CriticalCaption, MessageBoxButtons.YesNo) !=
                    DialogResult.Yes)
                    return;

                unitOfWork.Pays.Remove(_grid.GetCurrentItem);
                unitOfWork.Complete();
                _grid.RemoveCurrentItem();
            });

            AddAction("بروزرسانی کارکرد", button =>
            {
                var un = new UnitOfWork(new SalaryContext());

                var attendances = un.Logsheets.Find(l => l.PayId == _grid.GetCurrentItem.Id).ToList();

                var openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                var path = openFileDialog.FileName;
                var textfile = File.ReadAllLines(path).ToList();
                var sumLeavs = 0;
                foreach (var line in textfile)
                {
                    var fields = line.Split(',');
                    var leavs = fields.Where(d => d.ToString() == "م").ToList();
                    var workDays = fields.Where(d => d.ToString() == "ص" ||
                                                     d.ToString() == "ع" ||
                                                     d.ToString() == "ش" ||
                                                     d.ToString() == "ر" ||
                                                     d.ToString() == "آ" ||
                                                     d.ToString() == "م").ToList();
                    var ncode = fields[3];

                    var payDetails = unitOfWork.SalaryDetails.Find(sd => sd.Employee.Person.NationalCode == ncode)
                        .FirstOrDefault();

                    if (payDetails != null)
                    {
                        payDetails.LeaveDays = (byte)leavs.Count;
                        payDetails.DaysOfWork = (byte)workDays.Count;
                    }


                    unitOfWork.Complete();

                    sumLeavs += leavs.Count;
                }

                MessageBox.Show(sumLeavs.ToString());
            });

            AddAction("محاسبه", button =>
            {
                var currentPay = _grid.GetCurrentItem;

                if (currentPay.Status == Pay.PayStatus.Locked)
                {
                    MessageBox.Show(@"حقوق این ماه قفل شده و امکان محاسبه دوباره وجود ندارد ", @"خطا");
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
                        IPayDetails payDetail = new SalaryClaculatorEngin(entity);

                        un.Complete();
                    }


                    un.Pays.Get(currentPay.Id).EmployeesCount = salaryList.Count();

                    un.Complete();

                    MessageBox.Show(@"محاسبه حقوق با موفقیت انجام شد.", @"پیام سیستم");
                }

                _grid.ResetBindings();
            });

            AddAction("ایجاد فایل پرداخت", button =>
            {
                var paylist =
                    new SalaryContext().SalaryPayDetails.Where(
                        sd => sd.PayId == _grid.GetCurrentItem.Id && sd.NetAmount >= 0).ToList();
                var list = new List<string>();

                foreach (var payDetail in paylist)
                    list.Add(payDetail.Employee.Person.Lastname + "," + payDetail.Employee.Person.Firstname + "," +
                             payDetail.NetAmount + "," + payDetail.Employee.Person.BankAccount);

                var folderBrowser = new FolderBrowserDialog();

                if (folderBrowser.ShowDialog() != DialogResult.OK)
                    return;

                File.WriteAllLines(Path.Combine(folderBrowser.SelectedPath, "BankPay.txt"), list);
            });

            AddAction("قفل کردن ماه", button =>
            {
                var curretnPayList = unitOfWork.Pays.Get(_grid.GetCurrentItem.Id);
                if (curretnPayList.Status == Pay.PayStatus.Locked)
                {
                    MessageBox.Show(@"لیست  مورد نظر قبلاً قفل شده است.", @"پیام سیستم");
                    return;
                }
                curretnPayList.Status = Pay.PayStatus.Locked;
                unitOfWork.Complete();
                MessageBox.Show(@"لیست مورد نظر قفل شد.", @"پیام سیستم");
            });

            base.OnLoad(e); 
        }

       
    }
}