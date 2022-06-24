namespace WeChat.Core
{
    public enum AccountState
    {
        /// <summary>
        /// 已实名
        /// </summary>
        RealName_OK = 1,
        /// <summary>
        /// 未实名
        /// </summary>
        RealName_NOT = 0,

        /// <summary>
        /// 新号
        /// </summary>
        TYPE_NEW = 1,
        /// <summary>
        /// 老号
        /// </summary>
        TYPE_OLD = 0,

        /// <summary>
        /// 有头像
        /// </summary>
        HEADIMG_HAVE = 1,
        /// <summary>
        /// 没有头像
        /// </summary>
        HEADIMG_NOT = 0,

        /// <summary>
        /// 成功
        /// </summary>
        STATE_OK = 0,
        /// <summary>
        /// 失败（登录失败/帐号密码错误）
        /// </summary>
        STATE_FAIL = -1,
        /// <summary>
        /// 异常（代码异常/数据问题）
        /// </summary>
        STATE_ERROR = -2,
        /// <summary>
        /// 未知
        /// </summary>
        STATE_UNKNOWN = -3
    }
}
