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
            Syukko.EmID = ConfirmData.EmID;
            Syukko.SyFlag = 1;
            Syukko.SyHidden = DateTime.Now.ToString();


            context.SaveChanges();                                                     //更新を確定する
            context.Dispose();                                                         //contextを解放

            msg.MsgDsp("M11005");
        }


        /// <summary>
        /// 出庫非表示機能
        /// </summary>
        /// <param name="SyukkoID"></param>
        /// <returns>List<t_Syukko></returns>
        public void DeleteSyukko(int SyukkoID) //非表示
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            var Syukko = context.T_Syukkos.Single(x => x.SyID == SyukkoID);             //非表示にするレコードの抽出
            Syukko.SyFlag = 2;                                                          //入庫管理フラグを2にする
            context.SaveChanges();                                                      //更新を確定する
            context.Dispose();                                                          //contextを解放
        }

        /// <summary>
        /// 出庫情報取得モジュール
        /// </summary>
        /// <param>なし</param>
        /// <returns>List<T_Syukko></returns>
        public List<T_Syukko> GetData()
        {
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            return context.T_Syukkos.ToList();                          //入庫テーブルの全データを戻り値として返す
        }



        /// <summary>
        /// 出庫検索モジュール　（ID系）
        /// </summary>
        /// <param name="methodflg"></param>
        /// <param name="SearchInfo"></param>
        /// <returns>List<T_Syukko></returns>
        public List<T_Syukko> SearchEmployee(int methodflg, string SearchInfo)　//IDで検索
        {
            var context = new SalesManagement_DevContext();
            List<T_Syukko> SearchResult = null;

            if (methodflg == 1)　//社員IDで検索
            {
                int SyukkoID = int.Parse(SearchInfo);
                SearchResult = context.T_Syukkos.Where(x => x.SyID == SyukkoID).ToList();
            }

            else if (methodflg == 2)　//社員IDで検索
            {
                int EmployeeID = int.Parse(SearchInfo);
                SearchResult = context.T_Syukkos.Where(x => x.EmID == EmployeeID).ToList();
            }

            else if (methodflg == 3)　//顧客IDで検索
            {
                int ClientID = int.Parse(SearchInfo);
                SearchResult = context.T_Syukkos.Where(x => x.ClID == ClientID).ToList();
            }

            else if (methodflg == 4)　//営業所IDで検索
            {
                int SalesOfficeID = int.Parse(SearchInfo);
                SearchResult = context.T_Syukkos.Where(x => x.SoID == SalesOfficeID).ToList();
            }
            else if (methodflg == 5)　//受注IDで検索
            {
                int OrderID = int.Parse(SearchInfo);
                SearchResult = context.T_Syukkos.Where(x => x.OrID == OrderID).ToList();
            }



            return SearchResult;
        }




    }
}
