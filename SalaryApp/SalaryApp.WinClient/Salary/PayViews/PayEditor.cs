using SalaryApp.DataLayer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.PayViews
{

    public class PayEditor:EditorBase
    {
        Pay payEntity = new Pay();

        public PayEditor()
        {
            Load += PayEditor_Load;
            Accept.Click += Accept_Click;
            
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            unitOfWork.Pays.Add(payEntity);
            unitOfWork.Complete();
        }
        private void PayEditor_Load(object sender, EventArgs e)
        {

            AddTextFields<Pay>();
            AddComboBox(unitOfWork.PayTypes.GetAll().ToList(),paytype=>paytype.PayTitle, paytype => paytype.Id,"نوع پرداخت");
            AddComboBox(unitOfWork.Workshops.GetAll().ToList(), workshop=>workshop.Title, workshop=>workshop.Id, "کارگاه");
            AddComboBox(unitOfWork.FinancialYears.GetAll().ToList(), year=>year.Year,year=>year.Id,"سال مالی");

            foreach (var textbox in this.Controls.OfType<TextBox>())
            {
                textbox.DataBindings.Add("Text", payEntity, textbox.Name);
            }

            foreach (var comboBox in this.Controls.OfType<ComboBox>())
            {
                comboBox.DataBindings.Add("SelectedValue", payEntity,string.Format("{0}_Id",comboBox.Name));
            }

        }
    }
}
