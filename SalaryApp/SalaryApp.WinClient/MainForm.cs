using System;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.WinClient.BaseInfoForms.PersonViews;
using SalaryApp.WinClient.BaseInfoForms.WorkshopViews;
using SalaryApp.WinClient.Salary.PayViews;

namespace SalaryApp.WinClient
{
    public partial class MainForm : Form
    {
        private ViewEngin viewEngin;

        public MainForm()
        {
            InitializeComponent();
            viewEngin = new ViewEngin(this.MainTabControl);
            Load += MainForm_Load;
            var toolStripLabel = new ToolStripLabel();
            DateTimeTimer.Tick += (obj, e) => { toolStripLabel.Text = DateTime.Now.ToString("dd MM yyyy hh:mm:ss"); };

            DateTimeTimer.Interval = 1000;
            DateTimeTimer.Start();

            StatusBarStrip.Items.Add(toolStripLabel);
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            AppStatus.ActiceFinancialYearId = 1;
            AppStatus.ActiveWorkShopId = 1;
            AppStatus.ActiveUserId = 1;
        }


        private void EmployeeInfoMenu_Click(object sender, EventArgs e)
        {
        }

        private void ManageWorkshopButton_Click(object sender, EventArgs e)
        {
            viewEngin.ViewInTab<WorkshopList>();
        }

        private void PayButton_Click(object sender, EventArgs e)
        {
            viewEngin.ViewInTab<PayList>();

        }

        private void PersonListButton_Click(object sender, EventArgs e)
        {
           
        }

        public ViewEngin ViewEngin
        {
            get
            {
                if (viewEngin == null)
                    viewEngin = new ViewEngin(this.MainTabControl);
                return viewEngin;
            }
        }
    }
}