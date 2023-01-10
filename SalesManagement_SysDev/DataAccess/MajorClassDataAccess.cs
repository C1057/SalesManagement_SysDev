using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{




    class MajorClassDataAccess
    {

        MessageDsp msg = new MessageDsp();
        /// <summary>
        /// 大分類登録モジュール
        /// </summary>
        /// <param name="addData"></param>
        /// <return>void</return>
        public void AddMajorClass(M_MajorClassification addData)
        {
            DialogResult result = msg.MsgDsp("M3036"); //登録確認メッセージ
            if (result == DialogResult.Cancel)　//登録Cancel　登録モジュールを終了する
            {
                return;
            }

            try
            {
                var context = new SalesManagement_DevContext();

               


                context.M_MajorClassifications.Add(addData); //データをセット
                context.SaveChanges();　　//
                context.Dispose();  //　contextを開放

                msg.MsgDsp("M3037");　//登録完了メッセージ
            }
            catch
            {
                msg.MsgDsp("M3038"); //登録失敗メッセージ
            }

        }


        /// <summary>
        /// 大分類更新モジュール
        /// </summary>
        /// <param name="UpdateData"></param>
        /// <return>void</return>
        public void UpdateMajorClass(M_MajorClassification UpdateData)
        {
            DialogResult result = msg.MsgDsp("M3039"); //更新確認メッセージ
            if (result == DialogResult.Cancel)　//更新Cancel　更新モジュールを終了する
            {
                return;
            }
            try
            {
                var context = new SalesManagement_DevContext();       //クラスのインスタンス化
                var MajorClass = context.M_MajorClassifications.Single(x => x.McID == UpdateData.McID);    //更新対象データの取得
                //更新データをセット
                MajorClass.McName = UpdateData.McName;
                



                context.SaveChanges();  //
                context.Dispose();     //contextを開放

                msg.MsgDsp("M3040");
            }
            catch
            {
                msg.MsgDsp("M3041");
            }
        }


        /// <summary>
        /// 大分類非表示機能
        /// </summary>
        /// <param name=""></param>
        /// <param name="MajorClassID"></param>
        /// <returns>List<M_MajorClassifcation></returns>
        public void DeleteMajorClass(int MajorClassID) //非表示
        {
            msg.MsgDsp("M14001"); //非表示確認メッセージ
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            var MajorClass = context.M_MajorClassifications.Single(x => x.McID == MajorClassID);             //非表示にするレコードの抽出
            MajorClass.McFlag = 2;                                                          //大分類管理フラグを2にする
            context.SaveChanges();                                                      //更新を確定する
            context.Dispose();                                                          //contextを解放
        }


        /// <summary>
        /// 大分類情報取得モジュール
        /// </summary>
        /// <param>なし</param>
        /// <returns>List<M_MajorClassification></returns>
        public List<M_MajorClassification> GetData()
        {
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            return context.M_MajorClassifications.ToList();                          //大分類マスタの全データを戻り値として返す
        }
    }
}
