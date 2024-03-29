﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class MakerDataAccess
    {
        MessageDsp msg = new MessageDsp();
        public void DeleteMaker(int makerID,string Hidden)
        {
            var context = new SalesManagement_DevContext();  　　　　　　　　　　　 //SalesManagement_DevContextクラスのインスタンス化
            var maker = context.M_Makers.Single(x => x.MaID == makerID);           //非表示にするレコードの抽出

            maker.MaFlag = 2;      　　　　　　　　　　　　　　　　　              //顧客管理フラグを2にする
            maker.MaHidden = Hidden;                                                //非表示理由

            context.SaveChanges();                                               //更新を確定する
            context.Dispose();                                                  //contextを解放
        }

        public List<M_Maker> searchmakerclass(string searchinfo)　//検索機能モジュール
        {
            var context = new SalesManagement_DevContext(); //クラスのインスタンス化
            List<M_Maker> searchresult = null;              //検索結果用変数を宣言

            string MakerName = searchinfo;　
            searchresult = context.M_Makers.Where(M_Maker => M_Maker.MaName.Contains(searchinfo)).ToList();  //検索

            context.Dispose();　　//contextを解放

            return searchresult;
        }

        public List<M_Maker> addmakerclass(string searchinfo)  //検索機能モジュール
        {

            var context = new SalesManagement_DevContext();    //クラスのインスタンス化
            List<M_Maker> searchresult = null;

            string MakerName = searchinfo;                         
            searchresult = context.M_Makers.Where(M_Maker => M_Maker.MaName.Contains(searchinfo)).ToList();  //検索

            context.Dispose();  //contextを解放

            return searchresult;
        }

        public void AddMaker(M_Maker addmaker)
        {
            var Context = new SalesManagement_DevContext(); //クラスのインスタンス化
            MessageDsp msg = new MessageDsp();

            try
            {
                DialogResult result = msg.MsgDsp("M3070");　//登録メッセージ
                if (result == DialogResult.Cancel)  //登録確認がCancelの場合
                {
                    Context.Dispose();　　//メモリの解放
                    return;
                }

                Context.M_Makers.Add(addmaker);　　//内容を登録データといてcontextに登録
                Context.SaveChanges();  //変更の反映
                Context.Dispose();     //メモリの解放

                msg.MsgDsp("M3071");  //登録完了メッセージ
            }
            catch
            {
                msg.MsgDsp("M3072");  //登録失敗メッセージ
            }
        }

        public void UpdateMaker(M_Maker UpdateMaker)
        {
            DialogResult result = msg.MsgDsp("M3073");   //更新しますかメッセージ

            if (result == DialogResult.Cancel) //更新Cancel　更新モジュールを終了する
            {
                return;
            }
            try
            {
                var context = new SalesManagement_DevContext();       //クラスのインスタンス化
                var Maker = context.M_Makers.Single(x => x.MaID == UpdateMaker.MaID);    //更新対象データの取得

                Maker.MaName = UpdateMaker.MaName;  //更新データをセット
                Maker.MaAdress = UpdateMaker.MaAdress;
                Maker.MaPhone = UpdateMaker.MaPhone;
                Maker.MaPostal = UpdateMaker.MaPostal;
                Maker.MaFAX = UpdateMaker.MaFAX;
                Maker.MaHidden = UpdateMaker.MaHidden;

                context.SaveChanges();  //
                context.Dispose();     //contextを開放

                msg.MsgDsp("M3074");　　　//更新完了メッセージ
            }
            catch
            {
                msg.MsgDsp("M3075");　　　//更新失敗メッセージ
            }
        }

        public List<M_Maker> GetData()
        {
            var context = new SalesManagement_DevContext();             //SalesManagement_DevContextクラスのインスタンス化
            return context.M_Makers.ToList();                          //メーカーマスタの全データを戻り値として返す
        }

        public List<M_Maker> SearchMaker(int methodflg, string SearchInfo)
        {
            var Context = new SalesManagement_DevContext();
            List<M_Maker> searchresult = null;

            if (methodflg == 1)
            {
                int MakerID = int.Parse(SearchInfo);
                searchresult = Context.M_Makers.Where(x => x.MaID == MakerID).ToList();
                Context.Dispose();

            }
            return searchresult;
        }

        public List<M_Maker> SearchMaker(string SearchInfo)
        {
            var Context = new SalesManagement_DevContext();
            List<M_Maker> searchresult = null;

            string MakerName = SearchInfo;
            searchresult = Context.M_Makers.Where(M_Position => M_Position.MaName.Contains(MakerName)).ToList();

            Context.Dispose();

            return searchresult;

        }
    }
}
