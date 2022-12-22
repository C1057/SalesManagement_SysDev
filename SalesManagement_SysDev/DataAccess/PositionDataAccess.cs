using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class PositionDataAccess
    {
        MessageDsp msg = new MessageDsp();
        public void DeletePosition(int PositionID)
        {
            DialogResult result = msg.MsgDsp("M14001");
            if (result == DialogResult.Cancel)
            {
                return;
            }
            var context = new SalesManagement_DevContext();
            var position = context.M_Positions.Single(x => x.PoID == PositionID);
            position.PoFlag = 2;
            context.SaveChanges();
            context.Dispose();

            msg.MsgDsp("M14002");
        }

        public List<M_Position> SearchPosition(int methodflg, string SearchInfo)
        {
            var Context = new SalesManagement_DevContext();
            List<M_Position> searchresult = null;

            if (methodflg == 1)
            {
                int PositionID = int.Parse(SearchInfo);
                searchresult = Context.M_Positions.Where(x => x.PoFlag == PositionID).ToList();
                Context.Dispose();

            }
            return searchresult;
        }

        public List<M_Position> SearchPosition(string SearchInfo)
        {
            var Context = new SalesManagement_DevContext();
            List < M_Position >  searchresult　= null;

            string PositionName = SearchInfo;
            searchresult = Context.M_Positions.Where(M_Position => M_Position.PoName.Contains(PositionName)).ToList();

            Context.Dispose();

            return searchresult;

        }

        public void AddPosition(M_Position addposition)
        {
            var Context = new SalesManagement_DevContext();
            MessageDsp msg = new MessageDsp();

            try
            {
                DialogResult result = msg.MsgDsp("M5034");
                if (result == DialogResult.Cancel)
                {
                    Context.Dispose();
                    return;
                }

                Context.M_Positions.Add(addposition);
                Context.SaveChanges();
                Context.Dispose();

                msg.MsgDsp("M5035");
            }
            catch
            {
                msg.MsgDsp("M5036");
            }            
        }

        public void UpdatePosition(M_Position updateData)
        {
            DialogResult result = msg.MsgDsp("M5037");

            if (result == DialogResult.Cancel) //更新Cancel　更新モジュールを終了する
            {
                return;
            }
            try
            {
                var context = new SalesManagement_DevContext();       //クラスのインスタンス化
                var Position = context.M_Positions.Single(x => x.PoID == updateData.PoID);    //更新対象データの取得
                //更新データをセット
                Position.PoName = updateData.PoName;
                context.SaveChanges();  //
                context.Dispose();     //contextを開放

                msg.MsgDsp("M5038");
            }
            catch
            {
                msg.MsgDsp("M5039");
            }
        }

        public List<M_Position> GetData()
        {
            var context = new SalesManagement_DevContext();
            return context.M_Positions.ToList();
        }
    }
}

