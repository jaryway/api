using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class UploadTagRequest : IRequest
    {
        /// <summary>
        /// 标签ID
        /// </summary>
        public int tagid { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string tagname { get; set; }
    }
}
