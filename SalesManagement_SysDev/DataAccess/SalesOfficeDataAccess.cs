using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class SalesOfficeDataAccess
    {
        MessageDsp msg = new MessageDsp();

        /// <summary>
        /// 営業所情報をセットする
        /// </summary>
        /// <param>入力項目のTextプロパティ</param>
        /// <returns>(M_SalesOffice) SalesOfficeData</returns>

        /// <summary>
        /// 営業所情報登録モジュール
        /// </summary>
        /// <param name="AddData">登録用データ</param>
        /// <returns>なし</returns>
        public void SalesOffice(M_SalesOffice AddData)
        {
            DialogResult result = msg.MsgDsp("M5055");              //登録確認メッセージ
            if (result == DialogResult.Cancel)                      //resultがCancelの場合、営業所登録モジュールを終了する
            {
                return;
            }

            try                                                     //例外処理
            {
                var context = new SalesManagement_DevContext();     //SalesManagement_DevContextクラスのインスタンス化
                context.M_SalesOffices.Add(AddData);                //登録用データをセット
                context.SaveChanges();                              //データベースへの登録を確定する
                context.Dispose();                                  //contextを解放

                msg.MsgDsp("M5056");                                //登録完了メッセージの表示
            }
            catch
            {
                msg.MsgDsp("M5057");                                //登録失敗メッセージの表示
            }
        }

        /// <summary>
        /// 営業所情報更新モジュール
        /// </summary>
        /// <param name="UpdateData"></param>
        /// <returns>なし</returns>
        public void UpdateSalesOffice(M_SalesOffice UpdateData)
        {
            DialogResult result = msg.MsgDsp("M5058");              //更新確認メッセージ
            if (result == DialogResult.Cancel)                       //resultがCancelの場合、営業所更新モジュールを終了する
            {
                return;
            }

            try
            {
                var context = new SalesManagement_DevContext();     //SalesManagement_DevContextクラスのインスタンス化
                var SalesOffice = context.M_SalesOffices.Single(x => x.SoID == UpdateData.SoID);              //更新対象データを取得する
                SalesOffice = UpdateData;                                //更新データをセット
                context.SaveChanges();                              //データベースへの登録を確定する
                context.Dispose();                                  //contextを解放する

                msg.MsgDsp("M5059");                                //更新完了メッセージの表示
            }
            catch
            {
                msg.MsgDsp("M5060");                                //更新失敗メッセージの表示
            }

        }

        /// <summary>
        /// 営業所情報検索モジュール(ID系統)
        /// </summary>
        /// <param name="methodflg , SearchInfo"></param>
        /// <returns>List<M_SalesOffice></returns>
        public List<M_SalesOffice> SearchSalesOffice(int methodflg, string SearchInfo)
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            List<M_SalesOffice> SearchResult = null;                                         //検索結果用変数を宣言

            if (methodflg == 1)                                                         //営業所IDで検索
            {
                int SalesOfficeID = int.Parse(SearchInfo);                                   //検索用営業所IDを代入
                SearchResult = context.M_SalesOffices.Where(x => x.SoID == SalesOfficeID).ToList();           //検索

                context.Dispose();                                                      //contextを解放
            }

            return SearchResult;
        }

        /// <summary>
        /// 営業所情報検索モジュール(営業所名)
        /// </summary>
        /// <param name="SearchInfo"></param>
        /// <returns>List<M_SalesOffice></returns>
        public List<M_SalesOffice> SearchSalesOfficet(string SearchInfo)
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            List<M_SalesOffice> SearchResult = null;                                         //検索結果用変数の宣言

            string SalesOfficeName = SearchInfo;                                             //検索用営業所名を代入
            SearchResult = context.M_SalesOffices.Where(M_SalesOffice => M_SalesOffice.SoName.Contains(SearchInfo)).ToList();      //検索

            context.Dispose();                                                          //contextをする

            return SearchResult;
        }

        /// <summary>
        /// 営業所情報非表示機能
        /// </summary>
        /// <param name="SalesOfficeID"></param>
        /// <returns>List<M_SalesOffice></returns>
        public void DeleteClient(int SalesOfficeID)
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            var SalesOffice = context.M_SalesOffices.Single(x => x.SoID == SalesOfficeID);             //非表示にするレコードの抽出
            SalesOffice.SoFlag = 2;                                                          //営業所管理フラグを2にする
            context.SaveChanges();                                                      //更新を確定する
            context.Dispose();                                                          //contextを解放
        }

        /// <summary>
        /// 営業所情報取得モジュール
        /// </summary>
        /// <param>なし</param>
        /// <returns>List<M_SalesOffice></returns>
        public List<M_SalesOffice> GetData()
        {
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            return context.M_SalesOffices.ToList();                          //営業所マスタの全データを戻り値として返す
        }
    }
}
