using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Lanxin.Models
{
    /// <summary>
    /// 用于上传的媒体
    /// </summary>
    public class PostMedia
    {
        private Byte[] _byteData;
        /// <summary>
        /// 
        /// </summary>
        public PostMedia()
        {

        }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 文件名称，包含路径
        /// </summary>
        public string FullName { get; set; }
        ///// <summary>
        ///// 内容类型
        ///// </summary>
        //public string ContentType { get; set; }
        ///// <summary>
        ///// 内容大小
        ///// </summary>
        //public int ContentLength { get; set; }
        /// <summary>
        /// 文件流
        /// </summary>
        public Byte[] ByteData
        {
            get { return _byteData; }
            set { _byteData = value; }
        }
    }
}
