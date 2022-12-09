using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SalesManagement_SysDev
{
    class PasswordHash
    {
        /// <summary>
        /// ソルト生成モジュール
        /// </summary>
        /// <returns>string</returns>
        public string GenerateSalt()
        {
            const int SALT_SIZE = 24;                               //ソルトサイズ

            var buff = new byte[SALT_SIZE];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buff);
            }
            return Convert.ToBase64String(buff);
        }

        /// <summary>
        /// ハッシュ化モジュール
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="salt"></param>
        /// <returns>string</returns>
        public static string GeneratePasswordHash(string pwd, string salt)
        {
            var result = "";
            var saltAndPwd = String.Concat(pwd, salt);
            var encoder = new UTF8Encoding();
            var buffer = encoder.GetBytes(saltAndPwd);
            using (var csp = new SHA256CryptoServiceProvider())
            {
                var hash = csp.ComputeHash(buffer);
                result = Convert.ToBase64String(hash);
            }
            return result;
        }
    }
}
