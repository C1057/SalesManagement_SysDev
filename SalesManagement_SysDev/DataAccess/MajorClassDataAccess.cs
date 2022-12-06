﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{




    class MajorClassDataAccess
    {

        MessageDsp msg = new MessageDsp();
        /// <summary>
        /// 大分類登録モジュール
        /// </summary>
        /// <param name="addData"></param>
        /// <return>void</return>
        public void addMajorClass(M_MajorClassification addData)
        {
            DialogResult result = msg.MsgDsp("M3022"); //登録確認メッセージ
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


                context.M_MajorClassifications.Add(addData); //データをセット
                context.SaveChanges();　　//
                context.Dispose();  //　contextを開放

                msg.MsgDsp("M3023");　//登録完了メッセージ
            }
            catch
            {
                msg.MsgDsp("M3024"); //登録失敗メッセージ
            }

        }


        /// <summary>
        /// 大分類更新モジュール
        /// </summary>
        /// <param name="UpdateData"></param>
        /// <return>void</return>
        public void UpdateMajorClass(M_MajorClassification UpdateData)
        {
            DialogResult result = msg.MsgDsp("M3025"); //更新確認メッセージ
            if (result == DialogResult.Cancel)　//更新Cancel　更新モジュールを終了する
            {
                return;
            }
            try
            {
                var context = new SalesManagement_DevContext();       //クラスのインスタンス化
                var MajorClass = context.M_MajorClassifications.Single(x => x.McID == UpdateData.McID);    //更新対象データの取得
                MajorClass = UpdateData;  //更新データをセット
                context.SaveChanges();  //
                context.Dispose();     //contextを開放

                msg.MsgDsp("M3025");
            }
            catch
            {
                msg.MsgDsp("M3026");
            }
        }


        /// <summary>
        /// 大分類非表示機能
        /// </summary>
        /// <param name=""></param>
        /// <param name="MajorClassID"></param>
        /// <returns>List<M_Employee></returns>
        public void DeleteMajorClass(int MajorClassID) //非表示
        {
            var context = new SalesManagement_DevContext();                             //SalesManagement_DevContextクラスのインスタンス化
            var MajorClass = context.M_MajorClassifications.Single(x => x.McID == MajorClassID);             //非表示にするレコードの抽出
            MajorClass.McFlag = 2;                                                          //大分類管理フラグを2にする
            context.SaveChanges();                                                      //更新を確定する
            context.Dispose();                                                          //contextを解放
        }
    }
}
