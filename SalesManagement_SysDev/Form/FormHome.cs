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
        public int OrderID;                                                             //受注情報.受注ID登録用変数
        public int OrderDetailID;                                                       //受注詳細情報.受注詳細ID登録用変数
        public T_Order AddOrderData;                                                    //受注情報登録用変数
        private int ChumonID;                                                       //注文ID用変数
        private int SyukkoID;                                                           //出庫ID用変数
        private int ArrivalID;                                                          //入荷ID用変数
        private int ShipmentID;                                                         //出荷ID用変数
        private int SaleID;                                                             //売上ID用変数
        private int WarehousingID;                                                      //入庫ID用変数


        /// <summary>
        /// 別フォームのクラスをインスタンス化
        /// </summary>
        FormClassMana form4 = new FormClassMana();                                                      //商品分類管理フォーム
        MakerMana formMaker = new MakerMana();                                          //メーカ管理フォーム
        public FormProductSelect formproductselect;                 //商品選択フォーム
        FormSalesOfficeMana formSOMana = new FormSalesOfficeMana();                     //営業所管理フォーム
        FormPositionMana formPositionMana = new FormPositionMana();                     //役職管理フォーム

        ///<summary>
        ///共通モジュールのインスタンス化
        /// </summary>
        MessageDsp msg = new MessageDsp();                                              //メッセージ表示用クラス
        CheckExistence Existence = new CheckExistence();                                //IDの存在チェック用クラス
        DataInputCheck InputCheck = new DataInputCheck();                               //入力チェック用クラス
        PasswordHash PassHash = new PasswordHash();                                     //パスワードハッシュ化用クラス

        /// <summary>
        /// 各テーブルの操作をするためのクラスをインスタンス化する
        /// </summary>
        PositionDataAccess PositionAccess = new PositionDataAccess();                   //[役職マスタ]操作用クラスのインスタンス化
        MakerDataAccess MakerAccess = new MakerDataAccess();                            //[メーカーマスタ]操作用クラスのインスタンス化
        SalesOfficeDataAccess SalesOfficeAccess = new SalesOfficeDataAccess();          //[営業所マスタ]操作用クラスのインスタンス化
        ClientDataAccess ClientAccess = new ClientDataAccess();                         //[顧客マスタ]操作用クラスのインスタンス化
        ProductDataAccess ProductAccess = new ProductDataAccess();                      //[商品マスタ]操作用クラスのインスタンス化
        MajorClassDataAccess MajorClassAccess = new MajorClassDataAccess();             //[大分類マスタ]操作用クラスのインスタンス化
        SmallClassDataAccess SmallClassAccess = new SmallClassDataAccess();             //[小分類マスタ]操作用クラスのインスタンス化
        StockDateAccess StockAccess = new StockDateAccess();                            //[在庫テーブル]操作用クラスのインスタンス化
        EmployeeDateAccess EmployeeAccess = new EmployeeDateAccess();                   //[社員マスタ]操作用クラスのインスタンス化
        SaleDateAccess SaleAccess = new SaleDateAccess();                               //[売上テーブル]操作用クラスのインスタンス化
        OrderDateAccess OrderAccess = new OrderDateAccess();                            //[受注テーブル]操作用クラスのインスタンス化
        ChumonDateAccess ChumonAccess = new ChumonDateAccess();                         //[注文テーブル]操作用クラスのインスタンス化
        HattyuDataAccess HattyuAccess = new HattyuDataAccess();                         //[発注テーブル]操作用クラスのインスタンス化
        WarehosingDateAccess WareHousingAccess = new WarehosingDateAccess();            //[入庫テーブル]操作用クラスのインスタンス化
        SyukkoDateAccess SyukkoAccess = new SyukkoDateAccess();                         //[出庫テーブル]操作用クラスのインスタンス化
        ArrivalDateAccess ArrivalAccess = new ArrivalDateAccess();                      //[入荷テーブル]操作用クラスのインスタンス化
        ShipmentDateAccess ShipmentAccess = new ShipmentDateAccess();                   //[出荷テーブル]操作用クラスのインスタンス化


        /// <summary>
        /// 各テーブルの表示用データを保持するListの宣言
        /// </summary>
        List<M_Position> PositionList;                                                  //表示用[役職]情報を保持する変数
        List<M_Maker> MakerList;                                                        //表示用[メーカー]情報を保持する変数
        List<M_SalesOffice> SalesOfficeList;                                            //表示用[営業所]情報を保持する変数
        List<M_Client> ClientList;                                                      //表示用[顧客]情報を保持する変数
        public List<M_Product> ProductList;                                                    //表示用[商品]情報を保持する変数
        List<M_MajorClassification> MajorClassList;                                     //表示用[大分類]情報を保持する変数
        List<M_SmallClassification> SmallClassList;                                     //表示用[小分類]情報を保持する変数
        public List<T_Stock> StockList;                                                        //表示用[在庫]情報を保持する変数
        List<M_Employee> EmployeeList;                                                  //表示用[社員]情報を保持する変数
        List<T_Sale> SaleList;                                                          //表示用[売上]情報を保持する変数
        List<T_SaleDetail> SaleDetailList;                                              //表示用[売上詳細]情報を保持する変数
        public List<T_Order> OrderList;                                                        //表示用[受注]情報を保持する変数
        public List<T_OrderDetail> OrderDetailList;                                            //表示用[受注詳細]情報を保持する変数
        List<T_Chumon> ChumonList;                                                      //表示用[注文]情報を保持する変数
        List<T_ChumonDetail> ChumonDetailList;                                          //表示用[注文詳細]情報を保持する変数
        public List<T_Hattyu> HattyuList;                                                      //表示用[発注]情報を保持する変数
        public List<T_HattyuDetail> HattyuDetailList;                                          //表示用[発注詳細]情報を保持する変数
        List<T_Warehousing> WarehousingList;                                            //表示用[入庫]情報を保持する変数
        List<T_WarehousingDetail> WarehousingDetailList;                                //表示用[入庫詳細]情報を保持する変数
        List<T_Syukko> SyukkoList;                                                      //表示用[出庫]情報を保持する変数
        List<T_SyukkoDetail> SyukkoDetailList;                                          //表示用[出庫詳細]情報を保持する変数
        List<T_Arrival> ArrivalList;                                                    //表示用[入荷]情報を保持する変数
        List<T_ArrivalDetail> ArrivalDetailList;                                        //表示用[入荷詳細]情報を保持する変数
        List<T_Shipment> ShipmentList;                                                  //表示用[出荷]情報を保持する変数
        List<T_ShipmentDetail> ShipmentDetailList;                                      //表示用[出荷詳細]情報を保持する変数


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

            formproductselect = new FormProductSelect(this);

            Text = Application.ProductName;
            timer1.Interval = 1000;
            timer1.Enabled = true;

            Text = Application.ProductName;
            timer2.Interval = 1000;
            timer2.Enabled = true;

            timer3.Interval = 1;

            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化

            /// <summry>
            /// 顧客管理画面データグリッドビュー設定          //顧客テーブルデータグリッドビュー
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

            /// <summry>
            /// 商品管理画面データグリッドビュー設定      //商品テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "商品ID", "メーカID", "商品名", "価格", "安全在庫数", "小分類ID", "型番", "色", "発売日", "商品管理フラグ", "非表示理由"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true,true,true,true,true,false,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    100,100,200,150,100,100,100,100,200,100,285
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewCheckBoxCell(),
                new DataGridViewTextBoxCell()
            };

            for (int i = 0; i < columnText.Length; i++)                 //各列の設定を適用し追加する
            {
                var viewColumn = new DataGridViewColumn();
                viewColumn.HeaderText = columnText[i];                   //ヘッダーに表示される名称
                viewColumn.ReadOnly = ReadOnlySet[i];                   //読み取り可否
                viewColumn.Width = ColumnSize[i];                       //Width設定
                viewColumn.CellTemplate = columnCellType[i];  //セルのタイプ

                dataGridVieProduct.Columns.Add(viewColumn);          //列の追加
            }

            dataGridVieProduct.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            /// <summry>
            /// 在庫管理画面データグリッドビュー設定      //在庫テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "在庫ID", "商品ID", "商品名", "在庫数", "在庫管理フラグ", "非表示理由"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,false,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    200,200,400,200,200,335
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewCheckBoxCell(),
                new DataGridViewTextBoxCell()
            };

            for (int i = 0; i < columnText.Length; i++)                 //各列の設定を適用し追加する
            {
                var viewColumn = new DataGridViewColumn();
                viewColumn.HeaderText = columnText[i];                   //ヘッダーに表示される名称
                viewColumn.ReadOnly = ReadOnlySet[i];                   //読み取り可否
                viewColumn.Width = ColumnSize[i];                       //Width設定
                viewColumn.CellTemplate = columnCellType[i];  //セルのタイプ

                dataGridViewStock.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewStock.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            /// <summry>
            /// 社員管理画面データグリッドビュー設定      //社員テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "社員ID", "社員名", "営業所ID", "役職ID", "入社年月日", "電話番号", "社員管理フラグ", "非表示理由"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true,true,false,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    150,200,150,150,250,200,100,335
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewCheckBoxCell(),
                new DataGridViewTextBoxCell()
            };

            for (int i = 0; i < columnText.Length; i++)                 //各列の設定を適用し追加する
            {
                var viewColumn = new DataGridViewColumn();
                viewColumn.HeaderText = columnText[i];                   //ヘッダーに表示される名称
                viewColumn.ReadOnly = ReadOnlySet[i];                   //読み取り可否
                viewColumn.Width = ColumnSize[i];                       //Width設定
                viewColumn.CellTemplate = columnCellType[i];  //セルのタイプ

                dataGridViewEmMana.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewEmMana.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            /// <summry>
            /// 売上管理画面データグリッドビュー設定      //売上テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
               "売上ID", "顧客ID", "営業所ID", "受注社員ID", "受注ID", "売上日時", "売上管理フラグ", "非表示理由"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true,true,false,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    100,100,100,100,100,150,100,235
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewCheckBoxCell(),
                new DataGridViewTextBoxCell()
            };

            for (int i = 0; i < columnText.Length; i++)                 //各列の設定を適用し追加する
            {
                var viewColumn = new DataGridViewColumn();
                viewColumn.HeaderText = columnText[i];                   //ヘッダーに表示される名称
                viewColumn.ReadOnly = ReadOnlySet[i];                   //読み取り可否
                viewColumn.Width = ColumnSize[i];                       //Width設定
                viewColumn.CellTemplate = columnCellType[i];  //セルのタイプ

                dataGridViewSaleMain.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewSaleMain.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            /// <summry>
            /// 売上管理画面データグリッドビュー設定      //売上詳細テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
               "売上詳細ID", "売上ID", "商品ID", "個数", "合計金額"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    100,100,100,100,105
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
            };

            for (int i = 0; i < columnText.Length; i++)                 //各列の設定を適用し追加する
            {
                var viewColumn = new DataGridViewColumn();
                viewColumn.HeaderText = columnText[i];                   //ヘッダーに表示される名称
                viewColumn.ReadOnly = ReadOnlySet[i];                   //読み取り可否
                viewColumn.Width = ColumnSize[i];                       //Width設定
                viewColumn.CellTemplate = columnCellType[i];  //セルのタイプ

                dataGridViewSaDetail.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewSaDetail.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする           


            /// <summry>
            /// 受注管理画面データグリッドビュー設定      //受注テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "受注ID", "営業所ID", "社員ID", "顧客ID", "顧客担当者名", "受注年月日", "確定可否", "受注管理フラグ", "非表示理由"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true,true,false,false,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    80,80,80,80,150,150,60,60,245
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewCheckBoxCell(),
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

                dataGridViewOrderMain.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewOrderMain.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            /// <summry>
            /// 受注管理画面データグリッドビュー設定      //受注詳細テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "受注詳細ID", "受注ID", "商品ID", "数量", "合計金額"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    80,80,80,80,185
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
            };

            for (int i = 0; i < columnText.Length; i++)                 //各列の設定を適用し追加する
            {
                var viewColumn = new DataGridViewColumn();
                viewColumn.HeaderText = columnText[i];                   //ヘッダーに表示される名称
                viewColumn.ReadOnly = ReadOnlySet[i];                   //読み取り可否
                viewColumn.Width = ColumnSize[i];                       //Width設定
                viewColumn.CellTemplate = columnCellType[i];  //セルのタイプ

                dataGridViewOrderDetail.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewOrderDetail.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            /// <summry>
            /// 注文管理画面データグリッドビュー設定      //注文テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "注文ID", "営業所ID", "社員ID", "顧客ID", "受注ID", "注文年月日", "注文可否", "注文管理フラグ", "非表示理由"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true,true,false,false,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    80,80,80,80,80,150,95,95,245
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewCheckBoxCell(),
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

                dataGridViewChumonMain.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewChumonMain.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            /// <summry>
            /// 注文管理画面データグリッドビュー設定      //注文詳細テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "注文詳細ID", "注文ID", "商品ID", "商品名", "数量"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    85,85,85,150,100
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell()
            };

            for (int i = 0; i < columnText.Length; i++)                 //各列の設定を適用し追加する
            {
                var viewColumn = new DataGridViewColumn();
                viewColumn.HeaderText = columnText[i];                   //ヘッダーに表示される名称
                viewColumn.ReadOnly = ReadOnlySet[i];                   //読み取り可否
                viewColumn.Width = ColumnSize[i];                       //Width設定
                viewColumn.CellTemplate = columnCellType[i];  //セルのタイプ

                dataGridViewChumonDetail.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewChumonDetail.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            /// <summry>
            /// 発注管理画面データグリッドビュー設定      //発注テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "発注ID", "メーカID", "発注社員ID", "発注年月日", "入庫済可否(倉庫)", "発注管理フラグ", "非表示理由"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,false,false,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    100,100,100,150,150,100,285
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewCheckBoxCell(),
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

                dataGridViewHattyuMain.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewHattyuMain.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            /// <summry>
            /// 発注管理画面データグリッドビュー設定      //発注詳細テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "発注詳細ID", "発注ID", "商品ID", "商品名", "数量"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                   85,85,85,150,100
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell()
            };

            for (int i = 0; i < columnText.Length; i++)                 //各列の設定を適用し追加する
            {
                var viewColumn = new DataGridViewColumn();
                viewColumn.HeaderText = columnText[i];                   //ヘッダーに表示される名称
                viewColumn.ReadOnly = ReadOnlySet[i];                   //読み取り可否
                viewColumn.Width = ColumnSize[i];                       //Width設定
                viewColumn.CellTemplate = columnCellType[i];  //セルのタイプ

                dataGridViewHattyuDetail.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewHattyuDetail.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            ///<summary>
            ///入庫管理画面データグリッドビュー設定       //入庫テーブルデータグリッドビュー
            /// </summary>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "入庫ID", "発注ID", "入庫確認社員ID", "入庫年月日", "入庫済フラグ(棚)", "入庫管理フラグ", "非表示理由"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,false,false,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    100,100,100,150,150,100,285
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewCheckBoxCell(),
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

                dataGridViewWareHousingMain.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewWareHousingMain.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            /// <summry>
            /// 入庫管理画面データグリッドビュー設定      //入庫詳細テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "入庫詳細ID", "入庫ID", "商品ID", "商品名", "数量"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                   85,85,85,150,100
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell()
            };

            for (int i = 0; i < columnText.Length; i++)                 //各列の設定を適用し追加する
            {
                var viewColumn = new DataGridViewColumn();
                viewColumn.HeaderText = columnText[i];                   //ヘッダーに表示される名称
                viewColumn.ReadOnly = ReadOnlySet[i];                   //読み取り可否
                viewColumn.Width = ColumnSize[i];                       //Width設定
                viewColumn.CellTemplate = columnCellType[i];  //セルのタイプ

                dataGridViewWareHousingDetail.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewWareHousingDetail.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            ///<summary>
            ///出庫管理画面データグリッドビュー設定       //出庫テーブルデータグリッドビュー
            /// </summary>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "出庫ID", "社員ID", "顧客ID", "営業所ID", "受注ID", "出庫年月日", "出庫状態フラグ", "出庫管理フラグ", "非表示理由"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true,true,false,false,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    80,80,80,80,80,150,95,95,245
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewCheckBoxCell(),
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

                dataGridViewSyukkoMain.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewSyukkoMain.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            /// <summry>
            /// 出庫管理画面データグリッドビュー設定      //出庫詳細テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "出庫詳細ID", "出庫ID", "商品ID", "商品名", "数量"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                   85,85,85,150,100
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell()
            };

            for (int i = 0; i < columnText.Length; i++)                 //各列の設定を適用し追加する
            {
                var viewColumn = new DataGridViewColumn();
                viewColumn.HeaderText = columnText[i];                   //ヘッダーに表示される名称
                viewColumn.ReadOnly = ReadOnlySet[i];                   //読み取り可否
                viewColumn.Width = ColumnSize[i];                       //Width設定
                viewColumn.CellTemplate = columnCellType[i];  //セルのタイプ

                dataGridViewSyukkoDetail.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewSyukkoDetail.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            ///<summary>
            ///入荷管理画面データグリッドビュー設定       //入荷テーブルデータグリッドビュー
            /// </summary>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "入荷ID", "営業所ID", "社員ID", "顧客ID", "受注ID", "入荷年月日", "入荷状態フラグ", "入荷管理フラグ", "非表示理由"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true,true,false,false,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    80,80,80,80,80,150,95,95,245
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewCheckBoxCell(),
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

                dataGridViewArrivalMain.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewArrivalMain.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            /// <summry>
            /// 入荷管理画面データグリッドビュー設定      //入荷詳細テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "入荷詳細ID", "入荷ID", "商品ID", "商品名", "数量"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                   85,85,85,150,100
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell()
            };

            for (int i = 0; i < columnText.Length; i++)                 //各列の設定を適用し追加する
            {
                var viewColumn = new DataGridViewColumn();
                viewColumn.HeaderText = columnText[i];                   //ヘッダーに表示される名称
                viewColumn.ReadOnly = ReadOnlySet[i];                   //読み取り可否
                viewColumn.Width = ColumnSize[i];                       //Width設定
                viewColumn.CellTemplate = columnCellType[i];  //セルのタイプ

                dataGridViewArrivalDetail.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewArrivalDetail.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            ///<summary>
            ///出荷管理画面データグリッドビュー設定       //出荷テーブルデータグリッドビュー
            /// </summary>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "出荷ID", "顧客ID", "社員ID", "営業所ID", "受注ID", "出荷状態フラグ", "出荷完了年月日", "出荷管理フラグ", "非表示理由"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true,false,true,false,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    80,80,80,80,80,95,150,95,245
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewCheckBoxCell(),
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

                dataGridViewShipmentMain.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewShipmentMain.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            /// <summry>
            /// 出荷管理画面データグリッドビュー設定      //出荷詳細テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                      //各列のヘッダーテキストを設定
            {
                "出荷詳細ID", "出荷ID", "商品ID", "商品名", "数量"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                   85,85,85,150,100
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell()
            };

            for (int i = 0; i < columnText.Length; i++)                 //各列の設定を適用し追加する
            {
                var viewColumn = new DataGridViewColumn();
                viewColumn.HeaderText = columnText[i];                   //ヘッダーに表示される名称
                viewColumn.ReadOnly = ReadOnlySet[i];                   //読み取り可否
                viewColumn.Width = ColumnSize[i];                       //Width設定
                viewColumn.CellTemplate = columnCellType[i];  //セルのタイプ

                dataGridViewShipmentDetail.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewShipmentDetail.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする



            ///<summary>
            ///各テーブルの表示用データを取得する
            ///</summary>
            PositionList = context.M_Positions.ToList();                    //List<M_Position>型のPositionListに[役職]表示用データを代入する
            MakerList = context.M_Makers.ToList();                          //List<M_Maker>型のMakerListに[メーカー]表示用データを代入する
            SalesOfficeList = context.M_SalesOffices.ToList();              //List<M_SalesOffice>型のSalesOfficeListに[営業所]表示用データを代入する
            ClientList = context.M_Clients.ToList();                        //List<M_Client>型のClientListに[顧客]表示用データを代入する
            ProductList = context.M_Products.ToList();                      //List<M_Product>型のProductListに[商品]表示用データを代入する
            MajorClassList = context.M_MajorClassifications.ToList();       //List<M_MajorClassification>型のMajorClassListに[大分類]表示用データを代入する
            SmallClassList = context.M_SmallClassifications.ToList();       //List<M_SmallClassification>型のSmallClassListに[小分類]表示用データを代入する
            StockList = context.T_Stocks.ToList();                          //List<T_Stock>型のStockListに[在庫]表示用データを代入する
            EmployeeList = context.M_Employees.ToList();                    //List<T_Employee>型のEmployeeListに[社員]表示用データを代入する
            SaleList = context.T_Sale.ToList();                             //List<T_Sale>型のSaleListに[売上]表示用データを代入する
            SaleDetailList = context.T_SaleDetails.ToList();                //List<T_SaleDetail>型のSaleDetailListに[売上詳細]表示用データを代入する
            OrderList = context.T_Orders.ToList();                          //List<T_Order>型のOrderListに[受注]表示用データを代入する
            OrderDetailList = context.T_OrderDetails.ToList();              //List<T_OrderDetail>型のOrderDetailListに[受注詳細]表示用データを代入する
            ChumonList = context.T_Chumons.ToList();                        //List<T_Chumon>型のChumonListに[注文]表示用データを代入する
            ChumonDetailList = context.T_ChumonDetails.ToList();            //List<T_ChumonDetail>型のChumonDetailListに[注文詳細]表示用データを代入する
            HattyuList = context.T_Hattyus.ToList();                        //List<T_Hattyu>型のHattyuListに[発注]表示用データを代入する
            HattyuDetailList = context.T_HattyuDetails.ToList();            //List<T_HattyuDetail>型のHattyuDetailListに[発注詳細]表示用データを代入する
            WarehousingList = context.T_Warehousings.ToList();              //List<T_Warehousing>型のWarehousingListに[入庫]表示用データを代入する
            WarehousingDetailList = context.T_WarehousingDetails.ToList();  //List<T_WarehousingDetail>型のWarehousingDetailListに[入庫詳細]表示用データを代入する
            SyukkoList = context.T_Syukkos.ToList();                        //List<T_Syukko>型のSyukkoListに[出庫]表示用データを代入する
            SyukkoDetailList = context.T_SyukkoDetails.ToList();            //List<T_SyukkoDetail>型のSyukkoDetailListに[出庫詳細]表示用データを代入する
            ArrivalList = context.T_Arrivals.ToList();                      //List<T_Arrival>型のArrivalListに[入荷]表示用データを代入する
            ArrivalDetailList = context.T_ArrivalDetails.ToList();          //List<T_ArrivalDetail>型のArrivalDetailListに[入荷詳細]表示用データを代入する
            ShipmentList = context.T_Shipments.ToList();                    //List<T_Shipment>型のShipmentListに[出荷]表示用データを代入する
            ShipmentDetailList = context.T_ShipmentDetails.ToList();        //List<T_ShipmentDetail>型のShipmentDetailListに[出荷詳細]表示用データを代入する
        }

        //在庫管理ボタン
        private void buttonStock_Click(object sender, EventArgs e)
        {
            //入力項目に入力されているかチェック
            if (PanelCheck())
            {
                if (msg.MsgDsp("M15001") == DialogResult.Cancel)            //Cancelの場合何もせず終了する
                {
                    return;
                }
                ClearText(this);        //Okの場合全入力内容をクリアする                
            }

            ResetComboBox(panelStock);     //ComboBoxのItemsをリセットする
            //在庫IDコンボボックスにデータを追加
            foreach (var StockData in StockList)
            {
                comboBoxStStockID.Items.Add(StockData.StID);
            }
            //商品IDコンボボックスにデータを追加
            foreach (var ProductData in ProductList)
            {
                comboBoxStProductID.Items.Add(ProductData.PrID);
            }
            //大分類IDコンボボックスにデータを追加
            foreach (var MajorClassData in MajorClassList)
            {
                comboBoxStMajorClassID.Items.Add(MajorClassData.McID);
            }
            //小分類IDコンボボックスにデータを追加
            foreach (var SmallClassData in SmallClassList)
            {
                comboBoxStSmallClassID.Items.Add(SmallClassData.ScID);
            }

            //在庫管理画面を表示する
            panelHide();
            panelStock.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
            //データの表示
            ListStock();
        }

        //ログインボタン
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            panelStart.Hide();

            //ログイン後のタブストッププロパティ変更
            textBoxHomeLoginID.TabStop = false;
            textBoxHomePassword.TabStop = false;
        }

        //出庫管理ボタン
        private void buttonSyukko_Click(object sender, EventArgs e)
        {
            //入力項目に入力されているかチェック
            if (PanelCheck())
            {
                if (msg.MsgDsp("M15001") == DialogResult.Cancel)            //Cancelの場合何もせず終了する
                {
                    return;
                }
                ClearText(this);        //Okの場合全入力内容をクリアする
            }

            ResetComboBox(panelSyukko);     //ComboBoxのItemsをリセットする
            //出庫IDコンボボックスにデータを追加
            foreach (var SyukkoData in SyukkoList)
            {
                comboBoxSySyukkoID.Items.Add(SyukkoData.SyID);
            }
            //受注IDコンボボックスにデータを追加
            foreach (var OrderData in OrderList)
            {
                comboBoxSyOrderID.Items.Add(OrderData.OrID);
            }
            //営業所IDコンボボックスにデータを追加
            foreach (var SalesOfficeData in SalesOfficeList)
            {
                comboBoxSySalesOfficeID.Items.Add(SalesOfficeData.SoID);
            }
            //社員IDコンボボックスにデータを追加
            foreach (var EmployeeData in EmployeeList)
            {
                comboBoxSyEmployeeID.Items.Add(EmployeeData.EmID);
            }
            //顧客IDコンボボックスにデータを追加
            foreach (var ClientData in ClientList)
            {
                comboBoxSyClientID.Items.Add(ClientData.ClID);
            }

            //出庫管理画面を表示する
            panelHide();
            panelSyukko.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
            //データの表示
            ListSyukko();
        }

        //社員管理ボタン
        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            //入力項目に入力されているかチェック
            if (PanelCheck())
            {
                if (msg.MsgDsp("M15001") == DialogResult.Cancel)            //Cancelの場合何もせず終了する
                {
                    return;
                }
                ClearText(this);        //Okの場合全入力内容をクリアする
            }

            ResetComboBox(panelEmployee);     //ComboBoxのItemsをリセットする
            //社員IDコンボボックスにデータを追加
            foreach (var EmployeeData in EmployeeList)
            {
                comboBoxEmEmployeeID.Items.Add(EmployeeData.EmID);
            }
            //営業所IDコンボボックスにデータを追加
            foreach (var SalesOfficeData in SalesOfficeList)
            {
                comboBoxEmSalesOfficeID.Items.Add(SalesOfficeData.SoID);
            }
            //役職IDコンボボックスにデータを追加
            foreach (var PositionData in PositionList)
            {
                comboBoxEmPositionID.Items.Add(PositionData.PoID);
            }

            //社員管理画面を表示する
            panelHide();
            panelEmployee.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
            //データの表示
            ListEmployee();
        }

        //入荷管理ボタン
        private void buttonArrival_Click(object sender, EventArgs e)
        {
            //入力項目に入力されているかチェック
            if (PanelCheck())
            {
                if (msg.MsgDsp("M15001") == DialogResult.Cancel)            //Cancelの場合何もせず終了する
                {
                    return;
                }
                ClearText(this);        //Okの場合全入力内容をクリアする
            }

            ResetComboBox(panelArrival);     //ComboBoxのItemsをリセットする
            //入荷IDコンボボックスにデータを追加
            foreach (var ArrivalData in ArrivalList)
            {
                comboBoxArArrivalID.Items.Add(ArrivalData.ArID);
            }
            //受注IDコンボボックスにデータを追加
            foreach (var OrderData in OrderList)
            {
                comboBoxArOrderID.Items.Add(OrderData.OrID);
            }
            //営業所IDコンボボックスにデータを追加
            foreach (var SalesOfficeData in SalesOfficeList)
            {
                comboBoxArSalesOfficeID.Items.Add(SalesOfficeData.SoID);
            }
            //社員IDコンボボックスにデータを追加
            foreach (var EmployeeData in EmployeeList)
            {
                comboBoxArEmployeeID.Items.Add(EmployeeData.EmID);
            }
            //顧客IDコンボボックスにデータを追加
            foreach (var ClientData in ClientList)
            {
                comboBoxArClientID.Items.Add(ClientData.ClID);
            }

            //入荷管理画面を表示する
            panelHide();
            panelArrival.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
            //データの表示
            ListArrival();
        }

        //顧客管理ボタン
        private void buttonClient_Click(object sender, EventArgs e)
        {
            //入力項目に入力されているかチェック
            if (PanelCheck())
            {
                if (msg.MsgDsp("M15001") == DialogResult.Cancel)            //Cancelの場合何もせず終了する
                {
                    return;
                }
                ClearText(this);        //Okの場合全入力内容をクリアする
            }

            ResetComboBox(panelClient);     //ComboBoxのItemsをリセットする
            //顧客IDコンボボックスにデータを追加
            foreach (var ClientData in ClientList)
            {
                comboBoxCIClientID.Items.Add(ClientData.ClID);
            }
            //営業所IDコンボボックスにデータを追加
            foreach(var SalesOfficeData in SalesOfficeList)
            {
                comboBoxCISalesOfficeID.Items.Add(SalesOfficeData.SoID);
            }

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
            //入力項目に入力されているかチェック
            if (PanelCheck())
            {
                if (msg.MsgDsp("M15001") == DialogResult.Cancel)            //Cancelの場合何もせず終了する
                {
                    return;
                }
                ClearText(this);        //Okの場合全入力内容をクリアする
            }

            ResetComboBox(panelProduct);     //ComboBoxのItemsをリセットする
            //商品IDコンボボックスにデータを追加
            foreach (var ProductData in ProductList)
            {
                comboBoxPrProductID.Items.Add(ProductData.PrID);
            }
            //メーカIDコンボボックスにデータを追加
            foreach (var MakerData in MakerList)
            {
                comboBoxPrMakerID.Items.Add(MakerData.MaID);
            }
            //大分類IDコンボボックスにデータを追加
            foreach (var MajorClassData in MajorClassList)
            {
                comboBoxPrMajorClassID.Items.Add(MajorClassData.McID);
            }
            //小分類IDコンボボックスにデータを追加
            foreach (var SmallClassData in SmallClassList)
            {
                comboBoxPrSmallClassID.Items.Add(SmallClassData.ScID);
            }

            //商品管理画面を表示する
            panelHide();
            panelProduct.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
            //データの表示
            ListProduct();
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
            //入力項目に入力されているかチェック
            if (PanelCheck())
            {
                if (msg.MsgDsp("M15001") == DialogResult.Cancel)            //Cancelの場合何もせず終了する
                {
                    return;
                }
                ClearText(this);        //Okの場合全入力内容をクリアする
            }

            ResetComboBox(panelOrder);     //ComboBoxのItemsをリセットする
            //受注IDコンボボックスにデータを追加
            foreach (var OrderData in OrderList)
            {
                comboBoxOrOrderID.Items.Add(OrderData.OrID);
            }
            //営業所IDコンボボックスにデータを追加
            foreach (var SalesOfficeData in SalesOfficeList)
            {
                comboBoxOrSalesOfficeID.Items.Add(SalesOfficeData.SoID);
            }
            //社員IDコンボボックスにデータを追加
            foreach (var EmployeeData in EmployeeList)
            {
                comboBoxOrEmployeeID.Items.Add(EmployeeData.EmID);
            }
            //顧客IDコンボボックスにデータを追加
            foreach (var ClientData in ClientList)
            {
                comboBoxOrClientID.Items.Add(ClientData.ClID);
            }

            //受注管理画面を表示する
            panelHide();
            panelOrder.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
            //データの表示
            ListOrder();
        }

        //売上管理ボタン
        private void buttonSale_Click(object sender, EventArgs e)
        {
            //入力項目に入力されているかチェック
            if (PanelCheck())
            {
                if (msg.MsgDsp("M15001") == DialogResult.Cancel)            //Cancelの場合何もせず終了する
                {
                    return;
                }
                ClearText(this);        //Okの場合全入力内容をクリアする
            }

            ResetComboBox(panelSale);     //ComboBoxのItemsをリセットする
            //売上IDコンボボックスにデータを追加
            foreach (var SaleData in SaleList)
            {
                comboBoxSaSaleID.Items.Add(SaleData.SaID);
            }
            //受注IDコンボボックスにデータを追加
            foreach (var OrderData in OrderList)
            {
                comboBoxSaOrderID.Items.Add(OrderData.OrID);
            }
            //営業所IDコンボボックスにデータを追加
            foreach (var SalesOfficeData in SalesOfficeList)
            {
                comboBoxSaSalesOfficeID.Items.Add(SalesOfficeData.SoID);
            }
            //受注社員IDコンボボックスにデータを追加
            foreach (var EmployeeData in EmployeeList)
            {
                comboBoxSaOrderEmployeeID.Items.Add(EmployeeData.EmID);
            }
            //顧客IDコンボボックスにデータを追加
            foreach (var ClientData in ClientList)
            {
                comboBoxSaClientID.Items.Add(ClientData.ClID);
            }

            //売上管理画面を表示する
            panelHide();
            panelSale.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
            //データの表示
            ListSale();
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
            //入力項目に入力されているかチェック
            if (PanelCheck())
            {
                if (msg.MsgDsp("M15001") == DialogResult.Cancel)            //Cancelの場合何もせず終了する
                {
                    return;
                }
                ClearText(this);        //Okの場合全入力内容をクリアする
            }

            ResetComboBox(panelChumon);     //ComboBoxのItemsをリセットする
            //注文IDコンボボックスにデータを追加
            foreach (var ChumonData in ChumonList)
            {
                comboBoxChChumonID.Items.Add(ChumonData.ChID);
            }
            //受注IDコンボボックスにデータを追加
            foreach (var OrderData in OrderList)
            {
                comboBoxChOrderID.Items.Add(OrderData.OrID);
            }
            //営業所IDコンボボックスにデータを追加
            foreach (var SalesOfficeData in SalesOfficeList)
            {
                comboBoxChSalesOfficeID.Items.Add(SalesOfficeData.SoID);
            }
            //社員IDコンボボックスにデータを追加
            foreach (var EmployeeData in EmployeeList)
            {
                comboBoxChEmployeeID.Items.Add(EmployeeData.EmID);
            }
            //顧客IDコンボボックスにデータを追加
            foreach (var ClientData in ClientList)
            {
                comboBoxChClientID.Items.Add(ClientData.ClID);
            }

            //注文管理画面を表示する
            panelHide();
            panelChumon.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
            //データの表示
            ListChumon();
        }

        //発注管理ボタン
        private void buttonHattyu_Click(object sender, EventArgs e)
        {
            //入力項目に入力されているかチェック
            if (PanelCheck())
            {
                if (msg.MsgDsp("M15001") == DialogResult.Cancel)            //Cancelの場合何もせず終了する
                {
                    return;
                }
                ClearText(this);        //Okの場合全入力内容をクリアする
            }

            ResetComboBox(panelHattyu);     //ComboBoxのItemsをリセットする
            //発注IDコンボボックスにデータを追加
            foreach (var HattyuData in HattyuList)
            {
                comboBoxHaHattyuID.Items.Add(HattyuData.HaID);
            }
            //メーカIDコンボボックスにデータを追加
            foreach (var MakerData in MakerList)
            {
                comboBoxHaMakerID.Items.Add(MakerData.MaID);
            }
            //発注社員IDコンボボックスにデータを追加
            foreach (var EmployeeData in EmployeeList)
            {
                comboBoxHaEmployeeID.Items.Add(EmployeeData.EmID);
            }
            //商品IDコンボボックスにデータを追加
            foreach (var ProductData in ProductList)
            {
                comboBoxHaProductID.Items.Add(ProductData.PrID);
            }

            //発注管理画面を表示する
            panelHide();
            panelHattyu.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
            //データの表示
            ListHattyu();
        }

        //入庫管理ボタン
        private void buttonWareHousing_Click(object sender, EventArgs e)
        {
            //入力項目に入力されているかチェック
            if (PanelCheck())
            {
                if (msg.MsgDsp("M15001") == DialogResult.Cancel)            //Cancelの場合何もせず終了する
                {
                    return;
                }
                ClearText(this);        //Okの場合全入力内容をクリアする
            }

            ResetComboBox(panelWareHousing);     //ComboBoxのItemsをリセットする
            //入庫IDコンボボックスにデータを追加
            foreach (var WarehousingData in WarehousingList)
            {
                comboBoxWrWareHousingID.Items.Add(WarehousingData.WaID);
            }
            //発注IDコンボボックスにデータを追加
            foreach (var HattyuData in HattyuList)
            {
                comboBoxWrHattyuID.Items.Add(HattyuData.HaID);
            }
            //入庫確認社員IDコンボボックスにデータを追加
            foreach (var EmployeeData in EmployeeList)
            {
                comboBoxWrEmployeeID.Items.Add(EmployeeData.EmID);
            }

            //入庫管理画面を表示する
            panelHide();
            panelWareHousing.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
            //データの表示
            ListWarehousing();
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
            //FormHomeに配置されている検索名ラベルと全てのテキストボックスとコンボボックスのTextプロパティをリセットする
            ClearText(this);
        }

        //出荷管理ボタン
        private void buttonShipment_Click(object sender, EventArgs e)
        {
            //入力項目に入力されているかチェック
            if (PanelCheck())
            {
                if (msg.MsgDsp("M15001") == DialogResult.Cancel)            //Cancelの場合何もせず終了する
                {
                    return;
                }
                ClearText(this);        //Okの場合全入力内容をクリアする
            }

            ResetComboBox(panelShipment);     //ComboBoxのItemsをリセットする
            //出荷IDコンボボックスにデータを追加
            foreach (var ShipmentData in ShipmentList)
            {
                comboBoxShShipmentID.Items.Add(ShipmentData.ShID);
            }
            //受注IDコンボボックスにデータを追加
            foreach (var OrderData in OrderList)
            {
                comboBoxShOrderID.Items.Add(OrderData.OrID);
            }
            //営業所IDコンボボックスにデータを追加
            foreach (var SalesOfficeData in SalesOfficeList)
            {
                comboBoxShSalesOfficeID.Items.Add(SalesOfficeData.SoID);
            }
            //社員IDコンボボックスにデータを追加
            foreach (var EmployeeData in EmployeeList)
            {
                comboBoxShEmployeeID.Items.Add(EmployeeData.EmID);
            }
            //顧客IDコンボボックスにデータを追加
            foreach (var ClientData in ClientList)
            {
                comboBoxShClientID.Items.Add(ClientData.ClID);
            }
            //商品IDコンボボックスにデータを追加
            foreach (var ProductData in ProductList)
            {
                comboBoxShProductID.Items.Add(ProductData.PrID);
            }

            //出荷管理画面を表示する
            panelHide();
            panelShipment.Show();
            //画面タイトルを更新する
            labelManaTitle.Text = ((Button)sender).Text;
            //データの表示
            ListShipment();
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

        ///////////////////////////////////////////////////
        ///顧客管理画面コード
        ///////////////////////////////////////////////////

        /// <summary>
        /// 顧客情報一覧表示モジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void ListClient()
        {
            dataGridViewCI.Rows.Clear();                        //データグリッドビューをクリアする
            foreach (var ClientData in ClientList)
            {
                if (ClientData.ClFlag == 0)                     //顧客管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewCI.Rows.Add(ClientData.ClID, ClientData.SoID, ClientData.ClName, ClientData.ClAddress, ClientData.ClPhone,
                                                ClientData.ClPostal, ClientData.ClFAX, Convert.ToBoolean(ClientData.ClFlag), ClientData.ClHidden);
                }
            }
        }

        /// <summary>
        /// 顧客情報非表示リストモジュール
        /// (非表示になっているデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void DeleteListClient()
        {
            dataGridViewCI.Rows.Clear();                        //データグリッドビューをクリアする
            foreach (var ClientData in ClientList)
            {
                if (ClientData.ClFlag == 2)                     //顧客管理フラグが2の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewCI.Rows.Add(ClientData.ClID, ClientData.SoID, ClientData.ClName, ClientData.ClAddress, ClientData.ClPhone,
                                                ClientData.ClPostal, ClientData.ClFAX, Convert.ToBoolean(ClientData.ClFlag), ClientData.ClHidden);
                }
            }
        }

        /// <summary>
        /// 顧客情報登録ボタン
        /// </summary>
        /// <param>なし</param>
        /// <return>なし</return>
        private void buttonCIAdd_Click(object sender, EventArgs e)
        {
            //営業所IDの入力チェックメソッドの呼びだし
            if (!InputCheck.SalesOfficeIDInputCheck(comboBoxCISalesOfficeID.Text))
            {
                comboBoxCISalesOfficeID.Focus();
                return;
            }
            //入力チェックメソッドの呼び出し
            if (!ClientInputCheck())
            {
                return;
            }

            //登録用顧客情報のセット
            M_Client AddClientData = ClientAddDataSet();

            //顧客情報の登録
            ClientAccess.AddClient(AddClientData);

            //顧客情報一覧表示用データの更新
            ClientList = ClientAccess.GetData();

            //顧客情報再表示
            ListClient();
        }

        /// <summary>
        /// 顧客情報入力チェックメソッド
        /// </summary>
        /// <returns>異常あり:false, 異常なし:true</returns>
        private bool ClientInputCheck()
        {
            //顧客管理画面顧客名の空文字チェック
            if (string.IsNullOrEmpty(textBoxCIClientName.Text.Trim()))
            {
                msg.MsgDsp("M2007");
                textBoxCIClientName.Focus();
                return false;
            }

            //顧客管理画面顧客名の全角チェック
            if (!InputCheck.CheckFullWidth(textBoxCIClientName.Text.Trim()))
            {
                msg.MsgDsp("M2008");
                textBoxCIClientName.Focus();
                return false;
            }

            //顧客管理画面営業所IDの文字数チェック
            if (textBoxCIClientName.Text.Trim().Length > 50)
            {
                msg.MsgDsp("M2009");
                textBoxCIClientName.Focus();
                return false;
            }

            //顧客管理画面住所の空文字チェック
            if (string.IsNullOrEmpty(textBoxCIAddress.Text.Trim()))
            {
                msg.MsgDsp("M2010");
                textBoxCIAddress.Focus();
                return false;
            }

            //顧客管理画面住所の全角チェック
            if (!InputCheck.CheckFullWidth(textBoxCIAddress.Text.Trim()))
            {
                msg.MsgDsp("M2011");
                textBoxCIAddress.Focus();
                return false;
            }

            //顧客管理画面住所の文字数チェック
            if (textBoxCIAddress.Text.Trim().Length > 50)
            {
                msg.MsgDsp("M2012");
                textBoxCIAddress.Focus();
                return false;
            }

            //顧客管理画面電話番号の空文字チェック
            if (string.IsNullOrEmpty(textBoxCIPhone.Text.Trim()))
            {
                msg.MsgDsp("M2013");
                textBoxCIPhone.FindForm();
                return false;
            }

            //顧客管理画面電話番号の半角数字チェック
            if (!InputCheck.CheckNumericAndHalfChar(textBoxCIPhone.Text.Trim()))
            {
                msg.MsgDsp("M2014");
                textBoxCIPhone.Focus();
                return false;
            }

            //顧客管理画面電話番号の文字数チェック
            if (textBoxCIPhone.Text.Trim().Length > 13)
            {
                msg.MsgDsp("M2015");
                textBoxCIPhone.Focus();
                return false;
            }

            //顧客管理画面郵便番号の空文字チェック
            if (string.IsNullOrEmpty(textBoxCIPostal.Text.Trim()))
            {
                msg.MsgDsp("M2016");
                textBoxCIPostal.Focus();
                return false;
            }

            //顧客管理画面郵便番号の半角数字チェック
            if (!InputCheck.CheckNumericAndHalfChar(textBoxCIPostal.Text.Trim()))
            {
                msg.MsgDsp("M2017");
                textBoxCIPostal.Focus();
                return false;
            }

            //顧客管理画面郵便番号の文字数チェック
            if (textBoxCIPostal.Text.Trim().Length > 7)
            {
                msg.MsgDsp("M2018");
                textBoxCIPostal.Focus();
                return false;
            }

            //顧客管理画面FAXの空文字チェック
            if (string.IsNullOrEmpty(textBoxCIFax.Text.Trim()))
            {
                msg.MsgDsp("M2019");
                textBoxCIFax.Focus();
                return false;
            }

            //顧客管理画面FAXの半角数字チェック
            if (!InputCheck.CheckNumericAndHalfChar(textBoxCIFax.Text.Trim()))
            {
                msg.MsgDsp("M2020");
                textBoxCIFax.Focus();
                return false;
            }

            //顧客管理画面FAXの文字数チェック
            if (textBoxCIFax.Text.Trim().Length > 13)
            {
                msg.MsgDsp("M2021");
                textBoxCIFax.Focus();
                return false;
            }

            //異常が無い場合trueを返す
            return true;
        }

        /// <summary>
        /// 登録用顧客情報をセットする
        /// </summary>
        /// <returns>M_Client</returns>
        private M_Client ClientAddDataSet()
        {
            return new M_Client
            {
                SoID = int.Parse(comboBoxCISalesOfficeID.Text.Trim()),
                ClName = textBoxCIClientName.Text.Trim(),
                ClAddress = textBoxCIAddress.Text.Trim(),
                ClPhone = textBoxCIPhone.Text.Trim(),
                ClPostal = textBoxCIPostal.Text.Trim(),
                ClFAX = textBoxCIFax.Text.Trim(),
                ClFlag = 0,
                ClHidden = textBoxCIRsn.Text.Trim()
            };
        }

        /// <summary>
        /// 更新用顧客情報をセットする
        /// </summary>
        /// <returns></returns>
        private M_Client ClientUpdDataSet()
        {
            return new M_Client
            {
                ClID = int.Parse(comboBoxCIClientID.Text),
                SoID = int.Parse(comboBoxCISalesOfficeID.Text),
                ClName = textBoxCIClientName.Text,
                ClAddress = textBoxCIAddress.Text,
                ClPhone = textBoxCIPhone.Text,
                ClPostal = textBoxCIPostal.Text,
                ClFAX = textBoxCIFax.Text,
                ClHidden = textBoxCIRsn.Text
            };
        }

        /// <summary>
        /// 顧客情報更新ボタン
        /// </summary>
        /// <param>なし</param>
        private void buttonCIUpdate_Click(object sender, EventArgs e)
        {
            //顧客IDの入力チェック
            if (!InputCheck.ClientIDInputCheck(comboBoxCIClientID.Text))
            {
                comboBoxCIClientID.Focus();
                return;
            }
            //営業所IDの入力チェック
            if (!InputCheck.SalesOfficeIDInputCheck(comboBoxCISalesOfficeID.Text))
            {
                comboBoxCISalesOfficeID.Focus();
                return;
            }
            //顧客ID,営業所ID以外の入力チェック
            if (!ClientInputCheck())
            {
                return;
            }
            //更新用顧客情報をセット
            M_Client updClientData = ClientUpdDataSet();
            //顧客更新モジュール呼び出し
            ClientAccess.UpdateClient(updClientData);

            //顧客情報一覧表示用データの更新
            ClientList = ClientAccess.GetData();
            //顧客情報再表示
            ListClient();
        }

        /// <summary>
        /// 一覧表示ボタン
        /// </summary>
        /// <param >なし</param>
        private void buttonCIDisplay_Click(object sender, EventArgs e)
        {
            ListClient();                   //一覧表示メソッドの呼び出し
        }

        /// <summary>
        /// 顧客検索ボタン
        /// (SearchClient呼び出し)
        /// 引数1:(1:顧客ID, 2:営業所ID, なし:顧客名)
        /// </summary>
        private void buttonCISearch_Click(object sender, EventArgs e)
        {
            dataGridViewCI.Rows.Clear();                        //データグリッドビューの内容を消去する

            if (!string.IsNullOrEmpty(comboBoxCIClientID.Text))             //顧客IDコンボボックスの空文字チェック
            {
                //顧客IDの入力チェック
                if (!InputCheck.ClientIDInputCheck(comboBoxCIClientID.Text))
                {
                    comboBoxCIClientID.Focus();
                    return;
                }
                foreach (var ClData in ClientAccess.SearchClient(1, comboBoxCIClientID.Text))           //顧客IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewCI.Rows.Add(ClData.ClID, ClData.SoID, ClData.ClName, ClData.ClAddress, ClData.ClPhone, ClData.ClPostal, ClData.ClFAX
                                                        , Convert.ToBoolean(ClData.ClFlag), ClData.ClHidden);
                }
                labelCISearchTitle.Text = "顧客IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(textBoxCIClientName.Text))       //顧客名テキストボックスの空文字チェック
            {
                foreach (var ClData in ClientAccess.SearchClient(textBoxCIClientName.Text))             //顧客名で検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewCI.Rows.Add(ClData.ClID, ClData.SoID, ClData.ClName, ClData.ClAddress, ClData.ClPhone, ClData.ClPostal, ClData.ClFAX
                                                        , Convert.ToBoolean(ClData.ClFlag), ClData.ClHidden);
                }
                labelCISearchTitle.Text = "顧客名で検索しました";           //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxCISalesOfficeID.Text))   //営業所IDコンボボックスの空文字チェック
            {
                //営業所IDの入力チェック
                if (!InputCheck.SalesOfficeIDInputCheck(comboBoxCISalesOfficeID.Text))
                {
                    comboBoxCISalesOfficeID.Focus();
                    return;
                }
                foreach (var ClData in ClientAccess.SearchClient(2, comboBoxCISalesOfficeID.Text))      //営業所IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewCI.Rows.Add(ClData.ClID, ClData.SoID, ClData.ClName, ClData.ClAddress, ClData.ClPhone, ClData.ClPostal, ClData.ClFAX
                                                        , Convert.ToBoolean(ClData.ClFlag), ClData.ClHidden);
                }
                labelCISearchTitle.Text = "営業所IDで検索しました";         //何で検索したかを表示
            }
        }

        /// <summary>
        /// 顧客非表示ボタン
        /// (チェックボックスがチェックされているデータを非表示(論理削除)にする)
        /// </summary>
        /// <param>int ClientID</param>
        private void buttonCINDisplay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewCI.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewCI.Rows[i].Cells[7].Value)                    //1行ずつチェックボックスがチェックされているかを判定する
                {
                    ClientAccess.DeleteClient((int)dataGridViewCI.Rows[i].Cells[0].Value);      //チェックされている場合その行の顧客IDを引数に非表示機能モジュールを呼び出す
                }
            }
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //顧客情報一覧表示用データを更新
            ClientList = ClientAccess.GetData();
            //顧客情報再表示
            ListClient();
        }

        /// <summary>
        /// 顧客非表示リストボタン
        /// </summary>
        /// <param >なし</param>
        private void buttonCINDisplayList_Click(object sender, EventArgs e)
        {
            DeleteListClient();                     //非表示リストメソッドの呼び出し
        }

        ///////////////////////////////////////////////////
        ///商品管理画面コード
        ///////////////////////////////////////////////////

        /// <summary>
        /// 商品情報一覧表示モジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void ListProduct()
        {
            dataGridVieProduct.Rows.Clear();                        //データグリッドビューをクリアする
            foreach (var ProductData in ProductList)
            {
                if (ProductData.PrFlag == 0)                     //商品管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridVieProduct.Rows.Add(ProductData.PrID, ProductData.MaID, ProductData.PrName, ProductData.Price, ProductData.PrSafetyStock, ProductData.ScID, ProductData.PrModelNumber,
                                                    ProductData.PrColor, ProductData.PrReleaseDate, ProductData.PrFlag, ProductData.PrHidden);
                }
            }
        }

        /// <summary>
        /// 商品情報非表示リストモジュール
        /// (非表示になっているデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void DeleteListProduct()
        {
            dataGridVieProduct.Rows.Clear();                        //データグリッドビューをクリアする
            foreach (var ProductData in ProductList)
            {
                if (ProductData.PrFlag == 2)                     //商品管理フラグが2の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridVieProduct.Rows.Add(ProductData.PrID, ProductData.MaID, ProductData.PrName, ProductData.Price, ProductData.PrSafetyStock, ProductData.ScID, ProductData.PrModelNumber,
                                                    ProductData.PrColor, ProductData.PrReleaseDate, ProductData.PrFlag, ProductData.PrHidden);
                }
            }
        }

        /// <summary>
        /// 商品情報登録ボタン
        /// </summary>
        /// <param>なし</param>
        /// <return>なし</return>
        private void buttonPrAdd_Click(object sender, EventArgs e)
        {
            //メーカID入力チェックメソッドの呼びだし
            if (!InputCheck.MakerIDInputCheck(comboBoxPrMakerID.Text))
            {
                comboBoxPrMakerID.Focus();
                return;
            }
            //入力チェックメソッドの呼び出し
            if (!ProductInputCheck())
            {
                return;
            }

            //登録用商品情報のセット
            M_Product AddProductData = ProductAddDataSet();

            //商品情報の登録
            ProductAccess.AddProduct(AddProductData);

            //商品情報一覧表示用データの更新
            ProductList = ProductAccess.GetData();

            //商品情報一覧表示
            ListProduct();
        }

        /// <summary>
        /// 商品情報入力チェックメソッド
        /// </summary>
        /// <returns>異常あり:false, 異常なし:true</returns>
        private bool ProductInputCheck()
        {
            //商品間画面商品名の空文字チェック
            if (string.IsNullOrEmpty(textBoxPrProductName.Text))
            {
                msg.MsgDsp("M3007");
                textBoxPrProductName.Focus();
                return false;
            }

            ////商品管理画面商品名の全角チェック
            //if (!InputCheck.CheckFullWidth(textBoxPrProductName.Text))
            //{
            //    msg.MsgDsp("M3009");
            //    textBoxPrProductName.Focus();
            //    return false;
            //}

            //商品管理画面商品名の文字数チェック
            if (textBoxPrProductName.Text.Length > 50)
            {
                msg.MsgDsp("M3008");
                textBoxPrProductName.Focus();
                return false;
            }

            //商品管理画面価格の空文字チェック
            if (string.IsNullOrEmpty(textBoxPrPrice.Text))
            {
                msg.MsgDsp("M3010");
                textBoxPrPrice.Focus();
                return false;
            }

            //商品管理画面価格の半角数字チェック
            if (!InputCheck.CheckNumericAndHalfChar(textBoxPrPrice.Text))
            {
                msg.MsgDsp("M3011");
                textBoxPrPrice.Focus();
                return false;
            }

            //商品管理画面価格の文字数チェック
            if (textBoxPrPrice.Text.Length > 9)
            {
                msg.MsgDsp("M3012");
                textBoxPrPrice.Focus();
                return false;
            }

            //商品管理画面安全在庫数の空文字チェック
            if (string.IsNullOrEmpty(numericUpDownPrSafeStock.Text))
            {
                msg.MsgDsp("M3013");
                numericUpDownPrSafeStock.Focus();
                return false;
            }

            //商品管理画面安全在庫数の半角数字チェック
            if (!InputCheck.CheckNumericAndHalfChar(numericUpDownPrSafeStock.Value.ToString()))
            {
                msg.MsgDsp("M3014");
                numericUpDownPrSafeStock.Focus();
                return false;
            }

            //商品管理画面安全在庫数の文字数チェック
            if (numericUpDownPrSafeStock.Value.ToString().Length > 4)
            {
                msg.MsgDsp("M3015");
                numericUpDownPrSafeStock.Focus();
                return false;
            }

            //商品管理画面小分類IDの空文字チェック
            if (string.IsNullOrEmpty(comboBoxPrSmallClassID.Text))
            {
                msg.MsgDsp("M3016");
                comboBoxPrSmallClassID.Focus();
                return false;
            }

            //商品管理画面小分類IDの半角数字チェック
            if (!InputCheck.CheckNumericAndHalfChar(comboBoxPrSmallClassID.Text))
            {
                msg.MsgDsp("M3017");
                comboBoxPrSmallClassID.Focus();
                return false;
            }

            //商品管理画面小分類IDの文字数チェック
            if (comboBoxPrSmallClassID.Text.Length > 2)
            {
                msg.MsgDsp("M3018");
                comboBoxPrSmallClassID.Focus();
                return false;
            }

            //商品管理画面型番の空文字チェック
            if (string.IsNullOrEmpty(textBoxPrModelNumber.Text))
            {
                msg.MsgDsp("M3077");
                textBoxPrModelNumber.Focus();
                return false;
            }

            //商品管理画面型番の文字数チェック
            if (textBoxPrModelNumber.Text.Length > 20)
            {
                msg.MsgDsp("M3078");
                textBoxPrModelNumber.Focus();
                return false;
            }

            //商品管理画面色の空文字チェック
            if (string.IsNullOrEmpty(textBoxPrColor.Text))
            {
                msg.MsgDsp("M3019");
                textBoxPrColor.Focus();
                return false;
            }

            //商品管理画面色の全角チェック
            if (!InputCheck.CheckFullWidth(textBoxPrColor.Text))
            {
                msg.MsgDsp("M3020");
                textBoxPrColor.Focus();
                return false;
            }

            //商品管理画面色の文字数チェック
            if (textBoxPrColor.Text.Length > 20)
            {
                msg.MsgDsp("M3021");
                textBoxPrColor.Focus();
                return false;
            }

            //商品管理画面発売日の空文字チェック
            if (string.IsNullOrEmpty(DateTimePickerProduct.Value.ToString()))
            {
                msg.MsgDsp("M3022");
                DateTimePickerProduct.Focus();
                return false;
            }

            //異常なしの場合trueを返す
            return true;
        }

        /// <summary>
        /// 登録用商品情報をセットする
        /// </summary>
        /// <returns>M_Product</returns>
        private M_Product ProductAddDataSet()
        {
            return new M_Product
            {
                MaID = int.Parse(comboBoxPrMakerID.Text),
                PrName = textBoxPrProductName.Text,
                Price = int.Parse(textBoxPrPrice.Text),
                PrSafetyStock = int.Parse(numericUpDownPrSafeStock.Value.ToString()),
                ScID = int.Parse(comboBoxPrSmallClassID.Text),
                PrModelNumber = textBoxPrModelNumber.Text,
                PrColor = textBoxPrColor.Text,
                PrReleaseDate = DateTimePickerProduct.Value,
                PrFlag = 0,
                PrHidden = textBoxPrRsn.Text
            };
        }

        /// <summary>
        /// 更新用商品情報をセットする
        /// </summary>
        /// <returns>M_Product</returns>
        private M_Product ProductUpdDataSet()
        {
            return new M_Product
            {
                PrID = int.Parse(comboBoxPrProductID.Text),
                MaID = int.Parse(comboBoxPrMakerID.Text),
                PrName = textBoxPrProductName.Text,
                Price = int.Parse(textBoxPrPrice.Text),
                PrSafetyStock = int.Parse(numericUpDownPrSafeStock.Value.ToString()),
                ScID = int.Parse(comboBoxPrSmallClassID.Text),
                PrModelNumber = textBoxPrModelNumber.Text,
                PrColor = textBoxPrColor.Text,
                PrReleaseDate = DateTimePickerProduct.Value,
                PrHidden = textBoxPrRsn.Text
            };
        }

        /// <summary>
        /// 商品情報更新ボタン
        /// </summary>
        /// <param>なし</param>
        /// <return>なし</return>
        private void buttonPrUpdate_Click(object sender, EventArgs e)
        {
            //商品IDの入力チェック
            if (!InputCheck.ProductIDInputCheck(comboBoxPrProductID.Text))
            {
                comboBoxPrProductID.Focus();
                return;
            }
            //メーカIDの入力チェック
            if (!InputCheck.MakerIDInputCheck(comboBoxPrMakerID.Text))
            {
                comboBoxPrMakerID.Focus();
                return;
            }
            //商品ID,メーカID以外の入力チェック
            if (!ProductInputCheck())
            {
                return;
            }
            //更新用商品情報をセット
            M_Product updProductData = ProductUpdDataSet();

            //商品更新モジュール呼び出し
            ProductAccess.UpdateProduct(updProductData);

            //商品情報一覧表示用データの更新
            ProductList = ProductAccess.GetData();
            //商品情報再表示
            ListProduct();
        }

        /// <summary>
        /// 一覧表示ボタン
        /// </summary>
        /// <param>なし</param>
        private void buttonPrDisplay_Click(object sender, EventArgs e)
        {
            ListProduct();
        }

        /// <summary>
        /// 商品検索ボタン
        /// (SearchProduct呼び出し)
        /// 引数1:(1:商品ID, 2:メーカID, なし:商品名)
        /// </summary>
        /// <param>なし</param>
        /// <return>なし</return>
        private void buttonPrSearch_Click(object sender, EventArgs e)
        {
            dataGridVieProduct.Rows.Clear();                        //データグリッドビューの内容を消去する

            if (!string.IsNullOrEmpty(comboBoxPrProductID.Text))             //商品IDコンボボックスの空文字チェック
            {
                //商品IDの入力チェック
                if (!InputCheck.ProductIDInputCheck(comboBoxPrProductID.Text))
                {
                    comboBoxPrProductID.Focus();
                    return;
                }
                foreach (var PrData in ProductAccess.SearchProduct(1, comboBoxPrProductID.Text))           //商品IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridVieProduct.Rows.Add(PrData.PrID, PrData.MaID, PrData.PrName, PrData.Price, PrData.PrSafetyStock, PrData.ScID, PrData.PrModelNumber
                                                        , PrData.PrColor, PrData.PrReleaseDate, Convert.ToBoolean(PrData.PrFlag), PrData.PrHidden);
                }
                labelPrSearchTitle.Text = "商品IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(textBoxPrProductName.Text))       //商品名テキストボックスの空文字チェック
            {
                foreach (var PrData in ProductAccess.SearchProduct(textBoxPrProductName.Text))             //商品名で検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridVieProduct.Rows.Add(PrData.PrID, PrData.MaID, PrData.PrName, PrData.Price, PrData.PrSafetyStock, PrData.ScID, PrData.PrModelNumber
                                                        , PrData.PrColor, PrData.PrReleaseDate, Convert.ToBoolean(PrData.PrFlag), PrData.PrHidden);
                }
                labelPrSearchTitle.Text = "商品名で検索しました";           //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxPrMakerID.Text))   //メーカIDコンボボックスの空文字チェック
            {
                //メーカIDの入力チェック
                if (!InputCheck.MakerIDInputCheck(comboBoxPrMakerID.Text))
                {
                    comboBoxPrMakerID.Focus();
                    return;
                }
                foreach (var PrData in ProductAccess.SearchProduct(2, comboBoxPrMakerID.Text))      //メーカIDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridVieProduct.Rows.Add(PrData.PrID, PrData.MaID, PrData.PrName, PrData.Price, PrData.PrSafetyStock, PrData.ScID, PrData.PrModelNumber
                                                        , PrData.PrColor, PrData.PrReleaseDate, Convert.ToBoolean(PrData.PrFlag), PrData.PrHidden);
                }
                labelPrSearchTitle.Text = "メーカIDで検索しました";         //何で検索したかを表示
            }
        }

        /// <summary>
        /// 商品非表示ボタン
        /// (チェックボックスがチェックされているデータを非表示(論理削除)にする)
        /// </summary>
        /// <param >int ProductID</param>
        private void buttonPrNDisplay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridVieProduct.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridVieProduct.Rows[i].Cells[9].Value)                    //1行ずつチェックボックスがチェックされているかを判定する
                {
                    ProductAccess.DeleteProduct((int)dataGridVieProduct.Rows[i].Cells[0].Value);      //チェックされている場合その行の商品IDを引数に非表示機能モジュールを呼び出す
                }
            }
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //商品情報一覧表示用データを更新
            ProductList = ProductAccess.GetData();
            //商品情報再表示
            ListProduct();
        }

        /// <summary>
        /// 商品非表示リストボタン
        /// </summary>
        /// <param>なし</param>
        private void buttonPrNDisplayList_Click(object sender, EventArgs e)
        {
            DeleteListProduct();                     //非表示リストメソッドの呼び出し
        }

        ///////////////////////////////////////////////
        ///在庫管理画面コード
        ///////////////////////////////////////////////

        /// 在庫情報一覧表示モジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void ListStock()
        {
            dataGridViewStock.Rows.Clear();                        //データグリッドビューをクリアする
            foreach (var StockData in StockList)
            {
                if (StockData.StFlag == 0)                     //在庫管理フラグが0の場合表示する
                {
                    //商品名を抽出する
                    M_Product ProductData = ProductList.Single(Product => Product.PrID == StockData.PrID);

                    //データグリッドビューにデータを追加する
                    dataGridViewStock.Rows.Add(StockData.StID, StockData.PrID, ProductData.PrName, StockData.StQuantity, Convert.ToBoolean(StockData.StFlag), StockData.StHidden);
                }
            }
        }

        /// <summary>
        /// 在庫情報非表示リストモジュール
        /// (非表示になっているデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void DeleteListStock()
        {
            dataGridViewStock.Rows.Clear();                        //データグリッドビューをクリアする
            foreach (var StockData in StockList)
            {
                if (StockData.StFlag == 2)                     //在庫管理フラグが2の場合表示する
                {
                    //商品名を抽出する
                    M_Product ProductData = ProductList.Single(Product => Product.PrID == StockData.PrID);

                    //データグリッドビューにデータを追加する
                    dataGridViewStock.Rows.Add(StockData.StID, StockData.PrID, ProductData.PrName, StockData.StQuantity, Convert.ToBoolean(StockData.StFlag), StockData.StHidden);
                }
            }
        }

        /// <summary>
        /// 在庫情報入力チェックメソッド
        /// </summary>
        /// <returns>異常なし:true, 異常あり:false</returns>
        private bool StockInputCheck()
        {
            //在庫数の空文字チェック
            if (string.IsNullOrEmpty(textBoxStInventory.Text))
            {
                msg.MsgDsp("M4007");
                textBoxStInventory.Focus();
                return false;
            }

            //在庫数の半角数字チェック
            if (!InputCheck.CheckNumericAndHalfChar(textBoxStInventory.Text))
            {
                msg.MsgDsp("M4008");
                textBoxStInventory.Focus();
                return false;
            }

            //在庫数の文字数チェック
            if (textBoxStInventory.Text.Length > 4)
            {
                msg.MsgDsp("M4009");
                textBoxStInventory.Focus();
                return false;
            }

            //異常なしの場合trueを返す
            return true;
        }

        /// <summary>
        /// 更新用在庫情報をセットする
        /// </summary>
        /// <returns></returns>
        private T_Stock StockUpdDataSet()
        {
            return new T_Stock()
            {
                StID = int.Parse(comboBoxStStockID.Text),
                PrID = int.Parse(comboBoxStProductID.Text),
                StQuantity = int.Parse(textBoxStInventory.Text),
                StHidden = textBoxStRsn.Text
            };
        }

        /// <summary>
        /// 在庫更新ボタン
        /// </summary>
        /// <param></param>
        private void buttonStUpdate_Click(object sender, EventArgs e)
        {
            //在庫IDの入力チェックメソッド呼び出し
            if (!InputCheck.StockInputCheck(comboBoxStStockID.Text))
            {
                comboBoxStStockID.Focus();
                return;
            }
            //商品IDの入力チェックメソッド呼び出し
            if (!InputCheck.ProductIDInputCheck(comboBoxStProductID.Text))
            {
                comboBoxStProductID.Focus();
                return;
            }
            //在庫情報入力チェックメソッド呼び出し
            if (!StockInputCheck())
            {
                return;
            }
            //更新用在庫情報をセット
            T_Stock updStockData = StockUpdDataSet();
            //在庫更新モジュール呼び出し
            StockAccess.UpdateStock(updStockData);

            //在庫情報一覧表示用データの更新
            StockList = StockAccess.GetData();
            //在庫情報再表示
            ListStock();
        }

        /// <summary>
        /// 在庫一覧表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonStDisplay_Click(object sender, EventArgs e)
        {
            ListStock();
        }

        /// <summary>
        /// 在庫情報検索ボタン
        ///  (SearchStock呼び出し)
        /// 引数1:(1:在庫ID, 2:商品ID, なし:商品名)
        /// </summary>
        /// <param></param>
        private void buttonStSearch_Click(object sender, EventArgs e)
        {
            dataGridViewStock.Rows.Clear();                        //データグリッドビューの内容を消去する

            if (!string.IsNullOrEmpty(comboBoxStStockID.Text))             //在庫IDコンボボックスの空文字チェック
            {
                //在庫IDの入力チェック
                if (!InputCheck.StockInputCheck(comboBoxStStockID.Text))
                {
                    comboBoxStStockID.Focus();
                    return;
                }
                foreach (var StData in StockAccess.SearchStock(1, comboBoxStStockID.Text))           //在庫IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewStock.Rows.Add(StData.StID, StData.PrID, StData.StQuantity, Convert.ToBoolean(StData.StFlag), StData.StHidden);
                }
                labelStSearchTitle.Text = "在庫IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxStProductID.Text))       //商品IDコンボボックスの空文字チェック
            {
                //商品IDの入力チェック
                if (!InputCheck.ProductIDInputCheck(comboBoxStProductID.Text))
                {
                    comboBoxStProductID.Focus();
                    return;
                }
                foreach (var StData in StockAccess.SearchStock(2, comboBoxStProductID.Text))             //商品IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewStock.Rows.Add(StData.StID, StData.PrID, StData.StQuantity, Convert.ToBoolean(StData.StFlag), StData.StHidden);
                }
                labelStSearchTitle.Text = "商品IDで検索しました";           //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(textBoxStProductName.Text))   //商品名テキストボックスの空文字チェック
            {
                foreach (var StData in StockAccess.SearchStock(textBoxStProductName.Text))      //商品名で検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewStock.Rows.Add(StData.StID, StData.PrID, StData.StQuantity, Convert.ToBoolean(StData.StFlag), StData.StHidden);
                }
                labelStSearchTitle.Text = "商品名で検索しました";         //何で検索したかを表示
            }
        }

        /// <summary>
        /// 在庫非表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonStNDisplay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewStock.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewStock.Rows[i].Cells[4].Value)                    //1行ずつチェックボックスがチェックされているかを判定する
                {
                    StockAccess.DeleteStock((int)dataGridViewStock.Rows[i].Cells[0].Value);      //チェックされている場合その行の在庫IDを引数に非表示機能モジュールを呼び出す
                }
            }
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //在庫情報一覧表示用データを更新
            StockList = StockAccess.GetData();
            //在庫情報再表示
            ListStock();
        }

        /// <summary>
        /// 在庫非表示リストボタン
        /// </summary>
        /// <param></param>
        private void buttonStNDisplayList_Click(object sender, EventArgs e)
        {
            DeleteListStock();
        }

        /////////////////////////////////////////
        ///社員管理画面コード
        /////////////////////////////////////////

        /// <summary>
        /// 社員情報一覧表示モジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void ListEmployee()
        {
            dataGridViewEmMana.Rows.Clear();                        //データグリッドビューをクリアする
            foreach (var EmployeeData in EmployeeList)
            {
                if (EmployeeData.EmFlag == 0)                     //顧客管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewEmMana.Rows.Add(EmployeeData.EmID, EmployeeData.EmName, EmployeeData.SoID, EmployeeData.PoID, EmployeeData.EmHiredate, EmployeeData.EmPhone,
                                                    Convert.ToBoolean(EmployeeData.EmFlag), EmployeeData.EmHidden);
                }
            }
        }

        /// <summary>
        /// 顧客情報非表示リストモジュール
        /// (非表示になっているデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void DeleteListEmployee()
        {
            dataGridViewEmMana.Rows.Clear();                        //データグリッドビューをクリアする
            foreach (var EmployeeData in EmployeeList)
            {
                if (EmployeeData.EmFlag == 2)                     //社員管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewEmMana.Rows.Add(EmployeeData.EmID, EmployeeData.EmName, EmployeeData.SoID, EmployeeData.PoID, EmployeeData.EmHiredate, EmployeeData.EmPhone,
                                                    Convert.ToBoolean(EmployeeData.EmFlag), EmployeeData.EmHidden);
                }
            }
        }

        /// <summary>
        /// 社員情報登録ボタン
        /// </summary>
        /// <param></param>
        private void buttonEmRegist_Click(object sender, EventArgs e)
        {
            //営業所IDの入力チェックメソッド呼び出し
            if (!InputCheck.SalesOfficeIDInputCheck(comboBoxEmSalesOfficeID.Text))
            {
                comboBoxEmSalesOfficeID.Focus();
                return;
            }
            //役職IDの入力チェックメソッドの呼び出し
            if (!InputCheck.PositionIDInputCheck(comboBoxEmPositionID.Text))
            {
                comboBoxEmPositionID.Focus();
                return;
            }
            //入力チェックメソッドの呼び出し
            if (!EmployeeInputCheck())
            {
                return;
            }

            //パスワードの空文字チェック
            if (string.IsNullOrEmpty(textBoxEmEmployeePass.Text))
            {
                msg.MsgDsp("M5014");
                textBoxEmEmployeePass.Focus();
                return;
            }

            //パスワードの半角英数字チェック
            if (!InputCheck.CheckHalfAlphabetNumeric(textBoxEmEmployeePass.Text))
            {
                msg.MsgDsp("M5015");
                textBoxEmEmployeePass.Focus();
                return;
            }

            //パスワードの文字数チェック
            if (textBoxEmEmployeePass.Text.Length > 10)
            {
                msg.MsgDsp("M5016");
                textBoxEmEmployeePass.Focus();
                return;
            }

            //登録用社員情報のセット
            M_Employee AddEmployeeData = EmployeeAddDataSet();

            //社員情報の登録
            EmployeeAccess.addEmployee(AddEmployeeData);

            //社員情報一覧表示用データの更新
            EmployeeList = EmployeeAccess.GetData();

            //社員情報再表示
            ListEmployee();
        }

        private bool EmployeeInputCheck()
        {
            //社員名の空文字チェック
            if (string.IsNullOrEmpty(textBoxEmEmployeeName.Text))
            {
                msg.MsgDsp("M5004");
                textBoxEmEmployeeName.Focus();
                return false;
            }

            //社員名の全角チェック
            if (!InputCheck.CheckFullWidth(textBoxEmEmployeeName.Text))
            {
                msg.MsgDsp("M5005");
                textBoxEmEmployeeName.Focus();
                return false;
            }

            //社員名の文字数チェック
            if (textBoxEmEmployeeName.Text.Length > 50)
            {
                msg.MsgDsp("M5006");
                textBoxEmEmployeeName.Focus();
                return false;
            }

            //入社年月日の空文字チェック
            if (string.IsNullOrEmpty(dateTimePickerEmployee.Value.ToString()))
            {
                msg.MsgDsp("M5013");
                dateTimePickerEmployee.Focus();
                return false;
            }

            //電話番号の空文字チェック
            if (string.IsNullOrEmpty(textBoxEmEmployeePhone.Text))
            {
                msg.MsgDsp("M5017");
                textBoxEmEmployeePhone.Focus();
                return false;
            }

            //電話番号の半角数字チェック
            if (!InputCheck.CheckNumericAndHalfChar(textBoxEmEmployeePhone.Text))
            {
                msg.MsgDsp("M5018");
                textBoxEmEmployeePhone.Focus();
                return false;
            }

            //電話番号の文字数チェック
            if (textBoxEmEmployeePhone.Text.Length > 13)
            {
                msg.MsgDsp("M5019");
                textBoxEmEmployeePhone.Focus();
                return false;
            }

            //異常なしの場合trueを返す
            return true;
        }

        /// <summary>
        /// 登録用社員情報をセットする
        /// </summary>
        /// <returns>M_Employee</returns>
        private M_Employee EmployeeAddDataSet()
        {
            return new M_Employee
            {
                EmName = textBoxEmEmployeeName.Text,
                SoID = int.Parse(comboBoxEmSalesOfficeID.Text),
                PoID = int.Parse(comboBoxEmPositionID.Text),
                EmHiredate = dateTimePickerEmployee.Value,
                EmPassword = textBoxEmEmployeePass.Text,
                EmPhone = textBoxEmEmployeePhone.Text,
                EmFlag = 0,
            };
        }

        /// <summary>
        /// 更新用社員情報をセットする
        /// </summary>
        /// <returns>M_Employee</returns>
        private M_Employee EmployeeUpdDataSet()
        {
            return new M_Employee
            {
                EmID = int.Parse(comboBoxEmEmployeeID.Text),
                EmName = textBoxEmEmployeeName.Text,
                SoID = int.Parse(comboBoxEmSalesOfficeID.Text),
                PoID = int.Parse(comboBoxEmPositionID.Text),
                EmHiredate = dateTimePickerEmployee.Value,
                EmPhone = textBoxEmEmployeePhone.Text,
                EmHidden = textBoxEmEmployeeRsn.Text
            };
        }

        /// <summary>
        /// 社員情報更新ボタン
        /// </summary>
        /// <param></param>
        private void buttonEmUpdate_Click(object sender, EventArgs e)
        {
            //社員IDの入力チェックメソッド呼び出し
            if (!InputCheck.EmployeeIDInputCheck(comboBoxEmEmployeeID.Text))
            {
                comboBoxEmEmployeeID.Focus();
                return;
            }
            //営業所IDの入力チェックメソッド呼び出し
            if (!InputCheck.SalesOfficeIDInputCheck(comboBoxEmSalesOfficeID.Text))
            {
                comboBoxEmSalesOfficeID.Focus();
                return;
            }
            //役職IDの入力チェックメソッド呼び出し
            if (!InputCheck.PositionIDInputCheck(comboBoxEmPositionID.Text))
            {
                comboBoxEmPositionID.Focus();
                return;
            }
            //ID以外の入力チェックメソッド呼び出し
            if (!EmployeeInputCheck())
            {
                return;
            }

            //更新用社員情報をセット
            M_Employee AddEmployeeData = EmployeeAddDataSet();
            //社員情報更新モジュール呼び出し
            EmployeeAccess.addEmployee(AddEmployeeData);

            //社員情報一覧表示用データの更新
            EmployeeList = EmployeeAccess.GetData();
            //社員情報再表示
            ListEmployee();
        }

        /// <summary>
        /// 一覧表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonEmDisplay_Click(object sender, EventArgs e)
        {
            ListEmployee();
        }

        /// <summary>
        /// 社員検索ボタン
        /// (SearchEmployee呼び出し)
        /// 引数1:(1:社員ID, 2:営業所ID, 3:役職ID, なし:社員名)
        /// </summary>
        private void buttonEmSearch_Click(object sender, EventArgs e)
        {
            dataGridViewEmMana.Rows.Clear();                        //データグリッドビューの内容を消去する

            if (!string.IsNullOrEmpty(comboBoxEmEmployeeID.Text))             //社員IDコンボボックスの空文字チェック
            {
                //社員IDの入力チェック
                if (!InputCheck.EmployeeIDInputCheck(comboBoxEmEmployeeID.Text))
                {
                    comboBoxEmEmployeeID.Focus();
                    return;
                }
                foreach (var EmData in EmployeeAccess.SearchEmployee(1, comboBoxEmEmployeeID.Text))           //社員IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewEmMana.Rows.Add(EmData.EmID, EmData.EmName, EmData.SoID, EmData.PoID, EmData.EmHiredate, EmData.EmPhone, Convert.ToBoolean(EmData.EmFlag), EmData.EmHidden);
                }
                labelEmSearchTitle.Text = "社員IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(textBoxEmEmployeeName.Text))       //社員名テキストボックスの空文字チェック
            {
                foreach (var EmData in EmployeeAccess.SearchEmployee(textBoxEmEmployeeName.Text))             //社員名で検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewEmMana.Rows.Add(EmData.EmID, EmData.EmName, EmData.SoID, EmData.PoID, EmData.EmHiredate, EmData.EmPhone, Convert.ToBoolean(EmData.EmFlag), EmData.EmHidden);
                }
                labelEmSearchTitle.Text = "社員名で検索しました";           //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxEmSalesOfficeID.Text))   //営業所IDコンボボックスの空文字チェック
            {
                //営業所IDの入力チェック
                if (!InputCheck.SalesOfficeIDInputCheck(comboBoxEmSalesOfficeID.Text))
                {
                    comboBoxEmSalesOfficeID.Focus();
                    return;
                }
                foreach (var EmData in EmployeeAccess.SearchEmployee(2, comboBoxEmSalesOfficeID.Text))      //営業所IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewEmMana.Rows.Add(EmData.EmID, EmData.EmName, EmData.SoID, EmData.PoID, EmData.EmHiredate, EmData.EmPhone, Convert.ToBoolean(EmData.EmFlag), EmData.EmHidden);
                }
                labelEmSearchTitle.Text = "営業所IDで検索しました";         //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxEmPositionID.Text))
            {
                //役職IDの入力チェック
                if (!InputCheck.PositionIDInputCheck(comboBoxEmPositionID.Text))
                {
                    comboBoxEmPositionID.Focus();
                    return;
                }
                foreach (var EmData in EmployeeAccess.SearchEmployee(3, comboBoxEmPositionID.Text))      //役職IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewEmMana.Rows.Add(EmData.EmID, EmData.EmName, EmData.SoID, EmData.PoID, EmData.EmHiredate, EmData.EmPhone, Convert.ToBoolean(EmData.EmFlag), EmData.EmHidden);
                }
                labelEmSearchTitle.Text = "役職IDで検索しました";         //何で検索したかを表示
            }
        }

        /// <summary>
        /// 社員非表示ボタン
        /// </summary>
        /// <param>EmployeeID</param>
        private void buttonEmNdisplay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewEmMana.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewEmMana.Rows[i].Cells[6].Value)                    //1行ずつチェックボックスがチェックされているかを判定する
                {
                    EmployeeAccess.DeleteEmployee((int)dataGridViewEmMana.Rows[i].Cells[0].Value);      //チェックされている場合その行の社員IDを引数に非表示機能モジュールを呼び出す
                }
            }
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //社員情報一覧表示用データを更新
            EmployeeList = EmployeeAccess.GetData();
            //社員情報再表示
            ListEmployee();
        }

        /// <summary>
        /// 社員非表示リストボタン
        /// </summary>
        /// <param></param>
        private void buttonEmNdisplayList_Click(object sender, EventArgs e)
        {
            DeleteListEmployee();
        }

        /////////////////////////////////////////
        ///売上管理画面コード
        /////////////////////////////////////////

        /// <summary>
        /// 売上情報一覧表示モジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void ListSale()
        {
            dataGridViewSaleMain.Rows.Clear();                        //メインデータグリッドビューをクリアする
            dataGridViewSaDetail.Rows.Clear();                        //詳細データグリッドビューをクリアする
            foreach (var SaleData in SaleList)
            {
                if (SaleData.SaFlag == 0)                     //売上管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewSaleMain.Rows.Add(SaleData.SaID, SaleData.ClID, SaleData.SoID, SaleData.EmID, SaleData.ChID, SaleData.SaDate, Convert.ToBoolean(SaleData.SaFlag), SaleData.SaHidden);
                }
            }
        }

        /// <summary>
        /// 売上情報非表示リストモジュール
        /// (非表示になっているデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void DeleteListSale()
        {
            dataGridViewSaleMain.Rows.Clear();                        //メインデータグリッドビューをクリアする
            dataGridViewSaDetail.Rows.Clear();                        //詳細データグリッドビューをクリアする
            foreach (var SaleData in SaleList)
            {
                if (SaleData.SaFlag == 2)                     //売上管理フラグが2の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewSaleMain.Rows.Add(SaleData.SaID, SaleData.ClID, SaleData.SoID, SaleData.EmID, SaleData.ChID, SaleData.SaDate, Convert.ToBoolean(SaleData.SaFlag), SaleData.SaHidden);
                }
            }
        }

        /// <summary>
        /// 一覧表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonSaDisplay_Click(object sender, EventArgs e)
        {
            ListSale();
        }

        /// <summary>
        /// 売上情報検索ボタン
        /// 引数1:(1:売上ID, 2:顧客ID, 3:営業所ID, 4:受注社員ID, 5:受注ID)
        /// </summary>
        /// <param></param>
        private void buttonSaSearch_Click(object sender, EventArgs e)
        {
            dataGridViewSaleMain.Rows.Clear();                        //メインデータグリッドビューの内容を消去する
            dataGridViewSaDetail.Rows.Clear();                        //詳細データグリッドビューの内容を消去する

            if (!string.IsNullOrEmpty(comboBoxSaSaleID.Text))             //売上IDコンボボックスの空文字チェック
            {
                //売上IDの入力チェック
                if (!InputCheck.SaleInputCheck(comboBoxSaSaleID.Text))
                {
                    comboBoxSaSaleID.Focus();
                    return;
                }
                foreach (var SaData in SaleAccess.SearchSale(1, comboBoxSaSaleID.Text))           //売上IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewSaleMain.Rows.Add(SaData.SaID, SaData.ClID, SaData.SoID, SaData.EmID, SaData.ChID, SaData.SaDate, Convert.ToBoolean(SaData.SaFlag), SaData.SaHidden);
                }
                foreach (var SaleDetailData in SaleDetailList.Where(SaleDetailList => SaleDetailList.SaID == int.Parse(comboBoxSaSaleID.Text)))      //売上IDで売上詳細情報を検索する
                {
                    //詳細データグリッドビューにデータを表示する
                    dataGridViewSaDetail.Rows.Add(SaleDetailData.SaDetailID, SaleDetailData.SaID, SaleDetailData.PrID, SaleDetailData.SaQuantity, SaleDetailData.SaPrTotalPrice);
                }
                labelSaSearchTitle.Text = "売上IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxSaClientID.Text))       //顧客IDコンボボックスの空文字チェック
            {
                if (!InputCheck.ClientIDInputCheck(comboBoxSaClientID.Text))
                {
                    comboBoxSaClientID.Focus();
                    return;
                }
                foreach (var SaData in SaleAccess.SearchSale(2, comboBoxSaClientID.Text))           //顧客IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewSaleMain.Rows.Add(SaData.SaID, SaData.ClID, SaData.SoID, SaData.EmID, SaData.ChID, SaData.SaDate, Convert.ToBoolean(SaData.SaFlag), SaData.SaHidden);
                }
                labelSaSearchTitle.Text = "顧客IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxSaSalesOfficeID.Text))   //営業所IDコンボボックスの空文字チェック
            {
                //営業所IDの入力チェック
                if (!InputCheck.SalesOfficeIDInputCheck(comboBoxSaSalesOfficeID.Text))
                {
                    comboBoxSaSalesOfficeID.Focus();
                    return;
                }
                foreach (var SaData in SaleAccess.SearchSale(3, comboBoxSaSalesOfficeID.Text))      //営業所IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewSaleMain.Rows.Add(SaData.SaID, SaData.ClID, SaData.SoID, SaData.EmID, SaData.ChID, SaData.SaDate, Convert.ToBoolean(SaData.SaFlag), SaData.SaHidden);
                }
                labelSaSearchTitle.Text = "営業所IDで検索しました";         //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxSaOrderEmployeeID.Text))
            {
                //受注社員IDの入力チェック
                if (!InputCheck.EmployeeIDInputCheck(comboBoxSaOrderEmployeeID.Text))
                {
                    comboBoxSaOrderEmployeeID.Focus();
                    return;
                }
                foreach (var SaData in SaleAccess.SearchSale(4, comboBoxSaOrderEmployeeID.Text))      //受注社員IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewSaleMain.Rows.Add(SaData.SaID, SaData.ClID, SaData.SoID, SaData.EmID, SaData.ChID, SaData.SaDate, Convert.ToBoolean(SaData.SaFlag), SaData.SaHidden);
                }
                labelSaSearchTitle.Text = "受注社員IDで検索しました";         //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxSaOrderID.Text))
            {
                //受注IDの入力チェック
                if (!InputCheck.OrderInputCheck(comboBoxSaOrderID.Text))
                {
                    comboBoxSaOrderID.Focus();
                    return;
                }
                foreach (var SaData in SaleAccess.SearchSale(5, comboBoxSaOrderID.Text))      //受注IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewSaleMain.Rows.Add(SaData.SaID, SaData.ClID, SaData.SoID, SaData.EmID, SaData.ChID, SaData.SaDate, Convert.ToBoolean(SaData.SaFlag), SaData.SaHidden);
                }
                labelSaSearchTitle.Text = "受注IDで検索しました";         //何で検索したかを表示
            }
        }

        /// <summary>
        /// 売上非表示ボタン
        /// </summary>
        /// <param>int SaleID</param>
        private void buttonSaNDisplay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewSaleMain.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewSaleMain.Rows[i].Cells[6].Value)                    //1行ずつチェックボックスがチェックされているかを判定する
                {
                    SaleAccess.DeleteSale((int)dataGridViewSaleMain.Rows[i].Cells[0].Value);      //チェックされている場合その行の売上IDを引数に非表示機能モジュールを呼び出す
                }
            }
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //顧客情報一覧憑依用データを更新
            SaleList = SaleAccess.GetData();
            //顧客情報再表示
            ListSale();
        }

        /// <summary>
        /// 売上非表示リストボタン
        /// </summary>
        /// <param></param>
        private void buttonSaNDisplayList_Click(object sender, EventArgs e)
        {
            DeleteListSale();
        }

        ///////////////////////////////////
        ///受注管理画面コード
        ///////////////////////////////////

        /// <summary>
        /// 受注情報一覧表示モジュール
        /// </summary>
        private void ListOrder()
        {
            dataGridViewOrderMain.Rows.Clear();                        //メインデータグリッドビューをクリアする
            dataGridViewOrderDetail.Rows.Clear();                        //詳細データグリッドビューをクリアする
            foreach (var OrderData in OrderList)
            {
                if (OrderData.OrFlag == 0)                     //受注管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewOrderMain.Rows.Add(OrderData.OrID, OrderData.SoID, OrderData.EmID, OrderData.ClID, OrderData.ClCharge, OrderData.OrDate, Convert.ToBoolean(OrderData.OrStateFlag),
                                                        Convert.ToBoolean(OrderData.OrFlag), OrderData.OrHidden);
                }
            }
        }

        /// <summary>
        /// 受注情報一覧表示モジュール
        /// </summary>
        private void DeleteListOrder()
        {
            dataGridViewOrderMain.Rows.Clear();                        //メインデータグリッドビューをクリアする
            dataGridViewOrderDetail.Rows.Clear();                        //詳細データグリッドビューをクリアする
            foreach (var OrderData in OrderList)
            {
                if (OrderData.OrFlag == 2)                     //受注管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewOrderMain.Rows.Add(OrderData.OrID, OrderData.SoID, OrderData.EmID, OrderData.ClID, OrderData.ClCharge, OrderData.OrDate, Convert.ToBoolean(OrderData.OrStateFlag),
                                                        Convert.ToBoolean(OrderData.OrFlag), OrderData.OrHidden);
                }
            }
        }

        /// <summary>
        /// 受注一覧表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonOrDisplay_Click(object sender, EventArgs e)
        {
            ListOrder();
        }

        /// <summary>
        /// 受注検索ボタン
        /// 引数1:(1:受注ID, 2:営業所ID, 3:社員ID, 4:顧客ID, なし:顧客名)
        /// </summary>
        /// <param></param>
        private void buttonOrSearch_Click(object sender, EventArgs e)
        {
            dataGridViewOrderMain.Rows.Clear();                        //メインデータグリッドビューの内容を消去する
            dataGridViewOrderDetail.Rows.Clear();                        //詳細データグリッドビューの内容を消去する

            if (!string.IsNullOrEmpty(comboBoxOrOrderID.Text))             //受注IDコンボボックスの空文字チェック
            {
                //売上IDの入力チェック
                if (!InputCheck.OrderInputCheck(comboBoxOrOrderID.Text))
                {
                    comboBoxOrOrderID.Focus();
                    return;
                }
                foreach (var OrData in OrderAccess.SearchOrder(1, comboBoxOrOrderID.Text))           //受注IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewOrderMain.Rows.Add(OrData.OrID, OrData.SoID, OrData.EmID, OrData.ClID, OrData.ClCharge, OrData.OrDate, Convert.ToBoolean(OrData.OrStateFlag),
                                                        Convert.ToBoolean(OrData.OrFlag), OrData.OrHidden);
                }
                foreach (var OrderDetailData in OrderDetailList.Where(OrderDetailList => OrderDetailList.OrID == int.Parse(comboBoxOrOrderID.Text)))      //受注IDで受注詳細情報を検索する
                {
                    //詳細データグリッドビューにデータを表示する
                    dataGridViewOrderDetail.Rows.Add(OrderDetailData.OrDetailID, OrderDetailData.OrID, OrderDetailData.PrID, OrderDetailData.OrQuantity, OrderDetailData.OrTotalPrice);
                }
                labelOrSearchTitle.Text = "受注IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxOrSalesOfficeID.Text))       //営業所IDコンボボックスの空文字チェック
            {
                //社員IDの入力チェック
                if (!InputCheck.SalesOfficeIDInputCheck(comboBoxOrSalesOfficeID.Text))
                {
                    comboBoxOrSalesOfficeID.Focus();
                    return;
                }
                foreach (var OrData in OrderAccess.SearchOrder(2, comboBoxOrSalesOfficeID.Text))           //営業所IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewOrderMain.Rows.Add(OrData.OrID, OrData.SoID, OrData.EmID, OrData.ClID, OrData.ClCharge, OrData.OrDate, Convert.ToBoolean(OrData.OrStateFlag),
                                                        Convert.ToBoolean(OrData.OrFlag), OrData.OrHidden);
                }
                labelOrSearchTitle.Text = "営業所IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxOrEmployeeID.Text))   //社員IDコンボボックスの空文字チェック
            {
                //社員IDの入力チェック
                if (!InputCheck.EmployeeIDInputCheck(comboBoxOrEmployeeID.Text))
                {
                    comboBoxOrEmployeeID.Focus();
                    return;
                }
                foreach (var OrData in OrderAccess.SearchOrder(3, comboBoxOrEmployeeID.Text))      //社員IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewOrderMain.Rows.Add(OrData.OrID, OrData.SoID, OrData.EmID, OrData.ClID, OrData.ClCharge, OrData.OrDate, Convert.ToBoolean(OrData.OrStateFlag),
                                                        Convert.ToBoolean(OrData.OrFlag), OrData.OrHidden);
                }
                labelOrSearchTitle.Text = "社員IDで検索しました";         //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxOrClientID.Text))
            {
                //顧客IDの入力チェック
                if (!InputCheck.ClientIDInputCheck(comboBoxOrClientID.Text))
                {
                    comboBoxOrClientID.Focus();
                    return;
                }
                foreach (var OrData in OrderAccess.SearchOrder(4, comboBoxOrClientID.Text))      //顧客IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewOrderMain.Rows.Add(OrData.OrID, OrData.SoID, OrData.EmID, OrData.ClID, OrData.ClCharge, OrData.OrDate, Convert.ToBoolean(OrData.OrStateFlag),
                                                        Convert.ToBoolean(OrData.OrFlag), OrData.OrHidden);
                }
                labelOrSearchTitle.Text = "顧客IDで検索しました";         //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(textBoxOrClientName.Text))
            {
                foreach (var OrData in OrderAccess.SearchOrder(textBoxOrClientName.Text))      //顧客名で検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewOrderMain.Rows.Add(OrData.OrID, OrData.SoID, OrData.EmID, OrData.ClID, OrData.ClCharge, OrData.OrDate, Convert.ToBoolean(OrData.OrStateFlag),
                                                        Convert.ToBoolean(OrData.OrFlag), OrData.OrHidden);
                }
                labelOrSearchTitle.Text = "顧客名で検索しました";         //何で検索したかを表示
            }
        }

        /// <summary>
        /// 受注管理画面ID以外の入力チェック
        /// </summary>
        /// <returns>bool</returns>
        private bool OrderInputCheck()
        {
            //顧客担当者名の空文字チェック
            if (!string.IsNullOrEmpty(textBoxOrClientName.Text))
            {
                msg.MsgDsp("M7015");
                textBoxOrClientName.Focus();
                return false;
            }
            //顧客担当者名の全角チェック
            if (!InputCheck.CheckFullWidth(textBoxOrClientName.Text))
            {
                msg.MsgDsp("M7016");
                textBoxOrClientName.Focus();
                return false;
            }
            //顧客担当者名の文字数チェック
            if (textBoxOrClientName.Text.Length > 50)
            {
                msg.MsgDsp("M7017");
                textBoxOrClientName.Focus();
                return false;
            }

            //異常なしの場合trueを返す
            return true;
        }

        /// <summary>
        /// 商品選択ボタン
        /// </summary>
        /// <param></param>
        private void buttonOrSelectProduct_Click(object sender, EventArgs e)
        {
            //営業所IDの入力チェック
            if (!InputCheck.SalesOfficeIDInputCheck(comboBoxOrSalesOfficeID.Text))
            {
                comboBoxOrSalesOfficeID.Focus();
                return;
            }
            //社員IDの入力チェック
            if (!InputCheck.EmployeeIDInputCheck(comboBoxOrEmployeeID.Text))
            {
                comboBoxOrEmployeeID.Focus();
                return;
            }
            //顧客IDの入力チェック
            if (!InputCheck.ClientIDInputCheck(comboBoxOrClientID.Text))
            {
                comboBoxOrClientID.Focus();
                return;
            }
            //ID以外の入力チェック
            if (!OrderInputCheck())
            {
                return;
            }

            //登録用受注情報をセット
            AddOrderData = OrderAddDataSet();
            //受注情報.受注ID登録用変数に受注IDをセット
            OrderID = OrderList.Count + 1;
            //受注詳細情報.受注詳細ID登録用変数に受注詳細IDをセット
            OrderDetailID = OrderDetailList.Count + 1;

            //画面遷移確認メッセージ
            if (DialogResult.OK == msg.MsgDsp("M7019"))             //OKを押した場合       
            {
                //商品選択画面に遷移する
                formproductselect.Visible = true;
                //自身を見えなくする
                this.Visible = false;
            }
        }

        /// <summary>
        /// 登録用受注情報をセットする
        /// </summary>
        /// <returns>T_Order</returns>
        private T_Order OrderAddDataSet()
        {
            return new T_Order
            {
                SoID = int.Parse(comboBoxOrSalesOfficeID.Text),
                EmID = int.Parse(comboBoxOrEmployeeID.Text),
                ClID = int.Parse(comboBoxOrClientID.Text),
                ClCharge = textBoxOrClientManager.Text,
                //OrDate=dateTimePickerOrder.Value,
                OrDate = DateTime.Parse(dateTimePickerOrder.Text),
                OrStateFlag = 0,
                OrFlag = 0
            };
        }

        /// <summary>
        /// 受注確定用データをセット
        /// </summary>
        /// <param name="OrderID"></param>
        private T_Order OrderConfirmDataSet(int OrderID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化
            T_Order OrderData = context.T_Orders.Single(OrData => OrData.OrID == OrderID);      //IDと一致しているデータの抽出

            context.Dispose();      //contextの解放
            return OrderData;       //抽出したデータを返す
        }

        /// <summary>
        /// 受注確定用注文データセット
        /// </summary>
        /// <param name="OrderData"></param>
        private T_Chumon ChumonAddDataSet(T_Order OrderData)
        {
            return new T_Chumon
            {
                SoID = OrderData.SoID,
                ClID = OrderData.ClID,
                OrID = OrderData.OrID,
                ChFlag = 0
            };
        }

        /// <summary>
        /// 受注確定用注文詳細データセット
        /// </summary>
        /// <param name="OrderDetail"></param>
        private T_ChumonDetail ChumonDetailAddDataSet(T_OrderDetail OrderDetail)
        {
            return new T_ChumonDetail
            {
                ChID = ChumonID,
                PrID = OrderDetail.PrID,
                ChQuantity = OrderDetail.OrQuantity
            };
        }

        /// <summary>
        /// 確定ボタン
        /// </summary>
        private void buttonOrOrderConfirm_Click(object sender, EventArgs e)
        {
            //受注IDの入力チェック
            if (!InputCheck.ClientIDInputCheck(comboBoxOrOrderID.Text))
            {
                comboBoxOrOrderID.Focus();
                return;
            }

            //確定確認メッセージ
            if (msg.MsgDsp("M7024") == DialogResult.Cancel)
            {
                return;
            }

            //例外処理
            try
            {
                var context = new SalesManagement_DevContext();     //DB接続用クラスのインスタンス化

                //受注IDをセット
                int OrID = int.Parse(comboBoxOrOrderID.Text);

                T_Order OrderData = OrderConfirmDataSet(OrID);         //受注IDと一致する受注データを取得する

                //非表示にされているデータの確認
                if (OrderData.OrFlag == 2)
                {
                    MessageBox.Show("非表示にされているデータの受注確定は出来ません", "確定確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //注文テーブルに既にデータが存在するか確認する
                if (!context.T_Chumons.Any(Chumon => Chumon.OrID == OrID))
                {
                    //注文IDのセット
                    ChumonID = ChumonList.Count + 1;

                    //T_Order OrderData = OrderConfirmDataSet(OrID);         //受注IDと一致する受注データを取得する
                    T_Chumon ChumonData = ChumonAddDataSet(OrderData);                  //登録用注文データをセットする
                    context.T_Chumons.Add(ChumonData);                      //注文テーブルに登録する

                    //データベースへの変更を確定する
                    context.SaveChanges();

                    //受注IDと一致する受注詳細情報を取得する
                    //int OrID = int.Parse(dataGridViewOrderMain.Rows[i].Cells[0].Value.ToString());
                    List<T_OrderDetail> OrderDetailAllData = context.T_OrderDetails.Where(OrderDetail => OrderDetail.OrID == OrID).ToList();

                    foreach (var OrderDetailData in OrderDetailAllData)          //取得した受注詳細情報分繰り返す
                    {
                        T_ChumonDetail ChumonDetailData = ChumonDetailAddDataSet(OrderDetailData);       //登録用注文詳細データをセットする
                        context.T_ChumonDetails.Add(ChumonDetailData);              //注文詳細データを登録する

                        //データベースへの変更を確定する
                        context.SaveChanges();
                    }

                    //状態フラグを0から1へ変更する
                    OrderData = context.T_Orders.Single(Order => Order.OrID == OrID);
                    OrderData.OrStateFlag = 1;

                    //データベースへの変更を確定する
                    context.SaveChanges();

                    //受注一覧表示用データの更新
                    OrderList = context.T_Orders.ToList();
                    //注文一覧表示用データの更新
                    ChumonList = context.T_Chumons.ToList();
                    ChumonDetailList = context.T_ChumonDetails.ToList();

                    //contextの解放
                    context.Dispose();

                    //確定完了メッセージの表示
                    msg.MsgDsp("M7025");

                    //データの再表示
                    ListOrder();
                }
                else
                {
                    //すでに確定されている場合
                    MessageBox.Show("入力された受注IDのデータは既に確定されいます", "確定確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("確定に失敗しました", "確定確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 受注非表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonOrNDisplay_Click(object sender, EventArgs e)
        {
            var context = new SalesManagement_DevContext();     //DB接続用クラスのインスタンス化

            DialogResult result = MessageBox.Show("非表示にした場合選択された商品の在庫は元に戻ります", "非表示確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            for (int i = 0; i < dataGridViewOrderMain.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewOrderMain.Rows[i].Cells[7].Value)                    //1行ずつチェックボックスがチェックされているかを判定する
                {
                    OrderAccess.DeleteOrder((int)dataGridViewOrderMain.Rows[i].Cells[0].Value);      //チェックされている場合その行の受注IDを引数に非表示機能モジュールを呼び出す

                    int OrID = (int)dataGridViewOrderMain.Rows[i].Cells[0].Value;       //受注IDをセット
                    List<T_OrderDetail> OrderDetailData = context.T_OrderDetails.Where(OrderDetail => OrderDetail.OrID == OrID).ToList();       //受注IDと一致する受注詳細データを取得

                    foreach(var OrderDetail in OrderDetailData)
                    {
                        int PrID = OrderDetail.PrID;            //商品IDをセット
                        T_Stock StockData = context.T_Stocks.Single(Stock => Stock.PrID == PrID);           //商品IDと一致する在庫データを抽出する

                        StockData.StQuantity = StockData.StQuantity + OrderDetail.OrQuantity;               //在庫数を更新

                        context.SaveChanges();          //更新を確定
                    }
                }
            }
            context.Dispose();      //contextを解放
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //顧客情報一覧表示用データを更新
            OrderList = OrderAccess.GetData();
            //顧客情報再表示
            ListOrder();
        }

        /// <summary>
        /// 受注非表示リスト
        /// </summary>
        /// <param></param>
        private void buttonOrNDisplayList_Click(object sender, EventArgs e)
        {
            DeleteListOrder();
        }

        ////////////////////////////////////////////////
        ///注文管理画面コード
        ////////////////////////////////////////////////



        /// <summary>
        /// 注文情報一覧表示モジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void ListChumon()
        {
            dataGridViewChumonMain.Rows.Clear();                        //データグリッドビューをクリアする
            dataGridViewChumonDetail.Rows.Clear();
            foreach (var ChumonData in ChumonList)
            {
                if (ChumonData.ChFlag == 0)                     //注文管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewChumonMain.Rows.Add(ChumonData.ChID, ChumonData.SoID, ChumonData.EmID, ChumonData.ClID, ChumonData.OrID, ChumonData.ChDate, Convert.ToBoolean(ChumonData.ChStateFlag),
                                                            Convert.ToBoolean(ChumonData.ChFlag), ChumonData.ChHidden);
                }
            }
        }

        /// <summary>
        /// 注文情報非表示リストモジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void DeleteListChumon()
        {
            dataGridViewChumonMain.Rows.Clear();                        //データグリッドビューをクリアする
            dataGridViewChumonDetail.Rows.Clear();
            foreach (var ChumonData in ChumonList)
            {
                if (ChumonData.ChFlag == 2)                     //注文管理フラグが2の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewChumonMain.Rows.Add(ChumonData.ChID, ChumonData.SoID, ChumonData.EmID, ChumonData.ClID, ChumonData.OrID, ChumonData.ChDate, Convert.ToBoolean(ChumonData.ChStateFlag),
                                                            Convert.ToBoolean(ChumonData.ChFlag), ChumonData.ChHidden);
                }
            }
        }

        /// <summary>
        /// 注文確定用のデータをセットする
        /// </summary>
        /// <returns>T_Chumon</returns>
        private T_Chumon ChumonDataSet()
        {
            return new T_Chumon
            {
                ChID = int.Parse(comboBoxChChumonID.Text),
                EmID = int.Parse(comboBoxChEmployeeID.Text),
                ChDate = dateTimePickerChumon.Value,
                ChStateFlag = 1
            };
        }

        /// <summary>
        /// 注文一覧表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonChDisplay_Click(object sender, EventArgs e)
        {
            ListChumon();
        }

        /// <summary>
        /// 注文情報検索ボタン
        /// </summary>
        /// <param></param>
        private void buttonChSearch_Click(object sender, EventArgs e)
        {
            dataGridViewChumonMain.Rows.Clear();                        //メインデータグリッドビューの内容を消去する
            dataGridViewChumonDetail.Rows.Clear();                        //詳細データグリッドビューの内容を消去する

            if (!string.IsNullOrEmpty(comboBoxChChumonID.Text))             //受注IDコンボボックスの空文字チェック
            {
                //売上IDの入力チェック
                if (!InputCheck.ChumonInputCheck(comboBoxChChumonID.Text))
                {
                    comboBoxChChumonID.Focus();
                    return;
                }
                foreach (var ChData in ChumonAccess.SearchChumon(1, comboBoxChChumonID.Text))           //注文IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewChumonMain.Rows.Add(ChData.ChID, ChData.SoID, ChData.EmID, ChData.ClID, ChData.OrID, ChData.ChDate, Convert.ToBoolean(ChData.ChStateFlag),
                                                        Convert.ToBoolean(ChData.ChFlag), ChData.ChHidden);
                }
                foreach (var ChumonDetailData in ChumonDetailList.Where(ChumonDetailList => ChumonDetailList.ChID == int.Parse(comboBoxChChumonID.Text)))      //注文IDで注文詳細情報を検索する
                {
                    M_Product product = ProductList.Single(Pr => Pr.PrID == ChumonDetailData.PrID);        //商品IDと一致する商品データを取得

                    //詳細データグリッドビューにデータを表示する
                    dataGridViewChumonDetail.Rows.Add(ChumonDetailData.ChDetailID, ChumonDetailData.ChID, ChumonDetailData.PrID, product.PrName, ChumonDetailData.ChQuantity);
                }
                labelChSearchTitle.Text = "注文IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxChSalesOfficeID.Text))       //営業所IDコンボボックスの空文字チェック
            {
                //社員IDの入力チェック
                if (!InputCheck.SalesOfficeIDInputCheck(comboBoxChSalesOfficeID.Text))
                {
                    comboBoxChSalesOfficeID.Focus();
                    return;
                }
                foreach (var ChData in ChumonAccess.SearchChumon(2, comboBoxChSalesOfficeID.Text))           //営業所IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewChumonMain.Rows.Add(ChData.ChID, ChData.SoID, ChData.EmID, ChData.ClID, ChData.OrID, ChData.ChDate, Convert.ToBoolean(ChData.ChStateFlag),
                                                        Convert.ToBoolean(ChData.ChFlag), ChData.ChHidden);
                }
                labelChSearchTitle.Text = "営業所IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxChEmployeeID.Text))   //社員IDコンボボックスの空文字チェック
            {
                //社員IDの入力チェック
                if (!InputCheck.EmployeeIDInputCheck(comboBoxChEmployeeID.Text))
                {
                    comboBoxChEmployeeID.Focus();
                    return;
                }
                foreach (var ChData in ChumonAccess.SearchChumon(3, comboBoxChEmployeeID.Text))      //社員IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewChumonMain.Rows.Add(ChData.ChID, ChData.SoID, ChData.EmID, ChData.ClID, ChData.OrID, ChData.ChDate, Convert.ToBoolean(ChData.ChStateFlag),
                                                        Convert.ToBoolean(ChData.ChFlag), ChData.ChHidden);
                }
                labelChSearchTitle.Text = "社員IDで検索しました";         //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxChClientID.Text))
            {
                //顧客IDの入力チェック
                if (!InputCheck.ClientIDInputCheck(comboBoxChClientID.Text))
                {
                    comboBoxChClientID.Focus();
                    return;
                }
                foreach (var ChData in ChumonAccess.SearchChumon(4, comboBoxChClientID.Text))      //顧客IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewChumonMain.Rows.Add(ChData.ChID, ChData.SoID, ChData.EmID, ChData.ClID, ChData.OrID, ChData.ChDate, Convert.ToBoolean(ChData.ChStateFlag),
                                                        Convert.ToBoolean(ChData.ChFlag), ChData.ChHidden);
                }
                labelChSearchTitle.Text = "顧客IDで検索しました";         //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxChOrderID.Text))
            {
                //受注IDの入力チェック
                if (!InputCheck.OrderInputCheck(comboBoxChOrderID.Text))
                {
                    comboBoxChOrderID.Focus();
                    return;
                }
                foreach (var ChData in ChumonAccess.SearchChumon(5, comboBoxChOrderID.Text))      //受注IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewChumonMain.Rows.Add(ChData.ChID, ChData.SoID, ChData.EmID, ChData.ClID, ChData.OrID, ChData.ChDate, Convert.ToBoolean(ChData.ChStateFlag),
                                                        Convert.ToBoolean(ChData.ChFlag), ChData.ChHidden);
                }
                labelChSearchTitle.Text = "受注IDで検索しました";         //何で検索したかを表示
            }
        }

        /// <summary>
        /// 注文確定用出庫データセット
        /// </summary>
        /// <param name="ChumonData"></param>
        private T_Syukko SyukkoAddDataSet(T_Chumon ChumonData)
        {
            return new T_Syukko
            {
                ClID = ChumonData.ClID,
                SoID = ChumonData.SoID,
                OrID = ChumonData.OrID,
                SyFlag = 0
            };
        }

        /// <summary>
        /// 注文確定用出庫詳細データセット
        /// </summary>
        /// <param name="ChumonDetail"></param>
        private T_SyukkoDetail SyukkoDetailAddDataSet(T_ChumonDetail ChumonDetail)
        {
            return new T_SyukkoDetail
            {
                SyID = SyukkoID,
                PrID = ChumonDetail.PrID,
                SyQuantity = ChumonDetail.ChQuantity
            };
        }

        /// <summary>
        /// 注文情報確定ボタン
        /// </summary>
        /// <param></param>
        private void buttonChChumonConfirm_Click(object sender, EventArgs e)
        {
            //注文IDの入力チェック
            if (!InputCheck.ChumonInputCheck(comboBoxChChumonID.Text))
            {
                comboBoxChChumonID.Focus();
                return;
            }
            //社員IDの入力チェック
            if (!InputCheck.EmployeeIDInputCheck(comboBoxChEmployeeID.Text))
            {
                comboBoxChEmployeeID.Focus();
                return;
            }

            //注文確定確認メッセージ
            if (msg.MsgDsp("M8007") == DialogResult.Cancel)
            {
                return;
            }

            //例外処理
            try
            {
                var context = new SalesManagement_DevContext();     //DB接続用クラスのインスタンス化

                //受注IDをセット
                int ChID = int.Parse(comboBoxChChumonID.Text);

                //↓存在確認用の注文情報を取得
                T_Chumon ChumonData = context.T_Chumons.Single(Chumon => Chumon.ChID == ChID);         //受注IDと一致する受注データを取得する

                //注文テーブルに既にデータが存在するか確認する
                if (!context.T_Syukkos.Any(Syukko => Syukko.OrID == ChumonData.OrID))
                {
                    //注文IDのセット
                    SyukkoID = SyukkoList.Count + 1;

                    T_Syukko SyukkoData = SyukkoAddDataSet(ChumonData);                  //登録用出庫データをセットする
                    context.T_Syukkos.Add(SyukkoData);                      //出庫テーブルに登録する

                    //データベースへの変更を確定する
                    context.SaveChanges();

                    //注文IDと一致する注文詳細情報を取得する
                    List<T_ChumonDetail> ChumonDetailAllData = context.T_ChumonDetails.Where(ChumonDetail => ChumonDetail.ChID == ChID).ToList();

                    foreach (var ChumonDetailData in ChumonDetailAllData)          //取得した注文詳細情報分繰り返す
                    {
                        T_SyukkoDetail SyukkoDetailData = SyukkoDetailAddDataSet(ChumonDetailData);       //登録用出庫詳細データをセットする
                        context.T_SyukkoDetails.Add(SyukkoDetailData);              //出庫詳細データを登録する

                        //データベースへの変更を確定する
                        context.SaveChanges();
                    }

                    //注文状態フラグ, 社員ID, 確定年月日の更新
                    ChumonData.ChStateFlag = 1;
                    ChumonData.EmID = int.Parse(comboBoxChEmployeeID.Text);
                    ChumonData.ChDate = dateTimePickerChumon.Value;

                    //データベースへの変更を確定する
                    context.SaveChanges();

                    //注文一覧表示用データの更新
                    ChumonList = ChumonAccess.GetData();

                    //出庫一覧表示用データの更新
                    SyukkoList = context.T_Syukkos.ToList();
                    SyukkoDetailList = context.T_SyukkoDetails.ToList();

                    //確定完了メッセージの表示
                    msg.MsgDsp("M8008");

                    //データの再表示
                    ListChumon();
                }
                else
                {
                    //すでに確定されている場合
                    MessageBox.Show("入力された注文IDのデータは既に確定されています", "確定確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //contextの解放
                context.Dispose();
            }
            catch
            {
                MessageBox.Show("確定に失敗しました", "確定確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 注文情報非表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonChNDisplay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewChumonMain.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewChumonMain.Rows[i].Cells[7].Value)                    //1行ずつチェックボックスがチェックされているかを判定する
                {
                    ChumonAccess.DeleteChumon((int)dataGridViewChumonMain.Rows[i].Cells[0].Value);      //チェックされている場合その行の注文IDを引数に非表示機能モジュールを呼び出す
                }
            }
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //注文情報一覧表示用データを更新
            ChumonList = ChumonAccess.GetData();
            //注文情報再表示
            ListChumon();
        }

        /// <summary>
        /// 注文情報非表示リストボタン
        /// </summary>
        /// <param></param>
        private void buttonChNDisplayList_Click(object sender, EventArgs e)
        {
            DeleteListChumon();
        }

        ////////////////////////////////////////////////
        ///出庫管理画面コード
        ////////////////////////////////////////////////

        /// 出庫情報一覧表示モジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void ListSyukko()
        {
            dataGridViewSyukkoMain.Rows.Clear();                        //データグリッドビューをクリアする
            dataGridViewSyukkoDetail.Rows.Clear();
            foreach (var SyukkoData in SyukkoList)
            {
                if (SyukkoData.SyFlag == 0)                     //出庫管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewSyukkoMain.Rows.Add(SyukkoData.SyID, SyukkoData.EmID, SyukkoData.ClID, SyukkoData.SoID, SyukkoData.OrID, SyukkoData.SyDate,
                                                        Convert.ToBoolean(SyukkoData.SyStateFlag), Convert.ToBoolean(SyukkoData.SyFlag), SyukkoData.SyHidden);
                }
            }
        }

        /// <summary>
        /// 出庫情報非表示リストモジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void DeleteListSyukko()
        {
            dataGridViewSyukkoMain.Rows.Clear();                        //データグリッドビューをクリアする
            dataGridViewSyukkoDetail.Rows.Clear();
            foreach (var SyukkoData in SyukkoList)
            {
                if (SyukkoData.SyFlag == 2)                     //出庫管理フラグが2の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewSyukkoMain.Rows.Add(SyukkoData.SyID, SyukkoData.EmID, SyukkoData.ClID, SyukkoData.SoID, SyukkoData.OrID, SyukkoData.SyDate,
                                                        Convert.ToBoolean(SyukkoData.SyStateFlag), Convert.ToBoolean(SyukkoData.SyFlag), SyukkoData.SyHidden);
                }
            }
        }

        /// <summary>
        /// 出庫情報一覧表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonSyDisplay_Click(object sender, EventArgs e)
        {
            ListSyukko();
        }

        private void buttonSySearch_Click(object sender, EventArgs e)
        {
            dataGridViewSyukkoMain.Rows.Clear();                        //メインデータグリッドビューの内容を消去する
            dataGridViewSyukkoDetail.Rows.Clear();                        //詳細データグリッドビューの内容を消去する

            if (!string.IsNullOrEmpty(comboBoxSySyukkoID.Text))             //出庫IDコンボボックスの空文字チェック
            {
                //出庫IDの入力チェック
                if (!InputCheck.SyukkoInputCheck(comboBoxSySyukkoID.Text))
                {
                    comboBoxSySyukkoID.Focus();
                    return;
                }
                foreach (var SyData in SyukkoAccess.SearchSyukko(1, comboBoxSySyukkoID.Text))           //出庫IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewSyukkoMain.Rows.Add(SyData.SyID, SyData.EmID, SyData.ClID, SyData.SoID, SyData.OrID, SyData.SyDate, Convert.ToBoolean(SyData.SyStateFlag),
                                                        Convert.ToBoolean(SyData.SyFlag), SyData.SyHidden);
                }
                foreach (var SyukkoDetailData in SyukkoDetailList.Where(SyukkoDetailList => SyukkoDetailList.SyID == int.Parse(comboBoxSySyukkoID.Text)))      //出庫IDで出庫詳細情報を検索する
                {
                    M_Product product = ProductList.Single(Pr => Pr.PrID == SyukkoDetailData.PrID);        //商品IDと一致する商品データを取得

                    //詳細データグリッドビューにデータを表示する
                    dataGridViewSyukkoDetail.Rows.Add(SyukkoDetailData.SyDetailID, SyukkoDetailData.SyID, SyukkoDetailData.PrID, product.PrName, SyukkoDetailData.SyQuantity);
                }
                labelSySearchTitle.Text = "出庫IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxSyEmployeeID.Text))       //営業所IDコンボボックスの空文字チェック
            {
                //社員IDの入力チェック
                if (!InputCheck.EmployeeIDInputCheck(comboBoxSyEmployeeID.Text))
                {
                    comboBoxSyEmployeeID.Focus();
                    return;
                }
                foreach (var SyData in SyukkoAccess.SearchSyukko(2, comboBoxSyEmployeeID.Text))           //社員IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewSyukkoMain.Rows.Add(SyData.SyID, SyData.EmID, SyData.ClID, SyData.SoID, SyData.OrID, SyData.SyDate, Convert.ToBoolean(SyData.SyStateFlag),
                                                        Convert.ToBoolean(SyData.SyFlag), SyData.SyHidden);
                }
                labelSySearchTitle.Text = "社員IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxSyClientID.Text))   //顧客IDコンボボックスの空文字チェック
            {
                //社員IDの入力チェック
                if (!InputCheck.ClientIDInputCheck(comboBoxSyClientID.Text))
                {
                    comboBoxSyClientID.Focus();
                    return;
                }
                foreach (var SyData in SyukkoAccess.SearchSyukko(3, comboBoxSyClientID.Text))      //顧客IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewSyukkoMain.Rows.Add(SyData.SyID, SyData.EmID, SyData.ClID, SyData.SoID, SyData.OrID, SyData.SyDate, Convert.ToBoolean(SyData.SyStateFlag),
                                                        Convert.ToBoolean(SyData.SyFlag), SyData.SyHidden);
                }
                labelSySearchTitle.Text = "顧客IDで検索しました";         //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxSySalesOfficeID.Text))
            {
                //顧客IDの入力チェック
                if (!InputCheck.SalesOfficeIDInputCheck(comboBoxSySalesOfficeID.Text))
                {
                    comboBoxSySalesOfficeID.Focus();
                    return;
                }
                foreach (var SyData in SyukkoAccess.SearchSyukko(4, comboBoxSySalesOfficeID.Text))      //営業所IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewSyukkoMain.Rows.Add(SyData.SyID, SyData.EmID, SyData.ClID, SyData.SoID, SyData.OrID, SyData.SyDate, Convert.ToBoolean(SyData.SyStateFlag),
                                                        Convert.ToBoolean(SyData.SyFlag), SyData.SyHidden);
                }
                labelSySearchTitle.Text = "営業所IDで検索しました";         //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxSyOrderID.Text))
            {
                //受注IDの入力チェック
                if (!InputCheck.OrderInputCheck(comboBoxSyOrderID.Text))
                {
                    comboBoxSyOrderID.Focus();
                    return;
                }
                foreach (var SyData in SyukkoAccess.SearchSyukko(5, comboBoxSyOrderID.Text))      //受注IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewSyukkoMain.Rows.Add(SyData.SyID, SyData.EmID, SyData.ClID, SyData.SoID, SyData.OrID, SyData.SyDate, Convert.ToBoolean(SyData.SyStateFlag),
                                                        Convert.ToBoolean(SyData.SyFlag), SyData.SyHidden);
                }
                labelSySearchTitle.Text = "受注IDで検索しました";         //何で検索したかを表示
            }
        }

        /// <summary>
        /// 出庫確定用入荷データセット
        /// </summary>
        /// <param name="SyukkoData"></param>
        private T_Arrival ArrivalAddDataSet(T_Syukko SyukkoData)
        {
            return new T_Arrival
            {
                ClID = SyukkoData.ClID,
                SoID = SyukkoData.SoID,
                OrID = SyukkoData.OrID,
                ArFlag = 0
            };
        }

        /// <summary>
        /// 出庫確定用入荷詳細データセット
        /// </summary>
        /// <param name="SyukkoDetail"></param>
        private T_ArrivalDetail ArrivalDetailAddDataSet(T_SyukkoDetail SyukkoDetail)
        {
            return new T_ArrivalDetail
            {
                ArID = ArrivalID,
                PrID = SyukkoDetail.PrID,
                ArQuantity = SyukkoDetail.SyQuantity
            };
        }

        /// <summary>
        /// 出庫確定ボタン
        /// </summary>
        /// <param></param>
        private void buttonSySyukkoConfirm_Click(object sender, EventArgs e)
        {
            //出庫IDの入力チェック
            if (!InputCheck.SyukkoInputCheck(comboBoxSySyukkoID.Text))
            {
                comboBoxSySyukkoID.Focus();
                return;
            }
            //社員IDの入力チェック
            if (!InputCheck.EmployeeIDInputCheck(comboBoxSyEmployeeID.Text))
            {
                comboBoxSyEmployeeID.Focus();
                return;
            }

            //出庫確定確認メッセージ
            if (msg.MsgDsp("M11004") == DialogResult.Cancel)
            {
                return;
            }

            //例外処理
            try
            {
                var context = new SalesManagement_DevContext();     //DB接続用クラスのインスタンス化

                //出庫IDをセット
                int SyID = int.Parse(comboBoxSySyukkoID.Text);

                //↓存在確認用の出庫情報を取得
                T_Syukko SyukkoData = context.T_Syukkos.Single(Syukko => Syukko.SyID == SyID);         //出庫IDと一致する出庫データを取得する

                //出庫テーブルに既にデータが存在するか確認する
                if (!context.T_Arrivals.Any(Arrival => Arrival.OrID == SyukkoData.OrID))
                {
                    //入荷IDのセット
                    ArrivalID = ArrivalList.Count + 1;

                    T_Arrival ArrivalData = ArrivalAddDataSet(SyukkoData);                  //登録用入荷データをセットする
                    context.T_Arrivals.Add(ArrivalData);                      //入荷テーブルに登録する

                    //データベースへの変更を確定する
                    context.SaveChanges();


                    //出庫IDと一致する出庫詳細情報を取得する
                    List<T_SyukkoDetail> SyukkoDetailAllData = context.T_SyukkoDetails.Where(SyukkoDetail => SyukkoDetail.SyID == SyID).ToList();

                    foreach (var SyukkoDetailData in SyukkoDetailAllData)          //取得した出庫詳細情報分繰り返す
                    {
                        T_ArrivalDetail ArrivalDetailData = ArrivalDetailAddDataSet(SyukkoDetailData);       //登録用入荷詳細データをセットする
                        context.T_ArrivalDetails.Add(ArrivalDetailData);              //入荷詳細データを登録する

                        //データベースへの変更を確定する
                        context.SaveChanges();
                    }


                    //出庫状態フラグ, 社員ID, 確定年月日の更新
                    SyukkoData.SyStateFlag = 1;
                    SyukkoData.EmID = int.Parse(comboBoxSyEmployeeID.Text);
                    SyukkoData.SyDate = dateTimePickerSyukko.Value;

                    //データベースへの変更を確定する
                    context.SaveChanges();

                    //出庫一覧表示用データの更新
                    SyukkoList = SyukkoAccess.GetData();

                    //入荷一覧表示用データの更新
                    ArrivalList = context.T_Arrivals.ToList();
                    ArrivalDetailList = context.T_ArrivalDetails.ToList();

                    //確定完了メッセージの表示
                    msg.MsgDsp("M11005");

                    //データの再表示
                    ListSyukko();
                }
                else
                {
                    //すでに確定されている場合
                    MessageBox.Show("入力された出庫IDのデータは既に確定されいます", "確定確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //contextの解放
                context.Dispose();
            }
            catch
            {
                MessageBox.Show("確定に失敗しました", "確定確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 出庫非表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonSyNDisplay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewSyukkoMain.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewSyukkoMain.Rows[i].Cells[7].Value)                    //1行ずつチェックボックスがチェックされているかを判定する
                {
                    SyukkoAccess.DeleteSyukko((int)dataGridViewSyukkoMain.Rows[i].Cells[0].Value);      //チェックされている場合その行の出庫IDを引数に非表示機能モジュールを呼び出す
                }
            }
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //出庫情報一覧表示用データを更新
            SyukkoList = SyukkoAccess.GetData();
            //出庫情報再表示
            ListSyukko();
        }

        /// <summary>
        /// 出庫非表示リストボタン
        /// </summary>
        /// <param></param>
        private void buttonSyNDisplayList_Click(object sender, EventArgs e)
        {
            DeleteListSyukko();
        }

        //////////////////////////////////////
        ///入荷管理画面コード
        /////////////////////////////////////


        /// 入荷情報一覧表示モジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void ListArrival()
        {
            dataGridViewArrivalMain.Rows.Clear();                        //データグリッドビューをクリアする
            dataGridViewArrivalDetail.Rows.Clear();
            foreach (var ArrivalData in ArrivalList)
            {
                if (ArrivalData.ArFlag == 0)                     //入荷管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewArrivalMain.Rows.Add(ArrivalData.ArID, ArrivalData.SoID, ArrivalData.EmID, ArrivalData.ClID, ArrivalData.OrID, ArrivalData.ArDate,
                                                        Convert.ToBoolean(ArrivalData.ArStateFlag), Convert.ToBoolean(ArrivalData.ArFlag), ArrivalData.ArHidden);
                }
            }
        }

        /// <summary>
        /// 入荷情報非表示リストモジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void DeleteListArrival()
        {
            dataGridViewArrivalMain.Rows.Clear();                        //データグリッドビューをクリアする
            dataGridViewArrivalDetail.Rows.Clear();
            foreach (var ArrivalData in ArrivalList)
            {
                if (ArrivalData.ArFlag == 2)                     //入荷管理フラグが2の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewArrivalMain.Rows.Add(ArrivalData.ArID, ArrivalData.SoID, ArrivalData.EmID, ArrivalData.ClID, ArrivalData.OrID, ArrivalData.ArDate,
                                                        Convert.ToBoolean(ArrivalData.ArStateFlag), Convert.ToBoolean(ArrivalData.ArFlag), ArrivalData.ArHidden);
                }
            }
        }

        /// <summary>
        /// 入荷一覧表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonArDisplay_Click(object sender, EventArgs e)
        {
            ListArrival();
        }

        private void buttonArSearch_Click(object sender, EventArgs e)
        {
            dataGridViewArrivalMain.Rows.Clear();                        //メインデータグリッドビューの内容を消去する
            dataGridViewArrivalDetail.Rows.Clear();                        //詳細データグリッドビューの内容を消去する

            if (!string.IsNullOrEmpty(comboBoxArArrivalID.Text))             //入荷IDコンボボックスの空文字チェック
            {
                //入荷IDの入力チェック
                if (!InputCheck.ArrivalInputCheck(comboBoxArArrivalID.Text))
                {
                    comboBoxArArrivalID.Focus();
                    return;
                }
                foreach (var ArrivalData in ArrivalAccess.SearchArrival(1, comboBoxArArrivalID.Text))           //入荷IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewArrivalMain.Rows.Add(ArrivalData.ArID, ArrivalData.SoID, ArrivalData.EmID, ArrivalData.ClID, ArrivalData.OrID, ArrivalData.ArDate,
                                                        Convert.ToBoolean(ArrivalData.ArStateFlag), Convert.ToBoolean(ArrivalData.ArFlag), ArrivalData.ArHidden);
                }
                foreach (var ArrivalDetailData in ArrivalDetailList.Where(ArrivalDetailList => ArrivalDetailList.ArID == int.Parse(comboBoxArArrivalID.Text)))      //入荷IDで入荷詳細情報を検索する
                {
                    M_Product product = ProductList.Single(Pr => Pr.PrID == ArrivalDetailData.PrID);        //商品IDと一致する商品データを取得

                    //詳細データグリッドビューにデータを表示する
                    dataGridViewArrivalDetail.Rows.Add(ArrivalDetailData.ArDetailID, ArrivalDetailData.ArID, ArrivalDetailData.PrID, product.PrName, ArrivalDetailData.ArQuantity);
                }
                labelArSearchTitle.Text = "入荷IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxArSalesOfficeID.Text))       //営業所IDコンボボックスの空文字チェック
            {
                //社員IDの入力チェック
                if (!InputCheck.SalesOfficeIDInputCheck(comboBoxArSalesOfficeID.Text))
                {
                    comboBoxArSalesOfficeID.Focus();
                    return;
                }
                foreach (var ArrivalData in ArrivalAccess.SearchArrival(2, comboBoxArSalesOfficeID.Text))           //営業所IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewArrivalMain.Rows.Add(ArrivalData.ArID, ArrivalData.SoID, ArrivalData.EmID, ArrivalData.ClID, ArrivalData.OrID, ArrivalData.ArDate,
                                                        Convert.ToBoolean(ArrivalData.ArStateFlag), Convert.ToBoolean(ArrivalData.ArFlag), ArrivalData.ArHidden);
                }
                labelArSearchTitle.Text = "営業所IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxArEmployeeID.Text))   //社員IDコンボボックスの空文字チェック
            {
                //社員IDの入力チェック
                if (!InputCheck.EmployeeIDInputCheck(comboBoxArEmployeeID.Text))
                {
                    comboBoxArEmployeeID.Focus();
                    return;
                }
                foreach (var ArrivalData in ArrivalAccess.SearchArrival(3, comboBoxArEmployeeID.Text))      //社員IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewArrivalMain.Rows.Add(ArrivalData.ArID, ArrivalData.SoID, ArrivalData.EmID, ArrivalData.ClID, ArrivalData.OrID, ArrivalData.ArDate,
                                                        Convert.ToBoolean(ArrivalData.ArStateFlag), Convert.ToBoolean(ArrivalData.ArFlag), ArrivalData.ArHidden);
                }
                labelArSearchTitle.Text = "社員IDで検索しました";         //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxArClientID.Text))
            {
                //顧客IDの入力チェック
                if (!InputCheck.ClientIDInputCheck(comboBoxArClientID.Text))
                {
                    comboBoxArClientID.Focus();
                    return;
                }
                foreach (var ArrivalData in ArrivalAccess.SearchArrival(4, comboBoxArClientID.Text))      //顧客IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewArrivalMain.Rows.Add(ArrivalData.ArID, ArrivalData.SoID, ArrivalData.EmID, ArrivalData.ClID, ArrivalData.OrID, ArrivalData.ArDate,
                                                        Convert.ToBoolean(ArrivalData.ArStateFlag), Convert.ToBoolean(ArrivalData.ArFlag), ArrivalData.ArHidden);
                }
                labelArSearchTitle.Text = "顧客IDで検索しました";         //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxArOrderID.Text))
            {
                //受注IDの入力チェック
                if (!InputCheck.OrderInputCheck(comboBoxArOrderID.Text))
                {
                    comboBoxArOrderID.Focus();
                    return;
                }
                foreach (var ArrivalData in ArrivalAccess.SearchArrival(5, comboBoxArOrderID.Text))      //受注IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewArrivalMain.Rows.Add(ArrivalData.ArID, ArrivalData.SoID, ArrivalData.EmID, ArrivalData.ClID, ArrivalData.OrID, ArrivalData.ArDate,
                                                        Convert.ToBoolean(ArrivalData.ArStateFlag), Convert.ToBoolean(ArrivalData.ArFlag), ArrivalData.ArHidden);
                }
                labelArSearchTitle.Text = "受注IDで検索しました";         //何で検索したかを表示
            }
        }

        /// <summary>
        /// 入荷確定用出荷データセット
        /// </summary>
        /// <param name="ArrivalData"></param>
        private T_Shipment ShipmentAddDataSet(T_Arrival ArrivalData)
        {
            return new T_Shipment
            {
                ClID = ArrivalData.ClID,
                SoID = ArrivalData.SoID,
                OrID = ArrivalData.OrID,
                ShFlag = 0
            };
        }

        /// <summary>
        /// 入荷確定用出荷詳細データセット
        /// </summary>
        /// <param name="ArrivalDetail"></param>
        private T_ShipmentDetail ShipmentDetailAddDataSet(T_ArrivalDetail ArrivalDetail)
        {
            return new T_ShipmentDetail
            {
                ShID = ShipmentID,
                PrID = ArrivalDetail.PrID,
                ShDquantity = ArrivalDetail.ArQuantity
            };
        }

        /// <summary>
        /// 入荷確定ボタン
        /// </summary>
        /// <param></param>
        private void buttonArArrivalConfirm_Click(object sender, EventArgs e)
        {
            //入荷IDの入力チェック
            if (!InputCheck.ArrivalInputCheck(comboBoxArArrivalID.Text))
            {
                comboBoxArArrivalID.Focus();
                return;
            }
            //社員IDの入力チェック
            if (!InputCheck.EmployeeIDInputCheck(comboBoxArEmployeeID.Text))
            {
                comboBoxArEmployeeID.Focus();
                return;
            }

            //入荷確定確認メッセージ
            if (msg.MsgDsp("M12004") == DialogResult.Cancel)
            {
                return;
            }

            //例外処理
            try
            {
                var context = new SalesManagement_DevContext();     //DB接続用クラスのインスタンス化

                //入荷IDをセット
                int ArID = int.Parse(comboBoxArArrivalID.Text);

                //↓存在確認用の出庫情報を取得
                T_Arrival ArrivalData = context.T_Arrivals.Single(Arrival => Arrival.ArID == ArID);         //入荷IDと一致する入荷データを取得する

                //出荷テーブルに既にデータが存在するか確認する
                if (!context.T_Shipments.Any(Shipment => Shipment.OrID == ArrivalData.OrID))
                {
                    //出荷IDのセット
                    ShipmentID = ShipmentList.Count + 1;

                    T_Shipment ShipmentData = ShipmentAddDataSet(ArrivalData);                  //登録用出荷データをセットする
                    context.T_Shipments.Add(ShipmentData);                      //出荷テーブルに登録する

                    //データベースへの変更を確定する
                    context.SaveChanges();


                    //出荷IDと一致する出荷詳細情報を取得する
                    List<T_ArrivalDetail> ArrivalDetailAllData = context.T_ArrivalDetails.Where(ArrivalDetail => ArrivalDetail.ArID == ArID).ToList();

                    foreach (var ArrivalDetailData in ArrivalDetailAllData)          //取得した入荷詳細情報分繰り返す
                    {
                        T_ShipmentDetail ShipmentDetailData = ShipmentDetailAddDataSet(ArrivalDetailData);       //登録用出荷詳細データをセットする
                        context.T_ShipmentDetails.Add(ShipmentDetailData);              //出荷詳細データを登録する

                        //データベースへの変更を確定する
                        context.SaveChanges();
                    }


                    //入荷状態フラグ, 社員ID, 確定年月日の更新
                    ArrivalData.ArStateFlag = 1;
                    ArrivalData.EmID = int.Parse(comboBoxArEmployeeID.Text);
                    ArrivalData.ArDate = dateTimePickerAr.Value;

                    //データベースへの変更を確定する
                    context.SaveChanges();

                    //入荷一覧表示用データの更新
                    ArrivalList = ArrivalAccess.GetData();

                    //出荷一覧表示用データの更新
                    ShipmentList = context.T_Shipments.ToList();
                    ShipmentDetailList = context.T_ShipmentDetails.ToList();

                    //確定完了メッセージの表示
                    msg.MsgDsp("M12005");

                    //データの再表示
                    ListArrival();
                }
                else
                {
                    //すでに確定されている場合
                    MessageBox.Show("入力された入荷IDのデータは既に確定されいます", "確定確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //contextの解放
                context.Dispose();
            }
            catch
            {
                MessageBox.Show("確定に失敗しました", "確定確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 入荷非表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonArNDisplay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewArrivalMain.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewArrivalMain.Rows[i].Cells[7].Value)                    //1行ずつチェックボックスがチェックされているかを判定する
                {
                    ArrivalAccess.DeleteArrival((int)dataGridViewArrivalMain.Rows[i].Cells[0].Value);      //チェックされている場合その行の入荷IDを引数に非表示機能モジュールを呼び出す
                }
            }
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //注文情報一覧表示用データを更新
            ArrivalList = ArrivalAccess.GetData();
            //注文情報再表示
            ListArrival();
        }

        /// <summary>
        /// 入荷非表示リストボタン
        /// </summary>
        /// <param></param>
        private void buttonArNDisplayList_Click(object sender, EventArgs e)
        {
            DeleteListArrival();
        }




        /// <summary>
        /// 出荷情報一覧表示モジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void ListShipment()
        {
            dataGridViewShipmentMain.Rows.Clear();                        //データグリッドビューをクリアする
            dataGridViewShipmentDetail.Rows.Clear();
            foreach (var ShData in ShipmentList)
            {
                if (ShData.ShFlag == 0)                     //出荷管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewShipmentMain.Rows.Add(ShData.ShID, ShData.ClID, ShData.EmID, ShData.SoID, ShData.OrID, Convert.ToBoolean(ShData.ShStateFlag), ShData.ShFinishDate,
                                                            Convert.ToBoolean(ShData.ShFlag), ShData.ShHidden);
                }
            }
        }

        /// <summary>
        /// 出荷情報非表示リストモジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void DeleteListShipment()
        {
            dataGridViewShipmentMain.Rows.Clear();                        //データグリッドビューをクリアする
            dataGridViewShipmentDetail.Rows.Clear();
            foreach (var ShData in ShipmentList)
            {
                if (ShData.ShFlag == 2)                     //出荷管理フラグが2の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewShipmentMain.Rows.Add(ShData.ShID, ShData.ClID, ShData.EmID, ShData.SoID, ShData.OrID, Convert.ToBoolean(ShData.ShStateFlag), ShData.ShFinishDate,
                                                            Convert.ToBoolean(ShData.ShFlag), ShData.ShHidden);
                }
            }
        }

        /// <summary>
        /// 出荷一覧表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonShDisplay_Click(object sender, EventArgs e)
        {
            ListShipment();
        }

        /// <summary>
        /// 出荷検索ボタン
        /// </summary>
        /// <param></param>
        private void buttonShSearch_Click(object sender, EventArgs e)
        {
            dataGridViewShipmentMain.Rows.Clear();                        //メインデータグリッドビューの内容を消去する
            dataGridViewShipmentDetail.Rows.Clear();                        //詳細データグリッドビューの内容を消去する

            if (!string.IsNullOrEmpty(comboBoxShShipmentID.Text))             //出荷IDコンボボックスの空文字チェック
            {
                //売上IDの入力チェック
                if (!InputCheck.ShipmentInputCheck(comboBoxShShipmentID.Text))
                {
                    comboBoxShShipmentID.Focus();
                    return;
                }
                foreach (var ShData in ShipmentAccess.SearchShipment(1, comboBoxShShipmentID.Text))           //出荷IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewShipmentMain.Rows.Add(ShData.ShID, ShData.ClID, ShData.EmID, ShData.SoID, ShData.OrID, Convert.ToBoolean(ShData.ShStateFlag), ShData.ShFinishDate,
                                                            Convert.ToBoolean(ShData.ShFlag), ShData.ShHidden);
                }
                foreach (var ShipmentDetailData in ShipmentDetailList.Where(ShipmentDetailList => ShipmentDetailList.ShID == int.Parse(comboBoxShShipmentID.Text)))      //出荷IDで出荷詳細情報を検索する
                {
                    M_Product product = ProductList.Single(Pr => Pr.PrID == ShipmentDetailData.PrID);        //商品IDと一致する商品データを取得

                    //詳細データグリッドビューにデータを表示する
                    dataGridViewShipmentDetail.Rows.Add(ShipmentDetailData.ShDetailID, ShipmentDetailData.ShID, ShipmentDetailData.PrID, product.PrName, ShipmentDetailData.ShDquantity);
                }
                labelShSearchTitle.Text = "出荷IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxShClientID.Text))       //顧客IDコンボボックスの空文字チェック
            {
                //顧客IDの入力チェック
                if (!InputCheck.ClientIDInputCheck(comboBoxShClientID.Text))
                {
                    comboBoxShClientID.Focus();
                    return;
                }
                foreach (var ShData in ShipmentAccess.SearchShipment(2, comboBoxShShipmentID.Text))           //顧客IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewShipmentMain.Rows.Add(ShData.ShID, ShData.ClID, ShData.EmID, ShData.SoID, ShData.OrID, Convert.ToBoolean(ShData.ShStateFlag), ShData.ShFinishDate,
                                                            Convert.ToBoolean(ShData.ShFlag), ShData.ShHidden);
                }
                labelShSearchTitle.Text = "顧客IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxShEmployeeID.Text))   //社員IDコンボボックスの空文字チェック
            {
                //社員IDの入力チェック
                if (!InputCheck.EmployeeIDInputCheck(comboBoxShEmployeeID.Text))
                {
                    comboBoxShEmployeeID.Focus();
                    return;
                }
                foreach (var ShData in ShipmentAccess.SearchShipment(3, comboBoxShEmployeeID.Text))      //社員IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewShipmentMain.Rows.Add(ShData.ShID, ShData.ClID, ShData.EmID, ShData.SoID, ShData.OrID, Convert.ToBoolean(ShData.ShStateFlag), ShData.ShFinishDate,
                                                            Convert.ToBoolean(ShData.ShFlag), ShData.ShHidden);
                }
                labelShSearchTitle.Text = "社員IDで検索しました";         //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxShSalesOfficeID.Text))
            {
                //営業所IDの入力チェック
                if (!InputCheck.SalesOfficeIDInputCheck(comboBoxShSalesOfficeID.Text))
                {
                    comboBoxShSalesOfficeID.Focus();
                    return;
                }
                foreach (var ShData in ShipmentAccess.SearchShipment(4, comboBoxShSalesOfficeID.Text))      //営業所IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewShipmentMain.Rows.Add(ShData.ShID, ShData.ClID, ShData.EmID, ShData.SoID, ShData.OrID, Convert.ToBoolean(ShData.ShStateFlag), ShData.ShFinishDate,
                                                            Convert.ToBoolean(ShData.ShFlag), ShData.ShHidden);
                }
                labelShSearchTitle.Text = "営業所IDで検索しました";         //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxShOrderID.Text))
            {
                //受注IDの入力チェック
                if (!InputCheck.OrderInputCheck(comboBoxShOrderID.Text))
                {
                    comboBoxShOrderID.Focus();
                    return;
                }
                foreach (var ShData in ShipmentAccess.SearchShipment(5, comboBoxShOrderID.Text))      //受注IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewShipmentMain.Rows.Add(ShData.ShID, ShData.ClID, ShData.EmID, ShData.SoID, ShData.OrID, Convert.ToBoolean(ShData.ShStateFlag), ShData.ShFinishDate,
                                                            Convert.ToBoolean(ShData.ShFlag), ShData.ShHidden);
                }
                labelShSearchTitle.Text = "受注IDで検索しました";         //何で検索したかを表示
            }
        }

        /// <summary>
        /// 出荷確定用売上データセット
        /// </summary>
        /// <param name="ShipmentData"></param>
        private T_Sale SaleAddDataSet(T_Shipment ShipmentData)
        {
            T_Order OrderData = OrderList.Single(Order => Order.OrID == ShipmentData.OrID);

            return new T_Sale
            {
                ClID = ShipmentData.ClID,
                SoID = ShipmentData.SoID,
                EmID = OrderData.EmID,
                ChID = ShipmentData.OrID,
                SaDate = dateTimePickerShipment.Value,
                SaFlag = 0
            };
        }

        /// <summary>
        /// 出荷確定用売上詳細データセット
        /// </summary>
        /// <param name="ShipmentDetail"></param>
        private T_SaleDetail SaleDetailAddDataSet(T_ShipmentDetail ShipmentDetail)
        {
            M_Product product = ProductList.Single(PrData => PrData.PrID == ShipmentDetail.PrID);
            int TotalPrice = product.Price * ShipmentDetail.ShDquantity;

            return new T_SaleDetail
            {
                SaID = SaleID,
                PrID = ShipmentDetail.PrID,
                SaQuantity = ShipmentDetail.ShDquantity,
                SaPrTotalPrice = TotalPrice
            };
        }

        /// <summary>
        /// 出荷確定ボタン
        /// </summary>
        /// <param></param>
        private void buttonShConfirm_Click(object sender, EventArgs e)
        {
            //出荷IDの入力チェック
            if (!InputCheck.ShipmentInputCheck(comboBoxShShipmentID.Text))
            {
                comboBoxShShipmentID.Focus();
                return;
            }
            //社員IDの入力チェック
            if (!InputCheck.EmployeeIDInputCheck(comboBoxShEmployeeID.Text))
            {
                comboBoxShEmployeeID.Focus();
                return;
            }

            //出荷確定確認メッセージ
            if (msg.MsgDsp("M13004") == DialogResult.Cancel)
            {
                return;
            }

            //例外処理
            try
            {
                var context = new SalesManagement_DevContext();     //DB接続用クラスのインスタンス化

                //出荷IDをセット
                int ShID = int.Parse(comboBoxShShipmentID.Text);

                //↓存在確認用の出荷情報を取得
                T_Shipment ShipmentData = context.T_Shipments.Single(Shipment => Shipment.ShID == ShID);         //出荷IDと一致する出荷データを取得する

                //出荷テーブルに既にデータが存在するか確認する
                if (!context.T_Sale.Any(Sale => Sale.ChID == ShipmentData.OrID))
                {
                    //売上IDのセット
                    SaleID = SaleList.Count + 1;

                    T_Sale SaleData = SaleAddDataSet(ShipmentData);                  //登録用売上データをセットする
                    context.T_Sale.Add(SaleData);                      //売上テーブルに登録する

                    //データベースへの変更を確定する
                    context.SaveChanges();


                    //出荷IDと一致する出荷詳細情報を取得する
                    List<T_ShipmentDetail> ShipmentDetailAllData = context.T_ShipmentDetails.Where(ShipmentDetail => ShipmentDetail.ShID == ShID).ToList();

                    foreach (var ShipmentDetailData in ShipmentDetailAllData)          //取得した出荷詳細情報分繰り返す
                    {
                        T_SaleDetail SaleDetailData = SaleDetailAddDataSet(ShipmentDetailData);       //登録用売上詳細データをセットする
                        context.T_SaleDetails.Add(SaleDetailData);              //売上詳細データを登録する

                        //データベースへの変更を確定する
                        context.SaveChanges();
                    }


                    //出荷状態フラグ, 社員ID, 確定年月日の更新
                    ShipmentData.ShStateFlag = 1;
                    ShipmentData.EmID = int.Parse(comboBoxShEmployeeID.Text);
                    ShipmentData.ShFinishDate = dateTimePickerShipment.Value;

                    //データベースへの変更を確定する
                    context.SaveChanges();

                    //出荷一覧表示用データの更新
                    ShipmentList = ShipmentAccess.GetData();

                    //売上一覧表示用データの更新
                    SaleList = context.T_Sale.ToList();
                    SaleDetailList = context.T_SaleDetails.ToList();

                    //確定完了メッセージの表示
                    msg.MsgDsp("M13005");

                    //データの再表示
                    ListShipment();
                }
                else
                {
                    //すでに確定されている場合
                    MessageBox.Show("入力された出荷IDのデータは既に確定されいます", "確定確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //contextの解放
                context.Dispose();
            }
            catch
            {
                MessageBox.Show("確定に失敗しました", "確定確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 出荷非表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonShNDisplay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewShipmentMain.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewShipmentMain.Rows[i].Cells[7].Value)                    //1行ずつチェックボックスがチェックされているかを判定する
                {
                    ShipmentAccess.DeleteShipment((int)dataGridViewShipmentMain.Rows[i].Cells[0].Value);      //チェックされている場合その行の出荷IDを引数に非表示機能モジュールを呼び出す
                }
            }
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //出荷情報一覧表示用データを更新
            ShipmentList = ShipmentAccess.GetData();
            //出荷情報再表示
            ListShipment();
        }

        /// <summary>
        /// 出荷非表示リストボタン
        /// </summary>
        /// <param></param>
        private void buttonShNDisplayList_Click(object sender, EventArgs e)
        {
            DeleteListShipment();
        }

        ///////////////////////////////////////////////
        ///発注管理画面コード
        ///////////////////////////////////////////////

        /// <summary>
        /// 発注情報一覧表示モジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void ListHattyu()
        {
            dataGridViewHattyuMain.Rows.Clear();                        //データグリッドビューをクリアする
            dataGridViewHattyuDetail.Rows.Clear();
            foreach (var HaData in HattyuList)
            {
                if (HaData.HaFlag == 0)                     //発注管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewHattyuMain.Rows.Add(HaData.HaID, HaData.MaID, HaData.EmID, HaData.HaDate, Convert.ToBoolean(HaData.WaWarehouseFlag),
                                                        Convert.ToBoolean(HaData.HaFlag), HaData.HaHidden);
                }
            }
        }

        /// <summary>
        /// 発注情報非表示リストモジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void DeleteListHattyu()
        {
            dataGridViewHattyuMain.Rows.Clear();                        //データグリッドビューをクリアする
            dataGridViewHattyuDetail.Rows.Clear();
            foreach (var HaData in HattyuList)
            {
                if (HaData.HaFlag == 2)                     //発注管理フラグが2の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewHattyuMain.Rows.Add(HaData.HaID, HaData.MaID, HaData.EmID, HaData.HaDate, Convert.ToBoolean(HaData.WaWarehouseFlag),
                                                        Convert.ToBoolean(HaData.HaFlag), HaData.HaHidden);
                }
            }
        }

        /// <summary>
        /// 発注一覧表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonHaDisplay_Click(object sender, EventArgs e)
        {
            ListHattyu();
        }

        /// <summary>
        /// 発注検索ボタン
        /// </summary>
        /// <param></param>
        private void buttonHaSearch_Click(object sender, EventArgs e)
        {
            dataGridViewHattyuMain.Rows.Clear();                        //メインデータグリッドビューの内容を消去する
            dataGridViewHattyuDetail.Rows.Clear();                        //詳細データグリッドビューの内容を消去する

            if (!string.IsNullOrEmpty(comboBoxChChumonID.Text))             //受注IDコンボボックスの空文字チェック
            {
                //発注IDの入力チェック
                if (!InputCheck.HattyuInputCheck(comboBoxHaHattyuID.Text))
                {
                    comboBoxHaHattyuID.Focus();
                    return;
                }
                foreach (var HaData in HattyuAccess.SearchHattyu(1, comboBoxHaHattyuID.Text))           //発注IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewHattyuMain.Rows.Add(HaData.HaID, HaData.MaID, HaData.EmID, HaData.HaDate, Convert.ToBoolean(HaData.WaWarehouseFlag),
                                                        Convert.ToBoolean(HaData.HaFlag), HaData.HaHidden);
                }
                foreach (var HattyuDetailData in HattyuDetailList.Where(HattyuDetailList => HattyuDetailList.HaID == int.Parse(comboBoxHaHattyuID.Text)))      //発注IDで発注詳細情報を検索する
                {
                    M_Product product = ProductList.Single(Pr => Pr.PrID == HattyuDetailData.PrID);        //商品IDと一致する商品データを取得

                    //詳細データグリッドビューにデータを表示する
                    dataGridViewHattyuDetail.Rows.Add(HattyuDetailData.HaDetailID, HattyuDetailData.HaID, HattyuDetailData.PrID, product.PrName, HattyuDetailData.HaQuantity);
                }
                labelHaSearchTitle.Text = "発注IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxHaMakerID.Text))       //メーカIDコンボボックスの空文字チェック
            {
                //メーカIDの入力チェック
                if (!InputCheck.MakerIDInputCheck(comboBoxHaMakerID.Text))
                {
                    comboBoxHaMakerID.Focus();
                    return;
                }
                foreach (var HaData in HattyuAccess.SearchHattyu(2, comboBoxHaMakerID.Text))           //メーカIDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewHattyuMain.Rows.Add(HaData.HaID, HaData.MaID, HaData.EmID, HaData.HaDate, Convert.ToBoolean(HaData.WaWarehouseFlag),
                                                        Convert.ToBoolean(HaData.HaFlag), HaData.HaHidden);
                }
                labelHaSearchTitle.Text = "メーカIDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxHaEmployeeID.Text))   //社員IDコンボボックスの空文字チェック
            {
                //社員IDの入力チェック
                if (!InputCheck.EmployeeIDInputCheck(comboBoxHaEmployeeID.Text))
                {
                    comboBoxHaEmployeeID.Focus();
                    return;
                }
                foreach (var HaData in HattyuAccess.SearchHattyu(3, comboBoxHaEmployeeID.Text))      //社員IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewHattyuMain.Rows.Add(HaData.HaID, HaData.MaID, HaData.EmID, HaData.HaDate, Convert.ToBoolean(HaData.WaWarehouseFlag),
                                                        Convert.ToBoolean(HaData.HaFlag), HaData.HaHidden);
                }
                labelHaSearchTitle.Text = "社員IDで検索しました";         //何で検索したかを表示
            }
        }

        /// <summary>
        /// 発注確定用入庫データセット
        /// </summary>
        /// <param name="HattyuData"></param>
        private T_Warehousing WarehousingAddDataSet(T_Hattyu HattyuData)
        {
            return new T_Warehousing
            {
                HaID = HattyuData.HaID,
                EmID = HattyuData.EmID,
                WaDate = dateTimePickerHa.Value,
                WaShelfFlag = 0,
                WaFlag = 0
            };
        }

        /// <summary>
        /// 発注確定用入庫詳細データセット
        /// </summary>
        /// <param name="HattyuDetail"></param>
        private T_WarehousingDetail WarehousingDetailAddDataSet(T_HattyuDetail HattyuDetail)
        {
            return new T_WarehousingDetail
            {
                WaID = WarehousingID,
                PrID = HattyuDetail.PrID,
                WaQuantity = HattyuDetail.HaQuantity
            };
        }

        /// <summary>
        /// 発注確定ボタン
        /// </summary>
        /// <param></param>
        private void buttonHaConfirm_Click(object sender, EventArgs e)
        {
            //発注IDの入力チェック
            if (!InputCheck.HattyuInputCheck(comboBoxHaHattyuID.Text))
            {
                comboBoxHaHattyuID.Focus();
                return;
            }
            //社員IDの入力チェック
            if (!InputCheck.EmployeeIDInputCheck(comboBoxHaEmployeeID.Text))
            {
                comboBoxHaEmployeeID.Focus();
                return;
            }

            //発注確定確認メッセージ
            if (msg.MsgDsp("M9021") == DialogResult.Cancel)
            {
                return;
            }

            //例外処理
            try
            {
                var context = new SalesManagement_DevContext();     //DB接続用クラスのインスタンス化

                //発注IDをセット
                int HaID = int.Parse(comboBoxHaHattyuID.Text);

                //↓存在確認用の発注情報を取得
                T_Hattyu HattyuData = context.T_Hattyus.Single(Hattyu => Hattyu.HaID == HaID);         //発注IDと一致する入荷データを取得する

                //発注テーブルに既にデータが存在するか確認する
                if (!context.T_Warehousings.Any(Warehousing => Warehousing.HaID == HattyuData.HaID))
                {
                    //入庫IDのセット
                    WarehousingID = WarehousingList.Count + 1;

                    T_Warehousing WarehousingData = WarehousingAddDataSet(HattyuData);                  //登録用入庫データをセットする
                    context.T_Warehousings.Add(WarehousingData);                      //入庫テーブルに登録する

                    //データベースへの変更を確定する
                    context.SaveChanges();


                    //発注IDと一致する発注詳細情報を取得する
                    List<T_HattyuDetail> HattyuDetailAllData = context.T_HattyuDetails.Where(HattyuDetail => HattyuDetail.HaID == HaID).ToList();

                    foreach (var HattyuDetailData in HattyuDetailAllData)          //取得した発注詳細情報分繰り返す
                    {
                        T_WarehousingDetail WarehousingDetailData = WarehousingDetailAddDataSet(HattyuDetailData);       //登録用入庫詳細データをセットする
                        context.T_WarehousingDetails.Add(WarehousingDetailData);              //入庫詳細データを登録する

                        //データベースへの変更を確定する
                        context.SaveChanges();
                    }


                    //入庫状態フラグ(倉庫)の更新
                    HattyuData.WaWarehouseFlag = 1;

                    //データベースへの変更を確定する
                    context.SaveChanges();

                    //発注一覧表示用データの更新
                    HattyuList = HattyuAccess.GetDatahattyu();

                    //入庫一覧表示用データの更新
                    WarehousingList = context.T_Warehousings.ToList();
                    WarehousingDetailList = context.T_WarehousingDetails.ToList();

                    //確定完了メッセージの表示
                    msg.MsgDsp("M19022");

                    //データの再表示
                    ListHattyu();
                }
                else
                {
                    //すでに確定されている場合
                    MessageBox.Show("入力された発注IDのデータは既に確定されいます", "確定確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //contextの解放
                context.Dispose();
            }
            catch
            {
                MessageBox.Show("確定に失敗しました", "確定確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 発注非表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonHaNDisplay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewHattyuMain.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewHattyuMain.Rows[i].Cells[5].Value)                    //1行ずつチェックボックスがチェックされているかを判定する
                {
                    HattyuAccess.DeleteHattyu((int)dataGridViewHattyuMain.Rows[i].Cells[0].Value);      //チェックされている場合その行の発注IDを引数に非表示機能モジュールを呼び出す
                }
            }
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //発注情報一覧表示用データを更新
            HattyuList = HattyuAccess.GetDatahattyu();
            //発注情報再表示
            ListHattyu();
        }

        /// <summary>
        /// 発注非表示リストボタン
        /// </summary>
        /// <param></param>
        private void buttonHaNDisplayList_Click(object sender, EventArgs e)
        {
            DeleteListHattyu();
        }

        ////////////////////////////////////////////////
        ///入庫管理画面コード
        ////////////////////////////////////////////////

        /// <summary>
        /// 入庫情報一覧表示モジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void ListWarehousing()
        {
            dataGridViewWareHousingMain.Rows.Clear();                        //データグリッドビューをクリアする
            dataGridViewWareHousingDetail.Rows.Clear();
            foreach (var WaData in WarehousingList)
            {
                if (WaData.WaFlag == 0)                     //入庫管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewWareHousingMain.Rows.Add(WaData.WaID, WaData.HaID, WaData.EmID, WaData.WaDate, Convert.ToBoolean(WaData.WaShelfFlag), Convert.ToBoolean(WaData.WaFlag),
                                                                WaData.WaHidden);
                }
            }
        }

        /// <summary>
        /// 入庫情報非表示リストモジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void DeleteListWarehousing()
        {
            dataGridViewWareHousingMain.Rows.Clear();                        //データグリッドビューをクリアする
            dataGridViewWareHousingDetail.Rows.Clear();
            foreach (var WaData in WarehousingList)
            {
                if (WaData.WaFlag == 2)                     //入庫管理フラグが2の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewWareHousingMain.Rows.Add(WaData.WaID, WaData.HaID, WaData.EmID, WaData.WaDate, Convert.ToBoolean(WaData.WaShelfFlag), Convert.ToBoolean(WaData.WaFlag),
                                                                WaData.WaHidden);
                }
            }
        }

        /// <summary>
        /// 入庫一覧表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonWrDisplay_Click(object sender, EventArgs e)
        {
            ListWarehousing();
        }

        /// <summary>
        /// 入庫検索ボタン
        /// </summary>
        /// <param></param>
        private void buttonWrSearch_Click(object sender, EventArgs e)
        {
            dataGridViewWareHousingMain.Rows.Clear();                        //メインデータグリッドビューの内容を消去する
            dataGridViewWareHousingDetail.Rows.Clear();                        //詳細データグリッドビューの内容を消去する

            if (!string.IsNullOrEmpty(comboBoxWrWareHousingID.Text))             //入庫IDコンボボックスの空文字チェック
            {
                //入庫IDの入力チェック
                if (!InputCheck.WarehousingInputCheck(comboBoxWrWareHousingID.Text))
                {
                    comboBoxWrWareHousingID.Focus();
                    return;
                }
                foreach (var WaData in WareHousingAccess.SearchWarehousing(1, comboBoxWrWareHousingID.Text))           //入庫IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewWareHousingMain.Rows.Add(WaData.WaID, WaData.HaID, WaData.EmID, WaData.WaDate, Convert.ToBoolean(WaData.WaShelfFlag), Convert.ToBoolean(WaData.WaFlag),
                                                                WaData.WaHidden);
                }
                //入庫IDで入庫詳細情報を検索する
                foreach (var WaDetailData in WarehousingDetailList.Where(WarehousingDetailList => WarehousingDetailList.WaID == int.Parse(comboBoxWrWareHousingID.Text)))
                {
                    M_Product product = ProductList.Single(Pr => Pr.PrID == WaDetailData.PrID);        //商品IDと一致する商品データを取得

                    //詳細データグリッドビューにデータを表示する
                    dataGridViewWareHousingDetail.Rows.Add(WaDetailData.WaDetailID, WaDetailData.WaID, WaDetailData.PrID,
                                                                product.PrName, WaDetailData.WaQuantity);
                }
                labelWrSearchTitle.Text = "入庫IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxWrHattyuID.Text))       //発注IDコンボボックスの空文字チェック
            {
                //メーカIDの入力チェック
                if (!InputCheck.HattyuInputCheck(comboBoxWrHattyuID.Text))
                {
                    comboBoxWrHattyuID.Focus();
                    return;
                }
                foreach (var WaData in WareHousingAccess.SearchWarehousing(2, comboBoxWrHattyuID.Text))           //発注IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewWareHousingMain.Rows.Add(WaData.WaID, WaData.HaID, WaData.EmID, WaData.WaDate, Convert.ToBoolean(WaData.WaShelfFlag), Convert.ToBoolean(WaData.WaFlag),
                                                                WaData.WaHidden);
                }
                labelWrSearchTitle.Text = "発注IDで検索しました";            //何で検索したかを表示
            }
            else if (!string.IsNullOrEmpty(comboBoxWrEmployeeID.Text))   //社員IDコンボボックスの空文字チェック
            {
                //社員IDの入力チェック
                if (!InputCheck.EmployeeIDInputCheck(comboBoxWrEmployeeID.Text))
                {
                    comboBoxWrEmployeeID.Focus();
                    return;
                }
                foreach (var WaData in WareHousingAccess.SearchWarehousing(3, comboBoxWrEmployeeID.Text))      //社員IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewWareHousingMain.Rows.Add(WaData.WaID, WaData.HaID, WaData.EmID, WaData.WaDate, Convert.ToBoolean(WaData.WaShelfFlag), Convert.ToBoolean(WaData.WaFlag),
                                                                WaData.WaHidden);
                }
                labelWrSearchTitle.Text = "社員IDで検索しました";         //何で検索したかを表示
            }
        }

        /// <summary>
        /// 入庫確定ボタン
        /// </summary>
        /// <param></param>
        private void buttonWrConfirm_Click(object sender, EventArgs e)
        {
            //入庫IDの入力チェック
            if (!InputCheck.WarehousingInputCheck(comboBoxWrWareHousingID.Text))
            {
                comboBoxWrWareHousingID.Focus();
                return;
            }

            //入庫確定確認メッセージ
            if (msg.MsgDsp("M10004") == DialogResult.Cancel)
            {
                return;
            }

            //例外処理
            try
            {
                var context = new SalesManagement_DevContext();             //DB接続用クラスのインスタンス化

                //入庫IDのセット
                int WaID = int.Parse(comboBoxWrWareHousingID.Text);

                //既に確定処理がされているかの確認
                T_Warehousing WarehousingData = context.T_Warehousings.Single(WaData => WaData.WaID == WaID);
                if (WarehousingData.WaShelfFlag == 1)               //確定済み(状態フラグが1)の場合処理を終了する
                {
                    MessageBox.Show("入力されたデータは既に入庫確定処理を行っています。", "確定確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //入庫IDと一致する入庫詳細情報を取得する
                List<T_WarehousingDetail> WarehousingDetailAllData = context.T_WarehousingDetails.Where(WarehousingDetail => WarehousingDetail.WaID == WaID).ToList();

                //在庫テーブルを更新するための在庫データを取得、更新する
                foreach (var WaData in WarehousingDetailAllData)
                {
                    T_Stock StockUpdData = context.T_Stocks.Single(Stock => Stock.PrID == WaData.PrID);     //在庫テーブルから商品IDと一致するデータを取得する
                    StockUpdData.StQuantity = StockUpdData.StQuantity + WaData.WaQuantity;                  //在庫データの数量に入庫分をプラスする
                    context.SaveChanges();                                                                  //更新を確定する
                }

                //入庫状態フラグを更新
                WarehousingData.WaShelfFlag = 1;

                //更新を確定する
                context.SaveChanges();

                //確定完了メッセージ
                msg.MsgDsp("M10005");

                //入庫一覧表示用データの更新
                WarehousingList = WareHousingAccess.GetData();

                //在庫一覧表示用データの更新
                StockList = StockAccess.GetData();

                //データの再表示
                ListWarehousing();

                //contextの解放
                context.Dispose();
            }
            catch
            {
                MessageBox.Show("確定に失敗しました", "確定確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 入庫非表示ボタン
        /// </summary>
        /// <param></param>
        private void buttonWrNDisplay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewWareHousingMain.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewWareHousingMain.Rows[i].Cells[5].Value)                    //1行ずつチェックボックスがチェックされているかを判定する
                {
                    WareHousingAccess.DeleteWarehousing((int)dataGridViewWareHousingMain.Rows[i].Cells[0].Value);      //チェックされている場合その行の入庫IDを引数に非表示機能モジュールを呼び出す
                }
            }
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //入庫情報一覧表示用データを更新
            WarehousingList = WareHousingAccess.GetData();
            //入庫情報再表示
            ListWarehousing();
        }

        /// <summary>
        /// 入庫非表示リストボタン
        /// </summary>
        /// <param></param>
        private void buttonWrNDisplayList_Click(object sender, EventArgs e)
        {
            DeleteListWarehousing();
        }

    ////////////////////////////////////////////////////////
    ///テキストのクリア、ボタンの使用可否を変更するコード
    ////////////////////////////////////////////////////////        

        //全てのテキストボックスとコンボボックスの入力をクリアする
        private static void ClearText(Control hParent)
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

        /// <summary>
        /// 渡されたパネルのコントロールのTextをチェックする
        /// </summary>
        /// <param name="hParent"></param>
        /// <returns></returns>
        private static bool CheckText(Control hParent)
        {
            // hParent 内のすべてのコントロールを列挙する
            foreach (Control cControl in hParent.Controls)
            {
                // 列挙したコントロールにコントロールが含まれている場合は再帰呼び出しする
                if (cControl.HasChildren == true)
                {
                    CheckText(cControl);
                }

                // コントロールの型が TextBoxBase またはComboBoxの場合チェックする
                if (cControl is TextBoxBase || cControl is ComboBox)
                {
                    if (cControl.Text != String.Empty && cControl.Name != "textBoxHomeLoginID" && cControl.Name != "textBoxHomePassword")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 全てのパネルをの入力内容をチェックする
        /// </summary>
        private bool PanelCheck()
        {
            foreach (Panel panel in panelList)          //パネルリストからパネルを抽出
            {
                if (panel.Visible == true)              //Visibleプロパティがtrueの場合チェックする
                {
                    if (CheckText(panel))               //入力チェックメソッド呼び出し
                    {
                        return true;                    //入力されている場合trueを返す
                    }
                }
            }
            return false;                               //入力されていない場合falseを返す
        }

        //登録ボタンを使用不能、更新検索ボタンを使用可能にするメソッド
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

                // コントロールの型が Button の場合
                if (cControl is Button)
                {
                    if (cControl.Text == "登録")      //登録ボタンの場合
                    {
                        cControl.Enabled = false;
                    }
                    if (cControl.Text == "更新" || cControl.Text == "検索")     //更新、検索ボタンの場合
                    {
                        cControl.Enabled = true;
                    }
                }
            }
        }

        //登録ボタンを使用可能、更新検索ボタンを使用不能にするメソッド
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
                    if (cControl.Text == "登録")          //登録ボタンの場合
                    {
                        cControl.Enabled = true;
                    }
                    if (cControl.Text == "更新" || cControl.Text == "検索")     //更新、検索ボタンの場合
                    {
                        cControl.Enabled = false;
                    }
                }
            }
        }

        //販売在庫管理システムを終了する
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 顧客管理画面のボタン使用可否変更
        /// </summary>
        private void comboBoxCIClientID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxCIClientID.Text))           //主キーの項目に入力されていない場合
            {
                EnabledChangedtruebutton(panelClient);
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　　　　//主キーの項目に入力されている場合
            {
                EnabledChangedfalsebutton(panelClient);
            }
        }

        /// <summary>
        /// 商品管理画面のボタン使用可否変更
        /// </summary>
        private void comboBoxPrProductID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxPrProductID.Text))           //主キーの項目に入力されていない場合
            {
                EnabledChangedtruebutton(panelProduct);
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　　　　//主キーの項目に入力されている場合
            {
                EnabledChangedfalsebutton(panelProduct);
            }
        }

        /// <summary>
        /// 在庫管理画面のボタン使用可否変更
        /// </summary>
        private void comboBoxStStockID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxStStockID.Text))           //主キーの項目に入力されていない場合
            {
                EnabledChangedtruebutton(panelStock);
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　　　　//主キーの項目に入力されている場合
            {
                EnabledChangedfalsebutton(panelStock);
            }
        }

        /// <summary>
        /// 社員管理画面のボタン使用可否変更
        /// </summary>
        private void comboBoxEmEmployeeID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxEmEmployeeID.Text))           //主キーの項目に入力されていない場合
            {
                EnabledChangedtruebutton(panelEmployee);
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　　　　//主キーの項目に入力されている場合
            {
                EnabledChangedfalsebutton(panelEmployee);
            }
        }

        /// <summary>
        /// 売上管理画面のボタン使用可否変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxSaSaleID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSaSaleID.Text))           //主キーの項目に入力されていない場合
            {
                EnabledChangedtruebutton(panelSale);
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　　　　//主キーの項目に入力されている場合
            {
                EnabledChangedfalsebutton(panelSale);
            }
        }
        
        /// <summary>
        /// 受注管理画面のボタン使用可否変更
        /// </summary>
        private void comboBoxOrOrderID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxOrOrderID.Text))           //主キーの項目に入力されていない場合
            {
                EnabledChangedtruebutton(panelOrder);
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　　　　//主キーの項目に入力されている場合
            {
                EnabledChangedfalsebutton(panelOrder);
            }
        }

        /// <summary>
        /// 注文管理画面のボタン使用可否変更
        /// </summary>
        private void comboBoxChChumonID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxChChumonID.Text))           //主キーの項目に入力されていない場合
            {
                EnabledChangedtruebutton(panelChumon);
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　　　　//主キーの項目に入力されている場合
            {
                EnabledChangedfalsebutton(panelChumon);
            }
        }

        /// <summary>
        /// 出庫管理画面のボタン使用可否変更
        /// </summary>
        private void comboBoxSySyukkoID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSySyukkoID.Text))           //主キーの項目に入力されていない場合
            {
                EnabledChangedtruebutton(panelSyukko);
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　　　　//主キーの項目に入力されている場合
            {
                EnabledChangedfalsebutton(panelSyukko);
            }
        }

        /// <summary>
        /// 入荷管理画面のボタン使用可否変更
        /// </summary>
        private void comboBoxArArrivalID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxArArrivalID.Text))           //主キーの項目に入力されていない場合
            {
                EnabledChangedtruebutton(panelArrival);
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　　　　//主キーの項目に入力されている場合
            {
                EnabledChangedfalsebutton(panelArrival);
            }
        }

        /// <summary>
        /// 出荷管理画面のボタン使用可否変更
        /// </summary>
        private void comboBoxShShipmentID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxShShipmentID.Text))           //主キーの項目に入力されていない場合
            {
                EnabledChangedtruebutton(panelShipment);
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　　　　//主キーの項目に入力されている場合
            {
                EnabledChangedfalsebutton(panelShipment);
            }
        }

        /// <summary>
        /// 発注管理画面のボタン使用可否変更
        /// </summary>
        private void comboBoxHaHattyuID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxHaHattyuID.Text))           //主キーの項目に入力されていない場合
            {
                EnabledChangedtruebutton(panelHattyu);
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　　　　//主キーの項目に入力されている場合
            {
                EnabledChangedfalsebutton(panelHattyu);
            }
        }

        /// <summary>
        /// 入庫管理画面のボタン使用可否変更
        /// </summary>
        private void comboBoxWrWareHousingID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxWrWareHousingID.Text))           //主キーの項目に入力されていない場合
            {
                EnabledChangedtruebutton(panelWareHousing);
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　　　　//主キーの項目に入力されている場合
            {
                EnabledChangedfalsebutton(panelWareHousing);
            }
        }

        /// <summary>
        /// コンボボックスのItemsをリセットする
        /// </summary>
        private void ResetComboBox(Control hParent)
        {
            foreach (Control cControl in hParent.Controls)
            {
                // 列挙したコントロールにコントロールが含まれている場合は再帰呼び出しする
                if (cControl.HasChildren == true)
                {
                    ResetComboBox(cControl);
                }

                // コントロールの型が ComboBox の場合
                if (cControl is ComboBox)
                {
                    ComboBox Combo = (ComboBox)cControl;
                    Combo.Items.Clear();
                }
            }
        }

    ///////////////////////////////////////////////////
    ///データグリッドビューのセルクリックイベント
    ///////////////////////////////////////////////////

        /// <summary>
        /// 顧客データグリッドビューのセルクリックイベント
        /// </summary>
        private void dataGridViewCI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //顧客ID、顧客名
            comboBoxCIClientID.Text = dataGridViewCI.Rows[dataGridViewCI.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxCIClientName.Text = (string)dataGridViewCI.Rows[dataGridViewCI.CurrentRow.Index].Cells[2].Value;
            //営業所ID、営業所名
            comboBoxCISalesOfficeID.Text = dataGridViewCI.Rows[dataGridViewCI.CurrentRow.Index].Cells[1].Value.ToString();
            int SoID = (int)dataGridViewCI.Rows[dataGridViewCI.CurrentRow.Index].Cells[1].Value;
            var SalesOfficeData = SalesOfficeList.Single(SalesOffice => SalesOffice.SoID == SoID);
            textBoxCISalesOfficeName.Text = SalesOfficeData.SoName;
            //住所、電話番号、郵便番号、FAX、非表示理由
            textBoxCIAddress.Text = (string)dataGridViewCI.Rows[dataGridViewCI.CurrentRow.Index].Cells[3].Value;
            textBoxCIPhone.Text = (string)dataGridViewCI.Rows[dataGridViewCI.CurrentRow.Index].Cells[4].Value;
            textBoxCIPostal.Text = (string)dataGridViewCI.Rows[dataGridViewCI.CurrentRow.Index].Cells[5].Value;
            textBoxCIFax.Text = (string)dataGridViewCI.Rows[dataGridViewCI.CurrentRow.Index].Cells[6].Value;
            textBoxCIRsn.Text = (string)dataGridViewCI.Rows[dataGridViewCI.CurrentRow.Index].Cells[8].Value;
        }

        /// <summary>
        /// 商品データグリッドビューのセルクリックイベント
        /// </summary>
        private void dataGridVieProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //商品ID、商品名
            comboBoxPrProductID.Text = dataGridVieProduct.Rows[dataGridVieProduct.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxPrProductName.Text = dataGridVieProduct.Rows[dataGridVieProduct.CurrentRow.Index].Cells[2].Value.ToString();
            //メーカID、メーカ名
            comboBoxPrMakerID.Text = dataGridVieProduct.Rows[dataGridVieProduct.CurrentRow.Index].Cells[1].Value.ToString();
            int MakerID = (int)dataGridVieProduct.Rows[dataGridVieProduct.CurrentRow.Index].Cells[1].Value;
            var MakerData = MakerList.Single(Maker => Maker.MaID == MakerID);
            textBoxPrMakerName.Text = MakerData.MaName;
            //小分類ID、小分類名
            comboBoxPrSmallClassID.Text = dataGridVieProduct.Rows[dataGridVieProduct.CurrentRow.Index].Cells[5].Value.ToString();
            int ScID = (int)dataGridVieProduct.Rows[dataGridVieProduct.CurrentRow.Index].Cells[5].Value;
            var SmallClassData = SmallClassList.Single(SmallClass => SmallClass.ScID == ScID);
            textBoxPrSmallClassName.Text = SmallClassData.ScName;
            //大分類ID、大分類名
            comboBoxPrMajorClassID.Text = SmallClassData.McID.ToString();
            int McID = SmallClassData.McID;
            var MajorClassData = MajorClassList.Single(MajorClass => MajorClass.McID == McID);
            textBoxPrMajorClassName.Text = MajorClassData.McName.ToString();
            //型番、色、発売日、価格、安全在庫数、非表示理由
            textBoxPrModelNumber.Text = dataGridVieProduct.Rows[dataGridVieProduct.CurrentRow.Index].Cells[6].Value.ToString();
            textBoxPrColor.Text = dataGridVieProduct.Rows[dataGridVieProduct.CurrentRow.Index].Cells[7].Value.ToString();
            DateTimePickerProduct.Value = DateTime.Parse(dataGridVieProduct.Rows[dataGridVieProduct.CurrentRow.Index].Cells[8].Value.ToString());
            textBoxPrPrice.Text = dataGridVieProduct.Rows[dataGridVieProduct.CurrentRow.Index].Cells[3].Value.ToString();
            numericUpDownPrSafeStock.Value = decimal.Parse(dataGridVieProduct.Rows[dataGridVieProduct.CurrentRow.Index].Cells[4].Value.ToString());
            textBoxPrRsn.Text = (string)dataGridVieProduct.Rows[dataGridVieProduct.CurrentRow.Index].Cells[10].Value;
        }

        /// <summary>
        /// 在庫データグリッドビューセルクリックイベント
        /// </summary>
        private void dataGridViewStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //在庫ID
            comboBoxStStockID.Text = dataGridViewStock.Rows[dataGridViewStock.CurrentRow.Index].Cells[0].ToString();
            //商品ID,商品名
            comboBoxStProductID.Text = dataGridViewStock.Rows[dataGridViewStock.CurrentRow.Index].Cells[1].Value.ToString();
            int PrID = (int)dataGridViewStock.Rows[dataGridVieProduct.CurrentRow.Index].Cells[1].Value;
            var ProductData = ProductList.Single(Product => Product.PrID == PrID);
            textBoxStProductName.Text = ProductData.PrName;
            //小分類ID、小分類名
            comboBoxStSmallClassID.Text = ProductData.ScID.ToString();
            int ScID = ProductData.ScID;
            var SmallClassData = SmallClassList.Single(SmallClass => SmallClass.ScID == ScID);
            textBoxStSmallClassName.Text = SmallClassData.ScName.ToString();
            //大分類ID、大分類名
            comboBoxStMajorClassID.Text = SmallClassData.McID.ToString();
            int McID = SmallClassData.McID;
            var MajorClassData = MajorClassList.Single(MajorClassList => MajorClassList.McID == McID);
            textBoxStMajorClassName.Text = MajorClassData.McName.ToString();
            //在庫数、非表示理由
            textBoxStInventory.Text = dataGridViewStock.Rows[dataGridViewStock.CurrentRow.Index].Cells[3].Value.ToString();
            textBoxStRsn.Text = dataGridViewStock.Rows[dataGridViewStock.CurrentRow.Index].Cells[5].Value.ToString();
        }
    }
}