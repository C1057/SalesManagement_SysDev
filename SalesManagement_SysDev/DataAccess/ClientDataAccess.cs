using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class ClientDataAccess
    {
        MessageDsp msg = new MessageDsp();

        /// <summary>
        /// 顧客情報をセットする
        /// </summary>
        /// <param>入力項目のTextプロパティ</param>
        /// <returns>(M_Client) ClientData</returns>

        /// <summary>
        /// 顧客情報登録モジュール
        /// </summary>
        /// <param name="AddData">登録用データ</param>
        /// <returns>なし</returns>
        public void AddClient(M_Client AddData)
        {            
            DialogResult result = msg.MsgDsp("M2023");              //登録確認メッセージ
            if (result == DialogResult.Cancel)                      //resultがCancelの場合顧客登録モジュールを終了する
            {
                return;
            }

            try                                                     //例外処理
            {
                var context = new SalesManagement_DevContext();     //SalesManagement_DevContextクラスのインスタンス化
                context.M_Clients.Add(AddData);                     //登録用データをセット
                context.SaveChanges();                              //データベースへの登録を確定する
                context.Dispose();                                  //contextを解放

                msg.MsgDsp("M2024");                                //登録完了メッセージの表示
            }
            catch
            {
                msg.MsgDsp("M2025");                                //登録失敗メッセージの表示
            }
        }

        /// <summary>
        /// 顧客情報更新モジュール
        /// </summary>
        /// <param name="UpdateData"></param>
        /// <returns>なし</returns>
        public void UpdateClient(M_Client UpdateData)
        {
            DialogResult result = msg.MsgDsp("M2026");              //更新確認メッセージ
            if(result == DialogResult.Cancel)                       //resultがCancelの場合顧客更新モジュールを終了する
            {
                return;
            }

            try
            {
                var context = new SalesManagement_DevContext();     //SalesManagement_DevContextクラスのインスタンス化
                var Client = context.M_Clients.Single(x => x.ClID == UpdateData.ClID);              //更新対象データを取得する
                Client = UpdateData;                                //更新データをセット
                context.SaveChanges();                              //データベースへの登録を確定する
                context.Dispose();                                  //contextを解放する

                msg.MsgDsp("M2027");                                //更新完了メッセージの表示
            }
            catch
            {
                msg.MsgDsp("M2028");                                //更新失敗メッセージの表示
            }          
        }

        /// <summary>
        /// 顧客情報検索モジュール(ID系統)
        /// </summary>
        /// <param name="methodflg , SearchInfo"></param>
        /// <returns>List<M_Client></returns>
        public List<M_Client> SearchClient(int methodflg, string SearchInfo)
        {
            var context = new SalesManagement_DevContext();
            List<M_Client> SearchResult = null;

            if (methodflg == 1)
            {
                int ClientID = int.Parse(SearchInfo);
                SearchResult = context.M_Clients.Where(x => x.ClID == ClientID).ToList();

                context.Dispose();
            }
            else if (methodflg == 2)
            {
                int SalesOfficeID = int.Parse(SearchInfo);
                SearchResult = context.M_Clients.Where(x => x.SoID == SalesOfficeID).ToList();

                context.Dispose();
            }

            return SearchResult;
        }

        /// <summary>
        /// 顧客情報検索モジュール(顧客名)
        /// </summary>
        /// <param name="SearchInfo"></param>
        /// <returns>List<M_Client></returns>
        public List<M_Client> SearchClient(string SearchInfo)
        {
            var context = new SalesManagement_DevContext();
            List<M_Client> SearchResult = null;

            string ClientName = SearchInfo;
            SearchResult = context.M_Clients.Where(M_Client => M_Client.ClName.Contains(SearchInfo)).ToList();

            context.Dispose();

            return SearchResult;
        }

        /// <summary>
        /// 顧客情報非表示機能
        /// </summary>
        /// <param name="ClientID"></param>
        /// <returns>List<M_Client></returns>
        public List<M_Client> DeleteClient(int ClientID)
        {
            var context = new SalesManagement_DevContext();
            var Client = context.M_Clients.Single(x => x.ClID == ClientID);
            Client.ClFlag = 2;
            context.SaveChanges();
            context.Dispose();

            return GetData();
        }

        /// <summary>
        /// 顧客情報取得モジュール
        /// </summary>
        /// <param>なし</param>
        /// <returns>List<M_Client></returns>
        public List<M_Client> GetData()
        {
            var context = new SalesManagement_DevContext();
            return context.M_Clients.ToList();
        }
    }
}