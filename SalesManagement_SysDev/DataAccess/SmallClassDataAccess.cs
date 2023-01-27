using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class SmallClassDataAccess
    {
        MessageDsp msg = new MessageDsp();

        /// <summary>
        /// 小分類登録モジュール
        /// </summary>
        /// <param name="addData"></param>
        /// <return>void</return>
        public void AddSmallClass(M_SmallClassification addData)
        {
            DialogResult result = msg.MsgDsp("M3049"); //登録確認メッセージ
            if (result == DialogResult.Cancel)　//登録Cancel　登録モジュールを終了する
            {
                return;
            }

            try
            {
                var context = new SalesManagement_DevContext();

               

                context.M_SmallClassifications.Add(addData); //データをセット
                context.SaveChanges();　　//
                context.Dispose();  //　contextを開放

                msg.MsgDsp("M3050");　//登録完了メッセージ
            }
            catch
            {
                msg.MsgDsp("M3051"); //登録失敗メッセージ
            }

        }


        /// <summary>
        /// 小分類更新モジュール
        /// </summary>
        /// <param name="UpdateData"></param>
        /// <return>void</return>
        public void UpdateSmallClass(M_SmallClassification UpdateData)
        {
            DialogResult result = msg.MsgDsp("M3052"); //更新確認メッセージ
            if (result == DialogResult.Cancel)　//更新Cancel　更新モジュールを終了する
            {
                return;
            }
            try
            {
                var context = new SalesManagement_DevContext();       //クラスのインスタンス化
                var SmallClass = context.M_SmallClassifications.Single(x => x.ScID == UpdateData.ScID);    //更新対象データの取得
                //更新データをセット
                SmallClass.McID = UpdateData.McID;
                SmallClass.ScName = UpdateData.ScName;


                context.SaveChanges();  //
                context.Dispose();     //contextを開放

                msg.MsgDsp("M3053");
            }
            catch
            {
                msg.MsgDsp("M3054");
            }
        }


        /// <summary>
        /// 小分類非表示機能
        /// </summary>
        /// <param name=""></param>
        /// <param name="SmallClassID"></param>
        /// <returns>List<M_Employee></returns>
        public void DeleteSmallClass(int SmallClassID,string Hidden) //非表示
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            var SmallClass = context.M_SmallClassifications.Single(x => x.ScID == SmallClassID);             //非表示にするレコードの抽出

            SmallClass.ScFlag = 2;                                                          //小分類管理フラグを2にする
            SmallClass.ScHidden = Hidden;                                               //非表示理由

            context.SaveChanges();                                                      //更新を確定する
            context.Dispose();                                                          //contextを解放
        }

        /// <summary>
        /// 小分類情報取得モジュール
        /// </summary>
        /// <param>なし</param>
        /// <returns>List<M_MajorClassification></returns>
        public List<M_SmallClassification> GetData()
        {
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            return context.M_SmallClassifications.ToList();                          //小分類マスタの全データを戻り値として返す
        }


    }
}
