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
        PasswordHash PassHash = new PasswordHash();                 //ハッシュ化用クラスのインスタンス化


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


                //パスワードをハッシュ化が決まり次第コード記入
                addData.EmSalt = PassHash.GenerateSalt();       //ソルトの生成
                addData.EmPassword = PassHash.GeneratePasswordHash(addData.EmPassword, addData.EmSalt);         //ハッシュ化パスワードの生成

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


        /// <summary>
        /// 社員更新モジュール
        /// </summary>
        /// <param name="UpdateData"></param>
        /// <return>void</return>
        public void  UpdateEmployee (M_Employee UpdateData)
        {
            DialogResult result = msg.MsgDsp("M5024"); //更新確認メッセージ
            if (result == DialogResult.Cancel)　//更新Cancel　更新モジュールを終了する
            {
                return;
            }
            try
            {
                var context = new SalesManagement_DevContext();       //クラスのインスタンス化
                var Employee = context.M_Employees.Single(x => x.EmID == UpdateData.EmID);    //更新対象データの取得
                //更新データをセット
                Employee.EmName = UpdateData.EmName;
                Employee.SoID = UpdateData.SoID;
                Employee.PoID = UpdateData.PoID;
                Employee.EmHidden = UpdateData.EmHidden;
                Employee.EmPhone = UpdateData.EmPhone;
                Employee.EmHiredate = UpdateData.EmHiredate;


                context.SaveChanges();  //更新を確定する
                context.Dispose();     //contextを開放

                msg.MsgDsp("M5025");
            }
            catch
            {
                msg.MsgDsp("M5026");
            }
        }
        /// <summary>
        /// 社員検索モジュール　（ID系）
        /// </summary>
        /// <param name="methodflg"></param>
        /// <param name="SearchInfo"></param>
        /// <returns>List<M_Employee></returns>
        public List<M_Employee> SearchEmployee (int methodflg,string SearchInfo)　//IDで検索
        {
            var context = new SalesManagement_DevContext();
            List<M_Employee> SearchResult = null;

            if (methodflg == 1)　//社員IDで検索
            {
                int EmployeeID = int.Parse(SearchInfo);
                SearchResult = context.M_Employees.Where(x => x.EmID == EmployeeID).ToList();
            }
            else if (methodflg == 2)　//営業所IDで検索
            {
                int SalesOfficeID = int.Parse(SearchInfo);
                SearchResult = context.M_Employees.Where(x => x.SoID == SalesOfficeID).ToList();
            }
            else if (methodflg == 3)　//役職IDで検索
            {
                int PositionID = int.Parse(SearchInfo);
                SearchResult = context.M_Employees.Where(x => x.PoID == PositionID).ToList();
            }

            context.Dispose();
            return SearchResult;
        }
     

        /// <summary>
        /// 社員検索モジュール（名前）
        /// </summary>
        /// <param name="SearchInfo"></param>
        /// <returns></returns>
        public List<M_Employee> SearchEmployee (string SearchInfo)　//名前系で検索
        {
            var context = new SalesManagement_DevContext();
            List<M_Employee> SearchResult = null;

            string ClientName = SearchInfo;
            SearchResult = context.M_Employees.Where(M_Employee => M_Employee.EmName.Contains(SearchInfo)).ToList();

            context.Dispose();

            return SearchResult;
        }
        /// <summary>
        /// 社員非表示機能
        /// </summary>
        /// <param name=""></param>
        /// <param name="EmployeeID"></param>
        /// <returns>List<M_Employee></returns>
        public void DeleteEmployee (int EmployeeID) //非表示
        {
            DialogResult result = msg.MsgDsp("M14001");             //非表示確認メッセージ
            if (result == DialogResult.Cancel)
            {
                return;
            }

            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            var Employee = context.M_Employees.Single(x => x.EmID == EmployeeID);             //非表示にするレコードの抽出
            Employee.EmFlag = 2;                                                          //社員管理フラグを2にする
            context.SaveChanges();                                                      //更新を確定する
            context.Dispose();                                                          //contextを解放
        }

        /// <summary>
        /// 社員情報取得モジュール
        /// </summary>
        /// <param>なし</param>
        /// <returns>List<M_Employee></returns>
        public List<M_Employee> GetData()
        {
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            return context.M_Employees.ToList();                          //社員マスタの全データを戻り値として返す
        }





    }
}