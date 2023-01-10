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

        ///<summary>
        ///共通モジュールのインスタンス化
        /// </summary>
        MessageDsp msg = new MessageDsp();                                              //メッセージ表示用クラス
        CheckExistence Existence = new CheckExistence();                                //IDの存在チェック用クラス
        DataInputCheck InputCheck = new DataInputCheck();                               //入力チェック用クラス

        MajorClassDataAccess MajorClassAccess = new MajorClassDataAccess();
        SmallClassDataAccess SmallClassAccess = new SmallClassDataAccess();

        List<M_MajorClassification> MajorClassList;
        List<M_SmallClassification> SmallClassList;

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
                    dataGridViewSmallClass.Rows.Add(SmallClassData.ScID, SmallClassData.ScName, Convert.ToBoolean(SmallClassData.ScFlag), SmallClassData.ScHidden);
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
                    dataGridViewSmallClass.Rows.Add(SmallClassData.ScID, SmallClassData.ScName, Convert.ToBoolean(SmallClassData.ScFlag), SmallClassData.ScHidden);
                }

            }
        }

        private List<Panel> panelList = new System.Collections.Generic.List<Panel>();

        //bool flg = true;

        public FormClassMana()
        {
            InitializeComponent();

            panelList.Add(panel1);
            panelList.Add(panel2);

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
                    281,481,281,542
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
                "小分類ID","小分類名","小分類管理フラグ","非表示理由"
            };

            ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,false,true
            };

            ColumnSize = new int[]                          //各列のWidthを設定
            {
                    281,481,281,542
            };

            columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
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

                dataGridViewSmallClass.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewSmallClass.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする

            ListSmallClass();


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
            //timer1.Start();

            panel2.Hide();

            panel1.Show();

            label61.Text = ((Button)sender).Text + "管理";

        }

        private void maruibutton3_Click(object sender, EventArgs e)
        {

            panel1.Hide();

            panel2.Show();

            label61.Text = ((Button)sender).Text + "管理";

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
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
            for (int i = 0; i < dataGridViewMajorClass.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewMajorClass.Rows[i].Cells[2].Value)                 //1行ずつチェックボックスがチェックされているかを判定する
                {
                    MajorClassAccess.DeleteMajorClass((int)dataGridViewMajorClass.Rows[i].Cells[0].Value);      //チェックされている場合その行の役職IDを引数に非表示機能モジュールを呼び出す
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
            for (int i = 0; i < dataGridViewSmallClass.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewSmallClass.Rows[i].Cells[2].Value)                 //1行ずつチェックボックスがチェックされているかを判定する
                {
                    SmallClassAccess.DeleteSmallClass((int)dataGridViewSmallClass.Rows[i].Cells[0].Value);      //チェックされている場合その行の役職IDを引数に非表示機能モジュールを呼び出す
                }
            }
            msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //在庫情報一覧表示用データを更新
            SmallClassList = SmallClassAccess.GetData();
            //在庫情報再表示
            ListSmallClass();
        }

        private void maruibutton5_Click(object sender, EventArgs e)
        {
            DeleteListSmallClass();
        }
    }
}
