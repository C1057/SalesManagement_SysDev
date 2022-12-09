using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{
    class CheckExistence
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param>int 各ID</param>
        /// <returns>異常あり:false, 異常なし:true</returns>


        //入力された役職IDがDBに存在するかチェックする
        public bool CheckExistencePosition(int PositionID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.M_Positions.Any(x => x.PoID == PositionID);       //役職情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力されたメーカIDがDBに存在するかチェックする
        public bool CheckExistenceMaker (int MakerID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.M_Makers.Any(x => x.MaID==MakerID);       //メーカ情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された営業所IDがDBに存在するかチェックする
        public bool CheckExistenceSalesOffice(int SalesOfficeID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.M_SalesOffices.Any(x => x.SoID == SalesOfficeID);       //営業所情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された顧客IDがDBに存在するかチェックする
        public bool CheckExistenceClient(int ClientID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.M_Clients.Any(x => x.ClID == ClientID);       //顧客情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された社員IDがDBに存在するかチェックする
        public bool CheckExistenceEmployee(int EmployeeID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.M_Employees.Any(x => x.EmID == EmployeeID);       //社員情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された商品IDがDBに存在するかチェックする
        public bool CheckExistenceEProduct(int ProductID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.M_Products.Any(x => x.PrID == ProductID);       //商品情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された大分類IDがDBに存在するかチェックする
        public bool CheckExistenceMajorClass(int MajorClassID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.M_MajorClassifications.Any(x => x.McID == MajorClassID);       //大分類情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された小分類IDがDBに存在するかチェックする
        public bool CheckExistenceSmallClass(int SmallClassID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.M_SmallClassifications.Any(x => x.ScID == SmallClassID);       //小分類情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された在庫IDがDBに存在するかチェックする
        public bool CheckExistenceStock(int StockID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_Stocks.Any(x => x.StID == StockID);       //在庫情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された受注IDがDBに存在するかチェックする
        public bool CheckExistenceOrder(int OrderID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_Orders.Any(x => x.OrID == OrderID);       //受注情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された受注詳細IDがDBに存在するかチェックする
        public bool CheckExistenceOrderDetail(int OrderDetailID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_OrderDetails.Any(x => x.OrDetailID == OrderDetailID);       //受注詳細情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された注文IDがDBに存在するかチェックする
        public bool CheckExistenceChumon(int ChumonID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_Chumons.Any(x => x.ChID == ChumonID);       //注文情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された注文詳細IDがDBに存在するかチェックする
        public bool CheckExistenceChumonDetail(int ChumonDetailID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_ChumonDetails.Any(x => x.ChDetailID == ChumonDetailID);       //注文詳細情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された出庫IDがDBに存在するかチェックする
        public bool CheckExistenceSyukko(int SyukkoID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_Syukkos.Any(x => x.SyID == SyukkoID);       //出庫情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された出庫詳細IDがDBに存在するかチェックする
        public bool CheckExistenceSyukkoDetail(int SyukkoDetailID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_SyukkoDetails.Any(x => x.SyDetailID == SyukkoDetailID);       //出庫詳細情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された入荷IDがDBに存在するかチェックする
        public bool CheckExistenceArrival(int ArrivalID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_Arrivals.Any(x => x.ArID == ArrivalID);       //入荷情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された入荷詳細IDがDBに存在するかチェックする
        public bool CheckExistenceArrivalDetail(int ArrivalDetailID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_ArrivalDetails.Any(x => x.ArDetailID == ArrivalDetailID);       //入荷詳細情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された出荷IDがDBに存在するかチェックする
        public bool CheckExistenceShipment(int ShipmentID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_Shipments.Any(x => x.ShID == ShipmentID);       //出荷情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された出荷詳細IDがDBに存在するかチェックする
        public bool CheckExistenceShipmentDetail(int ShipmentDetailID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_ShipmentDetails.Any(x => x.ShDetailID == ShipmentDetailID);       //出荷詳細情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された発注IDがDBに存在するかチェックする
        public bool CheckExistenceHattyu(int HattyuID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_Hattyus.Any(x => x.HaID == HattyuID);       //発注情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された発注詳細IDがDBに存在するかチェックする
        public bool CheckExistenceHattyuDetail(int HattyuDetailID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_HattyuDetails.Any(x => x.HaDetailID == HattyuDetailID);       //発注詳細情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された入庫IDがDBに存在するかチェックする
        public bool CheckExistenceWareHousing(int WareHousingID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_Warehousings.Any(x => x.WaID == WareHousingID);       //入庫情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された入庫詳細IDがDBに存在するかチェックする
        public bool CheckExistenceWareHousingDetail(int WareHousingDetailID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_WarehousingDetails.Any(x => x.WaDetailID == WareHousingDetailID);       //入庫詳細情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された売上IDがDBに存在するかチェックする
        public bool CheckExistenceSale(int SaleID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_Sale.Any(x => x.SaID == SaleID);       //売上情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }

        //入力された売上詳細IDがDBに存在するかチェックする
        public bool CheckExistenceSaleDetail(int SaleDetailID)
        {
            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            bool ExistResult;                                       //結果用変数宣言
            ExistResult = context.T_SaleDetails.Any(x => x.SaDetailID == SaleDetailID);       //売上詳細情報がDBに存在するか検索する
            context.Dispose();                                      //contextを解放する

            return ExistResult;                                     //結果を返す
        }
    }
}
