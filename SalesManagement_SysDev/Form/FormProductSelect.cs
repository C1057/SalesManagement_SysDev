using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class FormProductSelect : Form
    {
        public FormProductSelect()
        {
            InitializeComponent();
        }

        private void FormProductSelect_Load(object sender, EventArgs e)
        {
            int n = 10000;

            labelProSelectTotalMoney.Text = n.ToString("C");
        }
    }
}
