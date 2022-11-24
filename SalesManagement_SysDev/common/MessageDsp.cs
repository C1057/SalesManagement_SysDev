using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class MessageDsp
    {
        public DialogResult MsgDsp(string MsgNumber)
        {
            DialogResult result=DialogResult.None;

            try
            {
                var context = new SalesManagement_DevContext();
                var message = context.M_Messages.Single(x => x.MsgCD == MsgNumber);
                MessageBoxButtons btn = (MessageBoxButtons)message.MsgButton;
                MessageBoxIcon icon = (MessageBoxIcon)message.MsgICon;
                result = MessageBox.Show(message.MsgComments, message.MsgTitle, btn, icon);

                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }
    }
}
