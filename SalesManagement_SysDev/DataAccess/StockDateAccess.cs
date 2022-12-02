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
        MessageDsp msg = new MessageDsp();

        public List<T_Stock> SearchStock(int methodflg, string SearchInfo)
        {
            var context = new SalesManagement_DevContext();
            List<T_Stock> SearchResult = null;

            if (methodflg == 1)
            {
                int StockID = int.Parse(SearchInfo);
                SearchResult = context.T_Stocks.Where(x => x.StID == StockID).ToList();
                context.Dispose();
            }
            else if (methodflg == 2)
            {
                int ProductID = int.Parse(SearchInfo);
                SearchResult = context.T_Stocks.Where(x => x.PrID == ProductID).ToList();
                context.Dispose();
            }

            return SearchResult;
        }

        public List<T_Stock> SearchResult(string SearchInfo)
        {
            var context = new SalesManagement_DevContext();
            List<T_Stock> SearchResult = null;

            string ProductName = SearchInfo;

            foreach(var product in context.M_Products)
            {
                if (product.PrName.Contains(ProductName))
                {
                    SearchResult.Add(context.T_Stocks.Where(stocks => stocks.PrID==product.PrID).Single());
                }
            }

            return SearchResult;
        }

        public void UpdateStock(T_Stock updateData)
        {
            DialogResult result = msg.MsgDsp("M4010");
            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                var context = new SalesManagement_DevContext();
                var Stock = context.T_Stocks.Single(x => x.StID == updateData.StID);
                Stock.PrID = updateData.PrID;
                Stock.StQuantity = updateData.StQuantity;

                context.SaveChanges();
                context.Dispose();

                msg.MsgDsp("M4011");
            }
            catch
            {
                msg.MsgDsp("M4012");
            }
        }
    }
}
