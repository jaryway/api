namespace Api.Weixin.Qy
{
    /// <summary>
    /// 用户简单属性
    /// </summary>
    public class UserSimple
    {
        /// <summary>
        /// 员工UserID。对应管理端的帐号，企业内必须唯一。长度为1~64个字符 
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 成员名称。长度为1~64个字符 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int[] department { get; set; }
    }
}