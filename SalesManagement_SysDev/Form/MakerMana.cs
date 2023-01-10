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

        private void buttonAddMaker_Click(object sender, EventArgs e)
        {
            //メーカーIDの入力チェックメソッドの呼びだし
            if (!InputCheck.MakerIDInputCheck(textBoxManaMekerID.Text))
            {
                textBoxManaMekerID.Focus();
                return;
            }
            //入力チェックメソッドの呼び出し
            //if (!MakerInputCheck())
            //{
            //    return;
            //}

            //登録用顧客情報のセット
            //M_Maker AddManaMakerData = MakerAddDataSet();

            //顧客情報の登録
            //MakerAccess.AddMaker(AddManaMakerData);

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
            ////メーカーIDの入力チェック
            //if (!InputCheck.ClientIDInputCheck(comboBoxManaMakerName.Text))
            //{
            //    textBoxManaMekerID.Focus();
            //    return;
            //}
            ////メーカー名の入力チェック
            //if (!InputCheck.SalesOfficeIDInputCheck(comboBoxManaMakerName.Text))
            //{
            //    comboBoxManaMakerName.Focus();
            //    return;
            //}
            ////顧客ID,営業所ID以外の入力チェック
            //if (!MakerInputCheck())
            //{
            //    return;
            //}
            ////更新用顧客情報をセット
            //M_Client updManaMakerData = MakerUpdDataSet();
            ////顧客更新モジュール呼び出し
            //MakerAccess.UpdateMaker(updMakerData);

            ////顧客情報一覧表示用データの更新
            //MakerList = MakerAccess.GetData();
            ////顧客情報再表示
            //ListMaker();
        }

        private void buttonListMaker_Click(object sender, EventArgs e)
        {
            foreach (var ManaMakerData in MakerList)
            {
                if (ManaMakerData.MaFlag == 0)                     //メーカー管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewManaMaker.Rows.Add(ManaMakerData.MaID, ManaMakerData.MaName, ManaMakerData.MaAdress,  ManaMakerData.MaPhone,
                                               ManaMakerData.MaPostal, ManaMakerData.MaFAX, Convert.ToBoolean(ManaMakerData.MaFlag), ManaMakerData.MaHidden);
                }
            }
        }

        private void buttonManaMakerDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonManaMakerDeleteList_Click(object sender, EventArgs e)
        {
            foreach (var ManaMakerData in MakerList)
            {
                if (ManaMakerData.MaFlag == 2)                     //メーカー管理フラグが0の場合表示する
                {
                    //データグリッドビューにデータを追加する
                    dataGridViewManaMaker.Rows.Add(ManaMakerData.MaID, ManaMakerData.MaName, ManaMakerData.MaAdress, ManaMakerData.MaPhone,
                                               ManaMakerData.MaPostal, ManaMakerData.MaFAX, Convert.ToBoolean(ManaMakerData.MaFlag), ManaMakerData.MaHidden);
                }
            }
        }

        /// <summary>
        /// メーカー情報入力チェックメソッド
        /// </summary>
        /// <returns>異常あり:false, 異常なし:true</returns>
        //private bool MakerIDInputCheck()
        //{
        //    //メーカー管理画面顧客名の空文字チェック
        //    if (string.IsNullOrEmpty(textBoxManaMekerID.Text.Trim()))
        //    {
        //        msg.MsgDsp("M");
        //        textBoxCIClientName.Focus();
        //        return false;
        //    }

        //    //顧客管理画面顧客名の全角チェック
        //    if (!InputCheck.CheckFullWidth(textBoxCIClientName.Text.Trim()))
        //    {
        //        msg.MsgDsp("M2008");
        //        textBoxCIClientName.Focus();
        //        return false;
        //    }

        //    //顧客管理画面営業所IDの文字数チェック
        //    if (textBoxCIClientName.Text.Trim().Length > 50)
        //    {
        //        msg.MsgDsp("M2009");
        //        textBoxCIClientName.Focus();
        //        return false;
        //    }

        //    //顧客管理画面住所の空文字チェック
        //    if (string.IsNullOrEmpty(textBoxCIAddress.Text.Trim()))
        //    {
        //        msg.MsgDsp("M2010");
        //        textBoxCIAddress.Focus();
        //        return false;
        //    }

        //    //顧客管理画面住所の全角チェック
        //    if (!InputCheck.CheckFullWidth(textBoxCIAddress.Text.Trim()))
        //    {
        //        msg.MsgDsp("M2011");
        //        textBoxCIAddress.Focus();
        //        return false;
        //    }

        //    //顧客管理画面住所の文字数チェック
        //    if (textBoxCIAddress.Text.Trim().Length > 50)
        //    {
        //        msg.MsgDsp("M2012");
        //        textBoxCIAddress.Focus();
        //        return false;
        //    }

        //    //顧客管理画面電話番号の空文字チェック
        //    if (string.IsNullOrEmpty(textBoxCIPhone.Text.Trim()))
        //    {
        //        msg.MsgDsp("M2013");
        //        textBoxCIPhone.FindForm();
        //        return false;
        //    }

        //    //顧客管理画面電話番号の半角数字チェック
        //    if (!InputCheck.CheckNumericAndHalfChar(textBoxCIPhone.Text.Trim()))
        //    {
        //        msg.MsgDsp("M2014");
        //        textBoxCIPhone.Focus();
        //        return false;
        //    }

        //    //顧客管理画面電話番号の文字数チェック
        //    if (textBoxCIPhone.Text.Trim().Length > 13)
        //    {
        //        msg.MsgDsp("M2015");
        //        textBoxCIPhone.Focus();
        //        return false;
        //    }

        //    //顧客管理画面郵便番号の空文字チェック
        //    if (string.IsNullOrEmpty(textBoxCIPostal.Text.Trim()))
        //    {
        //        msg.MsgDsp("M2016");
        //        textBoxCIPostal.Focus();
        //        return false;
        //    }

        //    //顧客管理画面郵便番号の半角数字チェック
        //    if (!InputCheck.CheckNumericAndHalfChar(textBoxCIPostal.Text.Trim()))
        //    {
        //        msg.MsgDsp("M2017");
        //        textBoxCIPostal.Focus();
        //        return false;
        //    }

        //    //顧客管理画面郵便番号の文字数チェック
        //    if (textBoxCIPostal.Text.Trim().Length > 7)
        //    {
        //        msg.MsgDsp("M2018");
        //        textBoxCIPostal.Focus();
        //        return false;
        //    }

        //    //顧客管理画面FAXの空文字チェック
        //    if (string.IsNullOrEmpty(textBoxCIFax.Text.Trim()))
        //    {
        //        msg.MsgDsp("M2019");
        //        textBoxCIFax.Focus();
        //        return false;
        //    }

        //    //顧客管理画面FAXの半角数字チェック
        //    if (!InputCheck.CheckNumericAndHalfChar(textBoxCIFax.Text.Trim()))
        //    {
        //        msg.MsgDsp("M2020");
        //        textBoxCIFax.Focus();
        //        return false;
        //    }

        //    //顧客管理画面FAXの文字数チェック
        //    if (textBoxCIFax.Text.Trim().Length > 13)
        //    {
        //        msg.MsgDsp("M2021");
        //        textBoxCIFax.Focus();
        //        return false;
        //    }

        //    //異常が無い場合trueを返す
        //    return true;
        }
    }

