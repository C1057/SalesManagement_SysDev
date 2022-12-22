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

            //追加確認メッセージ
            if (DialogResult.Cancel == msg.MsgDsp("M7020"))
            {
                return;
            }

            //合計金額の計算
            var ProductData = ProductList.Single(Product => Product.PrID == int.Parse(textBoxProSelectProID.Text));
            //int TotalPrice = int.Parse(labelProSelectTotalMoney.Text.ToString());
            int TotalPrice = ProductData.Price * int.Parse(numericUpDownProSelectQuantity.Value.ToString());

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
            var ProductData = ProductList.Single(ProductList => ProductList.PrID == int.Parse(textBoxProSelectProID.Text));
            ProductPrice = ProductData.Price;

            //合計金額の表示
            labelProSelectTotalMoney.Text = (ProductPrice * int.Parse(numericUpDownProSelectQuantity.Value.ToString())).ToString("C");
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

            //受注詳細IDをと一致するデータを削除する
            dataGridViewProSelect.Rows.RemoveAt(int.Parse(textBoxProSelectOrderDetailID.Text) - 1);
            
            //ずれた分の受注詳細IDを修正する
            for (int i = 0; i < dataGridViewProSelect.Rows.Count; i++)
            {
                dataGridViewProSelect.Rows[i].Cells[0].Value = i + 1;
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

                //登録データをデータグリッドビューから1行ずつ抽出する
                for (int i = 0; i < dataGridViewProSelect.Rows.Count; i++)
                {
                    //受注詳細テーブルにデータ追加する
                    context.T_OrderDetails.Add(OrderDetailAddDataSet(i));
                }

                context.SaveChanges();          //登録を確定

                //元の画面の一覧表示用データの更新
                formHome.OrderList = context.T_Orders.ToList();
                formHome.OrderDetailList = context.T_OrderDetails.ToList();

                context.Dispose();              //contextを解放

                msg.MsgDsp("M7025");        //受注詳細情報確定メッセージ

                this.Visible = false;       //商品選択画面を閉じる
                formHome.Visible = true;    //元の画面に戻る
            }
            catch
            {
                //例外エラー
                MessageBox.Show("登録に失敗しました", "登録確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
