using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class ChumonDateAccess
    {
        MessageDsp msg = new MessageDsp();

        public void DeleteChumon(int chumonID)
        {
            DialogResult result = msg.MsgDsp("M14001");
            if(result == DialogResult.Cancel)
            {
                return;
            }
            var context = new SalesManagement_DevContext();
            var chumon = context.T_Chumons.Single(x => x.ChID == chumonID);
            chumon.ChFlag = 2;
            context.SaveChanges();
            context.Dispose();

            msg.MsgDsp("M14002");
        }
    }
}
