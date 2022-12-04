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
                int OrderID = int.Parse(SearchInfo);                                   //検索用受注IDを代入
                SearchResult = context.T_Orders.Where(x => x.OrID == OrderID).ToList();           //検索

                context.Dispose();                                                      //contextを解放     
            }
            else if (methodflg == 3)                                                    //社員IDで検索
            {
                int OrderID = int.Parse(SearchInfo);                                   //検索用受注IDを代入
                SearchResult = context.T_Orders.Where(x => x.OrID == OrderID).ToList();           //検索

                context.Dispose();                                                      //contextを解放   
            }
            else if (methodflg == 4)                                                    //顧客IDで検索
            {
                int OrderID = int.Parse(SearchInfo);                                   //検索用顧客IDを代入
                SearchResult = context.T_Orders.Where(x => x.OrID == OrderID).ToList();           //検索

                context.Dispose();                                                      //contextを解放  
            }

            return SearchResult;
        }
    }
}
