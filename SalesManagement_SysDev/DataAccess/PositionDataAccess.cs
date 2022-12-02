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
    }
}
