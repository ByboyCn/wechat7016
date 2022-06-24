using System;
using System.Text;
using System.Xml;
using WeChat.Core.Protocol;

namespace WeChat.Core
{
    /// <summary>
    /// 微信设备
    /// </summary>
    [Serializable]
    public struct WXDevice
    {
        #region 属性
        /// <summary>
        /// 制造商（品牌）
        /// </summary>
        public string Manufacturer;
        /// <summary>
        /// 型号
        /// </summary>
        public string Model;
        /// <summary>
        /// 发布版本
        /// </summary>
        public string VersionRelease;
        /// <summary>
        /// 增量版本
        /// </summary>
        public string VersionIncremental;
        /// <summary>
        /// 显示名称
        /// </summary>
        public string Display;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造微信设备
        /// </summary>
        /// <param name="terminal"></param>
        public WXDevice(WXTerminal terminal)
        {
            Manufacturer = ""; Model = ""; VersionRelease = ""; VersionIncremental = ""; Display = "";
            if (terminal == WXTerminal.ANDROID) { Manufacturer = "vivo"; Model = "vivo R9"; VersionRelease = "6.0.2"; VersionIncremental = "eng.compiler.20170116.180408"; Display = "MMB29M release-keys"; }
            if (terminal == WXTerminal.IPAD) { Manufacturer = "Apple"; Model = "iPad"; VersionRelease = "14.3.0"; VersionIncremental = ""; Display = ""; }
            if (terminal == WXTerminal.IMAC) { Manufacturer = "Apple"; Model = "iMac"; VersionRelease = "10.15.7"; VersionIncremental = ""; Display = ""; }
            if (terminal == WXTerminal.IPHONE) { Manufacturer = "Apple"; Model = "iPhone"; VersionRelease = "14.3.0"; VersionIncremental = ""; Display = ""; }
        }
        /// <summary>
        /// 构造微信设备
        /// </summary>
        /// <param name="XmlConfig">XML</param>
        public WXDevice(string XmlConfig)
        {
            var doc = new XmlDocument(); doc.LoadXml(XmlConfig);
            var node = doc.SelectSingleNode("deviceinfo");
            node = node.SelectSingleNode("MANUFACTURER"); Manufacturer = node.Attributes["name"].Value;
            node = node.SelectSingleNode("MODEL"); Model = node.Attributes["name"].Value;
            node = node.SelectSingleNode("VERSION_RELEASE"); VersionRelease = node.Attributes["name"].Value;
            node = node.SelectSingleNode("VERSION_INCREMENTAL"); VersionIncremental = node.Attributes["name"].Value;
            node = node.SelectSingleNode("DISPLAY"); Display = node.Attributes["name"].Value;
        }
        /// <summary>
        /// 构造微信设备
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="model"></param>
        /// <param name="version_release"></param>
        /// <param name="version_incremental"></param>
        /// <param name="display"></param>
        public WXDevice(string manufacturer, string model, string version_release, string version_incremental, string display)
        {
            Manufacturer = manufacturer;
            Model = model;
            VersionRelease = version_release;
            VersionIncremental = version_incremental;
            Display = display;
        }
        #endregion

        #region 接口
        /// <summary>
        /// 转换成字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"<deviceinfo><MANUFACTURER name=\"{Manufacturer}\"><MODEL name=\"{Model}\"><VERSION_RELEASE name=\"{VersionRelease}\"><VERSION_INCREMENTAL name=\"{VersionIncremental}\"><DISPLAY name=\"{Display}\"></DISPLAY></VERSION_INCREMENTAL></VERSION_RELEASE></MODEL></MANUFACTURER></deviceinfo>";
        }
        #endregion

