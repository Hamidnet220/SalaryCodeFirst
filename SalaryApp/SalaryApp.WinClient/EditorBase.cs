using SalaryApp.DataLayer.Core;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
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
        int left = 0;
        int columnNumber =0;

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

        protected void AddTextFields<TModel>()
        {
            foreach (var item in typeof(TModel).GetProperties())
            {
                try
                {
                    var isComboBox = item.GetCustomAttributes(typeof(ComboBoxAttribute), false).OfType<ComboBoxAttribute>().Any();

                    if (isComboBox)
                        continue;

                    var verboseName = item.GetCustomAttributes(typeof(VerboseNameAttribute), false).OfType<VerboseNameAttribute>().FirstOrDefault().VerboseName;

                    AddLabel(item.Name, verboseName);
                    AddTextBox(item.Name);
                    AdjustControls();

                }
                catch (NullReferenceException)
                {

                }
               
            }
        }

        private void AdjustControls()
        {
            top += 25;

            if (top >= this.Height - 100)
            {
                top = 25;
                columnNumber++;
            }
        }

        private void AddTextBox(string textBoxName)
        {
            var textbox = new TextBox();
            textbox.Name = textBoxName;
            textbox.Top = top;
            textbox.Size = new System.Drawing.Size(150, 25);
            textbox.Left = left - textbox.Width;
            textbox.Anchor = AnchorStyles.Right;
            textbox.Anchor = AnchorStyles.Top;
            this.Controls.Add(textbox);
        }

        private void AddLabel(string labelName, string verboseName)
        {
            var label = new Label();
            label.Name = labelName + "Label";
            label.Top = top;
            left = (this.Width - label.Width - 20) - (columnNumber * 350);
            label.Left = left;
            label.Text = verboseName;
            label.Anchor = AnchorStyles.Right;
            label.Anchor = AnchorStyles.Top;
            this.Controls.Add(label);
        }

        protected void AddComboBox<TEntity,TPropM,TPropV>(List<TEntity> items, Expression<Func<TEntity, TPropM>> displayMember,
            Expression<Func<TEntity, TPropV>> displayValue,string labelText)
        {
            var expressionHandler = new ExpressionHandler();
            AddLabel(expressionHandler.GetPropertyName(displayMember), labelText);
            var combobox = new ComboBox();
            combobox.Name = typeof(TEntity).Name;
            combobox.DataSource = items;
            combobox.DisplayMember = expressionHandler.GetPropertyName(displayMember);
            combobox.ValueMember = expressionHandler.GetPropertyName(displayValue);
            combobox.Top = top;
            combobox.Left = left - combobox.Width;
            this.Controls.Add(combobox);

            AdjustControls();

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
