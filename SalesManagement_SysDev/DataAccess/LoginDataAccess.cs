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
        PasswordHash hash = new PasswordHash(); // 

        /// <summary>
        /// ログインモジュール
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <param name="Password"></param>
        /// <returns><M_Employee></returns>
        public bool Login(int EmployeeID, string Password) //ログイン
        {
            var context = new SalesManagement_DevContext();  //SalesManagement_DevContextのcontext化

            M_Employee EmployeeData = context.M_Employees.Single(Employee => Employee.EmID == EmployeeID); //
            string HashPassword = hash.GeneratePasswordHash(Password, EmployeeData.EmSalt);  //

            if (HashPassword == EmployeeData.EmPassword)
            {
                context.Dispose();　//contextを開放
                return true; //trueを返す


            }

            else
            {　
                context.Dispose();　//contextを開放
                return false; //falseを返す
            }


        }
            
            
    }
}
