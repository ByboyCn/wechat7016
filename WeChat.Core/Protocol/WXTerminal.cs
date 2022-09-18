using Newtonsoft.Json;
using System;
using XMS.WeChat.Core.Versions;

namespace WeChat.Core.Protocol
{
    /// <summary>
    /// 微信终端
    /// </summary>
    public enum WXTerminal
    {
        /// <summary>
        /// Android
        /// </summary>
        [WXTerminal(WXOS.ANDROID, 0x02, 0xff, 0x27001439, WXRSAVersion.RSA_VER_182)] //十六进制：27001439，十进制：654316601，版本：7.0.20:57
        ANDROID=0,
        /// <summary>
        /// iPhone
        /// </summary>
        [WXTerminal(WXOS.IOS, 0x0d, 0xff, 0x18000722, WXRSAVersion.RSA_VER_182)] //十六进制：1700140C，十进制：385881100，版本：7.0.20:12
        IPHONE=1,
        /// <summary>
        /// iPad
        /// </summary>
        [WXTerminal(WXOS.IOS, 0x0d, 0xff, (int)_8026.PlistVersion,0)] //十六进制：1700140C，十进制：385881100，版本：7.0.20:12
        IPAD=2,
        /// <summary>
        /// iMac
        /// </summary>
        [WXTerminal(WXOS.IOS, 0x0e, 0xff, 0x13000013, WXRSAVersion.RSA_VER_182)] //十六进制：1205000B，十进制：302317579，版本：2.5.0:11
        IMAC=3
    }
    /// <summary>
    /// 微信终端特性标记
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class WXTerminalAttribute : Attribute
    {
        /// <summary>
        /// 系统类型
        /// </summary>
        public WXOS OS { get; }
        /// <summary>
        /// 终端标志
        /// </summary>
        public byte TerminalFlag { get; }
        /// <summary>
        /// 固定标志
        /// </summary>
        public byte FixFlag { get; }
        /// <summary>
        /// 微信版本
        /// </summary>
        public WXVersion WeChatVersion { get; }
        /// <summary>
        /// RSA版本
        /// </summary>
        public WXRSAVersion RsaVersion { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="os"></param>
        /// <param name="terminal_flag"></param>
        /// <param name="fix_flag"></param>
        /// <param name="wechat_version"></param>
        /// <param name="rsa_version"></param>
        public WXTerminalAttribute(WXOS os, byte terminal_flag, byte fix_flag, int wechat_version, WXRSAVersion rsa_version)
        {
            OS = os;
            TerminalFlag = terminal_flag;
            FixFlag = fix_flag;
            WeChatVersion = wechat_version;
            RsaVersion = rsa_version;
        }
    }
    /// <summary>
    /// 微信终端扩展
    /// </summary>
    public static class WXTerminalExtensions
    {
        /// <summary>
        /// 获取系统类型
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static WXOS GetOS(this WXTerminal? target)
        {
            var result = default(WXOS);
            var attris = target.GetType().GetField(target.ToString()).GetCustomAttributes(typeof(WXTerminalAttribute), true);
            if (attris != null && attris.Length > 0)
            {
                WXTerminalAttribute coAttrs = attris[0] as WXTerminalAttribute;
                result = coAttrs.OS;
            }
            return result;
        }
        /// <summary>
        /// 获取终端标志
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static byte GetTerminalFlag(this WXTerminal? target)
        {
            var result = default(byte);
            var attris = target.GetType().GetField(target.ToString()).GetCustomAttributes(typeof(WXTerminalAttribute), true);
            if (attris != null && attris.Length > 0)
            {
                WXTerminalAttribute coAttrs = attris[0] as WXTerminalAttribute;
                result = coAttrs.TerminalFlag;
            }
            return result;
        }
        /// <summary>
        /// 获取固定标志
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static byte GetFixFlag(this WXTerminal? target)
        {
            var result = default(byte);
            var attris = target.GetType().GetField(target.ToString()).GetCustomAttributes(typeof(WXTerminalAttribute), true);
            if (attris != null && attris.Length > 0)
            {
                WXTerminalAttribute coAttrs = attris[0] as WXTerminalAttribute;
                result = coAttrs.FixFlag;
            }
            return result;
        }
        /// <summary>
        /// 获取微信版本
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static WXVersion GetWeChatVersion(this WXTerminal? target)
        {
            WXVersion result = (int)_8026.PlistVersion;
            return result;
        }
        /// <summary>
        /// 获取RSA版本
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static WXRSAVersion GetRsaVersion(this WXTerminal? target)
        {
            var result = default(WXRSAVersion);
            var attris = target.GetType().GetField(target.ToString()).GetCustomAttributes(typeof(WXTerminalAttribute), true);
            if (attris != null && attris.Length > 0)
            {
                WXTerminalAttribute coAttrs = attris[0] as WXTerminalAttribute;
                result = coAttrs.RsaVersion;
            }
            return result;
        }
    }
}
