using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.WinClient.CustomeControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms
{
    public class WorkshopForm:BaseForm
    {
        
        private CustomeControls.BaseTextBox titleTextBox;
        private CustomeControls.BaseTextBox addressTextBox;
        private CustomeControls.BaseTextBox telTextBox;
        private CustomeControls.BaseButton cancelButton;
        private CustomeControls.BaseButton saveButton;
        private CustomeControls.BaseLabel workshopName;
        private CustomeControls.BaseLabel baseLabel2;
        private CustomeControls.BaseLabel tel;
        private Panel DatagridPanel;
        private System.ComponentModel.IContainer components;
        BindingSource bindingSource = new BindingSource();
        GridControl grid = new GridControl();
        

        public WorkshopForm(string title)
        {
            Text=title;
            InitializeComponent();
            this.Load += new EventHandler(GetData);
        }

        public void GetData(object sender,EventArgs e)
        {
            using (var unitOfWork = new UnitOfWork(new SalaryContext()))
            {
                bindingSource.DataSource = unitOfWork.Workshops.GetAll();
            }

        }

        private void InitializeComponent()
        {
            this.titleTextBox = new SalaryApp.WinClient.CustomeControls.BaseTextBox();
            this.addressTextBox = new SalaryApp.WinClient.CustomeControls.BaseTextBox();
            this.telTextBox = new SalaryApp.WinClient.CustomeControls.BaseTextBox();
            this.cancelButton = new SalaryApp.WinClient.CustomeControls.BaseButton();
            this.saveButton = new SalaryApp.WinClient.CustomeControls.BaseButton();
            this.workshopName = new SalaryApp.WinClient.CustomeControls.BaseLabel();
            this.baseLabel2 = new SalaryApp.WinClient.CustomeControls.BaseLabel();
            this.tel = new SalaryApp.WinClient.CustomeControls.BaseLabel();
            this.DatagridPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(220, 22);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(299, 22);
            this.titleTextBox.TabIndex = 0;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(419, 50);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(100, 22);
            this.addressTextBox.TabIndex = 0;
            // 
            // telTextBox
            // 
            this.telTextBox.Location = new System.Drawing.Point(220, 78);
            this.telTextBox.Name = "telTextBox";
            this.telTextBox.Size = new System.Drawing.Size(299, 22);
            this.telTextBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 127);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(91, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "انصراف";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(117, 127);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(91, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "ذخیره";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // workshopName
            // 
            this.workshopName.AutoSize = true;
            this.workshopName.Location = new System.Drawing.Point(525, 25);
            this.workshopName.Name = "workshopName";
            this.workshopName.Size = new System.Drawing.Size(55, 14);
            this.workshopName.TabIndex = 2;
            this.workshopName.Text = "نام کارگاه";
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Location = new System.Drawing.Point(525, 53);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(35, 14);
            this.baseLabel2.TabIndex = 2;
            this.baseLabel2.Text = "آدرس";
            // 
            // tel
            // 
            this.tel.AutoSize = true;
            this.tel.Location = new System.Drawing.Point(525, 81);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(29, 14);
            this.tel.TabIndex = 2;
            this.tel.Text = "تلفن";
            // 
            // DatagridPanel
            // 
            this.DatagridPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DatagridPanel.Location = new System.Drawing.Point(0, 184);
            this.DatagridPanel.Name = "DatagridPanel";
            this.DatagridPanel.Size = new System.Drawing.Size(625, 250);
            this.DatagridPanel.TabIndex = 3;
            // 
            // WorkshopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(625, 434);
            this.Controls.Add(this.DatagridPanel);
            this.Controls.Add(this.tel);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.workshopName);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.telTextBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Name = "WorkshopForm";
            this.Load += new System.EventHandler(this.WorkshopForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            using (var unitOfWork=new UnitOfWork(new SalaryContext()))
            {
                if (titleTextBox.Text == "")
                {
                    MessageBox.Show("مقادیر وارد شده صحیح نیست");
                    return;
                }

                var workshop = new Workshop
                {
                    Title=titleTextBox.Text,
                    Address=addressTextBox.Text,
                    Tel=telTextBox.Text
                };

                unitOfWork.Workshops.Add(workshop);
                unitOfWork.Complete();

                MessageBox.Show("عملیات ثبت انجام شد");

            }
                
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void WorkshopForm_Load(object sender, EventArgs e)
        {
            grid.DataSource = bindingSource;
            DatagridPanel.Controls.Add(grid);
        }

        
        

       
    }
}
