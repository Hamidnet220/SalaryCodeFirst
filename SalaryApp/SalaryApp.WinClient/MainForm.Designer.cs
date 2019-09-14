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
            this.ManageWorkshopButton = new System.Windows.Forms.Button();
            this.EmployeeListButton = new System.Windows.Forms.Button();
            this.PayButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ManageWorkshopButton
            // 
            this.ManageWorkshopButton.Location = new System.Drawing.Point(457, 23);
            this.ManageWorkshopButton.Name = "ManageWorkshopButton";
            this.ManageWorkshopButton.Size = new System.Drawing.Size(185, 176);
            this.ManageWorkshopButton.TabIndex = 1;
            this.ManageWorkshopButton.Text = "ایجاد/ویرایش/انتخاب کارگاه";
            this.ManageWorkshopButton.UseVisualStyleBackColor = true;
            this.ManageWorkshopButton.Click += new System.EventHandler(this.ManageWorkshopButton_Click);
            // 
            // EmployeeListButton
            // 
            this.EmployeeListButton.Location = new System.Drawing.Point(648, 23);
            this.EmployeeListButton.Name = "EmployeeListButton";
            this.EmployeeListButton.Size = new System.Drawing.Size(208, 176);
            this.EmployeeListButton.TabIndex = 1;
            this.EmployeeListButton.Text = "ایجاد /ویرایش اشخاص";
            this.EmployeeListButton.UseVisualStyleBackColor = true;
            this.EmployeeListButton.Click += new System.EventHandler(this.PersonListButton_Click);
            // 
            // PayButton
            // 
            this.PayButton.Location = new System.Drawing.Point(244, 23);
            this.PayButton.Name = "PayButton";
            this.PayButton.Size = new System.Drawing.Size(207, 176);
            this.PayButton.TabIndex = 1;
            this.PayButton.Text = "ایجاد /ویرایش پرداخت";
            this.PayButton.UseVisualStyleBackColor = true;
            this.PayButton.Click += new System.EventHandler(this.PayButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(42, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(196, 176);
            this.button4.TabIndex = 1;
            this.button4.Text = "گزارشات";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 511);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.PayButton);
            this.Controls.Add(this.EmployeeListButton);
            this.Controls.Add(this.ManageWorkshopButton);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم اصلی";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ManageWorkshopButton;
        private System.Windows.Forms.Button EmployeeListButton;
        private System.Windows.Forms.Button PayButton;
        private System.Windows.Forms.Button button4;
    }
}

