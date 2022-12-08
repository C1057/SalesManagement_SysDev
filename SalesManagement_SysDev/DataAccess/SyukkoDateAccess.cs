using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class SyukkoDateAccess
    {
        MessageDsp msg = new MessageDsp();



        /// <summary>
        /// 出庫確定処理
        /// </summary>
        /// <param name="SyukkoID"></param>
        /// <returns></returns>
        public void ConfirmSyukko(T_Arrival ConfirmArrival, T_ArrivalDetail ConfirmArrivalDetail , T_Syukko ConfirmData )
        {
            DialogResult result = msg.MsgDsp("M11004");
            if (result == DialogResult.Cancel)
            {
                return;
            }


            var context = new SalesManagement_DevContext();  //SalesManagement_DevContextのcontext化



            

            
          
            context.T_Arrivals.Add(ConfirmArrival);
            context.T_ArrivalDetails.Add(ConfirmArrivalDetail);



            var Syukko = context.T_Syukkos.Single(x => x.SyID == ConfirmData.SyID); //出庫テーブルのデータを変更する
            Syukko.EmID = 
            Syukko.SyFlag = 1;
            Syukko.SyHidden = DateTime.Now.ToString();


            context.SaveChanges();                                                     //更新を確定する
            context.Dispose();                                                         //contextを解放

            msg.MsgDsp("M11005");
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







    }
}
