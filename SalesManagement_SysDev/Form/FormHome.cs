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

        PositionDataAccess PositionAccess = new PositionDataAccess();                   //役職マスタ操作用クラスのインスタンス化
        

        List<M_Position> PositionList;                                                  //表示用役職情報を保持する変数
        List<M_Maker> MakerList;                                                        //表示用メーカー情報を保持する変数
        List<M_SalesOffice> SalesOfficeList;                                            //表示用営業所情報を保持する変数
        List<M_Client> ClientList;                                                      //表示用顧客情報を保持する変数
        List<M_Product> ProductList;                                                    //表示用商品情報を保持する変数
        List<M_MajorClassification> MajorClassList;                                     //表示用大分類情報を保持する変数
        List<M_SmallClassification> SmallClassList;                                     //表示用小分類情報を保持する変数
        List<T_Stock> StockList;                                                        //表示用在庫情報を保持する変数
        List<T_Sale> SaleList;                                                          //表示用売上情報を保持する変数
        List<T_SaleDetail> SaleDetailList;                                              //表示用売上詳細情報を保持する変数
        List<T_Order> OrderList;                                                        //表示用受注情報を保持する変数
        List<T_OrderDetail> OrderDetailList;                                            //表示用受注詳細情報を保持する変数
        List<T_Chumon> ChumonList;                                                      //表示用注文情報を保持する変数
        List<T_ChumonDetail> ChumonDetailList;                                          //表示用注文詳細情報を保持する変数
        List<T_Hattyu> HattyuList;                                                      //表示用発注情報を保持する変数
        List<T_HattyuDetail> HattyuDetailList;                                          //表示用発注詳細情報を保持する変数
        List<T_Warehousing> WarehousingList;                                            //表示用入庫情報を保持する変数
        List<T_WarehousingDetail> WarehousingDetailList;                                //表示用入庫詳細情報を保持する変数
        List<T_Syukko> SyukkoList;                                                      //表示用出庫情報を保持する変数
        List<T_SyukkoDetail> SyukkoDetailList;                                          //表示用出庫詳細情報を保持する変数
        List<T_Arrival> ArrivalList;                                                    //表示用入荷情報を保持する変数
        List<T_ArrivalDetail> ArrivalDetailList;                                        //表示用入荷詳細情報を保持する変数
        List<T_Shipment> ShipmentList;                                                  //表示用出荷情報を保持する変数
        List<T_ShipmentDetail> ShipmentDetailList;                                      //表示用出荷詳細情報を保持する変数


        //各パネルをList型のPanelに代入する
        private List<Panel> panelList = new System.Collections.Generic.List<Panel>();

        //bool flg = true;

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
            this.Visible = false;                                       //システム起動時　FormHomeをロードしながら自分自身を見えなくする

            Text = Application.ProductName;
            timer1.Interval = 1000;
            timer1.Enabled = true;

            Text = Application.ProductName;
            timer2.Interval = 1000;
            timer2.Enabled = true;

            timer3.Interval = 1;

            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化

            /// <summry>
            /// 顧客管理画面データグリッドビュー設定
            /// </summry>
            var columnText = new string[]                       //各列のヘッダーテキストを設定
            {
                "顧客ID","営業所ID ","顧客名","住所","電話番号","郵便番号","FAX","非表示フラグ","非表示理由"
            };

            var ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true,true,true,false,true
            };

            var ColumnSize = new int[]                          //各列のWidthを設定
            {
                    100,100,150,250,150,100,100,100,485
            };

            var columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewCheckBoxCell(),
                new DataGridViewTextBoxCell(),
            };

            for (int i = 0; i < columnText.Length; i++)                 //各列の設定を適用し追加する
            {
                var viewColumn = new DataGridViewColumn();
                viewColumn.HeaderText = columnText[i];                   //ヘッダーに表示される名称
                viewColumn.ReadOnly = ReadOnlySet[i];                   //読み取り可否
                viewColumn.Width = ColumnSize[i];                       //Width設定
                viewColumn.CellTemplate = columnCellType[i];  //セルのタイプ

                dataGridViewCI.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewCI.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            ClientList = context.M_Clients.ToList();                    //List<M_Client>型のClientListに一覧表示用データを代入する
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
            //データグリッドビューにデータを表示する
            ListClient();
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

        /// <summary>
        /// 顧客情報一覧表示モジュール
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void ListClient()
        {
            dataGridViewCI.Rows.Clear();                        //データグリッドビューをクリアする
            //var context = new SalesManagement_DevContext();     //SalesManagement_DevContextクラスのインスタンス化
            foreach (var p in ClientList)                           //顧客マスタのデータを1行ずつ取得する
            {
                if (p.ClFlag == 0)                              //顧客管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewCI.Rows.Add(p.ClID, p.SoID, p.ClName, p.ClAddress, p.ClPhone, p.ClPostal, p.ClFAX, Convert.ToBoolean(p.ClFlag), p.ClHidden);
                }
            }
            //context.Dispose();                                  //contextを解放する
        }

        //販売在庫管理システムを終了する
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}