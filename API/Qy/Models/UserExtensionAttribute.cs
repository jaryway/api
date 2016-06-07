using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy
{
    /// <summary>
    /// 用户额外属性
    /// </summary>
    public class UserExtensionAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public List<UserExtensionAttributeItem> attrs { get; set; }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="item"></param>
        public void Add(UserExtensionAttributeItem item)
        {
            if (attrs == null)
                attrs = new List<UserExtensionAttributeItem>();
            attrs.Add(item);
        }
        public void Add(string name, string value)
        {
            var item = new UserExtensionAttributeItem(name, value);
            this.Add(item);
        }
    }
}
