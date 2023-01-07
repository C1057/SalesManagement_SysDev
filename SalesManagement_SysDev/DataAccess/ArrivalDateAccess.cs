using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class ArrivalDateAccess
    {
        MessageDsp msg = new MessageDsp();


        /// <summary>
        /// 入荷確定処理
        /// </summary>
        /// <param name="ArrivalID"></param>
        /// <returns></returns>
        public void ConfirmSyukko(T_Shipment ConfirmShipment, T_ShipmentDetail ConfirmShipmentDetail, T_Arrival ConfirmData)
        {
            DialogResult result = msg.MsgDsp("M12004");
            if (result == DialogResult.Cancel)
            {
                return;
            }


            var context = new SalesManagement_DevContext();  //SalesManagement_DevContextのcontext化

            context.T_Shipments.Add(ConfirmShipment); //出荷テーブルにレコードを作成
            context.T_ShipmentDetails.Add(ConfirmShipmentDetail);　//　出荷詳細テーブルにレコードを作成



            var Arrival = context.T_Arrivals.Single(x => x.ArID == ConfirmData.ArID); //入荷テーブルのデータを変更する
            Arrival.EmID = ConfirmData.EmID;
            Arrival.ArFlag = 1;
            Arrival.ArHidden = DateTime.Now.ToString();


            context.SaveChanges();                                                     //更新を確定する
            context.Dispose();                                                         //contextを解放

            msg.MsgDsp("M12005");
        }


        /// <summary>
        /// 入荷非表示機能　
        /// </summary>
        /// <param name="ArrivalID"></param>
        /// <returns>List<t_Arrival></returns>
        public void DeleteArrival(int ArrivalID) //非表示
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            var Arrival = context.T_Arrivals.Single(x => x.ArID == ArrivalID);             //非表示にするレコードの抽出
            Arrival.ArFlag = 2;                                                          //入荷管理フラグを2にする
            context.SaveChanges();                                                      //更新を確定する
            context.Dispose();                                                          //contextを解放
        }

        /// <summary>
        /// 入荷情報取得モジュール
        /// </summary>
        /// <param>なし</param>
        /// <returns>List<T_Arrival></returns>
        public List<T_Arrival> GetData()
        {
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            return context.T_Arrivals.ToList();                          //入庫テーブルの全データを戻り値として返す
        }



        /// <summary>
        /// 入荷検索モジュール　（ID系）
        /// </summary>
        /// <param name="methodflg"></param>
        /// <param name="SearchInfo"></param>
        /// <returns>List<T_Arrival></returns>
        public List<T_Arrival> SearchArrival(int methodflg, string SearchInfo)　//IDで検索
        {
            var context = new SalesManagement_DevContext();
            List<T_Arrival> SearchResult = null;

            if (methodflg == 1)　//入荷IDで検索
            {
                int ArrivalID = int.Parse(SearchInfo);
                SearchResult = context.T_Arrivals.Where(x => x.ArID == ArrivalID).ToList();
            }

            else if (methodflg == 2)　//営業所IDで検索
            {
                int SalesOfficeID = int.Parse(SearchInfo);
                SearchResult = context.T_Arrivals.Where(x => x.SoID == SalesOfficeID).ToList();
            }

            else if (methodflg == 3)　//社員IDで検索
            {
                int EmployeeID = int.Parse(SearchInfo);
                SearchResult = context.T_Arrivals.Where(x => x.EmID == EmployeeID).ToList();
            }

            else if (methodflg == 4)　//顧客IDで検索
            {
                int ClientID = int.Parse(SearchInfo);
                SearchResult = context.T_Arrivals.Where(x => x.ClID == ClientID).ToList();
            }
            else if (methodflg == 5)　//受注IDで検索
            {
                int OrderID = int.Parse(SearchInfo);
                SearchResult = context.T_Arrivals.Where(x => x.OrID == OrderID).ToList();
            }



            return SearchResult;
        }






    }
}
