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
    public partial class Form4 : Form
    {

        private List<Panel> panelList = new System.Collections.Generic.List<Panel>();

        //bool flg = true;

        public Form4()
        {
            InitializeComponent();

            panelList.Add(panel1);
            panelList.Add(panel2);

        }

        private void panelHide()
        {
            foreach (Panel panel in panelList)
            {
                panel.Hide();

            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label70_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //flg = !flg;

            //timer1.Stop();

            //if (flg == true && this.maruibutton3.Left > 0 - this.maruibutton3.Size.Width)
            //{
            //    this.maruibutton3.Location = new Point(this.maruibutton3.Left + 10, this.maruibutton3.Top);
            //}
            //else if (flg == false && this.maruibutton3.Right < this.maruibutton3.Size.Width)
            //{
            //    this.maruibutton3.Location = new Point(this.maruibutton3.Left - 10, this.maruibutton3.Top);
            //}
            //else if (flg == true)
            //{
            //    flg = !flg;

            //    maruibutton3.Size = new Size(248, 216);
            //    maruibutton3.Location = new Point(12, 12);

            //}

            //else if (flg == false)
            //{
            //    flg = !flg;
            //    timer1.Stop();

            //    maruibutton3.Size = new Size(248, 216);
            //    maruibutton3.Location = new Point(285, 12);

            
        }

        private void maruibutton1_Click(object sender, EventArgs e)
        {
            //timer1.Start();

            panel2.Hide();

            panel1.Show();

            label61.Text = ((Button)sender).Text + "管理";

        }

        private void maruibutton3_Click(object sender, EventArgs e)
        {

            panel1.Hide();

            panel2.Show();

            label61.Text = ((Button)sender).Text + "管理";

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
