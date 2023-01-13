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


        public MakerMana()
        {
            InitializeComponent();
        }

        private void buttonManaMakerReturn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private M_Maker ManaMakerUpdDataSet()
        {
            return new M_Maker
            {
                MaID = int.Parse(textBoxManaMekerID.Text.Trim()),
                MaName = comboBoxManaMakerName.Text.Trim(),
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
        private void DeleteListPosition()
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
            //メーカーIDの入力チェックメソッドの呼びだし
            if (!InputCheck.MakerIDInputCheck(textBoxManaMekerID.Text))
            {
                textBoxManaMekerID.Focus();
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
                MaID = int.Parse(textBoxManaMekerID.Text.Trim()),
                MaName = comboBoxManaMakerName.Text.Trim(),
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
            if (!InputCheck.MakerIDInputCheck(textBoxManaMekerID.Text))
            {
                textBoxManaMekerID.Focus();
                return;
            }
            //メーカー名の入力チェック
            if (!InputCheck.MakerNameInputCheck(comboBoxManaMakerName.Text))
            {
                comboBoxManaMakerName.Focus();
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
            for (int i = 0; i < dataGridViewManaMaker.Rows.Count; i++)                     //データグリッドビューの行の数だけ繰り返す
            {
                if ((bool)dataGridViewManaMaker.Rows[i].Cells[2].Value)                 //1行ずつチェックボックスがチェックされているかを判定する
                {
                    MakerAccess.DeleteMaker((int)dataGridViewManaMaker.Rows[i].Cells[0].Value);      //チェックされている場合その行の役職IDを引数に非表示機能モジュールを呼び出す
                }
            }
            
            msg.MsgDsp("M14002");                                                   //非表示完了メッセージ

            //メーカ情報一覧表示用データを更新
            MakerList = MakerAccess.GetData();
            //メーカ情報再表示
            ListMaker();
        }

        private void buttonManaMakerDeleteList_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonSearchMaker_Click(object sender, EventArgs e)
        {
            dataGridViewManaMaker.Rows.Clear();                        //データグリッドビューの内容を消去する

            if (!string.IsNullOrEmpty(textBoxManaMekerID.Text))             //メーカIDコンボボックスの空文字チェック
            {
                //メーカIDの入力チェック
                if (!InputCheck.MakerIDInputCheck(textBoxManaMekerID.Text))
                {
                    textBoxManaMekerID.Focus();
                    return;
                }

                foreach (var MaData in MakerAccess.SearchMaker(1, textBoxManaMekerID.Text))           //メーカIDで検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewManaMaker.Rows.Add(MaData.MaID, MaData.MaName,　MaData.MaAdress, MaData.MaPhone, 
                        MaData.MaPostal,MaData.MaFAX,  Convert.ToBoolean(MaData.MaFlag), MaData.MaHidden);
                }
                labelMaSearchTitle.Text = "メーカIDで検索しました";            //何で検索したかを表示
            }

            else if (!string.IsNullOrEmpty(comboBoxManaMakerName.Text))       //メーカ名テキストボックスの空文字チェック
            {
                foreach (var MaData in MakerAccess.SearchMaker(comboBoxManaMakerName.Text))             //顧客名で検索する
                {
                    //データグリッドビューにデータを表示
                    dataGridViewManaMaker.Rows.Add(MaData.MaID, MaData.MaName, MaData.MaAdress, MaData.MaPhone,
                        MaData.MaPostal, MaData.MaFAX, Convert.ToBoolean(MaData.MaFlag), MaData.MaHidden);
                }
                labelMaSearchTitle.Text = "役職名で検索しました";           //何で検索したかを表示
            }
        }
    }
}

