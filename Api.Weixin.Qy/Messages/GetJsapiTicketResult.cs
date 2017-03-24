using Api.Core;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class GetJsapiTicketResult : JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string ticket { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int expires_in { get; set; }
    }
}
