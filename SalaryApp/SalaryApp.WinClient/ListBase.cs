using SalaryApp.DataLayer.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient
{
    public partial class ListBase : BaseForm
    {


        protected UnitOfWork unitOfWork;
        protected virtual string FormTitle { get; set; }

        int buttonTop = 0;


        public ListBase()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork(new SalaryContext());
            Load += ViewBase_Load;
            FormClosed += ViewBase_FormClosed;
        }

        

        private void ViewBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            unitOfWork.Dispose();
        }

        private void ViewBase_Load(object sender, EventArgs e)
        {
            this.Text = FormTitle;
            this.WindowState = FormWindowState.Maximized;
        }

        protected void AddAction(string title, Action<Button> onClick)
        {
            var btn = new Button();
            btn.Text = title;
            btn.Click += (obj, e) =>
            {
                onClick(btn);
            };
            btn.Size = new Size(90, 25);
            buttonTop += 27;
            btn.Top = buttonTop;
            btn.Left = 35;
            oprationPanel.Controls.Add(btn);

        }
    }
}
