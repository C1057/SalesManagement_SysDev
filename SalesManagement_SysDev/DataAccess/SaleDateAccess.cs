using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class SaleDateAccess
    {
        MessageDsp msg = new MessageDsp();






        /// <summary>
        /// 売上検索モジュール（ID系）
        /// </summary>
        /// <param name="methodflg"></param>
        /// <param name="SearchInfo"></param>
        /// <returns></returns>
        public List<T_Sale> SearchSale (int methodflg, string SearchInfo)　//IDで検索
        {
            var context = new SalesManagement_DevContext();
            List<T_Sale> SearchResult = null;

            if (methodflg == 1)　//売上IDで検索
            {
                int SaleID = int.Parse(SearchInfo);
                SearchResult = context.T_Sale.Where(x => x.SaID == SaleID).ToList();
            }

            else if (methodflg == 2) //顧客IDで検索
            {
                int CliantID = int.Parse(SearchInfo);
                SearchResult = context.T_Sale.Where(x => x.ClID == CliantID).ToList();
            }

            else if (methodflg == 3) //営業所IDで検索
            {
                int SalesOfficeID = int.Parse(SearchInfo);
                SearchResult = context.T_Sale.Where(x => x.SoID == SalesOfficeID).ToList();
            }

            else if (methodflg == 4) //受注社員IDで検索
            {
                int EmployeeID = int.Parse(SearchInfo);
                SearchResult = context.T_Sale.Where(x => x.EmID == EmployeeID).ToList();
            }

            else if (methodflg == 5) //受注IDで検索
            {
                int ChumonID = int.Parse(SearchInfo);
                SearchResult = context.T_Sale.Where(x => x.ChID == ChumonID).ToList();
            } 

            return SearchResult;
        }

        /// <summary>
        /// 売上非表示機能
        /// </summary>
        /// <param name=""></param>
        /// <param name="SaleID"></param>
        /// <returns>List<T_Sale></returns>
        public void DeleteSale(int SaleID) //非表示
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            var Sale = context.T_Sale.Single(x => x.SaID == SaleID);             //非表示にするレコードの抽出
            Sale.SaFlag = 2;                                                          //売上管理フラグを2にする
            context.SaveChanges();                                                      //更新を確定する
            context.Dispose();                                                          //contextを解放
        }

        /// <summary>
        /// 売上情報取得モジュール
        /// </summary>
        /// <param>なし</param>
        /// <returns>List<T_Sale></returns>
        public List<T_Sale> GetData()
        {
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            return context.T_Sale.ToList();                          //売上テーブルの全データを戻り値として返す
        }






    }
}
