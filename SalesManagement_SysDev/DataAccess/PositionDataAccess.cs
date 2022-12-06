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
            List < M_Position > = searchresult null;
            Context.Dispose();

            return searchresult;

        }
    }
}

