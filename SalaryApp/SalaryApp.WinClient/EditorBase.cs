using SalaryApp.DataLayer.Core;
using SalaryApp.DataLayer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient
{
    public class EditorBase:BaseForm
    {
        protected UnitOfWork unitOfWork;

        private Panel OpretionPanel;
        protected Button Cancel;
        protected Button Accept;

        int top = 25;

        public enum FieldMode
        {
            LeftRight,
            TopDown
        }

        public EditorBase(FieldMode mode=FieldMode.LeftRight)
        {
            InitializeComponent();
            this.unitOfWork = new UnitOfWork(new SalaryContext());
            this.WindowState = FormWindowState.Maximized;
            FormClosed += EditorBase_FormClosed;
        }

        private void EditorBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            unitOfWork.Dispose();
        }

        protected void AddAllFields<TModel>()
        {
            foreach (var item in typeof(TModel).GetProperties())
            {
                try
                {
                    var verboseName = item.GetCustomAttributes(typeof(VerboseNameAttribute), false).OfType<VerboseNameAttribute>().FirstOrDefault().VerboseName;
                    
                    var textbox = new TextBox();
                    var label = new Label();

                    textbox.Name = item.Name;
                    label.Name = item.Name + "Label";

                    textbox.Top = top;
                    label.Top = top;

                    textbox.Size = new System.Drawing.Size(150, 25);

                    label.Left = this.Width-label.Width-20;
                    textbox.Left =this.Width-label.Width-textbox.Width-20;

                    textbox.Anchor = AnchorStyles.Right ;
                    textbox.Anchor = AnchorStyles.Top;

                    label.Anchor = AnchorStyles.Right;
                    label.Anchor = AnchorStyles.Top;

                    label.Text = verboseName;

                    this.Controls.Add(label);
                    this.Controls.Add(textbox);

                    top += 25;

                }
                catch (NullReferenceException)
                {

                }
               
            }
        }


        private int SetFieldPosition(Control control)
        {
            
            return 0;
        }

        private void InitializeComponent()
        {
            this.OpretionPanel = new System.Windows.Forms.Panel();
            this.Accept = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.OpretionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpretionPanel
            // 
            this.OpretionPanel.Controls.Add(this.Cancel);
            this.OpretionPanel.Controls.Add(this.Accept);
            this.OpretionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OpretionPanel.Location = new System.Drawing.Point(0, 334);
            this.OpretionPanel.Name = "OpretionPanel";
            this.OpretionPanel.Size = new System.Drawing.Size(595, 53);
            this.OpretionPanel.TabIndex = 0;
            // 
            // Accept
            // 
            this.Accept.Location = new System.Drawing.Point(133, 18);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(75, 23);
            this.Accept.TabIndex = 0;
            this.Accept.Text = "تایید";
            this.Accept.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.Cancel.Location = new System.Drawing.Point(52, 18);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 0;
            this.Cancel.Text = "انصراف";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // EditorBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(595, 387);
            this.Controls.Add(this.OpretionPanel);
            this.Name = "EditorBase";
            this.OpretionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
