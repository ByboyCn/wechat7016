using System;
using System.Text;
using WeChat.Core.Protocol;

namespace WeChat.Core
{
    /// <summary>
    /// 微信环境扩展
    /// </summary>
    public static partial class WXEnvironmentExtensions
    {
        /// <summary>
        /// 构建23明文
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        public static byte[] BuildClientCheckDataXml(this WXEnvironment environment)
        {
            return (environment.Terminal != WXTerminal.ANDROID)
                ? environment.BuildClientCheckDataXmlForIPad()
                : environment.BuildClientCheckDataXmlForAndroid();
        }

        /// <summary>
        /// 构建24明文
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        public static byte[] BuildClientCheckDataPB(this WXEnvironment environment)
        {
            return (environment.Terminal != WXTerminal.ANDROID)
                ? environment.BuildClientCheckDataPBForIPad()
                : environment.BuildClientCheckDataPBForAndroid();
        }

        /// <summary>
        /// 构建IPad 23 XML 明文
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="uuid">设备uuid</param>
        /// <returns></returns>
        private static byte[] BuildClientCheckDataXmlForIPad(this WXEnvironment environment)
        {
            var ccd_xml = new StringBuilder();
            var instdir = Guid.NewGuid().ToString();
            ccd_xml.Append($"<clientCheckData>");
            ccd_xml.Append($"<fileSafeAPI>yes</fileSafeAPI>");
            ccd_xml.Append($"<dylibSafeAPI>yes</dylibSafeAPI>");
            ccd_xml.Append($"<OSVersion>{environment.Device.VersionRelease}</OSVersion>");
            ccd_xml.Append($"<model>{environment.Device.Model}</model>");
            ccd_xml.Append($"<coreCount>2</coreCount>");
            ccd_xml.Append($"<vendorID>{environment.WeChatVendorId}</vendorID>");
            ccd_xml.Append($"<adID>{environment.WeChatAdvertId}</adID>");
            ccd_xml.Append($"<ssid>{Guid.NewGuid().ToString()}</ssid>");
            ccd_xml.Append($"<bssid>{Guid.NewGuid().ToString()}</bssid>");
            ccd_xml.Append($"<carrierName>KDDI</carrierName>");
            ccd_xml.Append($"<netType>1</netType>");
            ccd_xml.Append($"<isJailbreak>2</isJailbreak>");
            ccd_xml.Append($"<bundleID>com.tencent.xin</bundleID>");
            ccd_xml.Append($"<device>iPhone12,2</device>");
            ccd_xml.Append($"<displayName>WeChat</displayName>");
            ccd_xml.Append($"<version>{environment.Terminal.GetWeChatVersion().Code}</version>");
            ccd_xml.Append($"<plistVersion>{environment.Terminal.GetWeChatVersion().Code}</plistVersion>");
            ccd_xml.Append($"<USBState>2</USBState>");
            ccd_xml.Append($"<dibs>B4520BDF-115A-4CDB-96E9-CDE87D30B231</dibs>");
            ccd_xml.Append($"<HasSIMCard>2</HasSIMCard>");
            ccd_xml.Append($"<languageNum>zh</languageNum>");
            ccd_xml.Append($"<localeCountry>CN</localeCountry>");
            ccd_xml.Append($"<isInCalling>2</isInCalling>");
            ccd_xml.Append($"<weChatUUID>/var/mobile/Containers/Data/Application/{Guid.NewGuid().ToString()}/Documents</weChatUUID>");
            ccd_xml.Append($"<AppState>0</AppState>");
            ccd_xml.Append($"<illegalFileList><s>/bin/bash</s><s>/etc/apt</s></illegalFileList>");
            ccd_xml.Append($"<readOutOfSandBoxFileList>");
            ccd_xml.Append($"<s>/tmp/test.txt</s>");
            ccd_xml.Append($"</readOutOfSandBoxFileList>");
            ccd_xml.Append($"<encryptStatusOfMachO>1</encryptStatusOfMachO>");
            ccd_xml.Append($"<md5OfMachOHeader>19e2e84d0cbb0ffeedcfbbc669524182</md5OfMachOHeader>");
            ccd_xml.Append($"<weChatUUID>AD583C25-0DA6-357D-AEC7-94D7057A4C1C</weChatUUID>");
            ccd_xml.Append($"<dylibInfo>");
            ccd_xml.Append($"<i><s>/var/containers/Bundle/Application/{instdir}/WeChat.app/WeChat</s><u>AD583C25-0DA6-357D-AEC7-94D7057A4C1C</u></i>");
            ccd_xml.Append($"<i><s>/Library/MobileSubstrate/MobileSubstrate.dylib</s><u>3134CFB2-F722-310E-A2C7-42AE4DC131AB</u></i>");
            ccd_xml.Append($"<i><s>/private/var/containers/Bundle/Application/{instdir}/WeChat.app/Frameworks/ProtobufLite.framework/ProtobufLite</s><u>84A03C23-7111-3162-BCFC-C18F9CA14D97</u></i>");
            ccd_xml.Append($"<i><s>/private/var/containers/Bundle/Application/{instdir}/WeChat.app/Frameworks/marsbridgenetwork.framework/marsbridgenetwork</s><u>4504FCD4-0661-3F77-8F64-A3A3029C1A40</u></i>");
            ccd_xml.Append($"<i><s>/private/var/containers/Bundle/Application/{instdir}/WeChat.app/Frameworks/matrixreport.framework/matrixreport</s><u>1E7F06D2-DD36-31A8-AF3B-00D62054E1F9</u></i>");
            ccd_xml.Append($"<i><s>/private/var/containers/Bundle/Application/{instdir}/WeChat.app/Frameworks/MultiMedia.framework/MultiMedia</s><u>E237E8F4-6091-31D4-9D86-F7DBBBCE9B8A</u></i>");
            ccd_xml.Append($"<i><s>/private/var/containers/Bundle/Application/{instdir}/WeChat.app/Frameworks/mars.framework/mars</s><u>C844C187-9DB5-3D6B-A0F9-5389F1612D19</u></i>");
            ccd_xml.Append($"<i><s>/private/var/containers/Bundle/Application/{instdir}/WeChat.app/Frameworks/QMapKit.framework/QMapKit</s><u>D2BE7DA1-2309-3D77-BD8D-B9F0E92616C7</u></i>");
            ccd_xml.Append($"<i><s>/Library/Frameworks/CydiaSubstrate.framework/Libraries/SubstrateLoader.dylib</s><u>54645DC0-3212-31D8-8A02-2FD67A793278</u></i>");
            ccd_xml.Append($"</dylibInfo>");
            ccd_xml.Append($"</clientCheckData>");
            ccd_xml.Append($"<ccdcc>{ccd_xml.ToString().ToBytes().Crc32()}</ccdcc>");
            ccd_xml.Append($"<ccdts>{DateTime.Now.ToTimeStamp()}</ccdts>");
            return ccd_xml.ToString().ToBytes().ZIPCompress();
        }

