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
    public partial class FormOpening : Form
    {
        FormHome formhome = new FormHome();        

        public FormOpening()
        {
            InitializeComponent();
        }

        private void maruibutton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            formhome.Visible = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            formhome.Show();
        }
    }
}
