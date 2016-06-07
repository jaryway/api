using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class NonceHelper
    {
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Generate(int len, bool onlyNumber = false)
        {
            char[] arrChar = new char[]
            {
               'a','b','d','c','e','f','g','h','i','j','k','l','m','n','p','r','q','s','t','u','v','w','z','y','x',
               '0','1','2','3','4','5','6','7','8','9',
               'A','B','C','D','E','F','G','H','I','J','K','L','M','N','Q','P','R','T','S','V','U','W','X','Y','Z'
            };
            string code = string.Empty;
            CryptoRandom r = new CryptoRandom();
            for (int i = 0; i < len; i++)
            {
                if (onlyNumber)
                    code += arrChar[r.Next(24, 34)];
                else
                    code += arrChar[r.Next(0, arrChar.Length)];
            }

            return code;
        }
    }
}
