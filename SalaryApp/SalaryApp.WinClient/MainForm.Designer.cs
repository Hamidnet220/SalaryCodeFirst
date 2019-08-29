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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ManageWorkshopButton
            // 
            this.ManageWorkshopButton.Location = new System.Drawing.Point(702, 12);
            this.ManageWorkshopButton.Name = "ManageWorkshopButton";
            this.ManageWorkshopButton.Size = new System.Drawing.Size(154, 115);
            this.ManageWorkshopButton.TabIndex = 1;
            this.ManageWorkshopButton.Text = "ایجاد/ویرایش/انتخاب کارگاه";
            this.ManageWorkshopButton.UseVisualStyleBackColor = true;
            this.ManageWorkshopButton.Click += new System.EventHandler(this.ManageWorkshopButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(542, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 115);
            this.button2.TabIndex = 1;
            this.button2.Text = "ایجاد /ویرایش کارکنان";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(382, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 115);
            this.button3.TabIndex = 1;
            this.button3.Text = "ایجاد /ویرایش پرداخت";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(222, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(154, 115);
            this.button4.TabIndex = 1;
            this.button4.Text = "گزارشات";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 448);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

