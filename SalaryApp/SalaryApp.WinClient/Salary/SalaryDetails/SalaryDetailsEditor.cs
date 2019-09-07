using SalaryApp.DataLayer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.WinClient.Salary.SalaryDetails
{
    public class SalaryDetailsEditor:EditorBase
    {
        public SalaryDetailsEditor()
        {
            Load += SalaryDetailsEditor_Load;
        }

        private void SalaryDetailsEditor_Load(object sender, EventArgs e)
        {
            AddAllFields<SalaryPayDetails>();
        }
    }
}
