﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class OrderDateAccess
    {
            MessageDsp msg = new MessageDsp();

        /// <summary>
        /// 受注情報検索モジュール(ID系統)
        /// </summary>
        /// <param name="methodflg , SearchInfo"></param>
        /// <returns>List<M_Order></returns>
 
        public List<T_Order> SearchOrder(int methodflg, string SearchInfo)
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            List<T_Order> SearchResult = null;                                         //検索結果用変数を宣言

            if (methodflg == 1)                                                         //受注IDで検索
            {
                int OrderID = int.Parse(SearchInfo);                                   //検索用受注IDを代入
                SearchResult = context.T_Orders.Where(x => x.OrID == OrderID).ToList();           //検索

                context.Dispose();                                                      //contextを解放
            }
            else if (methodflg == 2)                                                    //営業所IDで検索
            {
                int SalesOfficeID = int.Parse(SearchInfo);                                   //検索用受注IDを代入
                SearchResult = context.T_Orders.Where(x => x.SoID == SalesOfficeID).ToList();           //検索

                context.Dispose();                                                      //contextを解放     
            }
            else if (methodflg == 3)                                                    //社員IDで検索
            {
                int EmployeeID = int.Parse(SearchInfo);                                   //検索用受注IDを代入
                SearchResult = context.T_Orders.Where(x => x.EmID == EmployeeID).ToList();           //検索

                context.Dispose();                                                      //contextを解放   
            }
            else if (methodflg == 4)                                                    //顧客IDで検索
            {
                int ClientID = int.Parse(SearchInfo);                                   //検索用受注IDを代入
                SearchResult = context.T_Orders.Where(x => x.ClID == ClientID).ToList();           //検索

                context.Dispose();                                                     //contextを解放  
            }

            return SearchResult;
        }

        /// <summary>
        /// 受注情報検索モジュール(顧客名)
        /// </summary>
        /// <param name="SearchInfo"></param>
        /// <returns>List<M_SalesOffice></returns>
        public List<M_SalesOffice> SearchClient(string SearchInfo)
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            List<M_SalesOffice> SearchResult = null;                                         //検索結果用変数の宣言

            string ClientName = SearchInfo;                                             //検索用顧客名を代入
            SearchResult = context.M_SalesOffices.Where(M_SalesOffice => M_SalesOffice.SoName.Contains(SearchInfo)).ToList();      //検索

            context.Dispose();                                                          //contextをする

            return SearchResult;
        }

        /// <summary>
        /// 受注情報確定モジュール
        /// </summary>
        /// <param name="SearchInfo"></param>
        /// <returns>List<M_SalesOffice></returns>
        public void ConformOrder(T_Order ConformData,T_OrderDetail conformDataDetail,string Sql)
        {
            DialogResult result = msg.MsgDsp("M7024");
            if (result == DialogResult.Cancel)                      //resultがCancelの場合受注登録モジュールを終了する
            {
                return;
            }


        }


        /// <summary>
        /// 受注情報非表示機能
        /// </summary>
        /// <param name="SalesOfficeID"></param>
        /// <returns>List<M_Client></returns>
        public void DeleteClient(int SalesOfficeID)
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            var SalesOffice = context.M_SalesOffices.Single(x => x.SoID == SalesOfficeID); //非表示にするレコードの抽出
            SalesOffice.SoFlag = 2;                                                      //受注管理フラグを2にする
            context.SaveChanges();                                                      //更新を確定する
            context.Dispose();                                                          //contextを解放
        }

        /// <summary>
        /// 受注情報取得モジュール
        /// </summary>
        /// <param>なし</param>
        /// <returns>List<M_SalesOffice></returns>
        public List<M_SalesOffice> GetData()
        {
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            return context.M_SalesOffices.ToList();                          //受注マスタの全データを戻り値として返す
        }
    }
}
