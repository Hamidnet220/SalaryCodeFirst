namespace SalaryApp.WinClient.BaseInfoForms
{
    partial class WorkshopForm
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
            this.GridViewPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Add = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridViewPanel
            // 
            this.GridViewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridViewPanel.Location = new System.Drawing.Point(0, 0);
            this.GridViewPanel.Name = "GridViewPanel";
            this.GridViewPanel.Size = new System.Drawing.Size(721, 386);
            this.GridViewPanel.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.Edit);
            this.panel1.Controls.Add(this.Add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 45);
            this.panel1.TabIndex = 4;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(181, 10);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 0;
            this.Add.Text = "جدید";
            this.Add.UseVisualStyleBackColor = true;
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(100, 10);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 23);
            this.Edit.TabIndex = 0;
            this.Edit.Text = "ویرایش";
            this.Edit.UseVisualStyleBackColor = true;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(19, 10);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 0;
            this.Delete.Text = "حذف";
            this.Delete.UseVisualStyleBackColor = true;
            // 
            // WorkshopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 437);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GridViewPanel);
            this.Name = "WorkshopForm";
            this.Text = "WorkshopsForm";
            this.Load += new System.EventHandler(this.WorkshopsForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel GridViewPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Add;
    }
}