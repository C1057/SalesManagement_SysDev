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

        public void DeleteChumon(int chumonID) //注文非表示機能
        {
            DialogResult result = msg.MsgDsp("M14001");　//非表示確認メッセージ
            if(result == DialogResult.Cancel)//の場合非表示機能モジュールの実行終了
            {
                return;　
            }
            var context = new SalesManagement_DevContext();　　　//クラスのインスタンス化
            var chumon = context.T_Chumons.Single(x => x.ChID == chumonID);   //検索
            chumon.ChFlag = 2;
            context.SaveChanges();　//変更の反映
            context.Dispose();　　//contextの解放

            msg.MsgDsp("M14002");
        }
    }
}
