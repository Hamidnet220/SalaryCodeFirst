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
    public partial class ViewBase : BaseForm
    {
        int buttonTop = 0;

        public ViewBase()
        {
            InitializeComponent();
            Load += ViewBase_Load;
           
        }

        private void ViewBase_Load(object sender, EventArgs e)
        {
            this.Text = "لیست کارکنان";
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
            buttonTop += 27;
            btn.Top = buttonTop;
            btn.Left = 45;
            oprationPanel.Controls.Add(btn);

        }
    }
}
