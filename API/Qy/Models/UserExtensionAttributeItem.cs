using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Qy
{
    public class UserExtensionAttributeItem
    {
        public UserExtensionAttributeItem() { }
        public UserExtensionAttributeItem(string name, string value)
        {
            this.name = name;
            this.value = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string value { get; set; }
    }
}
