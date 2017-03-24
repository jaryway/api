using Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 获取应用概况列表
    /// </summary>
    public class GetAgentListResult : JsonResult
    {
        /// <summary>
        /// 应用列表
        /// </summary>
        public AgentInfo[] agentlist { get; set; }
    }
}
