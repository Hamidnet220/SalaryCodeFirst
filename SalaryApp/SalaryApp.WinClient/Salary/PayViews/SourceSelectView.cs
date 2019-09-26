using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.Salary.PayViews
{
    public partial class SourceSelectView : ViewsBase
    {
        public PayList.SourceType SourceType { get; private set; }

        private int top;
        private int left;

        public SourceSelectView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            left = this.Width - 30 - oprationPanel.Width;
            top = 20;

            AddRedioButton("انتخاب از فایل حضور و غیاب", radio =>
            {
                this.SourceType=PayList.SourceType.Logsheet;
            },true);

            AddRedioButton("انتخاب از لیست کارکنان", radio =>
            {
                this.SourceType = PayList.SourceType.EmployeeList;
            });

            AddRedioButton("کپی از اطلاعات ماه قبل", radio =>
            {
                this.SourceType=PayList.SourceType.LastMonth;
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

        private void AddRedioButton(string title,Action<RadioButton> select,bool Ischecked=false)
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
        }
    }
}
