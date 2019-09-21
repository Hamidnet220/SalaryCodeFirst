using System;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.WinClient.BaseInfoForms.EmployeeViews;
using SalaryApp.WinClient.BaseInfoForms.PersonViews;
using SalaryApp.WinClient.BaseInfoForms.WorkshopViews;
using SalaryApp.WinClient.Salary.PayViews;

namespace SalaryApp.WinClient
{
    public partial class MainForm : Form
    {
        private ViewEngin viewEngin;
        private AppStatus appStatus;
        public MainForm()
        {
            InitializeComponent();
            viewEngin = new ViewEngin(this.MainTabControl);
            Load += MainForm_Load;
            var toolStripLabel = new ToolStripLabel();
            DateTimeTimer.Tick += (obj, e) => { toolStripLabel.Text = DateTime.Now.ToString(" hh:mm - yyyy/MM/dd"); };

            DateTimeTimer.Interval = 1000;
            DateTimeTimer.Start();

            StatusBarStrip.Items.Add(toolStripLabel);

            var context =new SalaryContext();
            appStatus = context.AppStatuse.FirstOrDefault();
            var activeWorkshopLabel = new ToolStripLabel();
            activeWorkshopLabel.Text ="کارگاه فعال: "+ AppStatus.Workshop.Title;
            StatusBarStrip.Items.Add(activeWorkshopLabel);

            var activeUserabel = new ToolStripLabel();
            activeUserabel.Text ="کاربر فعال:"+ AppStatus.User.Username;
            StatusBarStrip.Items.Add(activeUserabel);
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

            AppStatus.ActiceFinancialYearId = 1;
            AppStatus.ActiveWorkShopId = 1;
            AppStatus.ActiveUserId = 1;
        }


        private void EmployeeInfoMenu_Click(object sender, EventArgs e)
        {
            viewEngin.ViewInTab<EmployeeList>();
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
            viewEngin.ViewInTab<PersonList>();
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


        public AppStatus AppStatus
        {
            get
            {
                if(appStatus==null)
                    appStatus=new AppStatus();
                return appStatus;
            }
        }
        private void CloseCurrentView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            viewEngin.CloseViewTab(MainTabControl.SelectedTab);
        }
    }
}