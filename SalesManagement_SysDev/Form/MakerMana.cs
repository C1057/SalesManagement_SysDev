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
    public partial class MakerMana : Form
    {
        MessageDsp msg = new MessageDsp();          //メッセージ表示用クラスのインスタンス化
        DataInputCheck InputCheck = new DataInputCheck();   //入力チェック用クラスのインスタンス化
        CheckExistence Existence = new CheckExistence();    //存在チェック用クラスのインスタンス化

        MakerDataAccess MakerAccess = new MakerDataAccess();         //[メーカーマスタ]操作用クラスのインスタンス化

        List<M_Maker> MakerList;                                                        //表示用[メーカー]情報を保持する変数

        private FormHome formHome;

        public MakerMana(FormHome formHome)
        {
            InitializeComponent();

            this.formHome = formHome;
        }

        private void buttonManaMakerReturn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            formHome.Visible = true;


            ClearText(this);
            dataGridViewManaMaker.Rows.Clear();
        }

        private M_Maker ManaMakerUpdDataSet()
        {
            return new M_Maker
            {
                MaID = int.Parse(comboBoxManaMakerID.Text.Trim()),
                MaName = textBoxManaMakerName.Text.Trim(),
                MaAdress = textBoxManaMakerAdress.Text.Trim(),
                MaPhone = textBoxManaMakerPhone.Text.Trim(),
                MaPostal = textBoxManaMakerPostal.Text.Trim(),
                MaFAX = textBoxManaMakerFax.Text.Trim(),
                MaFlag = 0,
                MaHidden = textBoxManaMakerHidden.Text.Trim()
            };
        }


        private void MakerMana_Load(object sender, EventArgs e)
        {
            var context = new SalesManagement_DevContext();

            var columnText = new string[]                       //各列のヘッダーテキストを設定
            {
                "メーカーID","メーカー名","住所","電話番号","郵便番号","FAX","メーカー管理フラグ","非表示理由"
            };

            var ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true,true,false,true
            };

            var ColumnSize = new int[]                          //各列のWidthを設定
            {
                    100,150,200,100,100,100,100,290
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

                dataGridViewManaMaker.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewManaMaker.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする  

            MakerList = context.M_Makers.ToList();                          //List<M_Maker>型のMakerListに[メーカー]表示用データを代入する

            //フォームの最大化ボタンの表示、非表示を切り替える
            this.MaximizeBox = !this.MaximizeBox;
            //フォームの最小化ボタンの表示、非表示を切り替える
            this.MinimizeBox = !this.MinimizeBox;
            //フォームのコントロールボックスの表示、非表示を切り替える
            //コントロールボックスを非表示にすると最大化、最小化、閉じるボタンも消える
            this.ControlBox = !this.ControlBox;
        }

        private void ListMaker()
        {
            dataGridViewManaMaker.Rows.Clear();                        //データグリッドビューをクリアする
            foreach (var ManaMakerData in MakerList)
            {
                if (ManaMakerData.MaFlag == 0)                     //顧客管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewManaMaker.Rows.Add(ManaMakerData.MaID, ManaMakerData.MaName, ManaMakerData.MaAdress, ManaMakerData.MaPhone,
                                               ManaMakerData.MaPostal, ManaMakerData.MaFAX, Convert.ToBoolean(ManaMakerData.MaFlag), ManaMakerData.MaHidden);
                }
            }
        }

        private void dataGridViewManaMaker_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// メーカ情報非表示リストモジュール
        /// (非表示になっているデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>
        private void DeleteListMaker()
        {
            dataGridViewManaMaker.Rows.Clear();                        //データグリッドビューをクリアする

            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            foreach (var MaData in context.M_Makers)

            //  foreach (var PositionData in PositionList)
            {
                if (MaData.MaFlag == 2)                     //メーカ管理フラグが2の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewManaMaker.Rows.Add(MaData.MaID, MaData.MaName, MaData.MaAdress, MaData.MaPhone,
                        MaData.MaPostal, MaData.MaFAX, Convert.ToBoolean(MaData.MaFlag), MaData.MaHidden);
                }
            }
        }

        private void buttonAddMaker_Click(object sender, EventArgs e)
        {
            //メーカー名の入力チェック
            if (!InputCheck.MakerNameInputCheck(textBoxManaMakerName.Text))
            {
                textBoxManaMakerName.Focus();
                return;
            }
            //メーカーの住所の入力チェック
            if (!InputCheck.MakerAdressInputCheck(textBoxManaMakerAdress.Text))
            {
                textBoxManaMakerAdress.Focus();
                return;
            }

            //メーカーの電話番号の入力チェック
            if (!InputCheck.MakerPhoneInputCheck(textBoxManaMakerPhone.Text))
            {
                textBoxManaMakerPhone.Focus();
                return;
            }

            //メーカーの郵便番号の入力チェック
            if (!InputCheck.MakerPhoneInputCheck(textBoxManaMakerPostal.Text))
            {
                textBoxManaMakerPostal.Focus();
                return;
            }

            //メーカーのFAXの入力チェック
            if (!InputCheck.MakerFAXInputCheck(textBoxManaMakerFax.Text))
            {
                textBoxManaMakerFax.Focus();
                return;
            }

            //登録用顧客情報のセット
            M_Maker AddManaMakerData = ManaMakerAddDataSet();

            //顧客情報の登録
            MakerAccess.AddMaker(AddManaMakerData);

            //顧客情報一覧表示用データの更新
            MakerList = MakerAccess.GetData();

            //顧客情報再表示
            ListMaker();
        }

        private M_Maker ManaMakerAddDataSet()
        {
            return new M_Maker
            {
                MaName = textBoxManaMakerName.Text.Trim(),
                MaAdress = textBoxManaMakerAdress.Text.Trim(),
                MaPhone = textBoxManaMakerPhone.Text.Trim(),
                MaPostal = textBoxManaMakerPostal.Text.Trim(),
                MaFAX = textBoxManaMakerFax.Text.Trim(),
                MaFlag = 0,
                MaHidden = textBoxManaMakerHidden.Text.Trim()
            };
        }




        private void buttonUpdateMaker_Click(object sender, EventArgs e)
        {
            //メーカーIDの入力チェック
            if (!InputCheck.MakerIDInputCheck(comboBoxManaMakerID.Text))
            {
                comboBoxManaMakerID.Focus();
                return;
            }
            //メーカー名の入力チェック
            if (!InputCheck.MakerNameInputCheck(textBoxManaMakerName.Text))
            {
                textBoxManaMakerName.Focus();
                return;
            }
            //メーカーの住所の入力チェック
            if (!InputCheck.MakerAdressInputCheck(textBoxManaMakerAdress.Text))
            {
                textBoxManaMakerAdress.Focus();
                return;
            }

            //メーカーの電話番号の入力チェック
            if (!InputCheck.MakerPhoneInputCheck(textBoxManaMakerPhone.Text))
            {
                textBoxManaMakerPhone.Focus();
                return;
            }

            //メーカーの郵便番号の入力チェック
            if (!InputCheck.MakerPhoneInputCheck(textBoxManaMakerPostal.Text))
            {
                textBoxManaMakerPostal.Focus();
                return;
            }

            //メーカーのFAXの入力チェック
            if (!InputCheck.MakerFAXInputCheck(textBoxManaMakerFax.Text))
            {
                textBoxManaMakerFax.Focus();
                return;
            }

            //更新用顧客情報をセット
            M_Maker updManaMakerData = ManaMakerUpdDataSet();

            //顧客更新モジュール呼び出し
            MakerAccess.UpdateMaker(updManaMakerData);

            //顧客情報一覧表示用データの更新
            MakerList = MakerAccess.GetData();

            //顧客情報再表示
            ListMaker();
        }

        private void buttonListMaker_Click(object sender, EventArgs e)
        {
            ListMaker();
        }

        private void buttonManaMakerDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxManaMakerHidden.Text))
            {
                MessageBox.Show("非表示理由が入力されていません。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxManaMakerHidden.Focus();
                return;
            }

            DialogResult result = msg.MsgDsp("M14001");
            if (result == DialogResult.Cancel)
            {
                return;
            }

            for (int i = 0; i < dataGridViewManaMaker.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewManaMaker.Rows[i].Cells[6].Value)                 //1行ずつチェックボックスがチェックされているかを判定する
                {
                    MakerAccess.DeleteMaker((int)dataGridViewManaMaker.Rows[i].Cells[0].Value, textBoxManaMakerHidden.Text);      //チェックされている場合その行の役職IDを引数に非表示機能モジュールを呼び出す
                }
            }
            
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //メーカ情報一覧表示用データを更新
            MakerList = MakerAccess.GetData();
            //メーカ情報再表示
            ListMaker();
        }

        private void buttonManaMakerDeleteList_Click(object sender, EventArgs e)
        {
            DeleteListMaker();
        }

        private void buttonSearchMaker_Click(object sender, EventArgs e)
        {
            dataGridViewManaMaker.Rows.Clear();                        //データグリッドビューの内容を消去する

            if (!string.IsNullOrEmpty(comboBoxManaMakerID.Text))             //メーカIDコンボボックスの空文字チェック
            {
                //メーカIDの入力チェック
                if (!InputCheck.MakerIDInputCheck(comboBoxManaMakerID.Text))
                {
                    comboBoxManaMakerID.Focus();
                    return;
                }

                foreach (var MaData in MakerAccess.SearchMaker(1, comboBoxManaMakerID.Text))           //メーカIDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewManaMaker.Rows.Add(MaData.MaID, MaData.MaName,　MaData.MaAdress, MaData.MaPhone, 
                        MaData.MaPostal,MaData.MaFAX,  Convert.ToBoolean(MaData.MaFlag), MaData.MaHidden);
                }
                labelMaSearchTitle.Text = "メーカIDで検索しました";            //何で検索したかを表示
            }

            else if (!string.IsNullOrEmpty(textBoxManaMakerName.Text))       //メーカ名テキストボックスの空文字チェック
            {
                foreach (var MaData in MakerAccess.SearchMaker(textBoxManaMakerName.Text))             //顧客名で検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewManaMaker.Rows.Add(MaData.MaID, MaData.MaName, MaData.MaAdress, MaData.MaPhone,
                        MaData.MaPostal, MaData.MaFAX, Convert.ToBoolean(MaData.MaFlag), MaData.MaHidden);
                }
                labelMaSearchTitle.Text = "役職名で検索しました";           //何で検索したかを表示
            }
        }

        private void dataGridViewManaMaker_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //メーカーID
            comboBoxManaMakerID.Text = dataGridViewManaMaker.Rows[dataGridViewManaMaker.CurrentRow.Index].Cells[0].Value.ToString();
            //メーカー名
            textBoxManaMakerName.Text = dataGridViewManaMaker.Rows[dataGridViewManaMaker.CurrentRow.Index].Cells[1].Value.ToString();
            //住所
            textBoxManaMakerAdress.Text = dataGridViewManaMaker.Rows[dataGridViewManaMaker.CurrentRow.Index].Cells[2].Value.ToString();
            //電話番号
            textBoxManaMakerPhone.Text = dataGridViewManaMaker.Rows[dataGridViewManaMaker.CurrentRow.Index].Cells[3].Value.ToString();
            //郵便番号
            textBoxManaMakerPostal.Text = dataGridViewManaMaker.Rows[dataGridViewManaMaker.CurrentRow.Index].Cells[4].Value.ToString();
            //FAX
            textBoxManaMakerFax.Text = dataGridViewManaMaker.Rows[dataGridViewManaMaker.CurrentRow.Index].Cells[5].Value.ToString();
            //非表示理由
            textBoxManaMakerHidden.Text = (string)dataGridViewManaMaker.Rows[dataGridViewManaMaker.CurrentRow.Index].Cells[7].Value;

        }

        private void MakerMana_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                ListMaker();        //一覧表示

                ResetComboBox(this);     //ComboBoxのItemsをリセットする
                                         //出荷IDコンボボックスにデータを追加
                foreach (var MakerData in MakerList)
                {
                    comboBoxManaMakerID.Items.Add(MakerData.MaID);
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

        private void comboBoxManaMakerID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxManaMakerID.Text))           //主キーの項目に入力されていない場合
            {
                EnabledChangedtruebutton(this);
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　　　　//主キーの項目に入力されている場合
            {
                EnabledChangedfalsebutton(this);
            }
        }

        private void comboBoxManaMakerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MaID = int.Parse(comboBoxManaMakerID.SelectedItem.ToString());
            M_Maker MakerData = MakerList.Single(Maker => Maker.MaID == MaID);
            textBoxManaMakerName.Text = MakerData.MaName;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearText(this);
        }
    }
}

