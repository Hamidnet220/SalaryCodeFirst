﻿using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.WinClient.BaseInfoForms.WorkgroupViews;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;
using System;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.WorkshopViews
{
    public class WorkshopList:ListBase
    {
        
        GridControl<Workshop> grid;

        public WorkshopList()
        {
            Load += WorkshopList_Load;
            Load += AddActions;
            Load += PopulateGrid;
        }

        private void WorkshopList_Load(object sender, EventArgs e)
        {
            this.Text = "لیست کارکنان";
            this.WindowState = FormWindowState.Maximized;

        }

        private void PopulateGrid(object sender, EventArgs e)
        {
            grid = new GridControl<Workshop>(gridPanel);
            grid.AddTextBoxColumn(w=>w.Title, "نام کارگاه");
            grid.AddTextBoxColumn(w=>w.Tel, "تلفن");
            grid.AddTextBoxColumn(w=>w.Address, "آدرس");

            grid.PopulateDataGridView(unitOfWork.Workshops.GetAll());
        }

        private void AddActions(object sender, EventArgs e)
        {
            AddAction("+جدید", button =>
            {
                var employeeForm = new WorkshopEditor(new Workshop());
                employeeForm.ShowDialog();

                if (employeeForm.DialogResult == DialogResult.Cancel)
                    return;
                unitOfWork.Workshops.Add(employeeForm.entity);
                unitOfWork.Complete();
                grid.AddItem(employeeForm.entity);

            });

            AddAction("ویرایش", button =>
            {
                var entity = unitOfWork.Workshops.Get(grid.GetCurrentItem.Id);
                var employeeForm = new WorkshopEditor(entity);
                employeeForm.ShowDialog();

                if (employeeForm.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Complete();
                grid.ResetBindings();

            }); 

            AddAction("-حذف", button =>
            {
                if (MessageBox.Show(MessagesClass.DeleteConfirm, MessagesClass.CriticalCaption, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                unitOfWork.Workshops.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.RemoveCurrentItem();
            });


            AddAction(" گروهای کاری", button =>
             {
                 var workgroupForm = new WorkgroupList(grid.GetCurrentItem);
                 workgroupForm.ShowDialog();
             });

            AddAction(" لیست کارکنان", button =>
            {
                var employeeList = new EmployeeViews.EmployeeList(grid.GetCurrentItem);
                employeeList.ShowDialog();
            });
        }

       
    }
}
