using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Mp
{
    /// <summary>
    /// 分组
    /// </summary>
    public class Group
    {
        private int _count = 0;
        /// <summary>
        /// 分组id，由微信分配
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 分组名字，UTF8编码 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 分组内用户数量
        /// </summary>
        public int count
        {
            get { return _count; }
            set { _count = value; }
        }
    }
}
