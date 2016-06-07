using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Api.Lanxin.Messages
{
    /// <summary>
    /// 
    /// </summary>
    public class GetMediaResult : JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContentLength { get; set; }

        private Stream stream;
        /// <summary>
        /// 
        /// </summary>
        public Stream Stream
        {
            get { return stream; }
            set { stream = value; }
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveAs(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                byte[] bytes = new byte[stream.Length];
                int bytesRead = 0;
                int bytesToRead = (int)stream.Length;
                stream.Position = 0;
                while (bytesToRead > 0)
                {
                    int n = stream.Read(bytes, bytesRead, Math.Min(bytesToRead, int.MaxValue));
                    if (n <= 0)
                    {
                        break;
                    }
                    fs.Write(bytes, bytesRead, n);
                    bytesRead += n;
                    bytesToRead -= n;
                }
            }
        }
    }
}