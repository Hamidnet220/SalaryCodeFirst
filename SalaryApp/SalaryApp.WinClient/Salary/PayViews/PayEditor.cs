using System;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;

namespace SalaryApp.WinClient.Salary.PayViews
{

    public class PayEditor:EditorBase
    {
        public Pay entity { get; private set; }
        public event EventHandler<Pay> AddEntity;


        public PayEditor(Pay entity)
        {
            this.entity = entity;
            Load += PayEditor_Load;
            
        }

       private void PayEditor_Load(object sender, EventArgs e)
        {

            AddTextFields<Pay>();
            AddComboBox(unitOfWork.PayTypes.GetAll().ToList(),paytype=>paytype.PayTitle, paytype => paytype.Id,"نوع پرداخت",entity,pay=>new Pay().PayType_Id);
            AddComboBox(unitOfWork.Workshops.GetAll().ToList(), workshop=>workshop.Title, workshop=>workshop.Id, "کارگاه",entity, pay => new Pay().Workshop_Id);
            AddComboBox(unitOfWork.FinancialYears.GetAll().ToList(), year=>year.Year,year=>year.Id,"سال مالی", entity, pay => new Pay().FinancialYear_Id);

            foreach (var textbox in this.Controls.OfType<TextBox>())
            {
                textbox.DataBindings.Add("Text", entity, textbox.Name);
            }

        }
    }
}
