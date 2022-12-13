using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SalesManagement_SysDev
{
    class DataInputCheck
    {
        CheckExistence Existence = new CheckExistence();                                //IDの存在チェック用クラス
        MessageDsp msg = new MessageDsp();                                              //メッセージ表示用クラス

        /// <summary>
        /// 全角文字チェック
        /// （全角文字チェック）
        /// </summary>
        /// <param name="CheckText">対象文字列</param>
        /// <returns>true:全角文字のみ　false:全角文字以外を含む</returns>
        public bool CheckFullWidth(string CheckText)
        {
            int textLength = CheckText.Replace("\r\n", string.Empty).Length;
            int textByte = Encoding.GetEncoding("Shift_JIS").GetByteCount(CheckText.Replace("\r\n", string.Empty));
            if (textByte != textLength * 2)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 半角英数字チェック
        /// （半角英数字チェック）
        /// </summary>
        /// <param name="CheckText">対象文字列</param>
        /// <returns>true:半角英数字のみ　false:半角英数字以外を含む</returns>
        public bool CheckHalfAlphabetNumeric(string CheckText)
        {
            return (Regex.IsMatch(CheckText, @"^[0-9a-zA-Z]+"));
        }

        /// <summary>
        /// 半角カナチェック
        /// （半角カナと半角空白チェック）
        /// </summary>
        /// <param name="CheckText">対象文字列</param>
        /// <returns>true:半角カナのみ　false:半角カナ以外を含む</returns>
        public bool CheckHalfWidthKatakana(string CheckText)
        {
            return (Regex.IsMatch(CheckText, @"^[ ｡-ﾟ]*$"));
        }

        /// <summary>
        /// 数値チェック
        /// （数値チェック）
        /// </summary>
        /// <param name="CheckText">対象文字列</param>
        /// <returns>true:数値のみ　false:数値以外を含む</returns>
        public bool CheckNumeric(string CheckText)
        {
            return (Regex.IsMatch(CheckText, @"^[0-9]*$"));
        }

        /// <summary>
        /// 半角文字チェック
        /// （半角チェック）
        /// </summary>
        /// <param name="CheckText">対象文字列</param>
        /// <returns>true:半角文字のみ　false:半角文字以外を含む</returns>
        public bool CheckHalfChar(string CheckText)
        {
            return (Regex.IsMatch(CheckText, @"^[a-zｱ-ﾝ]*$"));
        }

        ///<summary>
        ///半角数字チェック
        /// </summary>
        /// <param name="="CheckText">対象文字列</param>
        /// <return>true:半角数字のみ false:半角数字でない</return>
        public bool CheckNumericAndHalfChar(string CheckText)
        {
            if(Regex.IsMatch(CheckText, @"^[0-9]*$"))
            {
                return true;
            }
            return false;
        }

        /////////////////////////////////////////////
        ///ID系統の入力チェック
        /////////////////////////////////////////////

        /// <summary>
        /// 役職ID入力チェックメソッド
        /// </summary>
        /// <returns>異常なし:true, 異常あり:false</returns>
        public bool PositionIDInputCheck(string InputText)
        {
            //役職IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M5028");
                return false;
            }

            //役職IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M5029");
                return false;
            }

            //役職IDの文字数チェック
            if (InputText.Length > 2)
            {
                msg.MsgDsp("M5030");
                return false;
            }

            //役職IDの存在チェック
            if (!Existence.CheckExistencePosition(int.Parse(InputText)))
            {
                msg.MsgDsp("M5040");
                return false;
            }

            //異常なしの場合trueを返す
            return true;
        }

        /// <summary>
        /// メーカID入力チェックメソッド
        /// </summary>
        /// <returns>異常なし:true, 異常あり:false</returns>
        public bool MakerIDInputCheck(string InputText)
        {
            //メーカIDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M3004");
                return false;
            }

            //メーカIDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M3005");
                return false;
            }

            //メーカIDの文字数チェック
            if (InputText.Length > 4)
            {
                msg.MsgDsp("M3006");
                return false;
            }

            //メーカIDの存在チェック
            if (!Existence.CheckExistenceMaker(int.Parse(InputText)))
            {
                msg.MsgDsp("M3076");
                return false;
            }

            //異常なしの場合trueを返す
            return true;
        }

        /// <summary>
        /// 営業所IDチェックメソッド
        /// </summary>
        /// <returns>異常なし:true, 異常あり:false</returns>
        public bool SalesOfficeIDInputCheck(string InputText)
        {
            //営業所IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M2004");
                return false;
            }

            //営業所IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M2005");
                return false;
            }

            //営業所IDの文字数チェック
            if (InputText.Length > 2)
            {
                msg.MsgDsp("M2006");
                return false;
            }

            //顧営業所IDの存在チェック
            if (!Existence.CheckExistenceSalesOffice(int.Parse(InputText)))
            {
                msg.MsgDsp("M5061");
                return false;
            }

            //異常なしの場合trueを返す
            return true;
        }

        /// <summary>
        /// 顧客IDチェックメソッド
        /// </summary>
        /// <returns>異常あり:false,異常なし:true</returns>
        public bool ClientIDInputCheck(string InputText)
        {
            //顧顧客IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M2001");
                return false;
            }

            //顧客IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M2002");
                return false;
            }

            //顧客IDの文字数チェック
            if (InputText.Length > 6)
            {
                msg.MsgDsp("M2003");
                return false;
            }

            //顧客IDの存在チェック
            if (!Existence.CheckExistenceClient(int.Parse(InputText)))
            {
                msg.MsgDsp("M2029");
                return false;
            }

            //異常が無い場合trueを返す
            return true;
        }

        /// <summary>
        /// 社員IDの入力チェック
        /// </summary>
        /// <param name="InputText"></param>
        /// <returns>異常あり:false, 異常なし:true</returns>
        public bool EmployeeIDInputCheck(string InputText)
        {
            //社員IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M5001");
                return false;
            }

            //社員IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M5002");
                return false;
            }

            //社員IDの文字数チェック
            if (InputText.Length > 6)
            {
                msg.MsgDsp("M5003");
                return false;
            }

            //社員IDの存在チェック
            if (!Existence.CheckExistenceEmployee(int.Parse(InputText)))
            {
                msg.MsgDsp("M5027");
                return false;
            }

            //異常が無い場合trueを返す
            return true;
        }

        /// <summary>
        /// 商品IDの入力チェック
        /// </summary>
        /// <returns>異常あり:false, 異常なし:true</returns>
        public bool ProductIDInputCheck(string InputText)
        {
            //商品IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M3001");
                return false;
            }

            //商品IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M3002");
                return false;
            }

            //商品IDの文字数チェック
            if (InputText.Length > 6)
            {
                msg.MsgDsp("M3003");
                return false;
            }

            //商品IDの存在チェック
            if (!Existence.CheckExistenceEProduct(int.Parse(InputText)))
            {
                msg.MsgDsp("M3029");
                return false;
            }

            //異常なしの場合trueを返す
            return true;
        }

        /// <summary>
        /// 大分類ID入力チェック
        /// </summary>
        /// <param name="InputText"></param>
        /// <returns>異常あり:false, 異常なし:true</returns>
        public bool MajorClassIDInputCheck(string InputText)
        {
            //大分類IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M3030");
                return false;
            }

            //大分類IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M3031");
                return false;
            }

            //大分類IDの文字数チェック
            if (InputText.Length > 2)
            {
                msg.MsgDsp("M3032");
                return false;
            }

            //大分類IDの存在チェック
            if (!Existence.CheckExistenceMajorClass(int.Parse(InputText)))
            {
                msg.MsgDsp("M3042");
                return false;
            }

            //異常なしの場合trueを返す
            return true;
        }

        /// <summary>
        /// 小分類ID入力チェック
        /// </summary>
        /// <param name="InputText"></param>
        /// <returns>異常あり:false, 異常なし:true</returns>
        public bool SmallClassIDInputCheck(string InputText)
        {
            //小分類IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M3043");
                return false;
            }

            //小分類IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M3044");
                return false;
            }

            //小分類IDの文字数チェック
            if (InputText.Length > 2)
            {
                msg.MsgDsp("M30345");
                return false;
            }

            //小分類IDの存在チェック
            if (!Existence.CheckExistenceSmallClass(int.Parse(InputText)))
            {
                msg.MsgDsp("M3055");
                return false;
            }

            //異常なしの場合trueを返す
            return true;
        }

        /// <summary>
        /// 在庫IDの入力チェック
        /// </summary>
        /// <returns>異常あり:false, 異常なし:true</returns>
        public bool StockInputCheck(string InputText)
        {
            //在庫IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M4001");
                return false;
            }

            //在庫IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M4002");
                return false;
            }

            //在庫IDの文字数チェック
            if (InputText.Length > 6)
            {
                msg.MsgDsp("M4003");
                return false;
            }

            //在庫IDの存在チェック
            if (!Existence.CheckExistenceStock(int.Parse(InputText)))
            {
                msg.MsgDsp("M4013");
                return false;
            }

            //異常が無い場合trueを返す
            return true;
        }

        /// <summary>
        /// 受注IDの入力チェック
        /// </summary>
        /// <returns>異常あり:false, 異常なし:true</returns>
        private bool OrderInputCheck(string InputText)
        {
            //受注IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M7001");
                return false;
            }

            //受注IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M7002");
                return false;
            }

            //受注IDの文字数チェック
            if (InputText.Length > 6)
            {
                msg.MsgDsp("M7003");
                return false;
            }

            //受注IDの存在チェック
            if (!Existence.CheckExistenceOrder(int.Parse(InputText)))
            {
                msg.MsgDsp("M7026");
                return false;
            }

            //異常が無い場合trueを返す
            return true;
        }

        /// <summary>
        /// 注文IDの入力チェック
        /// </summary>
        /// <returns>異常あり:false, 異常なし:true</returns>
        private bool ChumonInputCheck(string InputText)
        {
            //注文IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M8003");
                return false;
            }

            //注文IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M8004");
                return false;
            }

            //注文IDの文字数チェック
            if (InputText.Length > 6)
            {
                msg.MsgDsp("M8005");
                return false;
            }

            //注文IDの存在チェック
            if (!Existence.CheckExistenceChumon(int.Parse(InputText)))
            {
                msg.MsgDsp("M8009");
                return false;
            }

            //異常が無い場合trueを返す
            return true;
        }

        /// <summary>
        /// 出庫IDの入力チェック
        /// </summary>
        /// <returns>異常あり:false, 異常なし:true</returns>
        private bool SyukkoInputCheck(string InputText)
        {
            //出庫IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M11001");
                return false;
            }

            //出庫IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M11002");
                return false;
            }

            //出庫IDの文字数チェック
            if (InputText.Length > 6)
            {
                msg.MsgDsp("M11003");
                return false;
            }

            //出庫IDの存在チェック
            if (!Existence.CheckExistenceSyukko(int.Parse(InputText)))
            {
                msg.MsgDsp("M11006");
                return false;
            }

            //異常が無い場合trueを返す
            return true;
        }

        /// <summary>
        /// 入荷IDの入力チェック
        /// </summary>
        /// <returns>異常あり:false, 異常なし:true</returns>
        private bool ArrivalInputCheck(string InputText)
        {
            //入荷IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M12001");
                return false;
            }

            //入荷IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M12002");
                return false;
            }

            //入荷IDの文字数チェック
            if (InputText.Length > 6)
            {
                msg.MsgDsp("M12003");
                return false;
            }

            //入荷IDの存在チェック
            if (!Existence.CheckExistenceArrival(int.Parse(InputText)))
            {
                msg.MsgDsp("M12006");
                return false;
            }

            //異常が無い場合trueを返す
            return true;
        }

        /// <summary>
        /// 出荷IDの入力チェック
        /// </summary>
        /// <returns>異常あり:false, 異常なし:true</returns>
        private bool ShipmentInputCheck(string InputText)
        {
            //出荷IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M13001");
                return false;
            }

            //出荷IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M13002");
                return false;
            }

            //出荷IDの文字数チェック
            if (InputText.Length > 6)
            {
                msg.MsgDsp("M13003");
                return false;
            }

            //出荷IDの存在チェック
            if (!Existence.CheckExistenceShipment(int.Parse(InputText)))
            {
                msg.MsgDsp("M13006");
                return false;
            }

            //異常が無い場合trueを返す
            return true;
        }

        /// <summary>
        /// 発注IDの入力チェック
        /// </summary>
        /// <returns>異常あり:false, 異常なし:true</returns>
        private bool HattyuInputCheck(string InputText)
        {
            //発注IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M9001");
                return false;
            }

            //発注IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M9002");
                return false;
            }

            //発注IDの文字数チェック
            if (InputText.Length > 6)
            {
                msg.MsgDsp("M9003");
                return false;
            }

            //発注IDの存在チェック
            if (!Existence.CheckExistenceHattyu(int.Parse(InputText)))
            {
                msg.MsgDsp("M9023");
                return false;
            }

            //異常が無い場合trueを返す
            return true;
        }

        /// <summary>
        /// 入庫IDの入力チェック
        /// </summary>
        /// <returns>異常あり:false, 異常なし:true</returns>
        private bool WarehousingInputCheck(string InputText)
        {
            //入庫IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M10001");
                return false;
            }

            //入庫IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M10002");
                return false;
            }

            //入庫IDの文字数チェック
            if (InputText.Length > 6)
            {
                msg.MsgDsp("M10003");
                return false;
            }

            //入庫IDの存在チェック
            if (!Existence.CheckExistenceWareHousing(int.Parse(InputText)))
            {
                msg.MsgDsp("M10006");
                return false;
            }

            //異常が無い場合trueを返す
            return true;
        }

        /// <summary>
        /// 売上IDの入力チェック
        /// </summary>
        /// <returns>異常あり:false, 異常なし:true</returns>
        private bool SaleInputCheck(string InputText)
        {
            //売上IDの空文字チェック
            if (string.IsNullOrEmpty(InputText))
            {
                msg.MsgDsp("M6001");
                return false;
            }

            //売上IDの半角数字チェック
            if (!CheckNumericAndHalfChar(InputText))
            {
                msg.MsgDsp("M6002");
                return false;
            }

            //売上IDの文字数チェック
            if (InputText.Length > 6)
            {
                msg.MsgDsp("M6003");
                return false;
            }

            //売上IDの存在チェック
            if (!Existence.CheckExistenceSale(int.Parse(InputText)))
            {
                msg.MsgDsp("M6004");
                return false;
            }

            //異常が無い場合trueを返す
            return true;
        }
    }
}
