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
    public partial class FormSalesOfficeMana : Form
    {
        /// <summary>
        /// 役職テーブルの表示用データを保持するListの宣言
        /// </summary>

        List<M_SalesOffice> SalesOfficeList;

        ///<summary>
        ///共通モジュールのインスタンス化
        /// </summary>
        MessageDsp msg = new MessageDsp();                                              //メッセージ表示用クラス
        CheckExistence Existence = new CheckExistence();                                //IDの存在チェック用クラス
        DataInputCheck InputCheck = new DataInputCheck();                               //入力チェック用クラス

        SalesOfficeDataAccess SalesOfficeAccess = new SalesOfficeDataAccess();         //[営業所マスタ]操作用クラスのインスタンス化

        public FormHome formHome;

        private M_SalesOffice SalesOfficeAddDataSet()
        {
            return new M_SalesOffice
            {
                SoName = textBoxSoSalesOfficeName.Text.Trim(),
                SoAddress = textBoxSOManaAddress.Text.Trim(),
                SoPhone =textBoxSOManaPhone.Text.Trim(),
                SoPostal=textBoxSOManaPostal.Text.Trim(),
                SoFAX = textBoxSOManaFAX.Text.Trim(),
                SoFlag = 0,
                SoHidden =textBoxSOManaHidden.Text.Trim()
            };
        }

        private void DeleteListSOMana()
        {
            dataGridViewSOMana.Rows.Clear();                        //データグリッドビューをクリアする
            foreach (var SalesOfficeData in SalesOfficeList)
            {
                if (SalesOfficeData.SoFlag == 2)                     //役員管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewSOMana.Rows.Add(SalesOfficeData.SoID, SalesOfficeData.SoName, SalesOfficeData.SoAddress, SalesOfficeData.SoPhone,
                                                SalesOfficeData.SoPostal, SalesOfficeData.SoFAX, Convert.ToBoolean(SalesOfficeData.SoFlag), SalesOfficeData.SoHidden);
                }
            }
        }

        private M_SalesOffice SalesOfficeUpdDataSet()
        {
            return new M_SalesOffice
            {
                SoID = int.Parse(comboBoxSOManaSOID.Text),
                SoName = textBoxSoSalesOfficeName.Text.Trim(),
                SoAddress = textBoxSOManaAddress.Text.Trim(),
                SoPhone = textBoxSOManaPhone.Text.Trim(),
                SoPostal = textBoxSOManaPostal.Text.Trim(),
                SoFAX = textBoxSOManaFAX.Text.Trim(),
                SoFlag = 0,
                SoHidden = textBoxSOManaHidden.Text.Trim()
            };
        }

        /// <summary>
        /// 営業所情報入力チェック
        /// </summary>
        /// <returns></returns>
        private bool SaesOfficeInputCheck()
        {
            if (string.IsNullOrEmpty(textBoxSoSalesOfficeName.Text))//営業所名の空文字チェック
            {
                msg.MsgDsp("M5031");
                textBoxSoSalesOfficeName.Focus();
                return false;
            }

            if (textBoxSoSalesOfficeName.Text.Length > 50)//役職名の文字数チェック
            {
                msg.MsgDsp("M5032");
                textBoxSoSalesOfficeName.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 営業所情報一覧表示モジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>

        private void ListSalesOffice()
        {
            dataGridViewSOMana.Rows.Clear();                        //データグリッドビューをクリアする
            foreach (var SalesOfficeData in SalesOfficeList)
            {
                if (SalesOfficeData.SoFlag == 0)                     //役員管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewSOMana.Rows.Add(SalesOfficeData.SoID, SalesOfficeData.SoName, SalesOfficeData.SoAddress, SalesOfficeData.SoPhone,
                                                SalesOfficeData.SoPostal, SalesOfficeData.SoFAX, Convert.ToBoolean(SalesOfficeData.SoFlag), SalesOfficeData.SoHidden);
                }
            }
        }

        public FormSalesOfficeMana(FormHome formHome)
        {
            InitializeComponent();
            this.formHome = formHome;
        }

        private void buttonSOManaReturn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            formHome.Visible = true;
        }


        private void FormSalesOffice_Load(object sender, EventArgs e)
        {
            /// <summry>
            /// 営業所管理画面データグリッドビュー設定          //役職テーブルデータグリッドビュー
            /// </summry>
            var columnText = new string[]                       //各列のヘッダーテキストを設定
            {
                "営業所ID","営業所名","住所","電話番号","郵便番号","FAX","役職管理フラグ","非表示理由"
            };

            var ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true,true,false,true
            };

            var ColumnSize = new int[]                          //各列のWidthを設定
            {
                    100,200,250,100,100,100,100,191
            };

            var columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
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

                dataGridViewSOMana.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewSOMana.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            SalesOfficeList = SalesOfficeAccess.GetData();

             ListSalesOffice();

            foreach(var SoData in SalesOfficeList)
            {
                comboBoxSOManaSOID.Items.Add(SoData.SoID);
            }

            //フォームの最大化ボタンの表示、非表示を切り替える
            this.MaximizeBox = !this.MaximizeBox;
            //フォームの最小化ボタンの表示、非表示を切り替える
            this.MinimizeBox = !this.MinimizeBox;
            //フォームのコントロールボックスの表示、非表示を切り替える
            //コントロールボックスを非表示にすると最大化、最小化、閉じるボタンも消える
            this.ControlBox = !this.ControlBox;
        }

        private void buttonSOManaAdd_Click(object sender, EventArgs e)
        {
            //営業所名の入力チェック
            if (!InputCheck.SalesOfficeNameInputCheck(textBoxSoSalesOfficeName.Text))
            {
                textBoxSoSalesOfficeName.Focus();
                return;
            }

            //営業所の住所の入力チェック
            if (!InputCheck.SalesOfficeAdressInputCheck(textBoxSOManaAddress.Text))
            {
                textBoxSOManaAddress.Focus();
                return;
            }

            //営業所の電話番号の入力チェック
            if (!InputCheck.SalesOfficePhoneInputCheck(textBoxSOManaPhone.Text))
            {
                textBoxSOManaPhone.Focus();
                return;
            }

            //メーカーの郵便番号の入力チェック
            if (!InputCheck.SalesOfficePostalInputCheck(textBoxSOManaPostal.Text))
            {
                textBoxSOManaPostal.Focus();
                return;
            }

            //メーカーのFAXの入力チェック
            if (!InputCheck.SalesOfficeFaxInputCheck(textBoxSOManaFAX.Text))
            {
                textBoxSOManaFAX.Focus();
                return;
            }

            //登録用顧客情報のセット
            M_SalesOffice AddSalesOfficeData = SalesOfficeAddDataSet();

            //顧客情報の登録
            SalesOfficeAccess.AddSalesOffice(AddSalesOfficeData);

            //顧客情報一覧表示用データの更新
            SalesOfficeList = SalesOfficeAccess.GetData();

            //顧客情報再表示
            ListSalesOffice();
        }

        private void textBoxProSelectOrderID_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSOManaUpdate_Click(object sender, EventArgs e)
        {
            //営業所IDの入力チェック
            if (!InputCheck.SalesOfficeIDInputCheck(comboBoxSOManaSOID.Text))
            {
                comboBoxSOManaSOID.Focus();
                return;
            }
            //営業所名の入力チェック
            if (!InputCheck.SalesOfficeNameInputCheck(textBoxSoSalesOfficeName.Text))
            {
                textBoxSoSalesOfficeName.Focus();
                return;
            }
            //営業所の住所の入力チェック
            if (!InputCheck.SalesOfficeAdressInputCheck(textBoxSOManaAddress.Text))
            {
                textBoxSOManaAddress.Focus();
                return;
            }

            //営業所の電話番号の入力チェック
            if (!InputCheck.SalesOfficePhoneInputCheck(textBoxSOManaPhone.Text))
            {
                textBoxSOManaPhone.Focus();
                return;
            }

            //営業所の郵便番号の入力チェック
            if (!InputCheck.SalesOfficePhoneInputCheck(textBoxSOManaPostal.Text))
            {
                textBoxSOManaPostal.Focus();
                return;
            }

            //営業所のFAXの入力チェック
            if (!InputCheck.SalesOfficeFaxInputCheck(textBoxSOManaFAX.Text))
            {
                textBoxSOManaFAX.Focus();
                return;
            }

            //更新用営業所情報をセット
            M_SalesOffice updSalesOfficeData = SalesOfficeUpdDataSet();

            //営業所更新モジュール呼び出し
            SalesOfficeAccess.UpdateSalesOffice(updSalesOfficeData);

            //営業所情報一覧表示用データの更新
            SalesOfficeList = SalesOfficeAccess.GetData();

            //営業所情報再表示
            ListSalesOffice();
        }

        private void buttonSOManaSearch_Click(object sender, EventArgs e)
        {

        }

        private void buttonSOManaList_Click(object sender, EventArgs e)
        {
            ListSalesOffice();
        }

        private void maruibuttonSOManaDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSOManaHidden.Text))
            {
                MessageBox.Show("非表示理由が入力されていません。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSOManaHidden.Focus();
                return;
            }

            DialogResult result = msg.MsgDsp("M14001");
            if (result == DialogResult.Cancel)
            {
                return;
            }

            for (int i = 0; i < dataGridViewSOMana.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewSOMana.Rows[i].Cells[6].Value)                 //1行ずつチェックボックスがチェックされているかを判定する
                {
                    SalesOfficeAccess.DeleteClient((int)dataGridViewSOMana.Rows[i].Cells[0].Value, textBoxSOManaHidden.Text);      //チェックされている場合その行の役職IDを引数に非表示機能モジュールを呼び出す
                }
            }

            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //メーカ情報一覧表示用データを更新
            SalesOfficeList = SalesOfficeAccess.GetData();
            //メーカ情報再表示
            ListSalesOffice();
        }

        private void maruibuttonSOManaDeleteList_Click(object sender, EventArgs e)
        {
            DeleteListSOMana();
        }

        /// <summary>
        /// データグリッドビューセルクリックイベント
        /// </summary>
        private void dataGridViewSOMana_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //営業所ID、営業所名
            comboBoxSOManaSOID.Text = dataGridViewSOMana.Rows[dataGridViewSOMana.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxSoSalesOfficeName.Text = dataGridViewSOMana.Rows[dataGridViewSOMana.CurrentRow.Index].Cells[1].Value.ToString();
            //住所
            textBoxSOManaAddress.Text = dataGridViewSOMana.Rows[dataGridViewSOMana.CurrentRow.Index].Cells[2].Value.ToString();
            //電話番号
            textBoxSOManaPhone.Text = dataGridViewSOMana.Rows[dataGridViewSOMana.CurrentRow.Index].Cells[3].Value.ToString();
            //郵便番号
            textBoxSOManaPostal.Text = dataGridViewSOMana.Rows[dataGridViewSOMana.CurrentRow.Index].Cells[4].Value.ToString();
            //FAX
            textBoxSOManaFAX.Text = dataGridViewSOMana.Rows[dataGridViewSOMana.CurrentRow.Index].Cells[5].Value.ToString();
            //非表示理由
            textBoxSOManaHidden.Text = (string)dataGridViewSOMana.Rows[dataGridViewSOMana.CurrentRow.Index].Cells[7].Value;
        }

        private void comboBoxSOManaSOID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SoID = int.Parse(comboBoxSOManaSOID.SelectedItem.ToString());
            M_SalesOffice SalesOfficeData = SalesOfficeList.Single(SalesOffice => SalesOffice.SoID == SoID);
            textBoxSoSalesOfficeName.Text = SalesOfficeData.SoName;
        }

        /// <summary>
        /// クリアボタン
        /// </summary>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearText(this);
        }

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

        private void comboBoxSOManaSOID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSOManaSOID.Text))           //主キーの項目に入力されていない場合
            {
                EnabledChangedtruebutton(this);
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　　　　//主キーの項目に入力されている場合
            {
                EnabledChangedfalsebutton(this);
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
                        cControl.BackColor = Color.White;
                    }
                    if (cControl.Text == "更新")     //更新、検索ボタンの場合
                    {
                        cControl.Enabled = false;
                        cControl.BackColor = Color.FromArgb(170, 170, 170);
                    }
                }
            }
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
                        cControl.BackColor = Color.FromArgb(170, 170, 170);
                    }
                    if (cControl.Text == "更新")     //更新、検索ボタンの場合
                    {
                        cControl.Enabled = true;
                        cControl.BackColor = Color.White;
                    }
                }
            }
        }
    }
}
