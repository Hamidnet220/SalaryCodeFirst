using SalaryApp.DataLayer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.EmployeeViews
{
    public class EmployeeEditor:EditorBase
    {
        Employee employeeEnity = new Employee();


        public EmployeeEditor():base()
        {
            Load += EmployeeEditor_Load;
            Accept.Click += Accept_Click;

        }

        private void Accept_Click(object sender, EventArgs e)
        {
            unitOfWork.Employees.Add(employeeEnity);
        }

        private void EmployeeEditor_Load(object sender, EventArgs e)
        {
            AddAllFields<Employee>();
            foreach (var textbox in this.Controls.OfType<TextBox>())
            {
                textbox.DataBindings.Add("Text", employeeEnity, textbox.Name);
            }
        }
    }
}
