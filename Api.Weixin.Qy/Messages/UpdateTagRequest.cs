using Api.Core;

namespace Api.Weixin.Qy
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
