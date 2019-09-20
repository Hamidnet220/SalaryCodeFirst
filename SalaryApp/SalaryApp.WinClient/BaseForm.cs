using System.Windows.Forms;

namespace SalaryApp.WinClient
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        public string Titile { get; set; }
    }
}