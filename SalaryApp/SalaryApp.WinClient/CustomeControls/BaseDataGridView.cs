using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.CustomeControls
{
    public class GridControl:DataGridView
    {
        
        public GridControl()
        {
            this.Dock = DockStyle.Fill;
            this.AllowUserToDeleteRows = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.AllowUserToResizeColumns = false;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.RowsDefaultCellStyle.BackColor = Color.LightGray;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;

        }

        
    }
}
