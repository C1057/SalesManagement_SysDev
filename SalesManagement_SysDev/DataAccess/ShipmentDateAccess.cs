using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class ShipmentDateAccess
    {
        MessageDsp msg = new MessageDsp();


        /// <summary>
        /// 出荷確定処理
        /// </summary>
        /// <param name="ShipmentID"></param>
        /// <returns></returns>
        public void ConfirmShipment(T_Shipment ConfirmData)
        {
            DialogResult result = msg.MsgDsp("M13004");
            if (result == DialogResult.Cancel)
            {
                return;
            }


            var context = new SalesManagement_DevContext();  //SalesManagement_DevContextのcontext化



            var Shipment = context.T_Shipments.Single(x => x.ShID == ConfirmData.ShID); //出荷テーブルのデータを変更する
            Shipment.EmID = ConfirmData.EmID;
            Shipment.ShFlag = 1;
            Shipment.ShHidden = DateTime.Now.ToString();


            context.SaveChanges();                                                     //更新を確定する
            context.Dispose();                                                         //contextを解放

            msg.MsgDsp("M13005");
        }


        /// <summary>
        /// 出荷非表示機能　
        /// </summary>
        /// <param name="ShipmentlID"></param>
        /// <returns>List<t_Shipment></returns>
        public void DeleteShipment(int ShipmentID) //非表示
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            var Shipment = context.T_Shipments.Single(x => x.ShID == ShipmentID);             //非表示にするレコードの抽出
            Shipment.ShFlag = 2;                                                          //出荷管理フラグを2にする
            context.SaveChanges();                                                      //更新を確定する
            context.Dispose();                                                          //contextを解放
        }

        /// <summary>
        /// 出荷情報取得モジュール
        /// </summary>
        /// <param>なし</param>
        /// <returns>List<T_Arrival></returns>
        public List<T_Shipment> GetData()
        {
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            return context.T_Shipments.ToList();                          //出荷テーブルの全データを戻り値として返す
        }



        /// <summary>
        /// 出荷検索モジュール　（ID系）
        /// </summary>
        /// <param name="methodflg"></param>
        /// <param name="SearchInfo"></param>
        /// <returns>List<T_Shipment></returns>
        public List<T_Shipment> SearchShipment(int methodflg, string SearchInfo)　//IDで検索
        {
            var context = new SalesManagement_DevContext();
            List<T_Shipment> SearchResult = null;

            if (methodflg == 1)　//出荷IDで検索
            {
                int ShipmentID = int.Parse(SearchInfo);
                SearchResult = context.T_Shipments.Where(x => x.ShID == ShipmentID).ToList();
            }

            else if (methodflg == 2)　//顧客IDで検索
            {
                int ClientID = int.Parse(SearchInfo);
                SearchResult = context.T_Shipments.Where(x => x.ClID == ClientID).ToList();
            }

            else if (methodflg == 3)　//社員IDで検索
            {
                int EmployeeID = int.Parse(SearchInfo);
                SearchResult = context.T_Shipments.Where(x => x.EmID == EmployeeID).ToList();
            }

            else if (methodflg == 4)　//営業所IDで検索
            {
                int SalesOfficeID = int.Parse(SearchInfo);
                SearchResult = context.T_Shipments.Where(x => x.SoID == SalesOfficeID).ToList();
            }
            else if (methodflg == 5)　//受注IDで検索
            {
                int OrderID = int.Parse(SearchInfo);
                SearchResult = context.T_Shipments.Where(x => x.OrID == OrderID).ToList();
            }



            return SearchResult;
        }
    }
}
