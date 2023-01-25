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
    public partial class FormPositionMana : Form
    {



        private M_Position PositionAddDataSet ()
        {
            return new M_Position
            {
                PoName = textBoxPositionManaPositionName.Text.Trim(),
                PoFlag = 0,
                PoHidden = textBoxPositionManaHidden.Text.Trim()
            };
        }

        private M_Position PositionUpdDataSet()
        {
            return new M_Position
            {
                PoID = int.Parse(comboBoxPositionManaPositionID.Text.Trim()),
                PoName = textBoxPositionManaPositionName.Text.Trim(),
                PoFlag = 0,
                PoHidden = textBoxPositionManaHidden.Text.Trim()
            }; 
        }


        /// <summary>
        /// 役職情報入力チェック
        /// </summary>
        /// <returns></returns>
        private bool PositionInputCheck()
        {
            if (string.IsNullOrEmpty(textBoxPositionManaPositionName.Text))//役職名の空文字チェック
            {
                msg.MsgDsp("M5031");
                textBoxPositionManaPositionName.Focus();
                return false;
            }

            if (textBoxPositionManaPositionName.Text.Length > 50)//役職名の文字数チェック
            {
                msg.MsgDsp("M5032");
                textBoxPositionManaPositionName.Focus();
                return false;
            }

            return true;
        }

       

        public FormPositionMana()
        {
            InitializeComponent();
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

        private void buttonPositionManaReturn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ClearText(this);

        }

        /// <summary>
        /// 役職テーブルの操作をするためのクラスをインスタンス化する
        /// </summary>
        PositionDataAccess PositionAccess = new PositionDataAccess();                   //[役職マスタ]操作用クラスのインスタンス化

        /// <summary>
        /// 役職テーブルの表示用データを保持するListの宣言
        /// </summary>

        List<M_Position> PositionList = new List<M_Position>();

        ///<summary>
        ///共通モジュールのインスタンス化
        /// </summary>
        MessageDsp msg = new MessageDsp();                                              //メッセージ表示用クラス
        CheckExistence Existence = new CheckExistence();                                //IDの存在チェック用クラス
        DataInputCheck InputCheck = new DataInputCheck();                               //入力チェック用クラス
       // PasswordHash PassHash = new PasswordHash();                                     //パスワードハッシュ化用クラス

        /// <summary>
        /// 役職情報一覧表示モジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>

        private void ListPosition()
        {
            dataGridViewPositionMana.Rows.Clear();
            //データグリッドビューをクリアする
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            foreach (var PositionData in context.M_Positions)
            //foreach (var PositionData in PositionList)
            {
                if (PositionData.PoFlag == 0)                     //役員管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewPositionMana.Rows.Add(PositionData.PoID, PositionData.PoName, Convert.ToBoolean(PositionData.PoFlag), PositionData.PoHidden);
                }
            }
        }

        /// <summary>
        /// 役職情報非表示リストモジュール
        /// (非表示になっているデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void DeleteListPosition()
        {
            dataGridViewPositionMana.Rows.Clear();                        //データグリッドビューをクリアする

            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            foreach (var PositionData in context.M_Positions)

              //  foreach (var PositionData in PositionList)
            {
                if (PositionData.PoFlag == 2)                     //顧客管理フラグが2の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewPositionMana.Rows.Add(PositionData.PoID, PositionData.PoName, Convert.ToBoolean(PositionData.PoFlag), PositionData.PoHidden);
                }
            }
        }

        /// <summary>
        /// 役職情報登録ボタン
        /// </summary>
        /// <param>なし</param>
        /// <return>なし</return>
        //private void buttonPositionManaAdd_Click(object sender, EventArgs e)
        //{            
        //    //入力チェックメソッドの呼び出し
        //    if (!PositionInputCheck())
        //    {
        //        return;
        //    }

        //    //登録用役職情報のセット
        //    M_Position AddPositionData = PositionAddDataSet();

        //    //役職情報の登録
        //    PositionAccess.AddPosition(AddPositionData);

        //    //役職情報一覧表示用データの更新
        //    PositionList = PositionAccess.GetData();

        //    //役職情報再表示
        //    ListPosition();
        //}

        /// <summary>
        /// 役職情報更新ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPositionManaUpdate_Click(object sender, EventArgs e)
        {

            //役職IDの入力チェック
            if (!InputCheck.PositionIDInputCheck(comboBoxPositionManaPositionID.Text))
            {
                comboBoxPositionManaPositionID.Focus();
                return;
            }

            //役職名の入力チェック
            if (!PositionInputCheck())
            {
                textBoxPositionManaPositionName.Focus();
                return;
            }

            //更新用役職情報をセット
            M_Position updPositionData = PositionUpdDataSet();

            //役職更新モジュール呼び出し
            PositionAccess.UpdatePosition(updPositionData);

            //役職情報一覧表示用データの更新
            PositionList = PositionAccess.GetData();
            //役職情報再表示
            ListPosition();
        }

        private void FormPositionMana_Load(object sender, EventArgs e)
        {

            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            /// <summry>
            /// 役職管理画面データグリッドビュー設定          //役職テーブルデータグリッドビュー
            /// </summry>
            var columnText = new string[]                       //各列のヘッダーテキストを設定
            {
                "役職ID","役職名","役職管理フラグ","非表示理由"
            };

            var ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,false,true
            };

            var ColumnSize = new int[]                          //各列のWidthを設定
            {
                    281,281,281,282
            };

            var columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
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

                dataGridViewPositionMana.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewPositionMana.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            ListPosition();

            PositionList = context.M_Positions.ToList();


            foreach (var PositionData in PositionList)
            {
                comboBoxPositionManaPositionID.Items.Add(PositionData.PoID);
            }
        }

        private void buttonPositionManaSrarch_Click(object sender, EventArgs e)
        {
            dataGridViewPositionMana.Rows.Clear();                        //データグリッドビューの内容を消去する

            if (!string.IsNullOrEmpty(comboBoxPositionManaPositionID.Text))             //顧客IDコンボボックスの空文字チェック
            {
                //顧客IDの入力チェック
                if (!InputCheck.ClientIDInputCheck(comboBoxPositionManaPositionID.Text))
                {
                    comboBoxPositionManaPositionID.Focus();
                    return;
                }

                foreach (var PoData in PositionAccess.SearchPosition(1, comboBoxPositionManaPositionID.Text))           //顧客IDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewPositionMana.Rows.Add(PoData.PoID,PoData.PoName, Convert.ToBoolean(PoData.PoFlag),PoData.PoHidden);
                }
                labelPoSearchTitle.Text = "役職IDで検索しました";            //何で検索したかを表示
            }

            else if (!string.IsNullOrEmpty(textBoxPositionManaPositionName.Text))       //顧客名テキストボックスの空文字チェック
            {
                foreach (var PoData in PositionAccess.SearchPosition(textBoxPositionManaPositionName.Text))             //顧客名で検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewPositionMana.Rows.Add(PoData.PoID, PoData.PoName, Convert.ToBoolean(PoData.PoFlag), PoData.PoHidden);
                }
                labelPoSearchTitle.Text = "役職名で検索しました";           //何で検索したかを表示
            }
            
        }

        private void buttonPositionManaList_Click(object sender, EventArgs e)
        {
            ListPosition();
        }

        private void buttonPositionManaDeleteList_Click(object sender, EventArgs e)
        {
            DeleteListPosition();
        }

        private void buttonPositionManaDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewPositionMana.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool) dataGridViewPositionMana.Rows[i].Cells[2].Value)                 //1行ずつチェックボックスがチェックされているかを判定する
                {
                    PositionAccess.DeletePosition((int)dataGridViewPositionMana.Rows[i].Cells[0].Value);      //チェックされている場合その行の役職IDを引数に非表示機能モジュールを呼び出す
                }
            }
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //在庫情報一覧表示用データを更新
            PositionList = PositionAccess.GetData();
            //在庫情報再表示
            ListPosition();
        }

        private void buttonPositionManaAdd_Click_1(object sender, EventArgs e)
        {
            //入力チェックメソッドの呼び出し
            if (!PositionInputCheck())
            {
                return;
            }

            //登録用役職情報のセット
            M_Position AddPositionData = PositionAddDataSet();

            //役職情報の登録
            PositionAccess.AddPosition(AddPositionData);

            //役職情報一覧表示用データの更新
            PositionList = PositionAccess.GetData();

            //役職情報再表示
            ListPosition();
        }

        private void dataGridViewPositionMana_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //大分類ID,大分類名、非表示理由
            comboBoxPositionManaPositionID.Text = dataGridViewPositionMana.Rows[dataGridViewPositionMana.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxPositionManaPositionName.Text = (string)dataGridViewPositionMana.Rows[dataGridViewPositionMana.CurrentRow.Index].Cells[1].Value;
            textBoxPositionManaHidden.Text = (string)dataGridViewPositionMana.Rows[dataGridViewPositionMana.CurrentRow.Index].Cells[3].Value;
        }

        private void comboBoxPositionManaPositionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PoID = int.Parse(comboBoxPositionManaPositionID.SelectedItem.ToString());
            M_Position PositionData = PositionList.Single(Position => Position.PoID == PoID);
            textBoxPositionManaPositionName.Text = PositionData.PoName;
            textBoxPositionManaHidden.Text = PositionData.PoHidden;
        }

        /// <summary>
        /// クリアボタン
        /// </summary>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearText(this);
        }
    }
}

