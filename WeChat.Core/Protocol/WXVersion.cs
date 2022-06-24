namespace WeChat.Core.Protocol
{
    /// <summary>
    /// 微信版本
    /// </summary>
    public struct WXVersion
    {
        #region 属性
        /// <summary>
        /// 版本号
        /// </summary>
        public int Code;
        /// <summary>
        /// 主版本号
        /// </summary>
        public int Major => 0x0F & (Code >> 24);
        /// <summary>
        /// 次版本号
        /// </summary>
        public int Minor => 0xFF & (Code >> 16);
        /// <summary>
        /// 修订版本号
        /// </summary>
        public int Patch => 0xFF & (Code >> 8);
        /// <summary>
        /// 编译版本号
        /// </summary>
        public int Build => 0xFF & (Code >> 0);
        #endregion

        #region 重载
        /// <summary>
        /// 转换成字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Major}.{Minor}.{Patch}";
        /// <summary>
        /// 版本转换成整数
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator int(WXVersion value) => value.Code;
        /// <summary>
        /// 整数转换成版本号
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator WXVersion(int value) => new WXVersion() { Code = value };
        #endregion
    }
}
