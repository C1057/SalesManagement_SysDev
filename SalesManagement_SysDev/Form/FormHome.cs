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

        /// <summary>
        /// 別フォームのクラスをインスタンス化
        /// </summary>
        FormClassMana form4 = new FormClassMana();                                                      //商品分類管理フォーム
        MakerMana formMaker = new MakerMana();                                          //メーカ管理フォーム
        FormProductSelect formproductselect = new FormProductSelect();                  //商品選択フォーム
        FormSalesOfficeMana formSOMana = new FormSalesOfficeMana();                     //営業所管理フォーム
        FormPositionMana formPositionMana = new FormPositionMana();                     //役職管理フォーム

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
        StockDateAccess StockAcess = new StockDateAccess();                             //[在庫テーブル]操作用クラスのインスタンス化
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
        List<M_Product> ProductList;                                                    //表示用[商品]情報を保持する変数
        List<M_MajorClassification> MajorClassList;                                     //表示用[大分類]情報を保持する変数
        List<M_SmallClassification> SmallClassList;                                     //表示用[小分類]情報を保持する変数
        List<T_Stock> StockList;                                                        //表示用[在庫]情報を保持する変数
        List<T_Sale> SaleList;                                                          //表示用[売上]情報を保持する変数
        List<T_SaleDetail> SaleDetailList;                                              //表示用[売上詳細]情報を保持する変数
        List<T_Order> OrderList;                                                        //表示用[受注]情報を保持する変数
        List<T_OrderDetail> OrderDetailList;                                            //表示用[受注詳細]情報を保持する変数
        List<T_Chumon> ChumonList;                                                      //表示用[注文]情報を保持する変数
        List<T_ChumonDetail> ChumonDetailList;                                          //表示用[注文詳細]情報を保持する変数
        List<T_Hattyu> HattyuList;                                                      //表示用[発注]情報を保持する変数
        List<T_HattyuDetail> HattyuDetailList;                                          //表示用[発注詳細]情報を保持する変数
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
            ///各テーブルの表示用データを取得する
            ///</summary>
            PositionList = context.M_Positions.ToList();                //List<M_Position>型のPositionListに[役職]表示用データを代入する
            MakerList = context.M_Makers.ToList();                      //List<M_Maker>型のMakerListに[メーカー]表示用データを代入する
            SalesOfficeList = context.M_SalesOffices.ToList();          //List<M_SalesOffice>型のSalesOfficeListに[営業所]表示用データを代入する
            ClientList = context.M_Clients.ToList();                    //List<M_Client>型のClientListに[顧客]表示用データを代入する
            ProductList = context.M_Products.ToList();                  //List<M_Product>型のProductListに[商品]表示用データを代入する
            MajorClassList = context.M_MajorClassifications.ToList();   //List<M_MajorClassification>型のMajorClassListに[大分類]表示用データを代入する
            SmallClassList = context.M_SmallClassifications.ToList();   //List<M_SmallClassification>型のSmallClassListに[小分類]表示用データを代入する
            StockList = context.T_Stocks.ToList();                      //List<T_Stock>型のStockListに[在庫]表示用データを代入する
            SaleList = context.T_Sale.ToList();                         //List<T_Sale>型のSaleListに[売上]表示用データを代入する
            OrderList = context.T_Orders.ToList();                      //List<T_Order>型のOrderListに[受注]表示用データを代入する
            ChumonList = context.T_Chumons.ToList();                    //List<T_Chumon>型のChumonListに[注文]表示用データを代入する
            HattyuList = context.T_Hattyus.ToList();                    //List<T_Hattyu>型のHattyuListに[発注]表示用データを代入する
            WarehousingList = context.T_Warehousings.ToList();          //List<T_Warehousing>型のWarehousingListに[入庫]表示用データを代入する
            SyukkoList = context.T_Syukkos.ToList();                    //List<T_Syukko>型のSyukkoListに[出庫]表示用データを代入する
            ArrivalList = context.T_Arrivals.ToList();                  //List<T_Arrival>型のArrivalListに[入荷]表示用データを代入する
            ShipmentList = context.T_Shipments.ToList();                //List<T_Shipment>型のShipmentListに[出荷]表示用データを代入する
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