using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.BaseInfoForms.workshop
{
    public partial class WorkshopEditor : Form
    {
        public WorkshopEditor()
        {
            InitializeComponent();
            Load += WorkshopEditor_Load;
        }

        private void WorkshopEditor_Load(object sender, EventArgs e)
        {
            this.Text = "ویرایش کارگاه";
        }
    }
}
