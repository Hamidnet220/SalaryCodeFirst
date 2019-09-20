using System;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.WinClient.CustomeControls;
using SalaryApp.WinClient.GeneralClass;

namespace SalaryApp.WinClient.BaseInfoForms.PersonViews
{
    public partial class PersonList : ViewsBase
    {
        private GridControl<Person> grid;

        public PersonList()
        {
            InitializeComponent();
            ViewTitle = "لیست اشخاص";
            Load += PersonList_Load;
            Load += AddActions;
            Load += PopulateGrid;
        }


        private void PersonList_Load(object sender, EventArgs e)
        {
        }

        private void PopulateGrid(object sender, EventArgs e)
        {
            grid = new GridControl<Person>(this);
            grid.AddTextBoxColumn(emp => new Person().Firstname, "نام");
            grid.AddTextBoxColumn(emp => new Person().Lastname, "نام خانوادگی");
            grid.AddTextBoxColumn(emp => new Person().FatherName, "نام پدر");
            grid.AddTextBoxColumn(emp => new Person().NationalCode, "کد ملی");
            grid.AddTextBoxColumn(emp => new Person().IdNumber, "شماره شناسنامه");
            grid.AddTextBoxColumn(emp => new Person().BankAccount, "شماره حساب");
            grid.AddTextBoxColumn(emp => new Person().InsuranceId, "شماره بیمه");

            grid.PopulateDataGridView(unitOfWork.Persons.GetAll());
        }

        private void AddActions(object sender, EventArgs e)
        {
            AddAction("+جدید", button =>
            {
                var editor = ViewEngin.ViewInForm<PersonEditor>(p => p.Entity = new Person());

                if (editor.DialogResult != DialogResult.OK)
                    return;
                unitOfWork.Persons.Add(editor.Entity);
                unitOfWork.Complete();
                grid.AddItem(editor.Entity);
            });

            AddAction("ویرایش", button =>
            {
                var entity = unitOfWork.Persons.Get(grid.GetCurrentItem.Id);
                var personForm = ViewEngin.ViewInForm<PersonEditor>(ed => ed.Entity = entity);

                if (personForm.DialogResult == DialogResult.Cancel)
                    return;

                unitOfWork.Complete();
            });

            AddAction("-حذف", button =>
            {
                if (
                    MessageBox.Show(MessagesClass.DeleteConfirm, MessagesClass.CriticalCaption, MessageBoxButtons.YesNo) !=
                    DialogResult.Yes)
                    return;

                unitOfWork.Persons.Remove(grid.GetCurrentItem);
                unitOfWork.Complete();
                grid.RemoveCurrentItem();
            });
        }
    }
}