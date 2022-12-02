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
        MessageDsp msg = new MessageDsp();

        public List<T_Hattyu> GetDatahattyu()
        {
            var context = new SalesManagement_DevContext();                //クラスをインスタンス化
            return context.T_Hattyus.ToList();                      //発注テーブルのデータを戻り値として返す
        }

        public void DeleteHattyu(int HattyuID)
        {
            DialogResult result = msg.MsgDsp("M14001");
            if (result == DialogResult.Cancel)
            {
                return;
            }

            var context = new SalesManagement_DevContext();
            var hattyu = context.T_Hattyus.Single(x => x.HaID == HattyuID);
            hattyu.HaFlag = 2;
            context.SaveChanges();
            context.Dispose();

            msg.MsgDsp("M14002");
        }

        public List<T_Hattyu> SearchHattyu(int methodflg, string SearchInfo)
        {
            var Context = new SalesManagement_DevContext();
            List<T_Hattyu> searchresult = null;


            if (methodflg == 1)
            {
                int HattyuID = int.Parse(SearchInfo);
                searchresult = Context.T_Hattyus.Where(x => x.HaID == HattyuID).ToList();
                Context.Dispose();

            }
            else if (methodflg == 2)
            {
                int MakerID = int.Parse(SearchInfo);
                searchresult = Context.T_Hattyus.Where(x => x.MaID == MakerID).ToList();
                Context.Dispose();
            }
            else if (methodflg == 3)
            {
                int EmployeeID = int.Parse(SearchInfo);
                searchresult = Context.T_Hattyus.Where(x => x.EmID == EmployeeID).ToList();
                Context.Dispose();
            }

            return searchresult;
        }




        //発注確定機能未完成！！出来たらやってください。
        
    }
}
