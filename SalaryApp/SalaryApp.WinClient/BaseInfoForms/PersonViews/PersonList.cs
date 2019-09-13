using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.PersonViews
{
    public partial class PersonList : ListBase
    {
        GridControl<DataLayer.Core.Domain.Person> grid;

        public PersonList()
        {
            
            InitializeComponent();
            FormTitle = "لیست اشخاص";
            Load += PersonList_Load;
            Load += AddActions;
            Load += PopulateGrid;
        }


        private void PersonList_Load(object sender, EventArgs e)
        {
            
        }

        private void PopulateGrid(object sender, EventArgs e)
        {
            grid = new GridControl<DataLayer.Core.Domain.Person>(gridPanel);
            grid.AddTextBoxColumn(emp => new DataLayer.Core.Domain.Person().Firstname, "نام");
            grid.AddTextBoxColumn(emp => new DataLayer.Core.Domain.Person().Lastname, "نام خانوادگی");
            grid.AddTextBoxColumn(emp => new DataLayer.Core.Domain.Person().FatherName, "نام پدر");
            grid.AddTextBoxColumn(emp => new DataLayer.Core.Domain.Person().NationalCode, "کد ملی");
            grid.AddTextBoxColumn(emp => new DataLayer.Core.Domain.Person().IdNumber, "شماره شناسنامه");
            grid.AddTextBoxColumn(emp => new DataLayer.Core.Domain.Person().BankAccount, "شماره حساب");
            grid.AddTextBoxColumn(emp => new DataLayer.Core.Domain.Person().InsuranceId, "شماره بیمه");

            grid.PopulateDataGridView(unitOfWork.Persons.GetAll());
        }

        private void AddActions(object sender, EventArgs e)
        {
            AddAction("+جدید", button =>
            {
                var personForm = new PersonEditor(new Person());
                var resutl=personForm.ShowDialog();

                if (resutl != DialogResult.OK)
                    return;
                unitOfWork.Persons.Add(personForm.entity);
                unitOfWork.Complete();
                grid.AddItem(personForm.entity);
                
            });

            AddAction("ویرایش", button =>
            {
                var entity = unitOfWork.Persons.Get(grid.GetCurrentItem.Id);
                var personForm = new PersonEditor(entity);
                personForm.ShowDialog();

                if (personForm.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Complete();
            });

            AddAction("-حذف", button =>
            {
                if (MessageBox.Show(MessagesClass.DeleteConfirm, MessagesClass.CriticalCaption, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                unitOfWork.Persons.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.RemoveCurrentItem();
            });
        }
        
        
    }
}
