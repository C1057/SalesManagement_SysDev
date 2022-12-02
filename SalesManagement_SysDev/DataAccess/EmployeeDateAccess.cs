using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class EmployeeDateAccess
    {
        MessageDsp msg = new MessageDsp();


        /// <summary>
        /// 社員登録モジュール
        /// </summary>
        /// <param name="addData"></param>
        /// <return>void</return>
        
        

        public void addEmployee(M_Employee addData)
        {
            DialogResult result = msg.MsgDsp("M5021"); //登録確認メッセージ
            if (result == DialogResult.Cancel)　//登録Cancel　登録モジュールを終了する
            {
                return;
            }

            try
            {
                var context = new SalesManagement_DevContext();

                //
                //パスワードをハッシュ化が決まり次第コード記入
                //


                context.M_Employees.Add(addData); //データをセット
                context.SaveChanges();　　//
                context.Dispose();  //　contextを開放

                msg.MsgDsp("M5022");　//登録完了メッセージ
            }
            catch
            {
                msg.MsgDsp("M5023"); //登録失敗メッセージ
            }

        }






    }
}