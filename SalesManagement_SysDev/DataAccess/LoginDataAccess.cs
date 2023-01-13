using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class LoginDataAccess
    {
        PasswordHash hash = new PasswordHash();                 //ハッシュクラスのインスタンス化 
        DataInputCheck InputCheck = new DataInputCheck();       //データチェッククラスのインスタンス化

        /// <summary>
        /// ログインモジュール
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <param name="Password"></param>
        /// <returns><M_Employee></returns>
        public bool Login(string EmployeeID, string Password) //ログイン
        {
            var context = new SalesManagement_DevContext();  //SalesManagement_DevContextのcontext化
            
            if (!InputCheck.EmployeeIDInputCheck(EmployeeID))
            {
                return false;
            }

            int EmID = int.Parse(EmployeeID);           //社員ID用変数に代入
            M_Employee EmployeeData = context.M_Employees.Single(Employee => Employee.EmID == EmID); //IDと一致する社員データを取得する
            string HashPassword = hash.GeneratePasswordHash(Password, EmployeeData.EmSalt);  //入力されたパスワードと社員データのソルトを使ってハッシュ化する

            if (HashPassword == EmployeeData.EmPassword)            //ハッシュ化した入力パスワードと社員データのパスワードが一致したらtrueを返す
            {
                context.Dispose();　//contextを開放
                return true; //trueを返す
            }
            else
            {
                MessageBox.Show("パスワードが間違っています", "ログイン確認", MessageBoxButtons.OK, MessageBoxIcon.Error);     //パスワードが間違っている場合のエラーメッセージ

                context.Dispose();　//contextを開放
                return false; //falseを返す
            }
        }
    }
}
