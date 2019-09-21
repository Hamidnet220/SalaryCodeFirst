using System;
using System.Drawing;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;

namespace SalaryApp.WinClient
{
    public partial class ViewsBase : UserControl
    {
        private int buttonTop;
        public UnitOfWork unitOfWork;

        public ViewsBase()
        {
            InitializeComponent();
            unitOfWork=new UnitOfWork(new SalaryContext());
            Disposed += ViewsBase_Disposed;
        }

        protected override void OnLoad(EventArgs e)
        {
            TopButtonsBar.Visible = VisibleTopBar;
            oprationPanel.Visible = VisibleSideBar;
            Text = FormTitle;
        }

        public ViewEngin ViewEngin
        {
            get;
            internal set;
        }

        

        protected virtual string FormTitle { get; set; }

        private void ViewsBase_Disposed(object sender, EventArgs e)
        {
            unitOfWork.Dispose();
        }


        protected void AddAction(string title, Action<Button> onClick)
        {
            var btn = new Button();
            btn.Text = title;
            btn.Click += (obj, e) => { onClick(btn); };
            btn.Size = new Size(90, 25);
            buttonTop += 27;
            btn.Top = buttonTop;
            btn.Left = 35;
            oprationPanel.Controls.Add(btn);
        }

        public virtual string ViewIdentifier
        {
            get { return this.GetType().FullName; }

        }
        protected void CloseView(DialogResult? dialogResult = null)
        {
            ViewEngin.CloseView(this, dialogResult);
        }

        public virtual string ViewTitle { get; set; }

        public bool VisibleTopBar { get; set; }
        public bool VisibleSideBar { get; set; } 

        public DialogResult DialogResult { get; set; }
    }
}