        #region 重载
        /// <summary>
        /// 终端转换成设备
        /// </summary>
        /// <param name="terminal"></param>
        public static implicit operator WXDevice(WXTerminal terminal) => new WXDevice(terminal);
        /// <summary>
        /// 转换设备
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator WXDevice(ValueTuple<string, string, string, string, string> value) => new WXDevice(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5);
        #endregion
    }

    /// <summary>
    /// 微信环境
    /// </summary>
    [Serializable]
    public struct WXEnvironment
    {
        #region 属性
        /// <summary>
        /// 终端
        /// </summary>
        public WXTerminal Terminal { get; }
        /// <summary>
        /// 硬件信息
        /// </summary>
        public WXDevice Device { get; }
        /// <summary>
        /// 设备IMEI
        /// </summary>
        public string DeviceImei { get; }
        /// <summary>
        /// 设备MAC地址
        /// </summary>
        public string DeviceMac { get; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; }
        /// <summary>
        /// 设备品牌
        /// </summary>
        public string DeviceBrand { get; }
        /// <summary>
        /// 微信数据（62/A16）
        /// </summary>
        public string WeChatData { get; }
        /// <summary>
        /// 签名
        /// </summary>
        public string WeChatSignature { get; }
        /// <summary>
        /// 软件XML信息
        /// </summary>
        public string WeChatXmlInfo { get; }
        /// <summary>
        /// 设备Id数据
        /// </summary>
        public string WeChatDataId { get; }
        /// <summary>
        /// 系统类型
        /// </summary>
        public string WeChatOsType { get; }
        /// <summary>
        /// 浏览器UA
        /// </summary>
        public string WeChatUserAgent { get; }
        /// <summary>
        /// 应用包Id
        /// </summary>
        public string WeChatBundleId { get; }
        /// <summary>
        /// 微信UUID
        /// </summary>
        public string WeChatVendorId { get; }
        /// <summary>
        /// 广告UUID
        /// </summary>
        public string WeChatAdvertId { get; }
        #endregion

        #region 接口
        /// <summary>
        /// 创建环境信息
        /// </summary>
        /// <param name="terminal">终端类型</param>
        /// <param name="brand">设备品牌</param>
        /// <param name="wxdata">微信数据</param>
        /// <param name="info">xml信息</param>
        /// <param name="name">设备名称</param>
        /// <param name="imei">设备IMEI</param>
        /// <param name="mac">设备MAC地址</param>
        /// <param name="signature">设备签名</param>
        /// <param name="vendorid">微信UUID</param>
        /// <param name="advertid">广告UUID</param>
        public WXEnvironment(WXTerminal terminal, string brand = "", string wxdata = "", string info = "", string name = "", string imei = "", string mac = "", string signature = "", string vendorid = "", string advertid = "")
            : this(terminal, terminal, brand, wxdata, info, name, imei, mac, signature, vendorid, advertid)
        {
        }
        /// <summary>
        /// 创建环境信息
        /// </summary>
        /// <param name="terminal">终端类型</param>
        /// <param name="device">设备信息</param>
        /// <param name="brand">设备品牌</param>
        /// <param name="wxdata">微信数据</param>
        /// <param name="info">xml信息</param>
        /// <param name="name">设备名称</param>
        /// <param name="imei">设备IMEI</param>
        /// <param name="mac">设备MAC地址</param>
        /// <param name="signature">设备签名</param>
        /// <param name="vendorid">微信UUID</param>
        /// <param name="advertid">广告UUID</param>
        public WXEnvironment(WXTerminal terminal, WXDevice device, string brand = "", string wxdata = "", string info = "", string name = "", string imei = "", string mac = "", string signature = "", string vendorid = "", string advertid = "")
        {
            var rd = new Random();

            Terminal = terminal; Device = device; DeviceBrand = brand;
            DeviceImei = imei; DeviceMac = mac; DeviceName = name;
            WeChatData = wxdata; WeChatSignature = signature; WeChatXmlInfo = info;
            WeChatVendorId = vendorid; WeChatAdvertId = advertid;
            WeChatDataId = ""; WeChatOsType = ""; WeChatUserAgent = ""; WeChatBundleId = "";

            if (string.IsNullOrEmpty(WeChatVendorId)) { WeChatVendorId = Guid.NewGuid().ToString(); }
            if (string.IsNullOrEmpty(WeChatAdvertId)) { WeChatAdvertId = Guid.NewGuid().ToString(); }
            if (string.IsNullOrEmpty(WeChatData)) { WeChatData = CreateWxData(Terminal); }
            if (string.IsNullOrEmpty(DeviceImei)) { DeviceImei = ConvertWxDataToImei(Terminal, WeChatData); }
            if (string.IsNullOrEmpty(WeChatDataId)) { WeChatDataId = ConvertImeiToDeviceId(Terminal, DeviceImei); }
            if (string.IsNullOrEmpty(DeviceMac)) { DeviceMac = rd.CreateRandomMacAddress(); }
            if (string.IsNullOrEmpty(DeviceName)) { DeviceName = rd.CreateRandomString(6) + "的设备"; }
            if (string.IsNullOrEmpty(DeviceBrand)) { DeviceBrand = CreateBrand(Terminal, Device); }
            if (string.IsNullOrEmpty(WeChatSignature)) { WeChatSignature = CreateSignature(Terminal); }
            if (string.IsNullOrEmpty(WeChatXmlInfo)) { WeChatXmlInfo = CreateSoftXmlInfo(Terminal, Device, WeChatVendorId, DeviceImei, WeChatSignature, DeviceMac); }

            #region 可能影响效率 修改于2020-12-22
            //if (Terminal == WXTerminal.IMAC)
            //{
            //    WeChatOsType = $"iMac MacBookPro9,1 OSX OSX {Device.VersionRelease} build(15C50)";
            //    WeChatUserAgent = $"Mozilla/5.0 (iPhone; CPU iMac MacBookPro {Device.VersionRelease} like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 MicroMessenger/{Terminal.GetWeChatVersion()}(0x{Terminal.GetWeChatVersion().Code:X}) NetType/4G Language/zh_CN";
            //    WeChatBundleId = "com.tencent.xin";
            //}
            //if (Terminal == WXTerminal.IPHONE)
            //{
            //    WeChatOsType = $"iOS{Device.VersionRelease}";
            //    WeChatUserAgent = $"Mozilla/5.0 (iPhone; CPU iPhone OS {Device.VersionRelease} like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 MicroMessenger/{Terminal.GetWeChatVersion()}(0x{Terminal.GetWeChatVersion().Code:X}) NetType/4G Language/zh_CN";
            //    WeChatBundleId = "com.tencent.xin";
            //}
            //if (Terminal == WXTerminal.IPAD)
            //{
            //    WeChatOsType = $"iPad iOS{Device.VersionRelease}";
            //    WeChatUserAgent = $"Mozilla/5.0 (iPhone; CPU iPad iPhone OS {Device.VersionRelease} like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 MicroMessenger/{Terminal.GetWeChatVersion()}(0x{Terminal.GetWeChatVersion().Code:X}) NetType/4G Language/zh_CN";
            //    WeChatBundleId = "com.tencent.xin";
            //}
            //if (Terminal == WXTerminal.ANDROID)
            //{
            //    WeChatOsType = $"Android-18";
            //    WeChatUserAgent = $"Mozilla/5.0 (Linux; Android {Device.VersionRelease}; {Device.Model} Build/{Device.VersionIncremental}) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/66.0.3359.126 MQQBrowser/6.2 TBS/044904 Mobile Safari/537.36 MMWEBID/5448 MicroMessenger/{Terminal.GetWeChatVersion()}.{Terminal.GetWeChatVersion().Build}(0x{Terminal.GetWeChatVersion().Code:X}) Process/tools NetType/4G Language/zh_CN";
            //    WeChatBundleId = "com.tencent.mm";
            //}
            #endregion

            if (Terminal == WXTerminal.ANDROID)
            {
                WeChatOsType = $"Android-18";
                WeChatUserAgent = $"Mozilla/5.0 (Linux; Android {Device.VersionRelease}; {Device.Model} Build/{Device.VersionIncremental}) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/66.0.3359.126 MQQBrowser/6.2 TBS/044904 Mobile Safari/537.36 MMWEBID/5448 MicroMessenger/{Terminal.GetWeChatVersion()}.{Terminal.GetWeChatVersion().Build}(0x{Terminal.GetWeChatVersion().Code:X}) Process/tools NetType/4G Language/zh_CN";
                WeChatBundleId = "com.tencent.mm";
            }
            else if (Terminal == WXTerminal.IMAC)
            {
                WeChatOsType = "iMac MacBookPro16,1 OSX OSX 10.16 build(20D74)";
                //WeChatUserAgent = $"Mozilla/5.0 (iPhone; CPU iPad iPhone OS {Device.VersionRelease} like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 MicroMessenger/{Terminal.GetWeChatVersion()}(0x{Terminal.GetWeChatVersion().Code:X}) NetType/4G Language/zh_CN";
                WeChatUserAgent = $"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_16) AppleWebKit/605.1.15 (KHTML, like Gecko) MicroMessenger/6.8.0(0x16080000) MacWechat/3.0({Terminal.GetWeChatVersion()}) NetType/WIFI WindowsWechat";
                WeChatBundleId = "com.tencent.xinWeChat";
            }
            else if (Terminal == WXTerminal.IPHONE)
            {
                WeChatOsType = $"iPhone iOS{Device.VersionRelease}";
                WeChatUserAgent = $"Mozilla/5.0 (iPhone; CPU iPhone OS {Device.VersionRelease} like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 MicroMessenger/{Terminal.GetWeChatVersion()}(0x{Terminal.GetWeChatVersion().Code:X}) NetType/4G Language/zh_CN";
                WeChatBundleId = "com.tencent.xin";
            }
            else
            {
                WeChatOsType = $"iPad iOS{Device.VersionRelease}";
                WeChatUserAgent = $"Mozilla/5.0 (iPhone; CPU iPad iPhone OS {Device.VersionRelease} like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 MicroMessenger/{Terminal.GetWeChatVersion()}(0x{Terminal.GetWeChatVersion().Code:X}) NetType/4G Language/zh_CN";
                WeChatBundleId = "com.tencent.xin";
            }
        }
        #endregion

        #region 重载
        /// <summary>
        /// 转换微信环境
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator WXEnvironment(ValueTuple<WXTerminal, string> value) => new WXEnvironment(value.Item1, value.Item2);
        /// <summary>
        /// 转换微信环境
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator WXEnvironment(ValueTuple<WXTerminal, string, string> value) => new WXEnvironment(value.Item1, value.Item2, value.Item3);
        #endregion

        #region 辅助功能
        /// <summary>
        /// 创建软件xml数据
        /// </summary>
        /// <param name="terminal">终端</param>
        /// <param name="device">设备信息</param>
        /// <param name="vendorid">微信uuid</param>
        /// <param name="imei">imei</param>
        /// <param name="signature">签名</param>
        /// <param name="mac">mac地址</param>
        /// <returns></returns>
        public static string CreateSoftXmlInfo(WXTerminal terminal, WXDevice device, string vendorid, string imei, string signature, string mac)
        {
            var rd = new Random();
            StringBuilder builder = new StringBuilder();
            switch (terminal)
            {
                case WXTerminal.IMAC:
                case WXTerminal.IPAD:
                case WXTerminal.IPHONE:
                    builder.Append($"<k3>{device.VersionRelease}</k3>");
                    builder.Append($"<k9>{device.Model}</k9>").Append("<k10>2</k10>");
                    builder.Append($"<k19>{vendorid}</k19>");
                    builder.Append($"<k20>{imei}</k20>");
                    builder.Append($"<k21>{"TP_lINKS_6G"}</k21>").Append($"<k22>{"中国移动"}</k22>").Append($"<k24>{mac}</k24>");
                    builder.Append($"<k33>微信</k33>");
                    builder.Append($"<k47>1</k47>");
                    builder.Append($"<k50>1</k50>");
                    builder.Append($"<k51>com.tencent.xin</k51>");
                    builder.Append($"<k54>{device.Model},4</k54>");
                    builder.Append($"<k61>2</k61>");
                    break;
                case WXTerminal.ANDROID:
                    builder.Append($"<lctmoc>0</lctmoc>").Append($"<level>1</level>").Append($"<k26>0</k26>");
                    builder.Append($"<k1>{"AArch64 Processor rev 0 (aarch64)"}</k1>");
                    builder.Append($"<k2>{"-8976_GEN_PACK-1.82078.1.82572.1"}</k2>");
                    builder.Append($"<k3>{device.VersionRelease}</k3>");
                    builder.Append($"<k4>{imei}</k4>");
                    builder.Append($"<k5>{rd.CreateRandomString(15, "", true, false, false, false)}</k5>");
                    builder.Append($"<k6>{rd.CreateRandomString(20, "", true, false, false, false)}</k6>");
                    builder.Append($"<k7>{DateTime.Now.ToTimeStamp().ToString().MD5().ToLower().Substring(0, 16)}</k7>");
                    builder.Append($"<k8>{rd.CreateRandomString(8, "", true, false, false, false)}</k8>");
                    builder.Append($"<k9>{device.Model}</k9>").Append("<k10>8</k10>").Append($"<k14>{rd.CreateRandomMacAddress()}</k14>").Append($"<k15>{rd.CreateRandomMacAddress()}</k15>");
                    builder.Append($"<k16>{"fp asimd evtstrm aes pmull sha1 sha2 crc32"}</k16>");
                    builder.Append($"<k18>{signature}</k18>");
                    builder.Append($"<k21>{"TP_lINKS_6G"}</k21>").Append($"<k22>{"中国移动"}</k22>").Append($"<k24>{mac}</k24>");
                    builder.Append($"<k30>{"TP_lINKS_6G"}</k30>").Append($"<k33>com.tencent.mm</k33>");
                    builder.Append($"<k34>{device.Manufacturer + "/PD1619/PD1619:" + device.VersionRelease + "/MMB29M/compiler01161807:user/release-keys"}</k34>");
                    builder.Append($"<k35>{"msm8952"}</k35>").Append($"<k36>unknown</k36>");
                    builder.Append($"<k37>{device.Manufacturer}</k37>");
                    builder.Append($"<k38>{"PD1619"}</k38>");
                    builder.Append($"<k39>{"qcom"}</k39>");
                    builder.Append($"<k40>{"PD1619"}</k40>").Append($"<k41>0</k41>");
                    builder.Append($"<k42>{device.Manufacturer}</k42>").Append($"<k43>null</k43>").Append($"<k44>0</k44>").Append($"<k45>{imei.MD5().ToLower()}</k45>").Append($"<k46></k46>");
                    builder.Append($"<k47>{"4G"}</k47>");
                    builder.Append($"<k48>{imei}</k48>").Append($"<k49>{"/data/data/com.tencent.mm/"}</k49>");
                    builder.Append($"<k52>0</k52>").Append($"<k53>0</k53>").Append($"<k57>980</k57>").Append($"<k58></k58>").Append($"<k59>2</k59>");
                    break;
            }
            return $"<softtype>{builder.ToString().Replace("\r\n", "")}</softtype>";
        }

        /// <summary>
        /// 创建品牌
        /// </summary>
        /// <param name="terminal">终端类型</param>
        /// <param name="device">设备信息</param>
        /// <returns></returns>
        public static string CreateBrand(WXTerminal terminal, WXDevice device)
        {
            var result = "";
            switch (terminal)
            {
                case WXTerminal.ANDROID: result = device.Manufacturer; break;
                case WXTerminal.IMAC: result = "iMac"; break;
                case WXTerminal.IPAD: result = "iPad"; break;
                case WXTerminal.IPHONE: result = "iPhone"; break;
            }
            return result;
        }

        /// <summary>
        /// 创建微信数据
        /// </summary>
        /// <param name="terminal"></param>
        /// <returns></returns>
        public static string CreateWxData(WXTerminal terminal)
        {
            #region 可能影响效率 修改于2020-12-22
            //return terminal == WXTerminal.ANDROID
            //    ? $"{terminal.GetOS().GetWXDataPrefix()}{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 15)}"
            //    : $"{terminal.GetOS().GetWXDataPrefix()}{Guid.NewGuid().ToString().Replace("-", "").ToBytes().ToString(16, 2)}{terminal.GetOS().GetWXDataSuffix()}";
            #endregion

            return terminal == WXTerminal.ANDROID
               ? $"A{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 15)}"
               : $"62706c6973743030d4010203040506090a582476657273696f6e58246f626a65637473592461726368697665725424746f7012000186a0a2070855246e756c6c5f1020{Guid.NewGuid().ToString().Replace("-", "").ToBytes().ToString(16, 2)}5f100f4e534b657965644172636869766572d10b0c54726f6f74800108111a232d32373a406375787d0000000000000101000000000000000d0000000000000000000000000000007f";
        }

        /// <summary>
        /// 创建签名
        /// </summary>
        /// <param name="terminal"></param>
        /// <returns></returns>
        public static string CreateSignature(WXTerminal terminal)
        {
            return terminal == WXTerminal.ANDROID ? "18c867f0717aa67b2ab7347505ba07ed" : "";
        }

        /// <summary>
        /// 将微信数据转换为IMEI
        /// </summary>
        /// <param name="terminal">终端类型</param>
        /// <param name="wxdat">微信数据</param>
        /// <returns></returns>
        public static string ConvertWxDataToImei(WXTerminal terminal, string wxdata)
        {
            #region 可能影响效率 修改于2020-12-22
            //var result = "";
            //if (terminal != WXTerminal.ANDROID) { result = Encoding.UTF8.GetString(wxdata.Substring(terminal.GetOS().GetWXDataPrefix().Length, 64).ToByteArray(16, 2)); }
            //if (terminal == WXTerminal.ANDROID) { result = wxdata.Substring(1).ToBytes().ToString(16, 2); }
            //return result;
            #endregion

            #region 
            var result = "";
            if (terminal != WXTerminal.ANDROID)
            {
                result = Encoding.UTF8.GetString(wxdata.Substring(134, 64).ToByteArray(16, 2));
            }
            else
            {
                result = wxdata.Substring(1).ToBytes().ToString(16, 2);
            }
            return result;
            #endregion
        }

        /// <summary>
        /// 将微信数据转换为设备Id
        /// 可能会返回空 弃用于2020-12-22
        /// </summary>
        /// <param name="terminal">终端类型</param>
        /// <param name="wxdat">微信数据</param>
        /// <returns></returns>
        public static string ConvertWxDataToDeviceId(WXTerminal terminal, string wxdata)
        {
            var result = "";
            if (terminal != WXTerminal.ANDROID && wxdata.StartsWith(terminal.GetOS().GetWXDataPrefix(), StringComparison.OrdinalIgnoreCase))
            {
                result = Encoding.UTF8.GetString(wxdata.Substring(terminal.GetOS().GetWXDataPrefix().Length, 64).ToByteArray(16, 2));
                result = "49" + result.Substring(2, result.Length - 2);
            }
            if (terminal == WXTerminal.ANDROID && wxdata.StartsWith(terminal.GetOS().GetWXDataPrefix()) && wxdata.Length == 16)
            {
                result = (wxdata.Remove(wxdata.Length - 1) + "\0");
                result = result.ToBytes().ToString(16, 2);
            }
            return result;
        }

        /// <summary>
        /// 将微信数据转换为设备Id
        /// 启用于2020-12-22
        /// </summary>
        /// <param name="terminal">终端类型</param>
        /// <param name="wxdat">微信数据</param>
        /// <returns></returns>
        public static string ConvertImeiToDeviceId(WXTerminal terminal, string imei)
        {
            var result = "";
            if (terminal != WXTerminal.ANDROID)
            {
                result = "49" + imei.Substring(2, imei.Length - 2);
            }
            else
            {
                result = "41" + imei.Remove(28) + "00";
            }
            return result;
        }
        #endregion
    }
}
