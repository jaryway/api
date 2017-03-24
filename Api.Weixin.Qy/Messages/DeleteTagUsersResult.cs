

using Api.Core;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteTagUsersResult : JsonResult
    {
        /// <summary>
        /// 若部分userid非法，则返回 e.g. usr1|usr2|usr3
        /// </summary>
        public string invalidlist { get; set; }
    }
}