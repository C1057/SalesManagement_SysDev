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
    public partial class FormClassMana : Form
    {

        private FormHome formHome;
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

        ///<summary>
        ///共通モジュールのインスタンス化
        /// </summary>
        MessageDsp msg = new MessageDsp();                                              //メッセージ表示用クラス
        CheckExistence Existence = new CheckExistence();                                //IDの存在チェック用クラス
        DataInputCheck InputCheck = new DataInputCheck();                               //入力チェック用クラス

        MajorClassDataAccess MajorClassAccess = new MajorClassDataAccess();
        SmallClassDataAccess SmallClassAccess = new SmallClassDataAccess();

        public List<M_MajorClassification> MajorClassList;
        public List<M_SmallClassification> SmallClassList;



        private M_MajorClassification MajorClassifcationAddDataSet()　　//大分類登録データセット
        {
            return new M_MajorClassification
            {
                McName = textboxManaMajorClassName.Text.Trim(),
                McFlag = 0,
                McHidden = textboxCsManaMajorClassHidden.Text.Trim()
            };
        }

        private M_MajorClassification MajorClassUpdDataSet()　　//大分類更新データセット
        {
            return new M_MajorClassification
            {
                McID = int.Parse(comboBoxCsManaMajorClassID.Text.Trim()),
                McName = textboxManaMajorClassName.Text.Trim(),
                McFlag = 0,
                McHidden = textboxCsManaMajorClassHidden.Text.Trim()
            };
        }

        private bool MajorClassInputCheck()　　//大分類文字チェック
        {
            if (string.IsNullOrEmpty(textboxManaMajorClassName.Text))//大分類名の空文字チェック
            {
                msg.MsgDsp("M3033");
                textboxManaMajorClassName.Focus();
                return false;
            }

            if (textboxManaMajorClassName.Text.Length > 50)//大分類名の文字数チェック
            {
                msg.MsgDsp("M3034");
                textboxManaMajorClassName.Focus();
                return false;
            }

            return true;
        }

        private M_SmallClassification SmallClassifcationAddDataSet()　　//小分類登録データセット
        {
            return new M_SmallClassification
            {

                McID = int.Parse(comboBoxCsManaSmallMajorClassID.Text.Trim()),
                ScName = textBoxCsManaSmallClassName.Text.Trim(),
                ScFlag = 0,
                ScHidden = textBoxCsManaSmallClassHidden.Text.Trim()
            };
        }

        private M_SmallClassification SmallClassUpdDataSet()　　//小分類更新データセット
        {
            return new M_SmallClassification
            {
                ScID = int.Parse(comboBoxCsManaSmallClassID.Text.Trim()),
                McID = int.Parse(comboBoxCsManaSmallMajorClassID.Text.Trim()),
                ScName = textBoxCsManaSmallClassName.Text.Trim(),
                ScFlag = 0,
                ScHidden = textBoxCsManaSmallClassHidden.Text.Trim()
            };
        }

        private bool SmallClassInputCheck()　　//小分類文字チェック
        {
            if (string.IsNullOrEmpty(textBoxCsManaSmallClassName.Text))//小分類名の空文字チェック
            {
                msg.MsgDsp("M3046");
                textBoxCsManaSmallClassName.Focus();
                return false;
            }

            if (textBoxCsManaSmallClassName.Text.Length > 50)//名の文字数チェック
            {
                msg.MsgDsp("M3047");
                textBoxCsManaSmallClassName.Focus();
                return false;
            }

            return true;
        }

        private void ListMajorClass()
        {
            dataGridViewMajorClass.Rows.Clear();
            //データグリッドビューをクリアする
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            foreach (var MajorClassData in context.M_MajorClassifications)
            {
                if (MajorClassData.McFlag == 0)                     //役員管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewMajorClass.Rows.Add(MajorClassData.McID, MajorClassData.McName, Convert.ToBoolean(MajorClassData.McFlag), MajorClassData.McHidden);
                }

            }
        }
        private void DeleteListMajorClass()
        {
            dataGridViewMajorClass.Rows.Clear();
            //データグリッドビューをクリアする
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            foreach (var MajorClassData in context.M_MajorClassifications)
            {
                if (MajorClassData.McFlag == 2)                     //役員管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewMajorClass.Rows.Add(MajorClassData.McID, MajorClassData.McName, Convert.ToBoolean(MajorClassData.McFlag), MajorClassData.McHidden);
                }

            }
        }

        private void ListSmallClass()
        {
            dataGridViewSmallClass.Rows.Clear();
            //データグリッドビューをクリアする
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            foreach (var SmallClassData in context.M_SmallClassifications)
            {
                if (SmallClassData.ScFlag == 0)                     //役員管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewSmallClass.Rows.Add(SmallClassData.ScID,SmallClassData.McID, SmallClassData.ScName, Convert.ToBoolean(SmallClassData.ScFlag), SmallClassData.ScHidden);
                }

            }
        }
        private void DeleteListSmallClass()
        {
            dataGridViewSmallClass.Rows.Clear();
            //データグリッドビューをクリアする
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            foreach (var SmallClassData in context.M_SmallClassifications)
            {
                if (SmallClassData.ScFlag == 2)                     //役員管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewSmallClass.Rows.Add(SmallClassData.ScID,SmallClassData.McID, SmallClassData.ScName, Convert.ToBoolean(SmallClassData.ScFlag), SmallClassData.ScHidden);
                }

            }
        }

        private List<Panel> panelList = new System.Collections.Generic.List<Panel>();

        //bool flg = true;

        public FormClassMana(FormHome formHome)
        {
            InitializeComponent();

            panelList.Add(panel1);
            panelList.Add(panel2);

            this.formHome = formHome;
        }

        private void panelHide()
        {
            foreach (Panel panel in panelList)
            {
                panel.Hide();

            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化

            /// <summry>
            /// 大分類管理画面データグリッドビュー設定          //役職テーブルデータグリッドビュー
            /// </summry>
            var columnText = new string[]                       //各列のヘッダーテキストを設定
            {
                "大分類ID","大分類名","大分類管理フラグ","非表示理由"
            };

            var ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,false,true
            };

            var ColumnSize = new int[]                          //各列のWidthを設定
            {
                    200,350,200,385
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

                dataGridViewMajorClass.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewMajorClass.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            ListMajorClass();

            /// <summry>
            /// 小分類管理画面データグリッドビュー設定          //役職テーブルデータグリッドビュー
            /// </summry>
            columnText = new string[]                       //各列のヘッダーテキストを設定
            {
                "小分類ID","大分類ID","小分類名","小分類管理フラグ","非表示理由"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,false,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    150,150,350,150,335
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
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

                dataGridViewSmallClass.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewSmallClass.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            ListSmallClass();



            MajorClassList = context.M_MajorClassifications.ToList();       //List<M_MajorClassification>型のMajorClassListに[大分類]表示用データを代入する
            SmallClassList = context.M_SmallClassifications.ToList();       //List<M_SmallClassification>型のSmallClassListに[小分類]表示用データを代入する


            ResetComboBox(panel1);
            ResetComboBox(panel2);

            foreach (var MajorClassData in MajorClassList)
            {
                comboBoxCsManaMajorClassID.Items.Add(MajorClassData.McID);
            }

            //フォームの最大化ボタンの表示、非表示を切り替える
            this.MaximizeBox = !this.MaximizeBox;
            //フォームの最小化ボタンの表示、非表示を切り替える
            this.MinimizeBox = !this.MinimizeBox;
            //フォームのコントロールボックスの表示、非表示を切り替える
            //コントロールボックスを非表示にすると最大化、最小化、閉じるボタンも消える
            this.ControlBox = !this.ControlBox;
        }

        

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label70_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }



        private void maruibutton1_Click(object sender, EventArgs e)
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

            ResetComboBox(panel1);     //ComboBoxのItemsをリセットする

            foreach (var MajorClassData in MajorClassList)
            {
                comboBoxCsManaMajorClassID.Items.Add(MajorClassData.McID);
            }

            panel2.Hide();

            panel1.Show();

            label61.Text = ((Button)sender).Text + "管理";

            ListMajorClass();
            
            
            

        }

        private void maruibutton3_Click(object sender, EventArgs e)
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


            panel1.Hide();

            panel2.Show();

            label61.Text = ((Button)sender).Text + "管理";

            ResetComboBox(panel2);

            foreach (var SmallClassData in SmallClassList)
            {
                comboBoxCsManaSmallClassID.Items.Add(SmallClassData.ScID);
            }

            foreach (var MajorClassData in MajorClassList)
            {
                comboBoxCsManaSmallMajorClassID.Items.Add(MajorClassData.McID);
            }


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            formHome.Visible = true;

            //ResetComboBox();

            //foreach (var MajorClassData in MajorClassList)
            //{
            //    formHome.comboBoxPrMajorClassID.Items.Add(MajorClassData.McID);
            //}
            //foreach (var SmallClassData in SmallClassList)
            //{
            //    formHome.comboBoxPrSmallClassID.Items.Add(SmallClassData.ScID);
            //}
        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonCsManaMajorClassAdd_Click(object sender, EventArgs e)
        {
            //入力チェックメソッドの呼び出し
            if (!MajorClassInputCheck())
            {
                return;
            }

            //登録用役職情報のセット
            M_MajorClassification AddMajorClassData = MajorClassifcationAddDataSet();

            //役職情報の登録
            MajorClassAccess.AddMajorClass(AddMajorClassData);

            //役職情報一覧表示用データの更新
            MajorClassList = MajorClassAccess.GetData();

            //役職情報再表示
            ListMajorClass();
        }

        private void buttonCsManaMajorClassUpdate_Click(object sender, EventArgs e)
        {
            //大分類IDの入力チェック
            if (!InputCheck.MajorClassIDInputCheck(comboBoxCsManaMajorClassID.Text))
            {
               comboBoxCsManaMajorClassID.Focus();
                return;
            }

            //大分類名の入力チェック
            if (!MajorClassInputCheck())
            {
                textboxManaMajorClassName.Focus();
                return;
            }

            //更新用役職情報をセット
            M_MajorClassification updMajorClassData = MajorClassUpdDataSet();
            //役職更新モジュール呼び出し
            MajorClassAccess.UpdateMajorClass(updMajorClassData);

            //役職情報一覧表示用データの更新
            MajorClassList = MajorClassAccess.GetData();
            //役職情報再表示
            ListMajorClass();
        }

        private void buttonCsManaMajorClassList_Click(object sender, EventArgs e)
        {
            ListMajorClass();
        }

        private void maruibutton8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textboxCsManaMajorClassHidden.Text))
            {
                MessageBox.Show("非表示理由が入力されていません。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textboxCsManaMajorClassHidden.Focus();
                return;
            }

            DialogResult result = msg.MsgDsp("M14001");
            if (result == DialogResult.Cancel)
            {
                return;
            }

            for (int i = 0; i < dataGridViewMajorClass.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewMajorClass.Rows[i].Cells[2].Value)                 //1行ずつチェックボックスがチェックされているかを判定する
                {
                    MajorClassAccess.DeleteMajorClass((int)dataGridViewMajorClass.Rows[i].Cells[0].Value, textboxCsManaMajorClassHidden.Text);      //チェックされている場合その行の役職IDを引数に非表示機能モジュールを呼び出す
                }
            }
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //在庫情報一覧表示用データを更新
            MajorClassList = MajorClassAccess.GetData();
            //在庫情報再表示
            ListMajorClass();
        }

        private void buttonCsManaMajorClassDeletelist_Click(object sender, EventArgs e)
        {
            DeleteListMajorClass();
        }

        private void buttonCsManaSmallClassAdd_Click(object sender, EventArgs e)
        {
            //入力チェックメソッドの呼び出し
            if (!SmallClassInputCheck())
            {
                return;
            }

            //登録用役職情報のセット
            M_SmallClassification AddSmallClassData = SmallClassifcationAddDataSet();

            //役職情報の登録
            SmallClassAccess.AddSmallClass(AddSmallClassData);

            //役職情報一覧表示用データの更新
            SmallClassList = SmallClassAccess.GetData();

            //役職情報再表示
            ListSmallClass();
        }

        private void buttonCsManaSmallClassList_Click(object sender, EventArgs e)
        {
            ListSmallClass();
        }

        private void buttonCsManaSmallClassUodate_Click(object sender, EventArgs e)
        {
            //小分類IDの入力チェック
            if (!InputCheck.SmallClassIDInputCheck(comboBoxCsManaSmallClassID.Text))
            {
                comboBoxCsManaSmallClassID.Focus();
                return;
            }

            //小分類名の入力チェック
            if (!SmallClassInputCheck())
            {
                
                textBoxCsManaSmallClassName.Focus();
                return;
            }

            //更新用役職情報をセット
            M_SmallClassification updSmallClassData = SmallClassUpdDataSet();
            //役職更新モジュール呼び出し
            SmallClassAccess.UpdateSmallClass(updSmallClassData);

            //役職情報一覧表示用データの更新
            SmallClassList = SmallClassAccess.GetData();
            //役職情報再表示
            ListSmallClass();
        }

        private void maruibutton6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCsManaSmallClassHidden.Text))
            {
                MessageBox.Show("非表示理由が入力されていません。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCsManaSmallClassHidden.Focus();
                return;
            }

            DialogResult result = msg.MsgDsp("M14001");
            if (result == DialogResult.Cancel)
            {
                return;
            }

            for (int i = 0; i < dataGridViewSmallClass.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewSmallClass.Rows[i].Cells[3].Value)                 //1行ずつチェックボックスがチェックされているかを判定する
                {
                    SmallClassAccess.DeleteSmallClass((int)dataGridViewSmallClass.Rows[i].Cells[0].Value, textBoxCsManaSmallClassHidden.Text);      //チェックされている場合その行の役職IDを引数に非表示機能モジュールを呼び出す
                }
            }
            //msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //在庫情報一覧表示用データを更新
            SmallClassList = SmallClassAccess.GetData();
            //在庫情報再表示
            ListSmallClass();
        }

        private void maruibutton5_Click(object sender, EventArgs e)
        {
            DeleteListSmallClass();
        }

        

        

        private void dataGridViewMajorClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewMajorClass_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //大分類ID,大分類名、非表示理由
            comboBoxCsManaMajorClassID.Text = dataGridViewMajorClass.Rows[dataGridViewMajorClass.CurrentRow.Index].Cells[0].Value.ToString();
            textboxManaMajorClassName.Text = (string)dataGridViewMajorClass.Rows[dataGridViewMajorClass.CurrentRow.Index].Cells[1].Value;
            textboxCsManaMajorClassHidden.Text = (string)dataGridViewMajorClass.Rows[dataGridViewMajorClass.CurrentRow.Index].Cells[3].Value;
        }

        private void dataGridViewMajorClass_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCsManaMajorClassID_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int McID = int.Parse(comboBoxCsManaMajorClassID.SelectedItem.ToString());
            M_MajorClassification MajorClassData = MajorClassList.Single(MajorClass => MajorClass.McID == McID);
            textboxManaMajorClassName.Text = MajorClassData.McName;
            
        }

        private void dataGridViewSmallClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxCsManaSmallClassID.Text = dataGridViewSmallClass.Rows[dataGridViewSmallClass.CurrentRow.Index].Cells[0].Value.ToString();

            comboBoxCsManaSmallMajorClassID.Text = dataGridViewSmallClass.Rows[dataGridViewSmallClass.CurrentRow.Index].Cells[1].Value.ToString();
            int McID= int.Parse(dataGridViewSmallClass.Rows[dataGridViewSmallClass.CurrentRow.Index].Cells[1].Value.ToString());
            M_MajorClassification MajorClassData = MajorClassList.Single(MajorClass => MajorClass.McID == McID);
            textBoxCsManaSmallMajorClassName.Text = MajorClassData.McName;

            textBoxCsManaSmallClassName.Text = (string)dataGridViewSmallClass.Rows[dataGridViewSmallClass.CurrentRow.Index].Cells[2].Value;
            textBoxCsManaSmallClassHidden.Text = (string)dataGridViewSmallClass.Rows[dataGridViewSmallClass.CurrentRow.Index].Cells[4].Value;
        }

        private void comboBoxCsManaSmallClassID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ScID = int.Parse(comboBoxCsManaSmallClassID.SelectedItem.ToString());
            M_SmallClassification SmallClassData = SmallClassList.Single(SmallClass => SmallClass.ScID == ScID);
            //int McID = int.Parse(comboBoxCsManaSmallMajorClassID.Text);
            textBoxCsManaSmallClassName.Text = SmallClassData.ScName;
            //comboBoxCsManaSmallMajorClassID.Text = SmallClassData.McID;

            //foreach (SmallClassData in SmallClassList)
            //{
            //    comboBoxCsManaSmallMajorClassID.Items.Add(SmallClassData.McID);
            //}

        }

        private void comboBoxCsManaSmallMajorClassID_SelectedIndexChanged(object sender, EventArgs e)
        {

            int McID = int.Parse(comboBoxCsManaSmallMajorClassID.SelectedItem.ToString());
            M_MajorClassification MajorClassData = MajorClassList.Single(MajorClass => MajorClass.McID == McID);
            textBoxCsManaSmallMajorClassName.Text = MajorClassData.McName;

            comboBoxCsManaSmallClassID.Items.Clear();
            List<M_SmallClassification> SmallClassData = SmallClassList.Where(SmallClass => SmallClass.McID == McID).ToList();
            foreach(var ScData in SmallClassData)
            {
                comboBoxCsManaSmallClassID.Items.Add(ScData.ScID);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearText(this);
        }

        private void comboBoxCsManaSmallMajorClassID_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxCsManaMajorClassID.Text == "")
            {
                comboBoxCsManaSmallClassID.Items.Clear();
                //小分類IDコンボボックスにデータを追加
                foreach (var SmallClassData in SmallClassList)
                {
                    comboBoxCsManaSmallClassID.Items.Add(SmallClassData.ScID);
                }
            }
        }

        private void comboBoxCsManaMajorClassID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxCsManaMajorClassID.Text))           //主キーの項目に入力されていない場合
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

        private void comboBoxCsManaSmallClassID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxCsManaSmallClassID.Text))           //主キーの項目に入力されていない場合
            {
                EnabledChangedtruebutton(this);
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　　　　//主キーの項目に入力されている場合
            {
                EnabledChangedfalsebutton(this);
            }
        }
    }
}
