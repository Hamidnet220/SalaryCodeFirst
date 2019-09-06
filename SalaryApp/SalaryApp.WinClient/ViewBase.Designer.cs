namespace SalaryApp.WinClient
{
    partial class ListBase
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
            this.oprationPanel = new System.Windows.Forms.Panel();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // oprationPanel
            // 
            this.oprationPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.oprationPanel.Location = new System.Drawing.Point(711, 0);
            this.oprationPanel.Name = "oprationPanel";
            this.oprationPanel.Size = new System.Drawing.Size(133, 452);
            this.oprationPanel.TabIndex = 0;
            // 
            // gridPanel
            // 
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(0, 0);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(711, 452);
            this.gridPanel.TabIndex = 1;
            // 
            // ViewBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 452);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.oprationPanel);
            this.Name = "ViewBase";
            this.Text = "ViewBase";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel oprationPanel;
        protected System.Windows.Forms.Panel gridPanel;
    }
}