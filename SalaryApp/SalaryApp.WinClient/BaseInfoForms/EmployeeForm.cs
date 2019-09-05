using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms
{
    public partial class EmployeeForm : BaseForm
    {
        public EmployeeForm(string title)
        {
            this.Text = title;
           InitializeComponent();
            Load += EmployeeForm_Load;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
