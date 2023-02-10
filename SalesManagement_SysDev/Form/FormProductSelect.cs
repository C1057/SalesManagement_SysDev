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
        private void ListProductSelect()
        {
            dataGridViewProSelect.Rows.Clear();
            //データグリッドビューをクリアする
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            foreach (var ProductSelectData in context.T_OrderDetails)
            {
                
                    //データグリッドビューにデータを追加する
                    dataGridViewProSelect.Rows.Add(ProductSelectData.OrDetailID, ProductSelectData.OrID, ProductSelectData.PrID, ProductSelectData.OrQuantity, ProductSelectData.OrTotalPrice);
               

            }
        }

        //List<T_OrderDetail> OrderDetailList;

        private FormHome formHome;                  //FormHomeのデータを取得するための変数を宣言

        int OrderDetailID;                          //受注詳細ID
        int ProductPrice;                              //合計金額表示用の商品IDを保持する変数
        List<M_Product> ProductList;                //商品マスタの全情報を保持するList型変数

        MessageDsp msg = new MessageDsp();          //メッセージ表示用クラスのインスタンス化
        DataInputCheck InputCheck = new DataInputCheck();   //入力チェック用クラスのインスタンス化
        CheckExistence Existence = new CheckExistence();    //存在チェック用クラスのインスタンス化

        public FormProductSelect(FormHome formHome)
        {
            InitializeComponent();
            this.formHome = formHome;               //FormHomeのデータを取得するための変数に値を代入
        }

        private void FormProductSelect_Load(object sender, EventArgs e)
        {
            var columnText = new string[]                       //各列のヘッダーテキストを設定
            {
                "受注明細ID", "受注ID", "商品ID", "数量", "合計金額"
            };

            var ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true
            };

            var ColumnSize = new int[]                          //各列のWidthを設定
            {
                    225,225,225,225,251
            };

            var columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
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
                viewColumn.HeaderText = columnText[i];                  //ヘッダーに表示される名称
                viewColumn.ReadOnly = ReadOnlySet[i];                   //読み取り可否
                viewColumn.Width = ColumnSize[i];                       //Width設定
                viewColumn.CellTemplate = columnCellType[i];            //セルのタイプ

                dataGridViewProSelect.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewProSelect.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする 

            OrderDetailID = formHome.OrderDetailID;

            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            ProductList = context.M_Products.ToList();              //商品マスタの全情報を取得
            context.Dispose();                                      //contextの解放

            //フォームの最大化ボタンの表示、非表示を切り替える
            this.MaximizeBox = !this.MaximizeBox;
            //フォームの最小化ボタンの表示、非表示を切り替える
            this.MinimizeBox = !this.MinimizeBox;
            //フォームのコントロールボックスの表示、非表示を切り替える
            //コントロールボックスを非表示にすると最大化、最小化、閉じるボタンも消える
            this.ControlBox = !this.ControlBox;
            //数量に下限を設定
            numericUpDownProSelectQuantity.Minimum = 1;

            


        }

        /// <summary>
        /// 戻るボタン
        /// </summary>
        /// <param></param>
        private void buttonProSelectReturn_Click(object sender, EventArgs e)
        {
            //画面遷移確認
            if (msg.MsgDsp("M15001") == DialogResult.Cancel)
            {
                return;
            }
           
            //各コントロールの入力内容をクリアする
            ClearText(this);
            dataGridViewProSelect.Rows.Clear();

            //自身を閉じる
            this.Visible = false;
            //元の画面を開く
            formHome.Visible = true;
        }

        private void FormProductSelect_VisibleChanged(object sender, EventArgs e)
        {
            //Visibleがtrueになった場合
            if (this.Visible == true)
            {
                //受注IDをセット
                textBoxProSelectOrderID.Text = formHome.OrderID.ToString();
                //コンボボックスのItemをリセットする
                ResetComboBox(this);
                //商品名コンボボックスにデータを追加
                foreach (var ProductData in formHome.ProductList)
                {
                    comboBoxProSelectProductName.Items.Add(ProductData.PrName);
                }
                //大分類IDコンボボックスにデータを追加
                foreach (var MajorClassData in formHome.MajorClassList)
                {
                    comboBoxProSelectMajor.Items.Add(MajorClassData.McID);
                }
                //小分類IDコンボボックスにデータを追加
                foreach (var SmallClassData in formHome.SmallClassList)
                {
                    comboBoxProSelectSmall.Items.Add(SmallClassData.ScID);
                }
            }
        }

        /// <summary>
        /// ID以外の入力チェック
        /// </summary>
        private bool OrderDetailInputCheck()
        {
            //数量の空文字チェック
            if (string.IsNullOrEmpty(numericUpDownProSelectQuantity.Value.ToString()))
            {
                MessageBox.Show("数量が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDownProSelectQuantity.Focus();
                return false;
            }
            //数量の半角数字チェック
            if (!InputCheck.CheckNumericAndHalfChar(numericUpDownProSelectQuantity.Value.ToString()))
            {
                MessageBox.Show("数量は半角数字入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDownProSelectQuantity.Focus();
                return false;
            }
            //数量の文字数チェック
            if (numericUpDownProSelectQuantity.Value.ToString().Length > 4)
            {
                MessageBox.Show("数量は4文字以内です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDownProSelectQuantity.Focus();
                return false;
            }

            //異常なしの場合trueを返す
            return true;
        }

        /// <summary>
        /// 追加ボタン
        /// </summary>
        /// <param></param>
        private void buttonProSelectAdd_Click(object sender, EventArgs e)
        {
            var context = new SalesManagement_DevContext();                 //DB接続用クラスのインスタンス化

            //商品IDの入力チェック
            if (!InputCheck.ProductIDInputCheck(textBoxProSelectProID.Text))
            {
                textBoxProSelectProID.Focus();
                return;
            }
            //ID以外の入力チェック
            if (!OrderDetailInputCheck())
            {
                return;
            }
            //在庫が0の場合
            if (numericUpDownProSelectQuantity.Value == 0)
            {
                MessageBox.Show("選択された商品は現在在庫がありません", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //数量が在庫数を超えている場合
            if (int.Parse(numericUpDownProSelectQuantity.Text) > int.Parse(labelStockNow.Text))
            {
                MessageBox.Show("数量が現在個数を超えています", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            


            //追加確認メッセージ
            if (DialogResult.Cancel == msg.MsgDsp("M7020"))
            {
                return;
            }

            //合計金額の計算
            var ProductData = ProductList.Single(Product => Product.PrID == int.Parse(textBoxProSelectProID.Text));
            //int TotalPrice = int.Parse(labelProSelectTotalMoney.Text.ToString());
            int TotalPrice = ProductData.Price * int.Parse(numericUpDownProSelectQuantity.Text);

            //データグリッドビューにデータをセット
            dataGridViewProSelect.Rows.Add(OrderDetailID, formHome.OrderID, textBoxProSelectProID.Text,
                                                numericUpDownProSelectQuantity.Value, TotalPrice);
            OrderDetailID++;
        }

        /// <summary>
        /// 商品IDのテキストチェンジイベント
        /// </summary>
        /// <param></param>
        private void textBoxProSelectProID_TextChanged(object sender, EventArgs e)
        {
            //初期化
            ProductPrice=0;
            labelProSelectTotalMoney.Text = 0.ToString();

            //商品IDの空文字チェック
            if (string.IsNullOrEmpty(textBoxProSelectProID.Text))
            {
                return;
            }
            //商品IDの半角数字チェック
            if (!InputCheck.CheckNumericAndHalfChar(textBoxProSelectProID.Text))
            {
                return;
            }
            //商品IDの文字数チェック
            if (textBoxProSelectProID.Text.Length > 6)
            {
                return;
            }
            //商品IDの存在チェック
            if (!Existence.CheckExistenceEProduct(int.Parse(textBoxProSelectProID.Text)))
            {
                return;
            }

            //合計金額算出用変数に商品IDに対応する価格を代入する
            var ProductData = formHome.ProductList.Single(ProductList => ProductList.PrID == int.Parse(textBoxProSelectProID.Text));
            ProductPrice = ProductData.Price;

            //合計金額の表示
            labelProSelectTotalMoney.Text = (ProductPrice * int.Parse(numericUpDownProSelectQuantity.Value.ToString())).ToString("C");


            //int PrID = int.Parse(textBoxProSelectProID.ToString());
            ////M_Product ProductData = formHome.ProductList.Single(Product => Product.PrID == PrID);
            //comboBoxProSelectMajor.Text = ProductData.MaID.ToString();
            //comboBoxProSelectSmall.Text = ProductData.ScID.ToString();

        }

        /// <summary>
        /// 数量のvalueチェンジイベント
        /// </summary>
        /// <param></param>
        private void numericUpDownProSelectQuantity_ValueChanged(object sender, EventArgs e)
        {
            //初期化
            labelProSelectTotalMoney.Text = 0.ToString();

            //数量の空白チェック
            if (string.Empty == numericUpDownProSelectQuantity.Value.ToString())
            {
                return;
            }

            //合計金額の表示
            labelProSelectTotalMoney.Text = (ProductPrice * int.Parse(numericUpDownProSelectQuantity.Value.ToString())).ToString("C");
        }

        /// <summary>
        /// 更新ボタン
        /// </summary>
        /// <param></param>
        private void buttonProSelectUpdate_Click(object sender, EventArgs e)
        {
            //受注詳細IDの入力チェック
            if (!OrderDetailIDInputCheck())
            {
                textBoxProSelectOrderDetailID.Focus();
                return;
            }
            //商品IDの入力チェック
            if (!InputCheck.ProductIDInputCheck(textBoxProSelectProID.Text))
            {
                textBoxProSelectProID.Focus();
                return;
            }
            //ID以外の入力チェック
            if (!OrderDetailInputCheck())
            {
                return;
            }

            //更新確認メッセージ
            if(msg.MsgDsp("M7022")==DialogResult.Cancel)
            {
                return;
            }

            //合計金額の計算
            var ProductData = ProductList.Single(Product => Product.PrID == int.Parse(textBoxProSelectProID.Text));
            int TotalPrice = ProductData.Price * int.Parse(numericUpDownProSelectQuantity.Value.ToString());

            //データグリッドビューに表示されている値を更新する
            for (int i = 0; i < dataGridViewProSelect.Rows.Count; i++)
            {
                if ((int)dataGridViewProSelect.Rows[i].Cells[0].Value == int.Parse(textBoxProSelectOrderDetailID.Text))
                {
                    dataGridViewProSelect.Rows[i].Cells[2].Value = textBoxProSelectProID.Text;
                    dataGridViewProSelect.Rows[i].Cells[3].Value = numericUpDownProSelectQuantity.Value;
                    dataGridViewProSelect.Rows[i].Cells[4].Value = TotalPrice;
                }
            }
        }

        private bool OrderDetailIDInputCheck()
        {
            //受注詳細IDの空文字チェック
            if (string.IsNullOrEmpty(textBoxProSelectOrderDetailID.Text))
            {
                MessageBox.Show("受注詳細IDが入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //受注詳細IDの半角数字チェック
            if (!InputCheck.CheckNumericAndHalfChar(textBoxProSelectOrderDetailID.Text))
            {
                MessageBox.Show("受注詳細IDは半角数字入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //受注IDの文字数チェック
            if (textBoxProSelectOrderDetailID.Text.Length > 6)
            {
                MessageBox.Show("受注詳細IDは半角数字入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //受注詳細IDがデータグリッドビューに存在するかチェック
            for (int i = 0; i < dataGridViewProSelect.Rows.Count; i++)
            {
                if (((int)dataGridViewProSelect.Rows[i].Cells[0].Value == int.Parse(textBoxProSelectOrderDetailID.Text)))
                {
                    //IDが存在する場合trueを返す
                    return true;
                }
            }

            //異常なしの場合falseを返す
            MessageBox.Show("入力された受注詳細IDのデータが存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void buttonProSelectDelete_Click(object sender, EventArgs e)
        {
            //受注詳細IDの入力チェック
            if (!OrderDetailIDInputCheck())
            {
                textBoxProSelectOrderDetailID.Focus();
                return;
            }

            if (msg.MsgDsp("M7021") == DialogResult.Cancel)
            {
                return;
            }

            dataGridViewProSelect.Rows.RemoveAt(int.Parse(textBoxProSelectOrderDetailID.Text) - formHome.OrderDetailID);

            //ずれた分の受注詳細IDを修正する
            for (int i = 0; i < dataGridViewProSelect.Rows.Count; i++)
            {
                dataGridViewProSelect.Rows[i].Cells[0].Value = i + formHome.OrderDetailID;
            }

            OrderDetailID--;
        }

        /// <summary>
        /// 確定ボタン
        /// </summary>
        /// <param></param>
        private void buttonProSelectConfirm_Click(object sender, EventArgs e)
        {
            //データを入力しているかチェック
            if (dataGridViewProSelect.Rows.Count == 0)
            {
                MessageBox.Show("商品を選択してください", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var context = new SalesManagement_DevContext();             //DB接続クラスのインスタンス化
                context.T_Orders.Add(formHome.AddOrderData);                //受注情報登録
                                                                            //label1.Text = formHome.AddOrderData.OrDate.ToString();

                context.SaveChanges();

                int[] StockHattyuList = new int[dataGridViewProSelect.Rows.Count];
                int index = 0;

                //登録データをデータグリッドビューから1行ずつ抽出する
                for (int i = 0; i < dataGridViewProSelect.Rows.Count; i++)
                {
                    //追加データをセットする
                    T_OrderDetail OrderDetail = OrderDetailAddDataSet(i);
                    //受注詳細テーブルにデータ追加する
                    context.T_OrderDetails.Add(OrderDetail);

                    //選択された商品の在庫データと商品データを抽出
                    T_Stock StockData = context.T_Stocks.Single(Stock => Stock.PrID == OrderDetail.PrID);
                    M_Product ProductData = formHome.ProductList.Single(Product => Product.PrID == OrderDetail.PrID);
                    //在庫数を更新
                    StockData.StQuantity -= OrderDetail.OrQuantity;

                    context.SaveChanges();          //登録を確定

                    //安全在庫数を下回っているかチェックする
                    if (StockData.StQuantity <= ProductData.PrSafetyStock)
                    {
                        StockHattyuList[index] = OrderDetail.PrID;

                        index++;
                    }
                }

                /*安全在庫数を下回っている商品の発注データを作成*/
                int cnt = 1;            //繰り返し終了判定用変数
                while (cnt != 0)            //配列の全データの合計が0になったら終了する
                {
                    cnt = 0;            //繰り返し終了判定用変数の初期化
                    int fincnt = 0;         //配列のindex用変数

                    int MaID = 0;         //発注テーブル用のメーカIDセット
                    while (MaID == 0 && StockHattyuList.Length > fincnt)    //メーカIDが見つかった場合か、配列を全て見終わった場合終了
                    {
                        if (StockHattyuList[fincnt] != 0)           //配列内のデータが0でない場合
                        {
                            int PrID = StockHattyuList[fincnt];         //商品IDをセット
                            M_Product product = formHome.ProductList.Single(Product => Product.PrID == PrID);       //商品IDと一致する商品データを抽出する
                            MaID = product.MaID;            //メーカIDをセット

                            context.T_Hattyus.Add(HattyuAddDataSet(MaID));      //発注テーブルにデータをセット

                            context.SaveChanges();      //データベースへの登録を確定
                        }
                        fincnt++;       //index用変数に＋１
                    }
                    for(int i = 0; i < StockHattyuList.Length; i++)
                    {
                        if (StockHattyuList[i] != 0)        //商品IDが0でない場合
                        {
                            int PrID = StockHattyuList[i];          //商品IDをセット
                            M_Product product = formHome.ProductList.Single(Product => Product.PrID == PrID);       //商品IDと一致する商品データを抽出する
                            if (MaID == product.MaID)           //同じメーカIDの場合のみ
                            {
                                context.T_HattyuDetails.Add(HattyuDetailAddSet(product));           //発注詳細テーブルにデータをセット

                                context.SaveChanges();      //データベースへの登録を確定

                                StockHattyuList[i] = 0;         //登録処理の終わったデータの値を0に変える
                            }
                            cnt = 1;         //繰り返し終了用変数
                        }
                    }
                    if (cnt != 0)           //データの追加があった場合
                    {
                        //context.SaveChanges();      //データベースへの登録を確定
                        formHome.HattyuList = context.T_Hattyus.ToList();       //発注リストの更新
                        formHome.HattyuDetailList = context.T_HattyuDetails.ToList();       //発注詳細リストの更新
                    }
                }
                /*/////////////////////////////////////////////*/

                //元の画面の一覧表示用データの更新
                formHome.OrderList = context.T_Orders.ToList();
                formHome.OrderDetailList = context.T_OrderDetails.ToList();
                formHome.StockList = context.T_Stocks.ToList();

                context.Dispose();              //contextを解放

                msg.MsgDsp("M7025");        //受注詳細情報確定メッセージ

                ClearText(this);            //入力内容をクリアする
                dataGridViewProSelect.Rows.Clear();     //データグリッドビューの内容をクリアする

                this.Visible = false;       //商品選択画面を閉じる
                formHome.Visible = true;    //元の画面に戻る
            }
            catch
            {
                //例外エラー
                MessageBox.Show("登録に失敗しました", "登録確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            formHome.ListOrder();
        }

        /// <summary>
        /// 発注データのセットをするメソッド
        /// </summary>
        private T_Hattyu HattyuAddDataSet(int MaID)
        {
            return new T_Hattyu
            {
                MaID = MaID,
                EmID = formHome.AddOrderData.EmID,
                HaDate = formHome.AddOrderData.OrDate,
                WaWarehouseFlag = 0,
                HaFlag = 0
            };
        }

        /// <summary>
        /// 発注詳細データのセット
        /// </summary>
        private T_HattyuDetail HattyuDetailAddSet(M_Product Product)
        {
            return new T_HattyuDetail
            {
                HaID = formHome.HattyuList.Count + 1,
                PrID = Product.PrID,
                HaQuantity = Product.PrSafetyStock * 2
            };
        }

        private T_OrderDetail OrderDetailAddDataSet(int i)
        {
            return new T_OrderDetail()
            {
                OrID=formHome.OrderID,
                PrID=int.Parse(dataGridViewProSelect.Rows[i].Cells[2].Value.ToString()),
                OrQuantity=int.Parse(dataGridViewProSelect.Rows[i].Cells[3].Value.ToString()),
                OrTotalPrice=int.Parse(dataGridViewProSelect.Rows[i].Cells[4].Value.ToString())
            };
        }

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

        /// <summary>
        /// 大分類ID(入力がある時)
        /// </summary>
        private void comboBoxProSelectMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //大分類名
            int McID = int.Parse(comboBoxProSelectMajor.SelectedItem.ToString());
            M_MajorClassification MajorClassData = formHome.MajorClassList.Single(MajorClass => MajorClass.McID == McID);
            textBoxPrSelectMajorName.Text = MajorClassData.McName;
            //小分類IDコンボボックスに大分類IDと一致しているデータを追加する
            comboBoxProSelectSmall.Items.Clear();
            List<M_SmallClassification> SmallClassData = formHome.SmallClassList.Where(SmallClass => SmallClass.McID == McID).ToList();
            foreach (var SmallClass in SmallClassData)
            {
                comboBoxProSelectSmall.Items.Add(SmallClass.ScID);
            }
        }

        /// <summary>
        /// 大分類ID(入力がない時)
        /// </summary>
        private void comboBoxProSelectMajor_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxProSelectMajor.Text == "")
            {
                comboBoxProSelectSmall.Items.Clear();
                //小分類IDコンボボックスにデータを追加
                foreach (var SmallClassData in formHome.SmallClassList)
                {
                    comboBoxProSelectSmall.Items.Add(SmallClassData.ScID);
                }
            }
        }

        /// <summary>
        /// 小分類ID(入力がある時)
        /// </summary>
        private void comboBoxProSelectSmall_SelectedIndexChanged(object sender, EventArgs e)
        {
            //小分類名
            int ScID = int.Parse(comboBoxProSelectSmall.SelectedItem.ToString());
            M_SmallClassification SmallClassData = formHome.SmallClassList.Single(SmallClass => SmallClass.ScID == ScID);
            textBoxPrSelectSmallName.Text = SmallClassData.ScName;
            //商品名コンボボックスに小分類IDと一致しているデータを追加する
            comboBoxProSelectProductName.Items.Clear();
            List<M_Product> ProductData = formHome.ProductList.Where(Product => Product.ScID == ScID).ToList();
            foreach (var Product in ProductData)
            {
                comboBoxProSelectProductName.Items.Add(Product.PrName);
            }
        }

        /// <summary>
        /// 小分類ID(入力がない時)
        /// </summary>
        private void comboBoxProSelectSmall_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxProSelectSmall.Text == "")
            {
                comboBoxProSelectProductName.Items.Clear();
                //商品名コンボボックスにデータを追加
                foreach (var ProductData in formHome.ProductList)
                {
                    comboBoxProSelectProductName.Items.Add(ProductData.PrName);
                }
            }
        }

        /// <summary>
        /// 商品名
        /// </summary>
        private void comboBoxProSelectProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string PrName = comboBoxProSelectProductName.Text;
            M_Product ProductData = formHome.ProductList.Single(Product => Product.PrName == PrName);
            textBoxProSelectProID.Text = ProductData.PrID.ToString();


            

            T_Stock StockData = formHome.StockList.Single(Stock => Stock.PrID == ProductData.PrID);
            labelStockNow.Text = StockData.StQuantity.ToString();

            


            //数量の上限を設定
            numericUpDownProSelectQuantity.Maximum = StockData.StQuantity;
            //数量が現在庫を超えている場合に上限と合わせる
            if (numericUpDownProSelectQuantity.Value > StockData.StQuantity)
            {
                numericUpDownProSelectQuantity.Value = StockData.StQuantity;
            }
        }

        private void numericUpDownProSelectQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void dataGridViewProSelect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridViewProSelect_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBoxProSelectOrderDetailID.Text = dataGridViewProSelect.Rows[dataGridViewProSelect.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxProSelectProID.Text = dataGridViewProSelect.Rows[dataGridViewProSelect.CurrentRow.Index].Cells[1].Value.ToString();
            //numericUpDownProSelectQuantity.TextAlign = (HorizontalAlignment)dataGridViewProSelect.Rows[dataGridViewProSelect.CurrentRow.Index].Cells[2].Value;
        }

        private void textBoxProSelectOrderDetailID_TextChanged(object sender, EventArgs e)
        {

            


        }

        private void labelStockNow_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxProSelectProID.Text.ToString());
            
            ListProductSelect();
        }
    }
}
