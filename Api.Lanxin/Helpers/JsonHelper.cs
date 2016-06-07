using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Helpers;

namespace Api.Lanxin.Helpers
{
    /// <summary>
    /// Json帮助类，用于将对象/JSON对象转换
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// unicode解码
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private static string DecodeUnicode(Match match)
        {
            if (!match.Success)
                return null;
            char outStr = (char)int.Parse(match.Value.Remove(0, 2), System.Globalization.NumberStyles.HexNumber);
            return new string(outStr, 1);
        }
        /// <summary>
        /// 将数据对象转换为 JavaScript 对象表示法 (JSON) 格式的字符串。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Encode(object obj)
        {
            string encode = Json.Encode(obj);
            //解码Unicode，也可以通过设置App.Config（Web.Config）设置来做，这里只是暂时弥补一下，用到的地方不多
            MatchEvaluator evaluator = new MatchEvaluator(DecodeUnicode);
            //或：[\\u007f-\\uffff]，\对应为\u000a，但一般情况下会保持
            var json = Regex.Replace(encode, @"\\u[0123456789abcdef]{4}", evaluator);
            return json;
        }
        /// <summary>
        /// 将 JavaScript 对象表示法 (JSON) 格式的数据转换为指定的强类型数据列表。
        /// </summary>
        /// <typeparam name="T">必须是引用类型</typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T Decode<T>(string jsonString) where T : class
        {
            if (typeof(T) == typeof(string))
                return jsonString as T;

            return Json.Decode<T>(jsonString);
        }
    }
}
