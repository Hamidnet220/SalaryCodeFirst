using SalaryApp.DataLayer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.WinClient.BaseInfoForms.WorkshopViews
{
    public class WorkshopEditor:EditorBase
    {
        public WorkshopEditor()
        {
            Load += WorkshopEditor_Load;
        }

        private void WorkshopEditor_Load(object sender, EventArgs e)
        {
            AddAllFields<Workshop>();
        }
    }
}
