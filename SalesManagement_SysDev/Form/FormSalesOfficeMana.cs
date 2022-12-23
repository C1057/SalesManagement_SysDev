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
        PasswordHash PassHash = new PasswordHash();                                     //パスワードハッシュ化用クラス

        private M_SalesOffice SalesOfficeAddDataSet()
        {
            return new M_SalesOffice
            {
                SoID=int.Parse(comboBoxSOManaSOID.Text),
                SoName = textBoxProSelectOrderID.Text.Trim(),
                SoAddress = textBoxSOManaAddress.Text.Trim(),
                SoPhone =textBoxSOManaPhone.Text.Trim(),
                SoPostal=textBoxSOManaPostal.Text.Trim(),
                SoFAX = textBoxSOManaFAX.Text.Trim(),
                SoFlag = 0,
                SoHidden =textBoxSOManaHidden.Text.Trim()
            };
        }

        private M_SalesOffice SalesOfficeUpdDataSet()
        {
            return new M_SalesOffice
            {
                SoID = int.Parse(comboBoxSOManaSOID.Text),
                SoName = textBoxProSelectOrderID.Text.Trim(),
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
            if (string.IsNullOrEmpty(textBoxProSelectOrderID.Text))//営業所名の空文字チェック
            {
                msg.MsgDsp("M5031");
                textBoxProSelectOrderID.Focus();
                return false;
            }

            if (textBoxProSelectOrderID.Text.Length > 50)//役職名の文字数チェック
            {
                msg.MsgDsp("M5032");
                textBoxProSelectOrderID.Focus();
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

        public FormSalesOfficeMana()
        {
            InitializeComponent();    
        }

        private void buttonSOManaReturn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
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

            // ListSalesOffice();

        }
    }
}
