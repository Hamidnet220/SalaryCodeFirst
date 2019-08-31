using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using System;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms
{
    public partial class WorkshopEditor : BaseForm
    {
        Workshop workshop;
        UnitOfWork unitOfWork;
        public Workshop entity { get; private set; }
        string formTitle;

        public DialogResult dialogResult { get; private set; }

        public WorkshopEditor(Workshop workshop,UnitOfWork unitOfWork)
        {
            InitializeComponent();

            this.unitOfWork = unitOfWork;

            if (workshop.Id != 0)
            {
                this.workshop = workshop;
                formTitle = "ویرایش کارگاه";
                InitialTextBoxes();
            }
            else
            {
                workshop = new Workshop();
                formTitle = "ایجاد کارگاه";

            }

            Load += WorkshopEditor_Load;
        }

        private void WorkshopEditor_Load(object sender, EventArgs e)
        {
            this.Text = formTitle;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void InitialTextBoxes()
        {
            this.Title.Text = workshop.Title; 
            this.Tel.Text = workshop.Tel; 
            this.Address.Text = workshop.Address;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            //Edit entity. 
            if (workshop.Id != 0)
            {
               
                var editdWorkshop=unitOfWork.Workshops.Get(workshop.Id);
                editdWorkshop.Title = Title.Text;
                editdWorkshop.Tel = Tel.Text;
                editdWorkshop.Address = Address.Text;
                unitOfWork.Complete();
                dialogResult = DialogResult.OK;
                this.Close();
            }

            //Add new entity.
            else
            {
                var newWorkshop = new Workshop();
                newWorkshop.Title = Title.Text;
                newWorkshop.Tel = Tel.Text;
                newWorkshop.Address = Address.Text;
                unitOfWork.Workshops.Add(newWorkshop);
                unitOfWork.Complete();
                this.entity = newWorkshop;
                dialogResult = DialogResult.OK;
                this.Close();
            }

            

            
            
        }

        
    }
}
