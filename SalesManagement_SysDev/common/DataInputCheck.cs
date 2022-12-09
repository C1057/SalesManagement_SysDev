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
            return (Regex.IsMatch(CheckText, @"^[1-9a-z]+"));
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
    }
}