        /// <summary>
        /// 构建IPad 24 PB 明文
        /// </summary>
        /// <returns></returns>
        private static byte[] BuildClientCheckDataPBForIPad(this WXEnvironment environment)
        {
            var timestamp = DateTime.UtcNow.ToTimeStamp();
            var xorkey = (byte)((timestamp * 0xffffffed) + 7);
            var spamDataBody = new SpamIOSBody
            {
                UnKnown1 = 1,
                TimeStamp = timestamp,
                KeyHash = WCAES.makeKeyHash(xorkey),
                Yes1 = "yes".Xor(xorkey),
                Yes2 = "yes".Xor(xorkey),
                IosVersion = environment.Device.VersionRelease.Xor(xorkey),
                DeviceType = "iPad".Xor(xorkey),
                UnKnown2 = 2,
                IdentifierForVendor = environment.WeChatVendorId.Xor(xorkey),
                AdvertisingIdentifier = environment.WeChatAdvertId.Xor(xorkey),
                Carrier = "中国移动".Xor(xorkey),
                BatteryInfo = 1,
                NetworkName = "en0".Xor(xorkey),
                NetType = 1,
                AppBundleId = environment.WeChatBundleId.Xor(xorkey),
                DeviceName = "iPad Pro".Xor(xorkey),
                UserName = environment.DeviceName.Xor(xorkey),
                Unknown3 = 77968568554357776,
                Unknown4 = 77968568554357760,
                Unknown5 = 5,
                Unknown6 = 4,
                Lang = "zh".Xor(xorkey),
                Country = "CN".Xor(xorkey),
                Unknown7 = 4,
                DocumentDir = "/var/mobile/Containers/Data/Application/857C3940-0044-43E9-AD59-6C3240DACD91/Documents".Xor(xorkey),
                Unknown8 = 0,
                Unknown9 = 0,
                HeadMD5 = "d55ce16228afb0ea5205380af376761e".Xor(xorkey),
                AppUUID = environment.WeChatVendorId.Xor(xorkey),
                SyslogUUID = environment.WeChatAdvertId.Xor(xorkey),
                AppName = "微信".Xor(xorkey),
                SshPath = "/usr/bin/ssh".Xor(xorkey),
                TempTest = "/tmp/test.txt".Xor(xorkey),
                Unknown12 = "yyyy/MM/dd HH:mm".Xor(xorkey),
                IsModify = 0,
                ModifyMD5 = "83d6ad7f1c5045ab8112a8411c8091f2".Xor(xorkey),
                RqtHash = 288512216272273664,
                Unknown13 = 0,
                Unknown14 = 0,
                Ssid = "F3:48:B2:4B:34:EB".Xor(xorkey),
                Unknown15 = 0,
                Bssid = "F3:48:B2:4B:34:EC".Xor(xorkey),
                IsJail = 0,
                Seid = "D2:1B:61:E1:DE:C6".Xor(xorkey),
                Unknown16 = 60,
                Unknown17 = 61,
                Unknown18 = 62,
                WifiOn = 1,
                WifiName = "Xiaomi_L52C".Xor(xorkey),
                WifiMac = environment.DeviceMac.Xor(xorkey),
                BluethOn = 0,
                BluethName = "iPad Pro".Xor(xorkey),
                BluethMac = "F3:48:B2:4B:7B:65".Xor(xorkey),
                Unknown19 = 67,
                Unknown20 = 68,
                Unknown26 = 69,
                HasSim = 0,
                UsbState = 0,
                Unknown27 = 1300,
                Unknown28 = 73,
                Sign = environment.WeChatSignature.Xor(xorkey),
                PackageFlag = 0x01,
                AccessFlag = 0x03,
                Imei = environment.DeviceImei.Xor(xorkey),
                DevMD5 = "0582444e4a124e1cfb350384140fb5f4".Xor(xorkey),
                DevUser = environment.DeviceBrand.Xor(xorkey),
                DevPrefix = "Apple".Xor(xorkey),
                DevSerial = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16).Xor(xorkey),
                Unknown29 = 0x1d,
                Unknown30 = 0x1e,
                Unknown31 = 0x1f,
                Unknown32 = 0x20,
                AppNum = 0x10,
                Totcapacity = "0x200".Xor(xorkey),
                Avacapacity = "0x6685f".Xor(xorkey),
                Unknown33 = 0x21,
                Unknown34 = 0x28,
                Unknown35 = 0x69,
                Unknown103 = 0,
                Unknown104 = 0,
                Unknown105 = 0,
                Unknown106 = WCAES.CheckSoftType5(),
                Unknown107 = 107,
                Unknown108 = 0,
                Unknown109 = 109,
                Unknown110 = 0,
                Unknown111 = 13,
                Unknown112 = 0xf5,
                AppFileInfo = new FileInfo[]
                {
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/20278CED-292E-4C4F-930C-0D1E86B02AD1/WeChat.app/WeChat".Xor(xorkey),
                        Fileuuid = "B069D479-E08E-3557-B7C7-411AF31B4919".Xor(xorkey)
                    },
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/20278CED-292E-4C4F-930C-0D1E86B02AD1/WeChat.app/Frameworks/OpenSSL.framework/OpenSSL".Xor(xorkey),
                        Fileuuid = "7CED8A7F-509A-3820-9EBC-8EB3AE5B99D9".Xor(xorkey)
                    },
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/20278CED-292E-4C4F-930C-0D1E86B02AD1/WeChat.app/Frameworks/ProtobufLite.framework/ProtobufLite".Xor(xorkey),
                        Fileuuid = "69971FE3-4728-3F01-9137-4FD3FFC26AB4".Xor(xorkey)
                    },
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/20278CED-292E-4C4F-930C-0D1E86B02AD1/WeChat.app/Frameworks/marsbridgenetwork.framework/marsbridgenetwork".Xor(xorkey),
                        Fileuuid = "CFED9A03-C881-3D50-B014-732D0A09879F".Xor(xorkey)
                    },
                     new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/3C5AC4DE-D87D-4669-B996-D839E9100456/WeChat.app/Frameworks/zstd.framework/zstd".Xor(xorkey),
                        Fileuuid = "F326111B-2EBA-34E8-8830-657315905F43".Xor(xorkey)
                    },
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/3C5AC4DE-D87D-4669-B996-D839E9100456/WeChat.app/Frameworks/TXLiteAVSDK_Smart_No_VOD.framework/TXLiteAVSDK_Smart_No_VOD".Xor(xorkey),
                        Fileuuid = "606505A0-69D9-3EBC-A4DB-758D54BE46AA".Xor(xorkey)
                    },
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/20278CED-292E-4C4F-930C-0D1E86B02AD1/WeChat.app/Frameworks/matrixreport.framework/matrixreport".Xor(xorkey),
                        Fileuuid = "1E7F06D2-DD36-31A8-AF3B-00D62054E1F9".Xor(xorkey)
                    },
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/20278CED-292E-4C4F-930C-0D1E86B02AD1/WeChat.app/Frameworks/andromeda.framework/andromeda".Xor(xorkey),
                        Fileuuid = "0AE6A3E2-31A4-352E-9CAC-A1011043951A".Xor(xorkey)
                    },
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/3C5AC4DE-D87D-4669-B996-D839E9100456/WeChat.app/Frameworks/YTFaceProSDK.framework/YTFaceProSDK".Xor(xorkey),
                        Fileuuid = "4F58B750-3134-36A2-9524-147872E9A607".Xor(xorkey)
                    },
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/3C5AC4DE-D87D-4669-B996-D839E9100456/WeChat.app/Frameworks/GPUImage.framework/GPUImage".Xor(xorkey),
                        Fileuuid = "847B0606-87CA-3896-AE16-90DF0370DC94".Xor(xorkey)
                    },
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/3C5AC4DE-D87D-4669-B996-D839E9100456/WeChat.app/Frameworks/WCDB.framework/WCDB".Xor(xorkey),
                        Fileuuid = "09941A29-AF95-3C1F-A6EC-A571EC4529FC".Xor(xorkey)
                    },
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/3C5AC4DE-D87D-4669-B996-D839E9100456/WeChat.app/Frameworks/MMCommon.framework/MMCommon".Xor(xorkey),
                        Fileuuid = "917922FE-F15C-3A0C-9F9B-29DAE8BC08AF".Xor(xorkey)
                    },
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/3C5AC4DE-D87D-4669-B996-D839E9100456/WeChat.app/Frameworks/MultiMedia.framework/MultiMedia".Xor(xorkey),
                        Fileuuid = "7FBD2D5F-806D-38DE-A54F-AE471B3F342F".Xor(xorkey)
                    },
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/3C5AC4DE-D87D-4669-B996-D839E9100456/WeChat.app/Frameworks/QBar.framework/QBar".Xor(xorkey),
                        Fileuuid = "95DE8BA9-6A55-3642-8B1F-363BB507E2CD".Xor(xorkey)
                    },
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/3C5AC4DE-D87D-4669-B996-D839E9100456/WeChat.app/Frameworks/QMapKit.framework/QMapKit".Xor(xorkey),
                        Fileuuid = "231A339F-6CBC-39BC-A88B-96FF1282390F".Xor(xorkey)
                    },
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/3C5AC4DE-D87D-4669-B996-D839E9100456/WeChat.app/Frameworks/ConfSDK.framework/ConfSDK".Xor(xorkey),
                        Fileuuid = "BF039435-9428-3118-B245-219EADDB825A".Xor(xorkey)
                    },
                    new FileInfo
                    {
                        Filepath = "/var/containers/Bundle/Application/20278CED-292E-4C4F-930C-0D1E86B02AD1/WeChat.app/Frameworks/mars.framework/mars".Xor(xorkey),
                        Fileuuid = "B14DA1FF-1E28-32C4-B198-672A610690A7".Xor(xorkey)
                    }
                },
            }.SerializeToProtoBuf();
            var result = new ClientCheckData
            {
                C32Cdata = spamDataBody.Crc32(),
                TimeStamp = timestamp,
                Databody = spamDataBody
            }.SerializeToProtoBuf();
            return result.ZIPCompress();
        }

        /// <summary>
        /// 构建Android 23 XML 明文
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        private static byte[] BuildClientCheckDataXmlForAndroid(this WXEnvironment environment)
        {
            var ccd_xml = new StringBuilder();
            var RiskScanReqBuffer = "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";
            var InstallPackage = "com.android.providers.telephony#&#30005;&#35805;&#21644;&#30701;&#20449;&#23384;&#20648;&#44;org.cyanogenmod.snap#&#30456;&#26426;&#44;com.android.providers.calendar#&#26085;&#21382;&#23384;&#20648;&#44;com.android.providers.media#&#23186;&#20307;&#23384;&#20648;&#44;com.android.wallpapercropper#com.android.wallpapercropper&#44;com.quicinc.cne.CNEService#com.quicinc.cne.CNEService&#44;org.cyanogenmod.wallpapers.photophase#PhotoPhase&#44;com.android.documentsui#&#25991;&#26723;&#44;com.android.galaxy4#&#40657;&#27934;&#44;com.android.externalstorage#&#22806;&#37096;&#23384;&#20648;&#35774;&#22791;&#44;com.android.htmlviewer#HTML &#26597;&#30475;&#31243;&#24207;&#44;org.cyanogenmod.theme.chooser2#&#20027;&#39064;&#36873;&#25321;&#22120;&#44;com.android.mms.service#&#20449;&#24687;&#26381;&#21153;&#44;com.android.providers.downloads#&#19979;&#36733;&#31649;&#29702;&#31243;&#24207;&#44;com.android.messaging#&#30701;&#20449;&#44;com.android.terminal#&#32456;&#31471;&#44;org.cyanogenmod.audiofx#AudioFX&#44;com.android.browser#&#27983;&#35272;&#22120;&#44;org.cyanogenmod.providers.datausage#&#25968;&#25454;&#29992;&#37327;&#25552;&#20379;&#22120;&#44;com.android.soundrecorder#&#24405;&#38899;&#26426;&#44;com.android.defcontainer#&#36719;&#20214;&#21253;&#26435;&#38480;&#24110;&#21161;&#31243;&#24207;&#44;com.cyanogenmod.setupwizard#&#35774;&#32622;&#21521;&#23548;&#44;com.android.providers.downloads.ui#&#19979;&#36733;&#44;com.android.pacprocessor#PacProcessor&#44;org.cyanogenmod.themeservice#&#20027;&#39064;&#31649;&#29702;&#26381;&#21153;&#44;com.tencent.mm#&#24494;&#20449;&#44;com.android.certinstaller#&#35777;&#20070;&#23433;&#35013;&#31243;&#24207;&#44;com.android.carrierconfig#com.android.carrierconfig&#44;android#Android &#31995;&#32479;&#44;com.android.contacts#&#36890;&#35759;&#24405;&#44;cyanogenmod.platform#LineageOS &#31995;&#32479;&#44;com.android.hotwordenrollment#Ok Google enrollment&#44;com.android.nfc#NFC&#26381;&#21153;&#44;com.android.stk#SIM&#21345;&#24037;&#20855;&#21253;&#44;com.android.backupconfirm#com.android.backupconfirm&#44;org.cyanogenmod.profiles#&#24773;&#26223;&#27169;&#24335;&#20449;&#20219;&#25552;&#20379;&#22120;&#44;com.cyanogenmod.lockclock#cLock&#44;com.android.provision#com.android.provision&#44;org.codeaurora.ims#org.codeaurora.ims&#44;com.android.statementservice#Intent Filter Verification Service&#44;org.cyanogenmod.cmaudio.service#CM &#38899;&#39057;&#26381;&#21153;&#44;com.android.wallpaper.holospiral#&#20809;&#29615;&#34746;&#26059;&#44;com.android.calendar#&#26085;&#21382;&#44;com.android.phasebeam#&#38253;&#20809;&#44;com.qualcomm.qcrilmsgtunnel#com.qualcomm.qcrilmsgtunnel&#44;com.android.providers.settings#&#35774;&#32622;&#23384;&#20648;&#44;com.android.sharedstoragebackup#com.android.sharedstoragebackup&#44;com.android.printspooler#&#25171;&#21360;&#22788;&#29702;&#26381;&#21153;&#44;org.cyanogenmod.livelockscreen.service#&#21160;&#24577;&#38145;&#23631;&#26381;&#21153;&#44;com.android.dreams.basic#&#22522;&#26412;&#20114;&#21160;&#23631;&#20445;&#44;com.android.frameworks.telresources#com.android.frameworks.telresources&#44;com.android.webview#Android System WebView&#44;com.android.inputdevices#&#36755;&#20837;&#35774;&#22791;&#44;android.base.installer#Desopx&#44;com.android.cellbroadcastreceiver#&#23567;&#21306;&#24191;&#25773;&#44;com.android.onetimeinitializer#One Time Init&#44;com.android.server.telecom#&#36890;&#35805;&#31649;&#29702;&#44;org.cyanogenmod.screencast#&#23631;&#24149;&#24405;&#20687;&#44;org.cyanogenmod.themes.provider#&#20027;&#39064;&#25552;&#20379;&#22120;&#44;com.android.keychain#&#23494;&#38053;&#38142;&#44;com.cyanogenmod.wallpapers#CM &#22721;&#32440;&#44;com.android.dialer#&#30005;&#35805;&#44;com.android.gallery3d#&#22270;&#24211;&#44;com.cyanogenmod.trebuchet#Trebuchet&#44;org.cyanogenmod.cmsettings#CM &#35774;&#32622;&#23384;&#20648;&#44;com.android.calllogbackup#Call Log Backup/Restore&#44;com.android.packageinstaller#&#36719;&#20214;&#21253;&#23433;&#35013;&#31243;&#24207;&#44;com.svox.pico#Pico TTS&#44;com.android.proxyhandler#ProxyHandler&#44;com.cyanogenmod.filemanager#&#25991;&#20214;&#31649;&#29702;&#22120;&#44;com.android.inputmethod.latin#Android &#38190;&#30424; (AOSP)&#44;com.android.managedprovisioning#com.android.managedprovisioning&#44;com.android.dreams.phototable#&#29031;&#29255;&#23631;&#24149;&#20445;&#25252;&#31243;&#24207;&#44;com.android.noisefield#&#27873;&#27873;&#44;com.android.smspush#com.android.smspush&#44;com.android.wallpaper.livepicker#Live Wallpaper Picker&#44;com.android.apps.tag#Tags&#44;com.msg#Base&#44;org.cyanogenmod.hexolibre#HexoLibre&#44;com.android.settings#&#35774;&#32622;&#44;com.cyanogenmod.eleven#&#38899;&#20048;&#44;com.android.calculator2#&#35745;&#31639;&#22120;&#44;org.lineageos.updater#&#26356;&#26032;&#22120;&#44;com.android.wallpaper#Android&#21160;&#24577;&#22721;&#32440;&#44;com.android.vpndialogs#VpnDialogs&#44;com.android.email#&#30005;&#23376;&#37038;&#20214;&#44;com.android.phone#&#30005;&#35805;&#26381;&#21153;&#44;com.android.shell#Shell&#44;com.android.providers.userdictionary#&#29992;&#25143;&#23383;&#20856;&#44;com.android.location.fused#&#19968;&#20307;&#21270;&#20301;&#32622;&#20449;&#24687;&#44;com.android.deskclock#&#26102;&#38047;&#44;com.android.systemui#&#31995;&#32479;&#30028;&#38754;&#44;com.android.exchange#Exchange&#26381;&#21153;&#44;com.android.bluetoothmidiservice#Bluetooth MIDI Service&#44;org.cyanogenmod.wallpaperpicker#Wallpaper Picker&#44;com.android.bluetooth#&#34013;&#29273;&#20849;&#20139;&#44;com.qualcomm.timeservice#com.qualcomm.timeservice&#44;com.android.development#Dev Tools&#44;com.android.providers.contacts#&#32852;&#31995;&#20154;&#23384;&#20648;&#44;org.cyanogenmod.weatherservice#&#22825;&#27668;&#26381;&#21153;&#44;com.android.captiveportallogin#CaptivePortalLogin&#44;org.cyanogenmod.weather.provider#&#22825;&#27668;&#25552;&#20379;&#22120;";
            ccd_xml.Append($"<st>");
            ccd_xml.Append($"<IsMorkLocOpen>0</IsMorkLocOpen>");
            ccd_xml.Append($"<MsgLevel>0</MsgLevel>");
            ccd_xml.Append($"<IsDbgConnected>0</IsDbgConnected>");
            ccd_xml.Append($"<PkgHash1>fe635c04e9e88a273664f05b15d89106</PkgHash1>");
            ccd_xml.Append($"<PkgHash2>f1389a62a075e4786da0ee7b02c5b001775c0cec</PkgHash2>");
            ccd_xml.Append($"<PkgHash3>18c867f0717aa67b2ab7347505ba07ed</PkgHash3>");
            ccd_xml.Append($"<CpuString>AArch64 Processor rev 1 (aarch64) </CpuString>");
            ccd_xml.Append($"<RatioFwVer>angler-03.61</RatioFwVer>");
            ccd_xml.Append($"<OsRelVer>{environment.Device.VersionRelease}</OsRelVer>");
            ccd_xml.Append($"<IMEI>{environment.DeviceImei}</IMEI>");
            ccd_xml.Append($"<AndroidID>{environment.WeChatDataId}</AndroidID>");
            ccd_xml.Append($"<PhoneSerial>{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16)}</PhoneSerial>");
            ccd_xml.Append($"<PhoneModel>{environment.Device.Model}</PhoneModel>");
            ccd_xml.Append($"<CpuCoreCount>8</CpuCoreCount>");
            ccd_xml.Append($"<CpuHW>Qualcomm Technologies&#44; Inc MSM8994</CpuHW>");
            ccd_xml.Append($"<CpuRev>null</CpuRev>");
            ccd_xml.Append($"<CpuSerial>null</CpuSerial>");
            ccd_xml.Append($"<SelfMAC>{environment.DeviceMac}</SelfMAC>");
            ccd_xml.Append($"<CpuFeatures>fp asimd evtstrm aes pmull sha1 sha2 crc32 wp half thumb fastmult vfp edsp neon vfpv3 tlsi vfpv4 idiva idivt</CpuFeatures>");
            ccd_xml.Append($"<SSID>0x</SSID>");
            ccd_xml.Append($"<SpInfo>CMCC</SpInfo>");
            ccd_xml.Append($"<BSSID>00:00:00:00:00:00</BSSID>");
            ccd_xml.Append($"<APNInfo>cmnet</APNInfo>");
            ccd_xml.Append($"<PkgName>com.tencent.mm</PkgName>");
            ccd_xml.Append($"<BuildFP>google/angler/angler:6.0.1/MTC20L/3230295:user/release-keys</BuildFP>");
            ccd_xml.Append($"<BuildBoard>angler</BuildBoard>");
            ccd_xml.Append($"<BuildBootloader>angler-03.51</BuildBootloader>");
            ccd_xml.Append($"<BuildBrand>google</BuildBrand>");
            ccd_xml.Append($"<BuildDevice>angler</BuildDevice>");
            ccd_xml.Append($"<BuildHW>angler</BuildHW>");
            ccd_xml.Append($"<BuildProduct>angler</BuildProduct>");
            ccd_xml.Append($"<IsQemuEnv>1</IsQemuEnv>");
            ccd_xml.Append($"<Manufacturer>{environment.Device.Manufacturer}</Manufacturer>");
            ccd_xml.Append($"<PhoneNum>{Guid.NewGuid().ToString().MD5()}</PhoneNum>");
            ccd_xml.Append($"<NetType>13</NetType>");
            ccd_xml.Append($"<DataRoot>/data/user/0/com.tencent.mm/</DataRoot>");
            ccd_xml.Append($"<HasDupPkg>0</HasDupPkg>");
            ccd_xml.Append($"<HasQikuShadow>0</HasQikuShadow>");
            ccd_xml.Append($"<VersionCode>1300</VersionCode>");
            ccd_xml.Append($"<EntranceClassLoaderName>dalvik.system.PathClassLoader</EntranceClassLoaderName>");
            ccd_xml.Append($"<AppName>&#24494;&#20449;</AppName>");
            ccd_xml.Append($"<MMProcLoadedFiles>/data/app/com.tencent.mm-1/lib/arm/libFFmpeg.so&#44;/data/app/com.tencent.mm-1/lib/arm/libMMProtocalJni.so&#44;/data/app/com.tencent.mm-1/lib/arm/libSqliteLint-lib.so&#44;/data/app/com.tencent.mm-1/lib/arm/libappbrandcommon.so&#44;/data/app/com.tencent.mm-1/lib/arm/libhardcoder.so&#44;/data/app/com.tencent.mm-1/lib/arm/libmatrixmrs.so&#44;/data/app/com.tencent.mm-1/lib/arm/libmmvulkan.so&#44;/data/app/com.tencent.mm-1/lib/arm/libstlport_shared.so&#44;/data/app/com.tencent.mm-1/lib/arm/libtencentloc.so&#44;/data/app/com.tencent.mm-1/lib/arm/libtenpay_utils.so&#44;/data/app/com.tencent.mm-1/lib/arm/libtxmapengine.so&#44;/data/app/com.tencent.mm-1/lib/arm/libvoipMain.so&#44;/data/app/com.tencent.mm-1/lib/arm/libwcdb.so&#44;/data/app/com.tencent.mm-1/lib/arm/libwechatCrashForJni.so&#44;/data/app/com.tencent.mm-1/lib/arm/libwechatcommon.so&#44;/data/app/com.tencent.mm-1/lib/arm/libwechatmm.so&#44;/data/app/com.tencent.mm-1/lib/arm/libwechatnormsg.so&#44;/data/app/com.tencent.mm-1/lib/arm/libwechatpack.so&#44;/data/app/com.tencent.mm-1/lib/arm/libwechatsight_v7a.so&#44;/data/app/com.tencent.mm-1/lib/arm/libwechatvoicereco.so&#44;/data/app/com.tencent.mm-1/lib/arm/libwechatvoicesilk_v7a.so&#44;/data/app/com.tencent.mm-1/lib/arm/libwechatxlog.so&#44;/data/app/com.tencent.mm-1/oat/arm/base.odex&#44;/data/dalvik-cache/arm/data@app@com.msg-1@base.apk@classes.dex&#44;/data/dalvik-cache/arm/system@framework@AudioHal.jar@classes.dex&#44;/data/dalvik-cache/arm/system@framework@boot.oat&#44;/system/bin/app_process32_desopx&#44;/system/bin/linker&#44;/system/lib/hw/gralloc.msm8994.so&#44;/system/lib/hw/memtrack.msm8994.so&#44;/system/lib/libEGL.so&#44;/system/lib/libETC1.so&#44;/system/lib/libGLES_trace.so&#44;/system/lib/libGLESv1_CM.so&#44;/system/lib/libGLESv2.so&#44;/system/lib/libLLVM.so&#44;/system/lib/libRS.so&#44;/system/lib/libRSCpuRef.so&#44;/system/lib/libRSDriver.so&#44;/system/lib/libRScpp.so&#44;/system/lib/libandroid.so&#44;/system/lib/libandroid_runtime.so&#44;/system/lib/libandroidfw.so&#44;/system/lib/libart.so&#44;/system/lib/libaudiohal_jni.so&#44;/system/lib/libaudioutils.so&#44;/system/lib/libavcodec.so&#44;/system/lib/libavformat.so&#44;/system/lib/libavutil.so&#44;/system/lib/libbacktrace.so&#44;/system/lib/libbase.so&#44;/system/lib/libbcc.so&#44;/system/lib/libbcinfo.so&#44;/system/lib/libbinder.so&#44;/system/lib/libblas.so&#44;/system/lib/libc++.so&#44;/system/lib/libc.so&#44;/system/lib/libcamera_client.so&#44;/system/lib/libcamera_metadata.so&#44;/system/lib/libcommon_time_client.so&#44;/system/lib/libcompiler_rt.so&#44;/system/lib/libcrypto.so&#44;/system/lib/libcutils.so&#44;/system/lib/libdrmframework.so&#44;/system/lib/libeffects.so&#44;/system/lib/libemoji.so&#44;/system/lib/libexif.so&#44;/system/lib/libexpat.so&#44;/system/lib/libffmpeg_extractor.so&#44;/system/lib/libffmpeg_utils.so&#44;/system/lib/libft2.so&#44;/system/lib/libgui.so&#44;/system/lib/libhardware.so&#44;/system/lib/libhardware_legacy.so&#44;/system/lib/libharfbuzz_ng.so&#44;/system/lib/libhwui.so&#44;/system/lib/libicui18n.so&#44;/system/lib/libicuuc.so&#44;/system/lib/libimg_utils.so&#44;/system/lib/libinput.so&#44;/system/lib/libinputflinger.so&#44;/system/lib/libjavacore.so&#44;/system/lib/libjavacrypto.so&#44;/system/lib/libjnigraphics.so&#44;/system/lib/libjpeg.so&#44;/system/lib/libkeymaster1.so&#44;/system/lib/libkeymaster_messages.so&#44;/system/lib/libkeystore-engine.so&#44;/system/lib/libkeystore_binder.so&#44;/system/lib/liblog.so&#44;/system/lib/libm.so&#44;/system/lib/libmedia.so&#44;/system/lib/libmedia_jni.so&#44;/system/lib/libmediautils.so&#44;/system/lib/libmemalloc.so&#44;/system/lib/libmemtrack.so&#44;/system/lib/libminikin.so&#44;/system/lib/libmtp.so&#44;/system/lib/libnativebridge.so&#44;/system/lib/libnativehelper.so&#44;/system/lib/libnbaio.so&#44;/system/lib/libnetd_client.so&#44;/system/lib/libnetutils.so&#44;/system/lib/libopus.so&#44;/system/lib/libpcre.so&#44;/system/lib/libpdfium.so&#44;/system/lib/libpng.so&#44;/system/lib/libpowermanager.so&#44;/system/lib/libprocessgroup.so&#44;/system/lib/libprotobuf-cpp-lite.so&#44;/system/lib/libqdMetaData.so&#44;/system/lib/libqdutils.so&#44;/system/lib/libqservice.so&#44;/system/lib/libradio.so&#44;/system/lib/libradio_metadata.so&#44;/system/lib/libselinux.so&#44;/system/lib/libsigchain.so&#44;/system/lib/libskia.so&#44;/system/lib/libsoftkeymasterdevice.so&#44;/system/lib/libsonivox.so&#44;/system/lib/libsoundtrigger.so&#44;/system/lib/libspeexresampler.so&#44;/system/lib/libsqlite.so&#44;/system/lib/libssl.so&#44;/system/lib/libstagefright.so&#44;/system/lib/libstagefright_amrnb_common.so&#44;/system/lib/libstagefright_avc_common.so&#44;/system/lib/libstagefright_enc_common.so&#44;/system/lib/libstagefright_foundation.so&#44;/system/lib/libstagefright_http_support.so&#44;/system/lib/libstagefright_omx.so&#44;/system/lib/libstagefright_yuv.so&#44;/system/lib/libstdc++.so&#44;/system/lib/libswresample.so&#44;/system/lib/libsync.so&#44;/system/lib/libui.so&#44;/system/lib/libunwind.so&#44;/system/lib/libusbhost.so&#44;/system/lib/libutils.so&#44;/system/lib/libvorbisidec.so&#44;/system/lib/libwebviewchromium_loader.so&#44;/system/lib/libwilhelm.so&#44;/system/lib/libwpa_client.so&#44;/system/lib/libz.so&#44;/vendor/lib/egl/eglSubDriverAndroid.so&#44;/vendor/lib/egl/libEGL_adreno.so&#44;/vendor/lib/egl/libGLESv1_CM_adreno.so&#44;/vendor/lib/egl/libGLESv2_adreno.so&#44;/vendor/lib/libadreno_utils.so&#44;/vendor/lib/libgsl.so&#44;/vendor/lib/libllvm-glnext.so</MMProcLoadedFiles>");
            ccd_xml.Append($"<RiskScanReqBuffer>{RiskScanReqBuffer}</RiskScanReqBuffer>");
            ccd_xml.Append($"<EnvBits>{WCAES.CheckSoftType5()}</EnvBits>");
            ccd_xml.Append($"<EnabledAccessibilityServiceIds></EnabledAccessibilityServiceIds>");
            ccd_xml.Append($"<InstalledPackageInfos>{InstallPackage}</InstalledPackageInfos>");
            ccd_xml.Append($"<AccessibilityClickCount>0</AccessibilityClickCount>");
            ccd_xml.Append($"<APKLeadingMD5>027f7b15666dc8a209a52dda75fc7f5d</APKLeadingMD5>");
            ccd_xml.Append($"<ClientVersion>0x{environment.Terminal.GetWeChatVersion().Code.ToString("X")}</ClientVersion>");
            ccd_xml.Append($"<WXTag>{Guid.NewGuid().ToString("D")}</WXTag>");
            ccd_xml.Append($"<ClientIP>192.168.0.241</ClientIP>");
            ccd_xml.Append($"<Language>zh_CN</Language>");
            ccd_xml.Append($"<IsInCalling>0</IsInCalling>");
            ccd_xml.Append($"<IsSetScreenLock>0</IsSetScreenLock>");
            ccd_xml.Append($"<NeighborBSSIDList></NeighborBSSIDList>");
            ccd_xml.Append($"<IsWifiOpen>0</IsWifiOpen>");
            ccd_xml.Append($"<HasXposedStackTrace>0</HasXposedStackTrace>");
            ccd_xml.Append($"<XposedHookedMethods></XposedHookedMethods>");
            ccd_xml.Append($"<IsADBSwitchEnabled>0</IsADBSwitchEnabled>");
            ccd_xml.Append($"<IsRunningByMonkey>0</IsRunningByMonkey>");
            ccd_xml.Append($"<AppInstrumentationClassName>com.tencent.mm</AppInstrumentationClassName>");
            ccd_xml.Append($"<AMSBinderClassName>android.os.BinderProxy</AMSBinderClassName>");
            ccd_xml.Append($"<AMSSingletonClassName>android.app.ActivityManagerProxy</AMSSingletonClassName>");
            ccd_xml.Append($"</st>");
            ccd_xml.Append($"<ccdcc>{ccd_xml.ToString().ToBytes().Crc32()}</ccdcc>");
            ccd_xml.Append($"<ccdts>{DateTime.Now.ToTimeStamp()}</ccdts>");
            return ccd_xml.ToString().ToBytes().ZIPCompress();
        }

        /// <summary>
        /// 构建Android 24 PB 明文
        /// </summary>
        /// <returns></returns>
        private static byte[] BuildClientCheckDataPBForAndroid(this WXEnvironment environment)
        {
            var spamDataBody = new SpamAndroidBody
            {
                Loc = 0,
                Root = 0,
                Debug = 0,
                PackageSign = "18c867f0717aa67b2ab7347505ba07ed",
                RadioVersion = "M8994F-2.6.42.5.03",
                BuildVersion = "8.1.0",
                DeviceId = environment.DeviceImei,
                AndroidId = "06a78780bc297bbd",
                SerialId = "01c5cded725f4db6",
                Model = environment.Device.Model,
                CpuCount = 6,
                CpuBrand = "Qualcomm Technologies, Inc MSM8992",
                CpuExt = "half thumb fastmult vfp edsp neon vfpv3 tls vfpv4 idiva idivt evtstrm aes pmull sha1 sha2 crc32",
                WlanAddress = "00:a0:07:86:17:18",
                Ssid = "02:00:00:00:00:00",
                Bssid = "02:00:00:00:00:00",
                SimOperator = "",
                WifiName = "Chinanet-2.4G-103",
                BuildFP = "google/bullhead/bullhead:8.1.0/OPM7.181105.004/5038062:user/release-keys",
                BuildBoard = "bullhead",
                BuildBootLoader = "BHZ32c",
                BuildBrand = "google",
                BuildDevice = "bullhead",
                PhoneNum = "",
                DataDir = "/data/user/0/com.tencent.mm/",
                NetType = "wifi",
                PackageName = "com.tencent.mm",
                Task = 0,
                AccessFlag = 0,
                AdbEnable = 0,
                AppName = "微信",
                BaseAPKMD5 = "83d6ad7f1c5045ab8112a8411c8091f2",
                BuildHardware = "Hexagon 686",
                BuildManufacturer = "Qualcomm",
                BuildProduct = "Qualcomm Hexagon",
                CallState = 0,
                ClassLoader = "",
                ClientVersion = environment.Device.VersionRelease,
                FSID = "",
                GsmSimOperator = "",
                GsmSimOperatorNumber = "",
                GsmSimSate = "",
                HardwareMask = 0,
                Ip = "127.0.0.1",
                KernelReleaseNumber = "686",
                KeyGuardSecure = 0,
                Locale = "",
                Luckpackcount = 0,
                Modified = 0,
                Monkey = 0,
                NanoTime = 0,
                Oaid = Guid.NewGuid().ToString("D"),
                OsBinderProxy = "",
                PackageFlag = 0,
                Qemu = 0,
                Refreshtime = 0,
                SbMD5 = "",
                SfArm64MD5 = "",
                SfArmMD5 = "",
                SfMD5 = "",
                Sign = environment.WeChatSignature,
                SoftConfig = new byte[] { 02, 09, 13, 85, 36, 96 },
                SoftData = new byte[] { 01, 02 },
                SoterId = "",
                SoterId2 = "",
                SplashName = "",
                StubProxy = "",
                SubScriberId = "",
                TbVersion = "",
                TbVersionCrc = 0,
                TimeCheck = 0,
                Unkonwn = 0,
                UsbState = 0,
                VirtualNet = 0,
                Vpn = 0,
                WidevineDeviceID = environment.DeviceImei,
                WifiOn = 1,
                XposeCall = 0
            }.SerializeToProtoBuf();
            var result = new ClientCheckData
            {
                C32Cdata = spamDataBody.Crc32(),
                TimeStamp = DateTime.UtcNow.ToTimeStamp(),
                Databody = spamDataBody
            }.SerializeToProtoBuf();
            return result.ZIPCompress();
        }
    }
}
