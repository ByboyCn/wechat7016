using Google.Protobuf;
using MG.gRPC;
using MG.gRPCClient;
using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace XMS.WeChat.Core.Libraries.WCAes
{
    public class CheckClientData
    {
        public static byte[] GetNewSpamData(string DeviceId, string DevOsVersion, string DevType, uint CpuCores, string IphoneVer, string DevName, uint Version,string DevOsTtpe,
            uint PlistVersion, string Md5OfMachoHeader, string AppUUID, uint InstallTimes, string Imei, string DeviceToken, string StrVersion, byte[] softConfig, byte[] softData)
        {
            var client = Client.GetClient();
            var ccdClient = new CcData.CcDataClient(client);
            var reply = ccdClient.GetCcData(new CcDataRequest
            {
                AppUUId = AppUUID,
                CpuCore = CpuCores,
                DeviceId = DeviceId,//可变
                DeviceToken = DeviceToken,//可变
                DevName = DevName,//可变
                DevOsType = DevOsTtpe,//可变
                DevOsVersion = DevOsVersion,//可变
                DevType = DevType,//可变
                Imei = Imei,
                InstallTimes = InstallTimes,//可变
                IphoneVer = IphoneVer,
                Md5OfMachoHeader = Md5OfMachoHeader,
                PlistVersion = PlistVersion,
                StrVersion = StrVersion,
                Version = Version,//可变
                SoftConfig = ByteString.CopyFrom(softConfig),//可变
                SoftData = ByteString.CopyFrom(softData)//可变
            });
            return reply.Result.ToByteArray();
        }
        public static byte[] GetDeviceToken(string deviceToken)
        {
            var client = Client.GetClient();
            var ccdClient = new CcData.CcDataClient(client);
            var reply = ccdClient.GetZDData(new CcDataRequest
            {
                DeviceToken = deviceToken ?? ""
            });
            return reply.Result.ToByteArray();
        }
        public static byte[] GetZTData(string DeviceId, string DevOsVersion, string DevType, uint CpuCores, string IphoneVer, string DevName, uint Version, string DevOsTtpe,
    uint PlistVersion, string Md5OfMachoHeader, string AppUUID, uint InstallTimes, string Imei, string DeviceToken, string StrVersion, byte[] softConfig, byte[] softData)
        {
            var client = Client.GetClient();
            var ccdClient = new CcData.CcDataClient(client);
            var reply = ccdClient.GetDTData(new CcDataRequest
            {
                AppUUId = AppUUID,
                CpuCore = CpuCores,
                DeviceId = DeviceId,//可变
                DeviceToken = DeviceToken,//可变
                DevName = DevName,//可变
                DevOsType = DevOsTtpe,//可变
                DevOsVersion = DevOsVersion,//可变
                DevType = DevType,//可变
                Imei = Imei,
                InstallTimes = InstallTimes,//可变
                IphoneVer = IphoneVer,
                Md5OfMachoHeader = Md5OfMachoHeader,
                PlistVersion = PlistVersion,
                StrVersion = StrVersion,
                Version = Version,//可变
                SoftConfig = ByteString.CopyFrom(softConfig),//可变
                SoftData = ByteString.CopyFrom(softData)//可变
            });
            return reply.Result.ToByteArray();
        }
        public static byte[] GetWcste(string DeviceId, string DevOsVersion, string DevType, uint CpuCores, string IphoneVer, string DevName, uint Version, string DevOsTtpe,
uint PlistVersion, string Md5OfMachoHeader, string AppUUID, uint InstallTimes, string Imei, string DeviceToken, string StrVersion, byte[] softConfig, byte[] softData)
        {
            var client = Client.GetClient();
            var ccdClient = new CcData.CcDataClient(client);
            var reply = ccdClient.GetWcste(new CcDataRequest
            {
                AppUUId = AppUUID,
                CpuCore = CpuCores,
                DeviceId = DeviceId,//可变
                DeviceToken = DeviceToken,//可变
                DevName = DevName,//可变
                DevOsType = DevOsTtpe,//可变
                DevOsVersion = DevOsVersion,//可变
                DevType = DevType,//可变
                Imei = Imei,
                InstallTimes = InstallTimes,//可变
                IphoneVer = IphoneVer,
                Md5OfMachoHeader = Md5OfMachoHeader,
                PlistVersion = PlistVersion,
                StrVersion = StrVersion,
                Version = Version,//可变
                SoftConfig = ByteString.CopyFrom(softConfig),//可变
                SoftData = ByteString.CopyFrom(softData)//可变
            });
            return reply.Result.ToByteArray();
        }
        public static byte[] GetWcstf(string DeviceId, string DevOsVersion, string DevType, uint CpuCores, string IphoneVer, string DevName, uint Version, string DevOsTtpe,
uint PlistVersion, string Md5OfMachoHeader, string AppUUID, uint InstallTimes, string Imei, string DeviceToken, string StrVersion, byte[] softConfig, byte[] softData)
        {
            var client = Client.GetClient();
            var ccdClient = new CcData.CcDataClient(client);
            var reply = ccdClient.GetWcstf(new CcDataRequest
            {
                AppUUId = AppUUID,
                CpuCore = CpuCores,
                DeviceId = DeviceId,//可变
                DeviceToken = DeviceToken,//可变
                DevName = DevName,//可变
                DevOsType = DevOsTtpe,//可变
                DevOsVersion = DevOsVersion,//可变
                DevType = DevType,//可变
                Imei = Imei,
                InstallTimes = InstallTimes,//可变
                IphoneVer = IphoneVer,
                Md5OfMachoHeader = Md5OfMachoHeader,
                PlistVersion = PlistVersion,
                StrVersion = StrVersion,
                Version = Version,//可变
                SoftConfig = ByteString.CopyFrom(softConfig),//可变
                SoftData = ByteString.CopyFrom(softData)//可变
            });
            return reply.Result.ToByteArray();
        }
    }
}
