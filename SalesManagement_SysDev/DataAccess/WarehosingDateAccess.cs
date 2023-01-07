using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class WarehosingDateAccess
    {
        MessageDsp msg = new MessageDsp();
        
        
        /// <summary>
        /// 入庫確定処理
        /// </summary>
        /// <param name="WarehousingID"></param>
        /// <returns></returns>
        public void UpdateWarehosing (int WarehousingID)
        {
            DialogResult result = msg.MsgDsp("M10004");
            if(result == DialogResult.Cancel)
            {
                return;
            }

            
                var context = new SalesManagement_DevContext();  //SalesManagement_DevContextのcontext化
                var Warehousing = context.T_Warehousings.Single(x => x.WaID == WarehousingID);

                Warehousing.WaHidden = DateTime.Now.ToString();
                Warehousing.WaFlag = 1; //入庫状態フラグを1に変更する


                context.SaveChanges();                                                     //更新を確定する
                context.Dispose();                                                         //contextを解放

                msg.MsgDsp("M10005");
            }
            
        


        /// <summary>
        /// 入庫非表示機能
        /// </summary>
        /// <param name="WarehousingID"></param>
        /// <returns>List<t_Warehosing></returns>
        public void DeleteWarehousing(int WarehousingID) //非表示
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            var Warehousing = context.T_Warehousings.Single(x => x.WaID == WarehousingID);             //非表示にするレコードの抽出
            Warehousing.WaFlag = 2;                                                          //入庫管理フラグを2にする
            context.SaveChanges();                                                      //更新を確定する
            context.Dispose();                                                          //contextを解放
        }

        /// <summary>
        /// 入庫情報取得モジュール
        /// </summary>
        /// <param>なし</param>
        /// <returns>List<T_Warehousing></returns>
        public List<T_Warehousing> GetData()
        {
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            return context.T_Warehousings.ToList();                          //入庫テーブルの全データを戻り値として返す
        }

        public List<T_Warehousing> SearchWarehousing(int methodflg, string SearchInfo)
        {
            var Context = new SalesManagement_DevContext();  //クラスのインスタンス化
            List<T_Warehousing> searchresult = null;              //検索結果用変数を宣言


            if (methodflg == 1)
            {
                int WarehousingID = int.Parse(SearchInfo);
                searchresult = Context.T_Warehousings.Where(x => x.WaID == WarehousingID).ToList();  //検索
                Context.Dispose();

            }
            else if (methodflg == 2)
            {
                int HattyuID = int.Parse(SearchInfo);
                searchresult = Context.T_Warehousings.Where(x => x.HaID == HattyuID).ToList();   //検索
                Context.Dispose();
            }
            else if (methodflg == 3)
            {
                int EmployeeID = int.Parse(SearchInfo);
                searchresult = Context.T_Warehousings.Where(x => x.EmID == EmployeeID).ToList();　//検索
                Context.Dispose();
            }

            return searchresult;
        }



    }
}
