namespace Api.Weixin.Qy
{
    /// <summary>
    /// 微信部门
    /// </summary>
    public class Department
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 父级部门ID
        /// </summary>
        public int parentid { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int order { get; set; }
    }
}
