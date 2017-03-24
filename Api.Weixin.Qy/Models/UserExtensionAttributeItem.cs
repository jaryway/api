namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class UserExtensionAttributeItem
    {
        /// <summary>
        /// 
        /// </summary>
        public UserExtensionAttributeItem() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
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
