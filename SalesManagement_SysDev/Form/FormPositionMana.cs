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
        public FormPositionMana()
        {
            InitializeComponent();
        }

        private void buttonPositionManaReturn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        /// <summary>
        /// 役職テーブルの操作をするためのクラスをインスタンス化する
        /// </summary>
        PositionDataAccess PositionAccess = new PositionDataAccess();                   //[役職マスタ]操作用クラスのインスタンス化

        /// <summary>
        /// 役職テーブルの表示用データを保持するListの宣言
        /// </summary>

        List<M_Position> PositionList;

        ///<summary>
        ///共通モジュールのインスタンス化
        /// </summary>
        MessageDsp msg = new MessageDsp();                                              //メッセージ表示用クラス
        CheckExistence Existence = new CheckExistence();                                //IDの存在チェック用クラス
        DataInputCheck InputCheck = new DataInputCheck();                               //入力チェック用クラス
        PasswordHash PassHash = new PasswordHash();                                     //パスワードハッシュ化用クラス

        /// <summary>
        /// 役職情報一覧表示モジュール
        /// (非表示になっていないデータを表示)
        /// </summary>
        /// <param>なし</param>
        /// <returns>なし</returns>

        private void ListPosition()
        {
            dataGridViewPositionMana.Rows.Clear();                        //データグリッドビューをクリアする
            foreach (var PositionData in PositionList)
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
            foreach (var PositionData in PositionList)
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
        //    //営業所IDの入力チェックメソッドの呼びだし
        //    if (!InputCheck.SalesOfficeIDInputCheck(comboBoxPositionManaPositionID.Text))
        //    {
        //        comboBoxPositionManaPositionID.Focus();
        //        return;
        //    }
        //    //入力チェックメソッドの呼び出し
        //    if (!PositionIDInputCheck())
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
        }

        
    }
}
