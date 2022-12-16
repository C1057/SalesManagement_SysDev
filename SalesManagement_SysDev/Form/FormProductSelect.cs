﻿using System;
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
            this.Visible = false;
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
            if (!string.IsNullOrEmpty(numericUpDownProSelectQuantity.Value.ToString()))
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
            var ProductData = context.M_Products.Single(Product => Product.PrID == int.Parse(textBoxProSelectProID.Text));
            int TotalPrice = int.Parse(labelProSelectTotalMoney.Text);

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

            //データグリッドビューに表示されている値を更新する
            for(int i = 0; i < dataGridViewProSelect.Rows.Count; i++)
            {
                if ((int)dataGridViewProSelect.Rows[i].Cells[0].Value == int.Parse(textBoxProSelectOrderDetailID.Text))
                {
                    dataGridViewProSelect.Rows[i].Cells[2].Value = textBoxProSelectProID.Text;
                    dataGridViewProSelect.Rows[i].Cells[3].Value = numericUpDownProSelectQuantity.Value;
                    dataGridViewProSelect.Rows[i].Cells[4].Value = labelProSelectTotalMoney.Text;
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
                if (!((int)dataGridViewProSelect.Rows[i].Cells[0].Value == int.Parse(textBoxProSelectOrderDetailID.Text)))
                {
                    return false;
                }
            }

            //異常なしの場合trueを返す
            return true;
        }

        private void buttonProSelectDelete_Click(object sender, EventArgs e)
        {
            //受注詳細IDの入力チェック
            if (!OrderDetailIDInputCheck())
            {
                textBoxProSelectOrderDetailID.Focus();
                return;
            }

            //データグリッドビューに表示されている値を更新する
            for (int i = 0; i < dataGridViewProSelect.Rows.Count; i++)
            {
                if ((int)dataGridViewProSelect.Rows[i].Cells[0].Value == int.Parse(textBoxProSelectOrderDetailID.Text))
                {
                    dataGridViewProSelect.Rows.RemoveAt(i);
                }
                dataGridViewProSelect.Rows[i].Cells[0].Value = i + 1;
            }

            OrderDetailID--;
        }
    }
}
