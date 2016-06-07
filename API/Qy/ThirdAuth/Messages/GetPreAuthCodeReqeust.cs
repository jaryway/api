using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy.ThirdAuth
{
    /// <summary>
    /// 获取预授权码 所需参数
    /// </summary>
    public class GetPreAuthCodeReqeust : IRequest
    {
        /// <summary>
        /// 应用套件id 
        /// </summary>
        public string suite_id { get; set; }
        /// <summary>
        /// 应用id，本参数选填，表示用户能对本套件内的哪些应用授权，不填时默认用户有全部授权权限
        /// e.g.[id1,id2,id3]
        /// </summary>
        public List<int> appid { get; set; }

        /// <summary>
        /// 设置appid
        /// </summary>
        /// <param name="appIds"></param>
        public void SetAppId(params int[] appIds)
        {
            if (appid == null)
                appid = new List<int>();
            appid.AddRange(appIds);
        }
    }
}
