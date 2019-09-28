using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;

namespace SalaryApp.WinClient.Salary.Bonus
{
    public partial class BonusEditorView : EditorBase<BonusPayDetails>
    {
        public BonusEditorView()
        {
            InitializeComponent();
        }
    }
}
