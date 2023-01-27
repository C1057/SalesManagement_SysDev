using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class OrderDateAccess
    {
            MessageDsp msg = new MessageDsp();

        /// <summary>
        /// 受注情報検索モジュール(ID系統)
        /// </summary>
        /// <param name="methodflg , SearchInfo"></param>
        /// <returns>List<M_Order></returns>
 
        public List<T_Order> SearchOrder(int methodflg, string SearchInfo)
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            List<T_Order> SearchResult = null;                                         //検索結果用変数を宣言

            if (methodflg == 1)                                                         //受注IDで検索
            {
                int OrderID = int.Parse(SearchInfo);                                   //検索用受注IDを代入
                SearchResult = context.T_Orders.Where(x => x.OrID == OrderID).ToList();           //検索

                context.Dispose();                                                      //contextを解放
            }
            else if (methodflg == 2)                                                    //営業所IDで検索
            {
                int SalesOfficeID = int.Parse(SearchInfo);                                   //検索用受注IDを代入
                SearchResult = context.T_Orders.Where(x => x.SoID == SalesOfficeID).ToList();           //検索

                context.Dispose();                                                      //contextを解放     
            }
            else if (methodflg == 3)                                                    //社員IDで検索
            {
                int EmployeeID = int.Parse(SearchInfo);                                   //検索用受注IDを代入
                SearchResult = context.T_Orders.Where(x => x.EmID == EmployeeID).ToList();           //検索

                context.Dispose();                                                      //contextを解放   
            }
            else if (methodflg == 4)                                                    //顧客IDで検索
            {
                int ClientID = int.Parse(SearchInfo);                                   //検索用受注IDを代入
                SearchResult = context.T_Orders.Where(x => x.ClID == ClientID).ToList();           //検索

                context.Dispose();                                                     //contextを解放  
            }

            return SearchResult;
        }

        /// <summary>
        /// 受注情報検索モジュール(顧客名)
        /// </summary>
        /// <param name="SearchInfo"></param>
        /// <returns>List<M_SalesOffice></returns>
        public List<T_Order> SearchOrder(string SearchInfo)
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            List<T_Order> SearchResult = null;                                         //検索結果用変数の宣言

            string ClientName = SearchInfo;                                             //検索用顧客名を代入
            SearchResult = context.T_Orders.Where(T_Order => T_Order.ClCharge.Contains(SearchInfo)).ToList();      //検索

            context.Dispose();                                                          //contextをする

            return SearchResult;
        }

        /// <summary>
        /// 受注情報確定モジュール
        /// </summary>
        /// <param name="SearchInfo"></param>
        /// <returns>List<M_SalesOffice></returns>
        public void ConfirmOrder(T_Chumon ConfirmData,T_ChumonDetail ConfirmDataDetail, int OrID)
        {
            DialogResult result = msg.MsgDsp("M7024");
            if (result == DialogResult.Cancel)                      //resultがCancelの場合受注登録モジュールを終了する
            {
                return;
            }

            var context = new SalesManagement_DevContext();     //SalesManagement_DevContextクラスのインスタンス化

            //context.T_Chumons.Add(ConfirmData);                 //注文テーブルに登録
            //context.T_ChumonDetails.Add(ConfirmDataDetail);     //注文詳細テーブルに登録

            var Order = context.T_Orders.Single(x => x.OrID == OrID);              //更新対象データを取得する
            Order.OrFlag = 1;               //受注情報フラグを更新する
            context.SaveChanges();
            context.Dispose();
        }


        /// <summary>
        /// 受注情報非表示機能
        /// </summary>
        /// <param name="SalesOfficeID"></param>
        /// <returns>List<M_Client></returns>
        public void DeleteOrder(int OrderID,string Hidden)
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            var Order = context.T_Orders.Single(x => x.OrID == OrderID); //非表示にするレコードの抽出

            Order.OrFlag = 2;                                                      //受注管理フラグを2にする
            Order.OrHidden = Hidden;                                        //非表示理由

            context.SaveChanges();                                                      //更新を確定する
            context.Dispose();                                                          //contextを解放
        }

        /// <summary>
        /// 受注情報取得モジュール
        /// </summary>
        /// <param>なし</param>
        /// <returns>List<M_SalesOffice></returns>
        public List<T_Order> GetData()
        {
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            return context.T_Orders.ToList();                          //受注マスタの全データを戻り値として返す
        }
    }
}
