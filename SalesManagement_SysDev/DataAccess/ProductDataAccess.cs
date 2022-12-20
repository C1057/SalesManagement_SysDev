using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class ProductDataAccess
    {
        MessageDsp msg = new MessageDsp();

        /// <summary>
        /// 商品情報をセットする
        /// </summary>
        /// <param>入力項目のTextプロパティ</param>
        /// <returns>(M_Product)ProductData</returns>

        /// <summary>
        /// 商品情報登録モジュール
        /// </summary>
        /// <param name="AddData">登録用データ</param>
        /// <returns>なし</returns>
        public void AddProduct(M_Product AddData)
        {
            DialogResult result = msg.MsgDsp("M3023");              //登録確認メッセージ
            if (result == DialogResult.Cancel)                      //resultがCancelの場合商品登録モジュールを終了する
            {
                return;
            }

            try                                                     //例外処理
            {
                var context = new SalesManagement_DevContext();     //SalesManagement_DevContextクラスのインスタンス化
                context.M_Products.Add(AddData);                     //登録用データをセット
                context.SaveChanges();                              //データベースへの登録を確定する
                context.Dispose();                                  //contextを解放

                msg.MsgDsp("M3024");                                //登録完了メッセージの表示
            }
            catch
            {
                msg.MsgDsp("M3025");                                //登録失敗メッセージの表示
            }
        }

        /// <summary>
        /// 商品情報更新モジュール
        /// </summary>
        /// <param name="UpdateData"></param>
        /// <returns>なし</returns>
        public void UpdateProduct(M_Product UpdateData)
        {
            DialogResult result = msg.MsgDsp("M3026");              //更新確認メッセージ
            if (result == DialogResult.Cancel)                       //resultがCancelの場合商品更新モジュールを終了する
            {
                return;
            }

            try
            {
                var context = new SalesManagement_DevContext();     //SalesManagement_DevContextクラスのインスタンス化
                var Product = context.M_Products.Single(x => x.PrID == UpdateData.PrID);              //更新対象データを取得する

                //更新データベースをセット
                Product.MaID = UpdateData.MaID;                      //メーカIDをセット 
                Product.PrName = UpdateData.PrName;                  //商品をセット
                Product.Price = UpdateData.Price;            //価格をセット
                Product.PrSafetyStock = UpdateData.PrSafetyStock;                //安全在庫数をセット
                Product.ScID = UpdateData.ScID;              //小分類IDをセット
                Product.PrModelNumber = UpdateData.PrModelNumber;                    //型番をセット                             //更新データをセット
                Product.PrColor = UpdateData.PrColor;    //色をセット
                Product.PrReleaseDate = UpdateData.PrReleaseDate;   //発売日をセット

                context.SaveChanges();                              //データベースへの登録を確定する
                context.Dispose();                                  //contextを解放する

                msg.MsgDsp("M3027");                                //更新完了メッセージの表示
            }
            catch
            {
                msg.MsgDsp("M3028");                                //更新失敗メッセージの表示
            }
        }

        /// <summary>
        /// 商品情報検索モジュール(ID系統)
        /// </summary>
        /// <param name="methodflg , SearchInfo"></param>
        /// <returns>List<M_Product></returns>
        public List<M_Product> SearchProduct(int methodflg, string SearchInfo)
        {
            var context = new SalesManagement_DevContext();
            List<M_Product> SearchResult = null;

            if (methodflg == 1)
            {
                int ProductID = int.Parse(SearchInfo);
                SearchResult = context.M_Products.Where(x => x.PrID == ProductID).ToList();

                context.Dispose();
            }
            else if (methodflg == 2)
            {
                int MakerID = int.Parse(SearchInfo);
                SearchResult = context.M_Products.Where(x => x.MaID == MakerID).ToList();

                context.Dispose();
            }

            return SearchResult;
        }

        /// <summary>
        /// 商品情報検索モジュール(顧客名)
        /// </summary>
        /// <param name="SearchInfo"></param>
        /// <returns>List<M_Product></returns>
        public List<M_Product> SearchProduct(string SearchInfo)
        {
            var context = new SalesManagement_DevContext();
            List<M_Product> SearchResult = null;

            string ProductName = SearchInfo;
            SearchResult = context.M_Products.Where(M_Product => M_Product.PrName.Contains(SearchInfo)).ToList();

            context.Dispose();

            return SearchResult;
        }

        /// <summary>
        /// 商品情報非表示機能
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns>List<M_Product></returns>
        public void DeleteProduct(int ProductID)
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            var Product = context.M_Products.Single(x => x.PrID == ProductID);             //非表示にするレコードの抽出
            Product.PrFlag = 2;                                                          //商品管理フラグを2にする
            context.SaveChanges();                                                      //更新を確定する
            context.Dispose();                                                          //contextを解放
        }

        /// <summary>
        /// 商品情報取得モジュール
        /// </summary>
        /// <param>なし</param>
        /// <returns>List<M_Product></returns>
        public List<M_Product> GetData()
        {
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            return context.M_Products.ToList();                          //顧客マスタの全データを戻り値として返す
        }

    }

}
