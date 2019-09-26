using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;

namespace SalaryApp.WinClient.Salary.PayViews
{
    public partial class SourceSelectView : ViewsBase
    {
        public PayList.SourceType SourceType { get; private set; }

        private int top;
        private int left;
        readonly TextBox logsheetPath = new TextBox();
        readonly Button browsButton=new Button();
        public Pay Pay { get; set; }

        public SourceSelectView()
        {
            InitializeComponent();
            ViewTitle = "فراخوانی جزئیات حقوق";

        }

        protected override void OnLoad(EventArgs e)
        {
            left = this.Width - 30 - oprationPanel.Width;
            top = 20;

           

            var logsheetRadio= AddRedioButton("انتخاب از فایل حضور و غیاب", radio =>
                                {
                                    this.SourceType=PayList.SourceType.Logsheet;
                                    logsheetPath.Visible = true;
                                },true);

            logsheetRadio.CheckedChanged += (args, obj) =>
            {
                logsheetPath.Visible = !logsheetRadio.Visible;
                browsButton.Visible = !browsButton.Visible;
            };

            logsheetPath.Width = 200;
            logsheetPath.Top = logsheetRadio.Top;
            logsheetPath.Left = left - logsheetPath.Width-logsheetRadio.Width-60;
            logsheetPath.Visible = true;
            this.Controls.Add(logsheetPath);

            browsButton.Text = "جستجو";
            browsButton.Top = logsheetRadio.Top;
            browsButton.Left = logsheetPath.Left - browsButton.Width - 10;
            browsButton.Visible = true;
            browsButton.Click += (args, obj) =>
            {
                var openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                var path = openFileDialog.FileName;
                logsheetPath.Text = path;
                var lines = File.ReadLines(path);
                var entities =new  List<SalaryPayDetails>();
                var context = new SalaryContext();
                
                foreach (var line in lines)
                {
                    var ncode = line.Split(',')[3];
                    var employee = context.Employees.FirstOrDefault(emp => emp.Person.NationalCode==ncode);
                    if(employee==null)
                        continue;
                    context.SalaryPayDetails.Add(new SalaryPayDetails
                    {
                        PayId = Pay.Id,
                        EmployeeId = employee.Id
                    });

                    context.SaveChanges();
                }



            };

            this.Controls.Add(browsButton);



            AddRedioButton("انتخاب از لیست کارکنان", radio =>
            {
                this.SourceType = PayList.SourceType.EmployeeList;
            });

            AddRedioButton("کپی از اطلاعات یکی از ماه های قبل", radio =>
            {
                this.SourceType=PayList.SourceType.LastMonth;
            });


            AddRedioButton("کپی از اطلاعات ماه قبل", radio =>
            {
                this.SourceType = PayList.SourceType.LastMonth;
            });

            AddAction("تایید", btn =>
            {
                CloseView(dialogResult:DialogResult.OK);
            });

            AddAction("انصراف", btn =>
            {
                CloseView(dialogResult:DialogResult.Cancel);
            });

            base.OnLoad(e);
        }

        private RadioButton AddRedioButton(string title,Action<RadioButton> select,bool Ischecked=false)
        {
            var radioButton = new RadioButton();
            radioButton.Text = title;
            radioButton.Checked = Ischecked;
            radioButton.Click += (e, obj) =>
            {
                select(radioButton);

            };
            radioButton.AutoSize = true;
            
            radioButton.Top = top;

            Controls.Add(radioButton);
            radioButton.Left = left - radioButton.Width;
            top += radioButton.Height + 10;
            return radioButton;
        }
    }
}
