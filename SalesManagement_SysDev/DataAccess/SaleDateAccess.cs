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
    }
}
