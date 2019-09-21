namespace SalaryApp.WinClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ManageWorkshopButton = new System.Windows.Forms.Button();
            this.EmployeeListButton = new System.Windows.Forms.Button();
            this.PayButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.StatusBarStrip = new System.Windows.Forms.StatusStrip();
            this.DateTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.ManPage = new System.Windows.Forms.TabPage();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.CloseCurrentView = new System.Windows.Forms.LinkLabel();
            this.TopeBar = new System.Windows.Forms.Panel();
            this.ManPage.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.TopeBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ManageWorkshopButton
            // 
            this.ManageWorkshopButton.Location = new System.Drawing.Point(530, 37);
            this.ManageWorkshopButton.Name = "ManageWorkshopButton";
            this.ManageWorkshopButton.Size = new System.Drawing.Size(185, 176);
            this.ManageWorkshopButton.TabIndex = 1;
            this.ManageWorkshopButton.Text = "ایجاد/ویرایش/انتخاب کارگاه";
            this.ManageWorkshopButton.UseVisualStyleBackColor = true;
            this.ManageWorkshopButton.Click += new System.EventHandler(this.ManageWorkshopButton_Click);
            // 
            // EmployeeListButton
            // 
            this.EmployeeListButton.Location = new System.Drawing.Point(721, 37);
            this.EmployeeListButton.Name = "EmployeeListButton";
            this.EmployeeListButton.Size = new System.Drawing.Size(208, 176);
            this.EmployeeListButton.TabIndex = 1;
            this.EmployeeListButton.Text = "ایجاد /ویرایش اشخاص";
            this.EmployeeListButton.UseVisualStyleBackColor = true;
            this.EmployeeListButton.Click += new System.EventHandler(this.PersonListButton_Click);
            // 
            // PayButton
            // 
            this.PayButton.Location = new System.Drawing.Point(317, 37);
            this.PayButton.Name = "PayButton";
            this.PayButton.Size = new System.Drawing.Size(207, 176);
            this.PayButton.TabIndex = 1;
            this.PayButton.Text = "ایجاد /ویرایش پرداخت";
            this.PayButton.UseVisualStyleBackColor = true;
            this.PayButton.Click += new System.EventHandler(this.PayButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(115, 37);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(196, 176);
            this.button4.TabIndex = 1;
            this.button4.Text = "گزارشات";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // StatusBarStrip
            // 
            this.StatusBarStrip.Location = new System.Drawing.Point(0, 489);
            this.StatusBarStrip.Name = "StatusBarStrip";
            this.StatusBarStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatusBarStrip.Size = new System.Drawing.Size(1083, 22);
            this.StatusBarStrip.TabIndex = 2;
            this.StatusBarStrip.Text = "statusStrip1";
            // 
            // ManPage
            // 
            this.ManPage.Controls.Add(this.ManageWorkshopButton);
            this.ManPage.Controls.Add(this.EmployeeListButton);
            this.ManPage.Controls.Add(this.button4);
            this.ManPage.Controls.Add(this.PayButton);
            this.ManPage.Location = new System.Drawing.Point(4, 23);
            this.ManPage.Name = "ManPage";
            this.ManPage.Padding = new System.Windows.Forms.Padding(3);
            this.ManPage.Size = new System.Drawing.Size(1075, 436);
            this.ManPage.TabIndex = 0;
            this.ManPage.Text = "صفحه اصلی";
            this.ManPage.UseVisualStyleBackColor = true;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.ManPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 26);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MainTabControl.RightToLeftLayout = true;
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1083, 463);
            this.MainTabControl.TabIndex = 3;
            // 
            // CloseCurrentView
            // 
            this.CloseCurrentView.AutoSize = true;
            this.CloseCurrentView.Location = new System.Drawing.Point(9, 6);
            this.CloseCurrentView.Name = "CloseCurrentView";
            this.CloseCurrentView.Size = new System.Drawing.Size(14, 14);
            this.CloseCurrentView.TabIndex = 2;
            this.CloseCurrentView.TabStop = true;
            this.CloseCurrentView.Text = "X";
            this.CloseCurrentView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CloseCurrentView_LinkClicked);
            // 
            // TopeBar
            // 
            this.TopeBar.Controls.Add(this.CloseCurrentView);
            this.TopeBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopeBar.Location = new System.Drawing.Point(0, 0);
            this.TopeBar.Name = "TopeBar";
            this.TopeBar.Size = new System.Drawing.Size(1083, 26);
            this.TopeBar.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 511);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.StatusBarStrip);
            this.Controls.Add(this.TopeBar);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم اصلی";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ManPage.ResumeLayout(false);
            this.MainTabControl.ResumeLayout(false);
            this.TopeBar.ResumeLayout(false);
            this.TopeBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ManageWorkshopButton;
        private System.Windows.Forms.Button EmployeeListButton;
        private System.Windows.Forms.Button PayButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.StatusStrip StatusBarStrip;
        private System.Windows.Forms.Timer DateTimeTimer;
        private System.Windows.Forms.TabPage ManPage;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.LinkLabel CloseCurrentView;
        private System.Windows.Forms.Panel TopeBar;
    }
}

