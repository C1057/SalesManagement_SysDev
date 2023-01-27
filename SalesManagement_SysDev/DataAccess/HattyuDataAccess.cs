using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class HattyuDataAccess
    {
        MessageDsp msg = new MessageDsp();　//クラスのインスタンス化

        public List<T_Hattyu> GetDatahattyu()
        {
            var context = new SalesManagement_DevContext();                //クラスをインスタンス化
            return context.T_Hattyus.ToList();                      //発注テーブルのデータを戻り値として返す
        }

        public void DeleteHattyu(int HattyuID,string Hidden)
        {
            var context = new SalesManagement_DevContext();  //クラスのインスタンス化
            var hattyu = context.T_Hattyus.Single(x => x.HaID == HattyuID);

            hattyu.HaFlag = 2;                          //発注管理フラグを2にする
            hattyu.HaHidden = Hidden;                   //非表示理由
            
            context.SaveChanges();　　　　　　　　　　　　　//変更の反映
            context.Dispose();                             //contextの解放
        }

        public List<T_Hattyu> SearchHattyu(int methodflg, string SearchInfo)
        {
            var Context = new SalesManagement_DevContext();  //クラスのインスタンス化
            List<T_Hattyu> searchresult = null;              //検索結果用変数を宣言


            if (methodflg == 1)
            {
                int HattyuID = int.Parse(SearchInfo);
                searchresult = Context.T_Hattyus.Where(x => x.HaID == HattyuID).ToList();  //検索
                Context.Dispose();

            }
            else if (methodflg == 2)
            {
                int MakerID = int.Parse(SearchInfo);
                searchresult = Context.T_Hattyus.Where(x => x.MaID == MakerID).ToList();   //検索
                Context.Dispose();
            }
            else if (methodflg == 3)
            {
                int EmployeeID = int.Parse(SearchInfo);
                searchresult = Context.T_Hattyus.Where(x => x.EmID == EmployeeID).ToList();　//検索
                Context.Dispose();
            }

            return searchresult;
        }




        //発注確定機能未完成！！出来たらやってください。
        
    }
}
