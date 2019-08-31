﻿using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.WinClient.CustomeControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms
{
    public partial class WorkshopForm : BaseForm
    {

        GridControl<Workshop> grid;
        UnitOfWork unitOfWork;

        public WorkshopForm()
        {
            InitializeComponent();
            Load += InitalDataGridView;
            Load += DisableTextBoxes;
            FormClosing += ReleaseResource;
            
        }

        private void WorkshopsForm_Load(object sender, EventArgs e)
        {
        }

        private void DisableTextBoxes(object sender, EventArgs e)
        {

        }

        private void ReleaseResource(object sender, FormClosingEventArgs e)
        {
            unitOfWork.Dispose();
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WorkshopForm_Load(object sender, EventArgs e)
        {
            
        }

        public IEnumerable<Workshop> GetData()
        {
            IEnumerable<Workshop> data;
            unitOfWork = new UnitOfWork(new SalaryContext());
            data = unitOfWork.Workshops.GetAll();
            return data;

        }

        private void InitalDataGridView(object sender, EventArgs e)
        {
            grid = new GridControl<Workshop>(GridViewPanel);
            grid.AddTextBoxColumn(workshop => workshop.Title, "عنوان کارگاه");
            grid.AddTextBoxColumn(workshop => workshop.Tel, "تلفن تماس");
            grid.AddTextBoxColumn(workshop => workshop.Address, "آدرس");
            grid.PopulateDataGridView(GetData());
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            var workshop = new Workshop();
            workshop = grid.GetCurrentItem;
            unitOfWork.Workshops.Remove(workshop);
            unitOfWork.Complete();
            grid.RemoveCurrentItem();

        }

       

        private void Edit_Click(object sender, EventArgs e)
        {
            var workshoEditor = new WorkshopEditor(grid.GetCurrentItem,unitOfWork);
            workshoEditor.ShowDialog();
            grid.ResetBindings();


        }

        private void Add_Click(object sender, EventArgs e)
        {
            var workshoEditor = new WorkshopEditor(new Workshop(),unitOfWork);
            workshoEditor.ShowDialog();
            grid.AddItem(workshoEditor.entity);
            
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            unitOfWork.Workshops.Remove(grid.GetCurrentItem);
            unitOfWork.Complete();
            grid.RemoveCurrentItem();

        }
    }
}
