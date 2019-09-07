using SalaryApp.DataLayer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        private void PayEditor_Load(object sender, EventArgs e)
        {
            AddAllFields<Pay>();

            foreach (var textbox in this.Controls.OfType<TextBox>())
            {
                textbox.DataBindings.Add("Text", payEntity, textbox.Name);
            }
        }
    }
}
