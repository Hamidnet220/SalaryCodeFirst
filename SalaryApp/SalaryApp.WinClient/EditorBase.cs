using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Permissions;
using System.Windows.Forms;
using SalaryApp.DataLayer;
using SalaryApp.DataLayer.Core;
using SalaryApp.DataLayer.Persistence;

namespace SalaryApp.WinClient
{
    public class EditorBase<TEntity> : ViewsBase where TEntity:class
    {
        public TEntity Entity { get; set; }
        public enum FieldMode
        {
            LeftRight,
            TopDown
        }

        protected Button Accept;
        protected Button Cancel;
        private int columnNumber;
        private int left;

        private Panel OpretionPanel;

        private int top = 25;

        public EditorBase(FieldMode mode = FieldMode.LeftRight)
        {
            InitializeComponent();

            Accept.Click += Accept_Click;
            Cancel.Click += Cancel_Click;
        }

        
        protected void Cancel_Click(object sender, EventArgs e)
        {
            CloseView(dialogResult: DialogResult.Cancel);

        }

        protected void Accept_Click(object sender, EventArgs e)
        {
           CloseView(dialogResult:DialogResult.OK);
        }

       
        protected void AddTextFields<TModel>()
        {
            foreach (var item in typeof(TModel).GetProperties())
                try
                {
                    var attrs = item.CustomAttributes;
                    var customAttributeData = attrs.FirstOrDefault();
                    if (customAttributeData == null)
                        continue;
                    if(customAttributeData.AttributeType == typeof(VerboseNameAttribute))
                    {
                        var verboseNameAttribute = item.GetCustomAttributes(typeof(VerboseNameAttribute), false)
                       .OfType<VerboseNameAttribute>()
                       .FirstOrDefault();
                        var verboseName =verboseNameAttribute.VerboseName;
                        AddLabel(item.Name, verboseName);
                        AddTextBox(item.Name);
                        AdjustControls();
                    }
                    else if (customAttributeData.AttributeType== typeof(YesNoComboBoxAttribute))
                    {
                        var yesNoComboBox = item.GetCustomAttributes(typeof(YesNoComboBoxAttribute), false)
                      .OfType<YesNoComboBoxAttribute>()
                      .FirstOrDefault();
                        var title = yesNoComboBox.Title;
                        AddLabel(item.Name, title);
                        AddYesNoComboBox(item.Name);
                        AdjustControls();
                    }



                }
                catch (NullReferenceException)
                {

                }
        }

        private void AdjustControls()
        {
            top += 25;

            if (top >= Height - 100)
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
            textbox.Size = new Size(150, 25);
            textbox.Left = left - textbox.Width;
            textbox.Anchor = AnchorStyles.Right;
            textbox.Anchor = AnchorStyles.Top;
            Controls.Add(textbox);
        }

        private struct YesNo
        {
            public bool Status { get; set; }
            public string Title { get; set; }
        }
        private void AddYesNoComboBox(string comboBoxName)
        {
            var items = new List<YesNo>();
            items.Add(new YesNo() { Status = true, Title = "بله" });
            items.Add(new YesNo() { Status = false, Title = "خیر" });

            var comboBox = new ComboBox();
            comboBox.Name = comboBoxName;
            comboBox.DataSource = items;
            comboBox.Top = top;
            comboBox.DisplayMember = "Title";
            comboBox.ValueMember = "Status";
            comboBox.DataBindings.Add("SelectedValue", Entity, comboBoxName);
            comboBox.Size = new Size(150, 25);
            comboBox.Left = left - comboBox.Width;
            comboBox.Anchor = AnchorStyles.Right;
            comboBox.Anchor = AnchorStyles.Top;
            Controls.Add(comboBox);
        }

        private void AddLabel(string labelName, string verboseName)
        {
            var label = new Label();
            label.Name = labelName + "Label";
            label.Top = top;
            left = Width - label.Width - 20 - columnNumber * 350;
            label.Left = left;
            label.Text = verboseName;
            label.Anchor = AnchorStyles.Right;
            label.Anchor = AnchorStyles.Top;
            Controls.Add(label);
        }

        protected void AddComboBox<TModel, TBindModle, TPropM, TPropV, TPropBinig>(List<TModel> items,
            Expression<Func<TModel, TPropM>> displayMember,
            Expression<Func<TModel, TPropV>> displayValue, string labelText, TBindModle entityToBind,
            Expression<Func<TBindModle, TPropBinig>> bindProperty)
        {
            var expressionHandler = new ExpressionHandler();
            AddLabel(expressionHandler.GetPropertyName(displayMember), labelText);
            var combobox = new ComboBox();
            combobox.Name = typeof(TModel).Name;
            combobox.DataSource = items;
            combobox.DisplayMember = expressionHandler.GetPropertyName(displayMember);
            combobox.ValueMember = expressionHandler.GetPropertyName(displayValue);
            combobox.Top = top;
            combobox.Left = left - combobox.Width;
            combobox.DataBindings.Add("SelectedValue", entityToBind, expressionHandler.GetPropertyName(bindProperty));
            Controls.Add(combobox);

            AdjustControls();
        }

        private int SetFieldPosition(Control control)
        {
            return 0;
        }

        private void InitializeComponent()
        {
            OpretionPanel = new Panel();
            Accept = new Button();
            Cancel = new Button();
            OpretionPanel.SuspendLayout();
            SuspendLayout();
            // 
            // OpretionPanel
            // 
            OpretionPanel.Controls.Add(Cancel);
            OpretionPanel.Controls.Add(Accept);
            OpretionPanel.Dock = DockStyle.Bottom;
            OpretionPanel.Location = new Point(0, 334);
            OpretionPanel.Name = "OpretionPanel";
            OpretionPanel.Size = new Size(595, 53);
            OpretionPanel.TabIndex = 0;
            // 
            // Accept
            // 
            Accept.Location = new Point(133, 18);
            Accept.Name = "Accept";
            Accept.Size = new Size(75, 23);
            Accept.TabIndex = 0;
            Accept.Text = "تایید";
            Accept.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            Cancel.Location = new Point(52, 18);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(75, 23);
            Cancel.TabIndex = 0;
            Cancel.Text = "انصراف";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // EditorBase
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            ClientSize = new Size(595, 387);
            Controls.Add(OpretionPanel);
            Name = "EditorBase";
            OpretionPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}