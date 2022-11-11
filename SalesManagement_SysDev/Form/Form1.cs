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
    public partial class Form1 : Form
    {
        private List<Panel> panelList = new System.Collections.Generic.List<Panel>();

        



        bool flg = true;

        public Form1()
        {
            InitializeComponent();

            new ToolTip().SetToolTip(button2, "入力中の情報が初期状態に戻る");
            panelList.Add(panel5);
            panelList.Add(panel3);
            panelList.Add(panel4);
            panelList.Add(panel6);
            panelList.Add(panel7);
            panelList.Add(panel8);
            panelList.Add(panel9);
            panelList.Add(panel10);
            panelList.Add(panel11);
            panelList.Add(panel12);
            panelList.Add(panel13);
            panelList.Add(panel15);

            panelHide();
        }

        private void panelHide()
        {
            foreach (Panel panel in panelList)
            {
                panel.Hide();
                
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            label3.Text = string.Format("{0:00}:{1:00}:{2:00}", d.Hour, d.Minute, d.Second);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = Application.ProductName;
            timer1.Interval = 1000;
            timer1.Enabled = true;

            Text = Application.ProductName;
            timer2.Interval = 1000;
            timer2.Enabled = true;

            timer3.Interval = 1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelHide();

            panel5.Show();

            label61.Text = ((Button)sender).Text;
        }

        private void maruibutton1_Click(object sender, EventArgs e)
        {
            panel14.Hide();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            panelHide();

            panel11.Show();



            label61.Text = ((Button)sender).Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panelHide();

            panel6.Show();

            label61.Text = ((Button)sender).Text;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            panelHide();

            panel12.Show();



            label61.Text = ((Button)sender).Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelHide();

            panel3.Show();

            label61.Text = ((Button)sender).Text;

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            panelHide();

            panel4.Show();

            label61.Text = ((Button)sender).Text;
        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void maruibutton3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label53_Click(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            label53.Text = string.Format("{0:00}/{1:00}/{2:00}", d.Year, d.Month, d.Day);
            label53.Text += d.ToString("(ddd)");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panelHide();

            panel8.Show();

            label61.Text = ((Button)sender).Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panelHide();

            panel7.Show();

            label61.Text = ((Button)sender).Text;
        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button39_Click(object sender, EventArgs e)
        {
            
        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (flg == true && this.panel1.Left > 0 - this.panel1.Size.Width)
            {
                this.panel1.Location = new Point(this.panel1.Left - 10, this.panel1.Top);
            }
            else if (flg == false && this.panel1.Right < this.panel1.Size.Width)
            {
                this.panel1.Location = new Point(this.panel1.Left + 10, this.panel1.Top);
            }
            else if (flg == true)
            {
                flg = !flg;
                timer3.Stop();

                panel3.Size = new Size(1876, 738);
                panel3.Location = new Point(12, 285);

                panel4.Size = new Size(1876, 738);
                panel4.Location = new Point(12, 285);

                panel5.Size = new Size(1876, 738);
                panel5.Location = new Point(12, 285);

                panel6.Size = new Size(1876, 738);
                panel6.Location = new Point(12, 285);

                panel7.Size = new Size(1876, 738);
                panel7.Location = new Point(12, 285);

                panel8.Size = new Size(1876, 738);
                panel8.Location = new Point(12, 285);

                panel9.Size = new Size(1876, 738);
                panel9.Location = new Point(12, 285);

                panel10.Size = new Size(1876, 738);
                panel10.Location = new Point(12, 285);

                panel11.Size = new Size(1876, 738);
                panel11.Location = new Point(12, 285);

                panel12.Size = new Size(1876, 738);
                panel12.Location = new Point(12, 285);

                panel13.Size = new Size(1876, 738);
                panel13.Location = new Point(12, 285);

                panel14.Size = new Size(1876, 738);
                panel14.Location = new Point(12, 285);

                panel15.Size = new Size(1876, 738);
                panel15.Location = new Point(12, 285);

                dataGridView13.Size = new Size(1843, 306); 
                dataGridView13.Location = new Point(16, 401);

                dataGridView1.Size = new Size(1843, 306);
                dataGridView1.Location = new Point(16, 401);

                dataGridView2.Size = new Size(1843, 306);
                dataGridView2.Location = new Point(16, 401);

                dataGridView3.Size = new Size(1843, 306);
                dataGridView3.Location = new Point(16, 401);

                dataGridView4.Size = new Size(1843, 306);
                dataGridView4.Location = new Point(16, 401);

                dataGridView9.Size = new Size(1843, 306);
                dataGridView9.Location = new Point(16, 401);

                dataGridView10.Size = new Size(1843, 306);
                dataGridView10.Location = new Point(16, 401);

                dataGridView11.Size = new Size(1843, 306);
                dataGridView11.Location = new Point(16, 401);

                dataGridView12.Size = new Size(1843, 306);
                dataGridView12.Location = new Point(16, 401);
            }
            else if (flg == false)
            {
                flg = !flg;
                timer3.Stop();

                panel3.Size = new Size(1685, 738);
                panel3.Location = new Point(207, 285);


                panel4.Size = new Size(1685, 738);
                panel4.Location = new Point(207, 285);

                panel5.Size = new Size(1685, 738);
                panel5.Location = new Point(207, 285);

                panel6.Size = new Size(1685, 738);
                panel6.Location = new Point(207, 285);

                panel7.Size = new Size(1685, 738);
                panel7.Location = new Point(207, 285);

                panel8.Size = new Size(1685, 738);
                panel8.Location = new Point(207, 285);

                panel9.Size = new Size(1685, 738);
                panel9.Location = new Point(207, 285);

                panel10.Size = new Size(1685, 738);
                panel10.Location = new Point(207, 285);

                panel11.Size = new Size(1685, 738);
                panel11.Location = new Point(207, 285);

                panel12.Size = new Size(1685, 738);
                panel12.Location = new Point(207, 285);

                panel13.Size = new Size(1685, 738);
                panel13.Location = new Point(207, 285);

                panel14.Size = new Size(1685, 738);
                panel14.Location = new Point(207, 285);

                panel15.Size = new Size(1685, 738);
                panel15.Location = new Point(207, 285);

                dataGridView13.Size = new Size(1614, 306);
                dataGridView13.Location = new Point(38, 401);

                dataGridView13.Size = new Size(1614, 306);
                dataGridView13.Location = new Point(38, 401);

                dataGridView1.Size = new Size(1614, 306);
                dataGridView1.Location = new Point(38, 401);

                dataGridView2.Size = new Size(1614, 306);
                dataGridView2.Location = new Point(38, 401);

                dataGridView3.Size = new Size(1614, 306);
                dataGridView3.Location = new Point(38, 401);

                dataGridView4.Size = new Size(1614, 306);
                dataGridView4.Location = new Point(38, 401);

                dataGridView9.Size = new Size(1614, 306);
                dataGridView9.Location = new Point(38, 401);

                dataGridView10.Size = new Size(1614, 306);
                dataGridView10.Location = new Point(38, 401);

                dataGridView11.Size = new Size(1614, 306);
                dataGridView11.Location = new Point(38, 401);

                dataGridView12.Size = new Size(1614, 306);
                dataGridView12.Location = new Point(38, 401);
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            panelHide();

            panel14.Show();

            label61.Text = ((Button)sender).Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panelHide();

            panel13.Show();



            label61.Text = ((Button)sender).Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panelHide();

            panel9.Show();



            label61.Text = ((Button)sender).Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panelHide();

            panel10.Show();



            label61.Text = ((Button)sender).Text;
        }

        private void maruibutton10_Click(object sender, EventArgs e)
        {
            new ToolTip().SetToolTip(button2, "パスワードを表示");
        }

        private void maruibutton10_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.PasswordChar = (char)'*';
        }

        private void maruibutton10_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.PasswordChar = (char)'\0';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            textBox2.ResetText();


        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            panelHide();

            panel15.Show();



            label61.Text = ((Button)sender).Text;
        }

        private void button39_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button39_Click_2(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();

            form4.Show();　　　　　　
        }

        private void label61_Click(object sender, EventArgs e)
        {

        }
    }
    }

