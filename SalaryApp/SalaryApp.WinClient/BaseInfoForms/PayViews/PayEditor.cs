using SalaryApp.DataLayer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.WinClient.BaseInfoForms.PayViews
{
    public class PayEditor:EditorBase
    {
        public PayEditor()
        {
            Load += PayEditor_Load;
        }

        private void PayEditor_Load(object sender, EventArgs e)
        {
            AddAllFields<Pay>();
        }
    }
}
