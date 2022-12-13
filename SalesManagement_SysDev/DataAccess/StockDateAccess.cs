using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class StockDateAccess
    {
        MessageDsp msg = new MessageDsp();                                  //メッセージ表示用クラスのインスタンス化

        /// <summary>
        /// 在庫情報検索(ID系統)
        /// </summary>
        /// <param name="methodflg"></param>
        /// <param name="SearchInfo"></param>
        /// <returns>SearchResult</returns>
        public List<T_Stock> SearchStock(int methodflg, string SearchInfo)
        {
            var context = new SalesManagement_DevContext();                 //SalesManagement_DevContext()クラスのインスタンス化
            List<T_Stock> SearchResult = null;                              //検索結果用変数の宣言

            if (methodflg == 1)         //在庫IDで検索
            {
                int StockID = int.Parse(SearchInfo);                        //検索用文字列の代入
                SearchResult = context.T_Stocks.Where(x => x.StID == StockID).ToList();         //検索
                context.Dispose();              //contextの解放
            }
            else if (methodflg == 2)    //商品IDで検索
            {
                int ProductID = int.Parse(SearchInfo);                      //検索用文字列の代入
                SearchResult = context.T_Stocks.Where(x => x.PrID == ProductID).ToList();       //検索
                context.Dispose();              //contextの解放
            }

            return SearchResult;        //検索結果を返す
        }

        /// <summary>
        /// 在庫情報検索(商品名)
        /// </summary>
        /// <param name="SearchInfo"></param>
        /// <returns>SearchResult</returns>
        public List<T_Stock> SearchStock(string SearchInfo)
        {
            var context = new SalesManagement_DevContext();                 //SalesManagement_DevContext()クラスのインスタンス化
            List<T_Stock> SearchResult = null;                              //検索結果用変数の宣言

            string ProductName = SearchInfo;                    //検索用文字列の代入

            foreach(var product in context.M_Products)          //検索
            {
                if (product.PrName.Contains(ProductName))       //商品名と部分一致する場合中身を実行
                {
                    SearchResult.Add(context.T_Stocks.Where(stocks => stocks.PrID==product.PrID).Single());     //商品名と部分一致していた商品IDを取得する
                }
            }

            return SearchResult;                //検索結果を返す
        }

        /// <summary>
        /// 在庫情報更新モジュール
        /// </summary>
        /// <param name="updateData"></param>
        public void UpdateStock(T_Stock updateData)
        {
            DialogResult result = msg.MsgDsp("M4010");      //更新確認メッセージの表示
            if (result == DialogResult.Cancel)              //更新確認メッセージでCancelを選んだ場合終了する
            {
                return;
            }

            try                                    //例外処理
            {
                var context = new SalesManagement_DevContext();         //SalesManagement_DevContext()クラスのインスタンス化
                var Stock = context.T_Stocks.Single(x => x.StID == updateData.StID);            //更新対象データの取得
                Stock.PrID = updateData.PrID;                           //商品IDの代入
                Stock.StQuantity = updateData.StQuantity;               //在庫数の代入
                Stock.StHidden = updateData.StHidden;                   //非表示理由の代入

                context.SaveChanges();                                  //更新を確定
                context.Dispose();                                      //contextの解放

                msg.MsgDsp("M4011");                                    //更新完了メッセージ
            }
            catch           //例外エラー
            {   
                msg.MsgDsp("M4012");                                    //更新失敗メッセージ
            }
        }
    }
}
