namespace SalaryApp.WinClient
{
    partial class ViewsBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.oprationPanel = new System.Windows.Forms.Panel();
            this.TopButtonsBar = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // oprationPanel
            // 
            this.oprationPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.oprationPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.oprationPanel.Location = new System.Drawing.Point(749, 48);
            this.oprationPanel.Name = "oprationPanel";
            this.oprationPanel.Size = new System.Drawing.Size(151, 442);
            this.oprationPanel.TabIndex = 0;
            // 
            // TopButtonsBar
            // 
            this.TopButtonsBar.BackColor = System.Drawing.SystemColors.Highlight;
            this.TopButtonsBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopButtonsBar.Location = new System.Drawing.Point(0, 0);
            this.TopButtonsBar.Name = "TopButtonsBar";
            this.TopButtonsBar.Size = new System.Drawing.Size(900, 48);
            this.TopButtonsBar.TabIndex = 2;
            // 
            // ViewsBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oprationPanel);
            this.Controls.Add(this.TopButtonsBar);
            this.Name = "ViewsBase";
            this.Size = new System.Drawing.Size(900, 490);
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Panel oprationPanel;
        protected System.Windows.Forms.Panel TopButtonsBar;
    }
}
