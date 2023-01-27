using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class ChumonDateAccess
    {
        MessageDsp msg = new MessageDsp();

        public void DeleteChumon(int chumonID,string Hidden) //注文非表示機能
        {           
            var context = new SalesManagement_DevContext();　　　//クラスのインスタンス化
            var chumon = context.T_Chumons.Single(x => x.ChID == chumonID);   //検索

            chumon.ChFlag = 2;                          //注文管理フラグを2にする
            chumon.ChHidden = Hidden;                   //非表示理由

            context.SaveChanges();　//変更の反映
            context.Dispose();　　//contextの解放

            //msg.MsgDsp("M14002");　　//非表示完了メッセージ
        }

        public List<T_Chumon> SearchChumon(int methodflg, string SearchInfo)
        {
            var context = new SalesManagement_DevContext();
            List<T_Chumon> SearchResult = null;

            if (methodflg == 1)　//注文IDで検索
            {
                int ChumonID = int.Parse(SearchInfo);
                SearchResult = context.T_Chumons.Where(x => x.ChID == ChumonID).ToList();
            }

            else if (methodflg == 2)　//営業所IDで検索
            {
                int SalesOfficeID = int.Parse(SearchInfo);
                SearchResult = context.T_Chumons.Where(x => x.SoID == SalesOfficeID).ToList();
            }

            else if (methodflg == 3)　//社員IDで検索
            {
                int EmployeeID = int.Parse(SearchInfo);
                SearchResult = context.T_Chumons.Where(x => x.EmID == EmployeeID).ToList();
            }

            else if (methodflg == 4)　//顧客IDで検索
            {
                int ClientID = int.Parse(SearchInfo);
                SearchResult = context.T_Chumons.Where(x => x.ClID == ClientID).ToList();
            }
            else if (methodflg == 5)　//受注IDで検索
            {
                int OrderID = int.Parse(SearchInfo);
                SearchResult = context.T_Chumons.Where(x => x.OrID == OrderID).ToList();
            }

            return SearchResult;
        }

        public List<T_Chumon> GetData()
        {
            var context = new SalesManagement_DevContext();

            var Result = context.T_Chumons.ToList();
            context.Dispose();

            return Result;
        }
    }
}
