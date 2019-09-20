using System;
using System.Linq;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;

namespace SalaryApp.WinClient.Salary.PayViews
{
    public class PayEditor : EditorBase<Pay>
    {

        public PayEditor(Pay entity)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            AddTextFields<Pay>();
            AddComboBox(unitOfWork.PayTypes.GetAll().ToList(), paytype => paytype.PayTitle, paytype => paytype.Id,
                "نوع پرداخت", Entity, pay => new Pay().PayType_Id);
            AddComboBox(unitOfWork.Workshops.GetAll().ToList(), workshop => workshop.Title, workshop => workshop.Id,
                "کارگاه", Entity, pay => new Pay().Workshop_Id);
            AddComboBox(unitOfWork.FinancialYears.GetAll().ToList(), year => year.Year, year => year.Id, "سال مالی",
                Entity, pay => new Pay().FinancialYear_Id);

            foreach (var textbox in Controls.OfType<TextBox>())
                textbox.DataBindings.Add("Text", Entity, textbox.Name);

            base.OnLoad(e); 
        }

        public override string ViewTitle
        {
            get
            {
                if (Entity.Id == 0)
                    return "ایجاد پرداخت جدید";
                return "ویرایش پرداخت";
            }
        }
    }
}