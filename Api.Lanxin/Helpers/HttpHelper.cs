
using Api.Lanxin.Helpers;
using Api.Lanxin.Logging;
using Api.Lanxin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Api.Lanxin.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpHelper
    {
        #region const fileds
        const string USERAGENT = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.2; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        const string CONTENTTYPE = "application/json;charset=UTF-8";
        const string REQUESTENCODING = "utf-8";
        const string RESPONSEENCODING = "utf-8";
        /// <summary>
        /// 边界符
        /// </summary>
        static string BOUNDARY = "---------------" + DateTime.Now.Ticks.ToString("x");
        #endregion
        /// <summary>
        /// HttpPost对象用于提交Post请求
        /// </summary>
        public static class HttpPost
        {
            #region GetJsonResult
            /// <summary>
            /// POST数据同时获取POST返回的JSON结果
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <typeparam name="TResult">JSON结果</typeparam>
            /// <param name="data">待提交的数据</param>
            /// <param name="url">提交的地址</param>
            /// <returns></returns>
            public static TResult GetJsonResult<T, TResult>(string url, T data) where TResult : class
            {
                var result = GetResult(JsonHelper.Encode(data), url);
                return JsonHelper.Decode<TResult>(result);
            }
            #endregion

            #region GetXmlResult
            /// <summary>
            /// POST数据并获取XML结果
            /// </summary>
            /// <typeparam name="T">任何自定义Class</typeparam>
            /// <typeparam name="TResult">返回的xml对象</typeparam>
            /// <param name="data"></param>
            /// <param name="url"></param>
            /// <returns></returns>
            public static TResult GetXmlResult<T, TResult>(string url, T data)
                where T : class
            {
                var result = GetResult(url, XmlHelper.Serialize(data));
                return XmlHelper.Deserialize<TResult>(result);
            }
            /// <summary>
            /// POST数据并将获取到的数据转成字段
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="data"></param>
            /// <param name="url"></param>
            /// <returns></returns>
            public static Dictionary<string, string> GetXmlResult<T>(string url, T data)
                where T : class
            {
                var result = GetResult(XmlHelper.Serialize(data), url);
                return XmlHelper.ToDictionary(result);
            }
            /// <summary>
            /// POST数据并获取Dictionary结果
            /// </summary>
            /// <param name="data">要提交的数据</param>
            /// <param name="url">要提交的地址</param>
            /// <param name="certPath">证书地址，如：E:/wwww/weixin.cert</param>
            /// <param name="password">证书密码</param>
            /// <returns>返回Dictionary结果</returns>
            public static Dictionary<string, string> GetXmlResult(string url, string data, string certPath = null, string password = null)
            {
                Encoding encoding = Encoding.GetEncoding(REQUESTENCODING);
                byte[] bytesToPost = encoding.GetBytes(data);
                return GetXmlResult(url, bytesToPost, certPath, password);
            }

            /// <summary>
            /// Post数据并获取Dictionary结果
            /// </summary>
            /// <param name="data">待提交的数据</param>
            /// <param name="url">提交的地址</param>
            /// <param name="certPath">证书地址，如：E:/wwww/weixin.cert</param>
            /// <param name="password">证书密码</param>
            /// <returns>返回Dictionary结果</returns>
            public static Dictionary<string, string> GetXmlResult(string url, byte[] data, string certPath, string password)
            {
                var result = GetResult(url, data, certPath, password);
                return XmlHelper.ToDictionary(result);
            }
            #endregion

            #region GetResult
            /// <summary>
            /// POST数据同时获取POST返回的结果
            /// </summary>
            /// <param name="data">待提交的数据</param>
            /// <param name="url">提交的地址</param>
            /// <param name="certPath">证书地址，如：E:/wwww/weixin.cert</param>
            /// <param name="password">证书密码</param>
            /// <returns>返回POST后的结果</returns>
            public static string GetResult(string url, string data, string certPath = null, string password = null)
            {
                Encoding encoding = Encoding.GetEncoding(REQUESTENCODING);
                byte[] bytesToPost = encoding.GetBytes(data);
                return GetResult(url, bytesToPost);
            }

            /// <summary>
            /// Post数据同时或POST返回的结果
            /// </summary>
            /// <param name="data">待提交的数据</param>
            /// <param name="url">提交的地址</param>
            /// <param name="certPath">证书地址，如：E:/wwww/weixin.cert</param>
            /// <param name="password">证书密码</param>
            /// <returns>返回POST后的结果</returns>
            public static string GetResult(string url, byte[] data, string certPath = null, string password = null)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

                    if (!string.IsNullOrEmpty(certPath) && !string.IsNullOrEmpty(password))
                    {
                        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                        X509Certificate cer = new X509Certificate(certPath, password);
                        request.ClientCertificates.Add(cer);
                    }

                    request.UserAgent = USERAGENT;
                    request.ContentType = CONTENTTYPE;
                    request.Method = "POST";
                    request.ContentLength = data != null ? data.Length : 0;
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                    request.KeepAlive = true;

                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Close();

                    HttpWebResponse webreponse = (HttpWebResponse)request.GetResponse();

                    Stream stream = webreponse.GetResponseStream();
                    string result = string.Empty;
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    LoggerFactory.GetLogger().Error(ex);
                    throw ex;
                }
            }
            #endregion

            #region 文件上传

            /// <summary>
            /// 上传媒体文件
            /// </summary>
            /// <param name="media"></param>
            /// <param name="url"></param>
            /// <returns></returns>
            public static string GetMediaResult(string url, PostMedia media)
            {
                Encoding encoding = Encoding.GetEncoding(REQUESTENCODING);
                byte[] boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + BOUNDARY + "\r\n");
                byte[] endbytes = Encoding.ASCII.GetBytes("\r\n--" + BOUNDARY + "--\r\n");

                // content-type前不能有空格
                string format = "content-disposition: form-data; name=\"{0}\"; filename=\"{1}\";filelegth=\"{2}\"\r\ncontent-type: application/octet-stream\r\n\r\n";
                byte[] headerbytes = encoding.GetBytes(string.Format(format, "media", media.FullName, media.ByteData.Length));
                byte[] buffer;
                using (var stream = new MemoryStream())
                {
                    stream.Write(boundarybytes, 0, boundarybytes.Length);
                    stream.Write(headerbytes, 0, headerbytes.Length);
                    stream.Write(media.ByteData, 0, media.ByteData.Length);
                    stream.Write(endbytes, 0, endbytes.Length);//1.3 form end
                    buffer = stream.GetBuffer();
                }

                return GetFileResult(url, buffer);
            }
            /// <summary>
            /// 上传文件
            /// </summary>
            /// <param name="data"></param>
            /// <param name="url"></param>
            /// <returns></returns>
            public static string GetFileResult(string url, byte[] data)
            {
                var responseContent = string.Empty;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                if (request == null)
                {
                    var msg = string.Format("Invalid url string: {0}", url);
                    throw new ApplicationException(msg);
                }

                request.UserAgent = USERAGENT;
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=" + BOUNDARY;
                request.KeepAlive = true;
                request.Credentials = CredentialCache.DefaultCredentials;
                request.ContentLength = data.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                var response = request.GetResponse();
                if (response == null)
                    return responseContent;

                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.GetEncoding(RESPONSEENCODING));
                    responseContent = reader.ReadToEnd();
                    reader.Dispose();
                }
                response.Close();

                return responseContent;
            }
            #endregion

            #region Private Methods
            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="certificate"></param>
            /// <param name="chain"></param>
            /// <param name="sslPolicyErrors"></param>
            /// <returns></returns>
            private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                if (sslPolicyErrors == SslPolicyErrors.None)
                    return true;
                return false;
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public static class HttpGet
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="url"></param>
            /// <returns></returns>
            public static dynamic GetDynamicResult(string url)
            {
                var result = GetResult(url);
                return JsonHelper.Decode<dynamic>(result.Content);
            }
            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="TResult"></typeparam>
            /// <param name="url"></param>
            /// <returns></returns>
            public static TResult GetJsonResult<TResult>(string url) where TResult : class
            {
                var result = GetResult(url);
                return JsonHelper.Decode<TResult>(result.Content);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="TResult"></typeparam>
            /// <param name="url"></param>
            /// <returns></returns>
            public static TResult GetXmlResult<TResult>(string url)
            {
                var result = GetResult(url);
                return XmlHelper.Deserialize<TResult>(result.Content);
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="url"></param>
            /// <returns></returns>
            public static Dictionary<string, string> GetXmlResult(string url)
            {
                var result = GetResult(url);
                return XmlHelper.ToDictionary(result.Content);
            }

            /// <summary>
            /// 从指定url获取数据
            /// </summary>
            /// <param name="url"></param>
            /// <returns></returns>
            public static ResponseData GetResult(string url)
            {
                ResponseData data = new ResponseData();
                string responseContent = string.Empty;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 10000;
                var response = request.GetResponse();
                if (response == null)
                    return data;

                var contentType = response.ContentType.ToLower().Split(new char[] { ';' })[0];

                //是文本类型直接返回
                string[] contentTypes = { "application/json", "text/xml", "text/html", "text/plain" };
                if (contentTypes.Contains(contentType))
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream, Encoding.GetEncoding(REQUESTENCODING));
                        data.Content = reader.ReadToEnd();
                        reader.Dispose();
                    }

                    LoggerFactory.GetLogger().Error(string.Format("{0}:{1}", url, data.Content));

                    return data;
                }
                //文件类型，处理文件
                Dictionary<string, string> dic = new Dictionary<string, string>();
                foreach (var key in response.Headers.AllKeys)
                {
                    string _key = key.ToLower();
                    var k = _key.Replace("-", "");
                    //获取文件 content-disposition，主要用户Get时获取filename
                    if (_key == "content-disposition")
                    {
                        var dispositions = response.Headers[key].Split(new char[] { ';' });
                        if (dispositions.Length > 0)
                        {
                            foreach (var disposition in dispositions)
                            {
                                var items = disposition.Split(new char[] { '=' });
                                if (items.Length >= 2)
                                    dic.Add(items[0].Trim(), items[1].Replace("\"", ""));
                            }
                        }
                        continue;
                    }
                    dic.Add(k, response.Headers[key]);
                }

                data.Content = JsonHelper.Encode(dic);
                var responseStream = response.GetResponseStream();
                var mstream = new MemoryStream();
                responseStream.CopyTo(mstream);
                data.Stream = mstream;
                responseStream.Dispose();
                response.Close();
                return data;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static TResult Get<TResult>(string url) where TResult : class
        {
            return HttpGet.GetJsonResult<TResult>(url);
        }

        /// <summary>
        /// 使用POST发送并获取发送后的结果
        /// 比如 <![CDATA[Send<dynamic,IJsonResult>(new{userName='xiaoming'})]]>
        /// </summary>
        /// <typeparam name="T">任意Class</typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url">发送的URL</param>
        /// <param name="t">数据实体</param>
        /// <returns></returns>
        public static TResult Send<T, TResult>(string url, T t) where TResult : class
        {
            return HttpPost.GetJsonResult<T, TResult>(url, t);
        }

        #region ResponseData
        /// <summary>
        /// 
        /// </summary>
        public class ResponseData
        {
            /// <summary>
            /// 
            /// </summary>
            public ResponseData()
            {
                Content = string.Empty;
            }
            /// <summary>
            /// 文本内容
            /// </summary>
            public string Content { get; set; }
            /// <summary>
            /// 流内容
            /// </summary>
            public Stream Stream { get; set; }
        }
        #endregion
    }
}
