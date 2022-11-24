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
    public partial class FormHome : Form
    {
        //各フォームのインスタンス化
        FormClassMana form4 = new FormClassMana();                                                      //商品分類管理フォーム
        MakerMana formMaker = new MakerMana();                                          //メーカ管理フォーム
        FormProductSelect formproductselect = new FormProductSelect();                  //商品選択フォーム
        FormSalesOfficeMana formSOMana = new FormSalesOfficeMana();                     //営業所管理フォーム
        FormPositionMana formPositionMana = new FormPositionMana();                     //役職管理フォーム

        //各パネルをList型のPanelに代入する
        private List<Panel> panelList = new System.Collections.Generic.List<Panel>();

        bool flg = true;

        public FormHome()
        {
            InitializeComponent();

            new ToolTip().SetToolTip(buttonClear, "入力中の情報が初期状態に戻る");
            panelList.Add(panelStock);
            panelList.Add(panelClient);
            panelList.Add(panelProduct);
            panelList.Add(panelEmployee);
            panelList.Add(panelSale);
            panelList.Add(panelOrder);
            panelList.Add(panelHattyu);
            panelList.Add(panelWareHousing);
            panelList.Add(panelSyukko);
            panelList.Add(panelArrival);
            panelList.Add(panelChumon);
            panelList.Add(panelShipment);

            panelHide();
        }

        //全てのパネルを隠すメソッド
        private void panelHide()
        {
            foreach (Panel panel in panelList)
            {
                panel.Hide();
            }
        }

        //時間表示機能//
        //時間、分、秒を表示する
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            labelNowTime.Text = string.Format("{0:00}:{1:00}:{2:00}", d.Hour, d.Minute, d.Second);
        }

        //フォームロードイベント//
        //タイマーへの初期設定
        private void FormHome_Load(object sender, EventArgs e)
        {
            Text = Application.ProductName;
            timer1.Interval = 1000;
            timer1.Enabled = true;

            Text = Application.ProductName;
            timer2.Interval = 1000;
            timer2.Enabled = true;

            timer3.Interval = 1;
        }

        //在庫管理ボタン
        private void buttonStock_Click(object sender, EventArgs e)
        {
            //在庫管理画面を表示する
            panelHide();
            panelStock.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
        }

        //ログインボタン
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            panelStart.Hide();
        }

        //出庫管理ボタン
        private void buttonSyukko_Click(object sender, EventArgs e)
        {
            //出庫管理画面を表示する
            panelHide();
            panelSyukko.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
        }

        //社員管理ボタン
        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            //社員管理画面を表示する
            panelHide();
            panelEmployee.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
        }

        //入荷管理ボタン
        private void buttonArrival_Click(object sender, EventArgs e)
        {
            //入荷管理画面を表示する
            panelHide();
            panelArrival.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
        }

        //顧客管理ボタン
        private void buttonClient_Click(object sender, EventArgs e)
        {
            //顧客管理画面を表示する
            panelHide();
            panelClient.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
        }

        //商品管理ボタン
        private void buttonProduct_Click(object sender, EventArgs e)
        {
            //商品管理画面を表示する
            panelHide();
            panelProduct.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
        }

        //時間表示機能//
        //年、月、日を表示する
        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            labelNowDays.Text = string.Format("{0:00}/{1:00}/{2:00}", d.Year, d.Month, d.Day);
            labelNowDays.Text += d.ToString("(ddd)");
        }

        //受注管理ボタン
        private void buttonOrder_Click(object sender, EventArgs e)
        {
            //受注管理画面を表示する
            panelHide();
            panelOrder.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
        }

        //売上管理ボタン
        private void buttonSale_Click(object sender, EventArgs e)
        {
            //売上管理画面を表示する
            panelHide();
            panelSale.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
        }

        //private void timer3_Tick(object sender, EventArgs e)
        //{
            //if (flg == true && this.panel1.Left > 0 - this.panel1.Size.Width)
            //{
            //    this.panel1.Location = new Point(this.panel1.Left - 10, this.panel1.Top);
            //}
            //else if (flg == false && this.panel1.Right < this.panel1.Size.Width)
            //{
            //    this.panel1.Location = new Point(this.panel1.Left + 10, this.panel1.Top);
            //}
            //else if (flg == true)
            //{
            //    flg = !flg;
            //    timer3.Stop();

            //    panelClient.Size = new Size(1876, 738);
            //    panelClient.Location = new Point(12, 285);

            //    panelPrSearchTitle.Size = new Size(1876, 738);
            //    panelPrSearchTitle.Location = new Point(12, 285);

            //    panelStock.Size = new Size(1876, 738);
            //    panelStock.Location = new Point(12, 285);

            //    panelProduct.Size = new Size(1876, 738);
            //    panelProduct.Location = new Point(12, 285);

            //    panelSale.Size = new Size(1876, 738);
            //    panelSale.Location = new Point(12, 285);

            //    panelOrder.Size = new Size(1876, 738);
            //    panelOrder.Location = new Point(12, 285);

            //    panelHattyu.Size = new Size(1876, 738);
            //    panelHattyu.Location = new Point(12, 285);

            //    panelWareHousing.Size = new Size(1876, 738);
            //    panelWareHousing.Location = new Point(12, 285);

            //    panelSyukko.Size = new Size(1876, 738);
            //    panelSyukko.Location = new Point(12, 285);

            //    panelArrival.Size = new Size(1876, 738);
            //    panelArrival.Location = new Point(12, 285);

            //    panelChumon.Size = new Size(1876, 738);
            //    panelChumon.Location = new Point(12, 285);

            //    panelStart.Size = new Size(1876, 738);
            //    panelStart.Location = new Point(12, 285);

            //    panelShipment.Size = new Size(1876, 738);
            //    panelShipment.Location = new Point(12, 285);

            //    dataGridViewChumonMain.Size = new Size(1843, 306);
            //    dataGridViewChumonMain.Location = new Point(16, 401);

            //    dataGridViewStock.Size = new Size(1843, 306);
            //    dataGridViewStock.Location = new Point(16, 401);

            //    dataGridVieProduct.Size = new Size(1843, 306);
            //    dataGridVieProduct.Location = new Point(16, 401);

            //    dataGridViewShipmentMain.Size = new Size(1843, 306);
            //    dataGridViewShipmentMain.Location = new Point(16, 401);

            //    dataGridViewEmMana.Size = new Size(1843, 306);
            //    dataGridViewEmMana.Location = new Point(16, 401);

            //    dataGridViewHattyuMain.Size = new Size(1843, 306);
            //    dataGridViewHattyuMain.Location = new Point(16, 401);

            //    dataGridViewWareHousingMain.Size = new Size(1843, 306);
            //    dataGridViewWareHousingMain.Location = new Point(16, 401);

            //    dataGridViewSyukkoMain.Size = new Size(1843, 306);
            //    dataGridViewSyukkoMain.Location = new Point(16, 401);

            //    dataGridViewArrivalMain.Size = new Size(1843, 306);
            //    dataGridViewArrivalMain.Location = new Point(16, 401);
            //}
            //else if (flg == false)
            //{
            //    flg = !flg;
            //    timer3.Stop();

            //    panelClient.Size = new Size(1685, 738);
            //    panelClient.Location = new Point(207, 285);


            //    panelPrSearchTitle.Size = new Size(1685, 738);
            //    panelPrSearchTitle.Location = new Point(207, 285);

            //    panelStock.Size = new Size(1685, 738);
            //    panelStock.Location = new Point(207, 285);

            //    panelProduct.Size = new Size(1685, 738);
        //        panelProduct.Location = new Point(207, 285);

        //        panelSale.Size = new Size(1685, 738);
        //        panelSale.Location = new Point(207, 285);

        //        panelOrder.Size = new Size(1685, 738);
        //        panelOrder.Location = new Point(207, 285);

        //        panelHattyu.Size = new Size(1685, 738);
        //        panelHattyu.Location = new Point(207, 285);

        //        panelWareHousing.Size = new Size(1685, 738);
        //        panelWareHousing.Location = new Point(207, 285);

        //        panelSyukko.Size = new Size(1685, 738);
        //        panelSyukko.Location = new Point(207, 285);

        //        panelArrival.Size = new Size(1685, 738);
        //        panelArrival.Location = new Point(207, 285);

        //        panelChumon.Size = new Size(1685, 738);
        //        panelChumon.Location = new Point(207, 285);

        //        panelStart.Size = new Size(1685, 738);
        //        panelStart.Location = new Point(207, 285);

        //        panelShipment.Size = new Size(1685, 738);
        //        panelShipment.Location = new Point(207, 285);

        //        dataGridViewChumonMain.Size = new Size(1614, 306);
        //        dataGridViewChumonMain.Location = new Point(38, 401);

        //        dataGridViewChumonMain.Size = new Size(1614, 306);
        //        dataGridViewChumonMain.Location = new Point(38, 401);

        //        dataGridViewStock.Size = new Size(1614, 306);
        //        dataGridViewStock.Location = new Point(38, 401);

        //        dataGridVieProduct.Size = new Size(1614, 306);
        //        dataGridVieProduct.Location = new Point(38, 401);

        //        dataGridViewShipmentMain.Size = new Size(1614, 306);
        //        dataGridViewShipmentMain.Location = new Point(38, 401);

        //        dataGridViewEmMana.Size = new Size(1614, 306);
        //        dataGridViewEmMana.Location = new Point(38, 401);

        //        dataGridViewHattyuMain.Size = new Size(1614, 306);
        //        dataGridViewHattyuMain.Location = new Point(38, 401);

        //        dataGridViewWareHousingMain.Size = new Size(1614, 306);
        //        dataGridViewWareHousingMain.Location = new Point(38, 401);

        //        dataGridViewSyukkoMain.Size = new Size(1614, 306);
        //        dataGridViewSyukkoMain.Location = new Point(38, 401);

        //        dataGridViewArrivalMain.Size = new Size(1614, 306);
        //        dataGridViewArrivalMain.Location = new Point(38, 401);
        //    }
        //}

        //private void button40_Click(object sender, EventArgs e)
        //{
        //    timer3.Start();
        //}

        //ログアウトボタン
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            //ログアウト、スタート画面を表示する
            panelHide();
            panelStart.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
        }

        //注文管理ボタン
        private void buttonChumon_Click(object sender, EventArgs e)
        {
            //注文管理画面を表示する
            panelHide();
            panelChumon.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
        }

        //発注管理ボタン
        private void buttonHattyu_Click(object sender, EventArgs e)
        {
            //発注管理画面を表示する
            panelHide();
            panelHattyu.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
        }

        //入庫管理ボタン
        private void buttonWareHousing_Click(object sender, EventArgs e)
        {
            //入庫管理画面を表示する
            panelHide();
            panelWareHousing.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
        }
                
        //ツールチップ機能
        private void maruibutton10_Click(object sender, EventArgs e)
        {
            new ToolTip().SetToolTip(buttonClear, "パスワードを表示");
        }

        //パスワードを隠す
        private void buttonHidePassword_MouseUp(object sender, MouseEventArgs e)
        {
            //buttonHidePasswordのクリックが解除された場合パスワードを見えなくする
            textBoxHomePassword.PasswordChar = (char)'*';
        }

        //パスワードを可視化する
        private void buttonHidePassword_MouseDown(object sender, MouseEventArgs e)
        {
            //buttonHidePasswordをクリックしてる間パスワードを見えるようにする
            textBoxHomePassword.PasswordChar = (char)'\0';
        }

        //クリアボタン
        private void buttonClear_Click(object sender, EventArgs e)
        {
            //FormHomeに配置されている全てのテキストボックスとコンボボックスのTextプロパティをリセットする
            ClearText(this);
        }

        //出荷管理ボタン
        private void buttonShipment_Click(object sender, EventArgs e)
        {
            //出荷管理画面を表示する
            panelHide();
            panelShipment.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
        }

        //商品分類管理ボタン
        private void buttonPrProductClassOpen_Click(object sender, EventArgs e)
        {
            //商品管理画面に遷移する
            form4.Visible = true;
        }

        //メーカ管理ボタン
        private void buttonPrMakerOpen_Click(object sender, EventArgs e)
        {
            //メーカ管理画面に遷移する
            formMaker.Visible = true;
        }

        //商品選択ボタン
        private void buttonOrSelectProduct_Click(object sender, EventArgs e)
        {
            //商品選択画面に遷移する
            formproductselect.Visible = true;
        }

        //営業所管理ボタン
        private void buttonEmSOManaOpen_Click(object sender, EventArgs e)
        {            
            //営業所管理画面に遷移する
            formSOMana.Visible = true;
        }

        //役職管理ボタン
        private void buttonEmPositionManaOpen_Click(object sender, EventArgs e)
        {
            //役職管理画面に遷移する
            formPositionMana.Visible = true;
        }

        //受注IDコンボボックスに入力がある場合登録ボタンを使えなくする
        private void comboBoxOrOrderID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxOrOrderID.Text))
            {
                EnabledChangedtruebutton(panelOrder);
            }
            else
            {
                EnabledChangedfalsebutton(panelOrder);
            }
        }

        //全てのテキストボックスとコンボボックスの入力をクリアする
        public static void ClearText(Control hParent)
        {
            // hParent 内のすべてのコントロールを列挙する
            foreach (Control cControl in hParent.Controls)
            {
                // 列挙したコントロールにコントロールが含まれている場合は再帰呼び出しする
                if (cControl.HasChildren == true)
                {
                    ClearText(cControl);
                }

                // コントロールの型が TextBoxBase からの派生型の場合は Text をクリアする
                if (cControl is TextBoxBase || cControl is ComboBox)
                {
                    cControl.Text = string.Empty;
                }
            }
        }

        //登録ボタンを使用不能にするメソッド
        public static void EnabledChangedfalsebutton(Control hParent)
        {
            // hParent 内のすべてのコントロールを列挙する
            foreach (Control cControl in hParent.Controls)
            {
                // 列挙したコントロールにコントロールが含まれている場合は再帰呼び出しする
                if (cControl.HasChildren == true)
                {
                    EnabledChangedfalsebutton(cControl);
                }

                // コントロールの型が TextBoxBase からの派生型の場合は Text をクリアする
                if (cControl is Button)
                {
                    if (cControl.Text == "登録")
                    {
                        cControl.Enabled = false;
                    }
                }
            }
        }

        //登録ボタンを使用可能にするメソッド
        public static void EnabledChangedtruebutton(Control hParent)
        {
            // hParent 内のすべてのコントロールを列挙する
            foreach (Control cControl in hParent.Controls)
            {
                // 列挙したコントロールにコントロールが含まれている場合は再帰呼び出しする
                if (cControl.HasChildren == true)
                {
                    EnabledChangedtruebutton(cControl);
                }

                // コントロールの型が TextBoxBase からの派生型の場合は Text をクリアする
                if (cControl is Button)
                {
                    if (cControl.Text == "登録")
                    {
                        cControl.Enabled = true;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalesManagement_DevContext context = new SalesManagement_DevContext();
            context.SaveChanges();
            context.Dispose();

            MessageBox.Show("データベース生成完了");
        }
    }
}