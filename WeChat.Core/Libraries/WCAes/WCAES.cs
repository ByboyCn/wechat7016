using ProtoBuf;

namespace System
{
    [Serializable, ProtoContract]
    public partial class DeviceRunningInfo23
    {
        [ProtoMember(1, Options = MemberSerializationOptions.Required)]
        public string Version;
        [ProtoMember(2, Options = MemberSerializationOptions.Required)]
        public int Encrypted;
        [ProtoMember(3, Options = MemberSerializationOptions.Required)]
        public byte[] Data;
    }
    [Serializable, ProtoContract]
    public partial class DeviceRunningInfo24
    {
        [ProtoMember(1, Options = MemberSerializationOptions.Required)]
        public string Version;
        [ProtoMember(2, Options = MemberSerializationOptions.Required)]
        public int Encrypted;
        [ProtoMember(3, Options = MemberSerializationOptions.Required)]
        public byte[] Data;
        [ProtoMember(4, Options = MemberSerializationOptions.Required)]
        public uint Timestamp;
        [ProtoMember(5, Options = MemberSerializationOptions.Required)]
        public uint Optype;
        [ProtoMember(6, Options = MemberSerializationOptions.Required)]
        public uint Uin;
    }
    [Serializable, ProtoContract]
    public class FileInfo
    {
        [ProtoMember(1, Options = MemberSerializationOptions.Required)]
        public string Filepath;
        [ProtoMember(2, Options = MemberSerializationOptions.Required)]
        public string Fileuuid;
    }
    [Serializable, ProtoContract]
    public class SpamIOSBody
    {
        [ProtoMember(1, Options = MemberSerializationOptions.Required)]
        public int UnKnown1;
        [ProtoMember(2, Options = MemberSerializationOptions.Required)]
        public int TimeStamp;
        [ProtoMember(3, Options = MemberSerializationOptions.Required)]
        public int KeyHash;
        [ProtoMember(11, Options = MemberSerializationOptions.Required)]
        public string Yes1;
        [ProtoMember(12, Options = MemberSerializationOptions.Required)]
        public string Yes2;
        [ProtoMember(13, Options = MemberSerializationOptions.Required)]
        public string IosVersion;
        [ProtoMember(14, Options = MemberSerializationOptions.Required)]
        public string DeviceType;
        [ProtoMember(15, Options = MemberSerializationOptions.Required)]
        public int UnKnown2;
        [ProtoMember(16, Options = MemberSerializationOptions.Required)]
        public string IdentifierForVendor;
        [ProtoMember(17, Options = MemberSerializationOptions.Required)]
        public string AdvertisingIdentifier;
        [ProtoMember(18, Options = MemberSerializationOptions.Required)]
        public string Carrier;
        [ProtoMember(19, Options = MemberSerializationOptions.Required)]
        public int BatteryInfo;
        [ProtoMember(20, Options = MemberSerializationOptions.Required)]
        public string NetworkName;
        [ProtoMember(21, Options = MemberSerializationOptions.Required)]
        public int NetType;
        [ProtoMember(22, Options = MemberSerializationOptions.Required)]
        public string AppBundleId;
        [ProtoMember(23, Options = MemberSerializationOptions.Required)]
        public string DeviceName;
        [ProtoMember(24, Options = MemberSerializationOptions.Required)]
        public string UserName;
        [ProtoMember(25, Options = MemberSerializationOptions.Required)]
        public long Unknown3;
        [ProtoMember(26, Options = MemberSerializationOptions.Required)]
        public long Unknown4;
        [ProtoMember(27, Options = MemberSerializationOptions.Required)]
        public int Unknown5;
        [ProtoMember(28, Options = MemberSerializationOptions.Required)]
        public int Unknown6;
        [ProtoMember(29, Options = MemberSerializationOptions.Required)]
        public string Lang;
        [ProtoMember(30, Options = MemberSerializationOptions.Required)]
        public string Country;
        [ProtoMember(31, Options = MemberSerializationOptions.Required)]
        public int Unknown7;
        [ProtoMember(32, Options = MemberSerializationOptions.Required)]
        public string DocumentDir;
        [ProtoMember(33, Options = MemberSerializationOptions.Required)]
        public int Unknown8;
        [ProtoMember(34, Options = MemberSerializationOptions.Required)]
        public int Unknown9;
        [ProtoMember(35, Options = MemberSerializationOptions.Required)]
        public string HeadMD5;
        [ProtoMember(36, Options = MemberSerializationOptions.Required)]
        public string AppUUID;
        [ProtoMember(37, Options = MemberSerializationOptions.Required)]
        public string SyslogUUID;
        [ProtoMember(38, Options = MemberSerializationOptions.Required)]
        public string WifiName;
        [ProtoMember(39, Options = MemberSerializationOptions.Required)]
        public string WifiMac;
        [ProtoMember(40, Options = MemberSerializationOptions.Required)]
        public string AppName;
        [ProtoMember(41, Options = MemberSerializationOptions.Required)]
        public string SshPath;
        [ProtoMember(42, Options = MemberSerializationOptions.Required)]
        public string TempTest;
        [ProtoMember(43, Options = MemberSerializationOptions.Required)]
        public string DevMD5;
        [ProtoMember(44, Options = MemberSerializationOptions.Required)]
        public string DevUser;
        [ProtoMember(45, Options = MemberSerializationOptions.None)]
        public string DevPrefix;
        [ProtoMember(46, Options = MemberSerializationOptions.Required)]
        public FileInfo[] AppFileInfo;
        [ProtoMember(47, Options = MemberSerializationOptions.Required)]
        public string Unknown12;
        [ProtoMember(50, Options = MemberSerializationOptions.Required)]
        public int IsModify;
        [ProtoMember(51, Options = MemberSerializationOptions.Required)]
        public string ModifyMD5;
        [ProtoMember(52, Options = MemberSerializationOptions.Required)]
        public long RqtHash;
        [ProtoMember(53, Options = MemberSerializationOptions.None)]
        public int Unknown13;
        [ProtoMember(54, Options = MemberSerializationOptions.None)]
        public int Unknown14;
        [ProtoMember(55, Options = MemberSerializationOptions.None)]
        public string Ssid;
        [ProtoMember(56, Options = MemberSerializationOptions.None)]
        public int Unknown15;
        [ProtoMember(57, Options = MemberSerializationOptions.None)]
        public string Bssid;
        [ProtoMember(58, Options = MemberSerializationOptions.None)]
        public uint IsJail;
        [ProtoMember(59, Options = MemberSerializationOptions.None)]
        public string Seid;
        [ProtoMember(60, Options = MemberSerializationOptions.None)]
        public int Unknown16;
        [ProtoMember(61, Options = MemberSerializationOptions.None)]
        public int Unknown17;
        [ProtoMember(62, Options = MemberSerializationOptions.None)]
        public int Unknown18;
        [ProtoMember(63, Options = MemberSerializationOptions.None)]
        public uint WifiOn;
        [ProtoMember(64, Options = MemberSerializationOptions.None)]
        public uint BluethOn;
        [ProtoMember(65, Options = MemberSerializationOptions.None)]
        public string BluethName;
        [ProtoMember(66, Options = MemberSerializationOptions.None)]
        public string BluethMac;
        [ProtoMember(67, Options = MemberSerializationOptions.None)]
        public int Unknown19;
        [ProtoMember(68, Options = MemberSerializationOptions.None)]
        public int Unknown20;
        [ProtoMember(69, Options = MemberSerializationOptions.None)]
        public int Unknown26;
        [ProtoMember(70, Options = MemberSerializationOptions.None)]
        public uint HasSim;
        [ProtoMember(71, Options = MemberSerializationOptions.None)]
        public uint UsbState;
        [ProtoMember(72, Options = MemberSerializationOptions.None)]
        public int Unknown27;
        [ProtoMember(73, Options = MemberSerializationOptions.None)]
        public int Unknown28;
        [ProtoMember(74, Options = MemberSerializationOptions.None)]
        public string Sign;
        [ProtoMember(75, Options = MemberSerializationOptions.None)]
        public uint PackageFlag;
        [ProtoMember(76, Options = MemberSerializationOptions.None)]
        public uint AccessFlag;
        [ProtoMember(77, Options = MemberSerializationOptions.None)]
        public string Imei;
        [ProtoMember(78, Options = MemberSerializationOptions.None)]
        public string DevSerial;
        [ProtoMember(79, Options = MemberSerializationOptions.None)]
        public int Unknown29;
        [ProtoMember(80, Options = MemberSerializationOptions.None)]
        public int Unknown30;
        [ProtoMember(81, Options = MemberSerializationOptions.None)]
        public int Unknown31;
        [ProtoMember(82, Options = MemberSerializationOptions.None)]
        public int Unknown32;
        [ProtoMember(83, Options = MemberSerializationOptions.None)]
        public int AppNum;
        [ProtoMember(84, Options = MemberSerializationOptions.None)]
        public string Totcapacity;
        [ProtoMember(85, Options = MemberSerializationOptions.None)]
        public string Avacapacity;
        [ProtoMember(86, Options = MemberSerializationOptions.None)]
        public int Unknown33;
        [ProtoMember(87, Options = MemberSerializationOptions.None)]
        public int Unknown34;
        [ProtoMember(88, Options = MemberSerializationOptions.None)]
        public int Unknown35;
        [ProtoMember(89, Options = MemberSerializationOptions.None)]
        public int Unknown103;
        [ProtoMember(90, Options = MemberSerializationOptions.None)]
        public int Unknown104;
        [ProtoMember(91, Options = MemberSerializationOptions.None)]
        public int Unknown105;
        [ProtoMember(92, Options = MemberSerializationOptions.None)]
        public uint Unknown106;
        [ProtoMember(93, Options = MemberSerializationOptions.None)]
        public int Unknown107;
        [ProtoMember(94, Options = MemberSerializationOptions.None)]
        public int Unknown108;
        [ProtoMember(95, Options = MemberSerializationOptions.None)]
        public int Unknown109;
        [ProtoMember(96, Options = MemberSerializationOptions.None)]
        public int Unknown110;
        [ProtoMember(97, Options = MemberSerializationOptions.None)]
        public int Unknown111;
        [ProtoMember(98, Options = MemberSerializationOptions.None)]
        public int Unknown112;
    }
    [Serializable, ProtoContract]
    public class SpamAndroidBody
    {
        [ProtoMember(1, Options = MemberSerializationOptions.Required)]
        public uint Loc;
        [ProtoMember(2, Options = MemberSerializationOptions.Required)]
        public uint Root;
        [ProtoMember(3, Options = MemberSerializationOptions.Required)]
        public uint Debug;
        [ProtoMember(4, Options = MemberSerializationOptions.Required)]
        public string PackageSign;
        [ProtoMember(5, Options = MemberSerializationOptions.Required)]
        public string RadioVersion;
        [ProtoMember(6, Options = MemberSerializationOptions.Required)]
        public string BuildVersion;
        [ProtoMember(7, Options = MemberSerializationOptions.Required)]
        public string DeviceId;
        [ProtoMember(8, Options = MemberSerializationOptions.Required)]
        public string AndroidId;
        [ProtoMember(9, Options = MemberSerializationOptions.Required)]
        public string SerialId;
        [ProtoMember(10, Options = MemberSerializationOptions.Required)]
        public string Model;
        [ProtoMember(11, Options = MemberSerializationOptions.Required)]
        public uint CpuCount;
        [ProtoMember(12, Options = MemberSerializationOptions.None)]
        public string CpuBrand;
        [ProtoMember(13, Options = MemberSerializationOptions.None)]
        public string CpuExt;
        [ProtoMember(14, Options = MemberSerializationOptions.None)]
        public string WlanAddress;
        [ProtoMember(15, Options = MemberSerializationOptions.None)]
        public string Ssid;
        [ProtoMember(16, Options = MemberSerializationOptions.None)]
        public string Bssid;
        [ProtoMember(17, Options = MemberSerializationOptions.None)]
        public string SimOperator;
        [ProtoMember(18, Options = MemberSerializationOptions.None)]
        public string WifiName;
        [ProtoMember(19, Options = MemberSerializationOptions.None)]
        public string BuildFP;
        [ProtoMember(20, Options = MemberSerializationOptions.None)]
        public string BuildBoard;
        [ProtoMember(21, Options = MemberSerializationOptions.None)]
        public string BuildBootLoader;
        [ProtoMember(22, Options = MemberSerializationOptions.None)]
        public string BuildBrand;
        [ProtoMember(23, Options = MemberSerializationOptions.None)]
        public string BuildDevice;
        [ProtoMember(24, Options = MemberSerializationOptions.None)]
        public string BuildHardware;
        [ProtoMember(25, Options = MemberSerializationOptions.None)]
        public string BuildProduct;
        [ProtoMember(26, Options = MemberSerializationOptions.None)]
        public string BuildManufacturer;
        [ProtoMember(27, Options = MemberSerializationOptions.None)]
        public string PhoneNum;
        [ProtoMember(28, Options = MemberSerializationOptions.None)]
        public string NetType;
        [ProtoMember(29, Options = MemberSerializationOptions.None)]
        public uint Qemu;
        [ProtoMember(30, Options = MemberSerializationOptions.None)]
        public uint Modified;
        [ProtoMember(31, Options = MemberSerializationOptions.None)]
        public uint Task;
        [ProtoMember(32, Options = MemberSerializationOptions.None)]
        public string PackageName;
        [ProtoMember(33, Options = MemberSerializationOptions.None)]
        public string AppName;
        [ProtoMember(34, Options = MemberSerializationOptions.None)]
        public string DataDir;
        [ProtoMember(35, Options = MemberSerializationOptions.None)]
        public string ClassLoader;
        [ProtoMember(38, Options = MemberSerializationOptions.None)]
        public uint HardwareMask;
        [ProtoMember(41, Options = MemberSerializationOptions.None)]
        public uint Luckpackcount;
        [ProtoMember(42, Options = MemberSerializationOptions.None)]
        public string BaseAPKMD5;
        [ProtoMember(43, Options = MemberSerializationOptions.None)]
        public string ClientVersion;
        [ProtoMember(44, Options = MemberSerializationOptions.None)]
        public string TbVersion;
        [ProtoMember(45, Options = MemberSerializationOptions.None)]
        public string Ip;
        [ProtoMember(46, Options = MemberSerializationOptions.None)]
        public string Locale;
        [ProtoMember(47, Options = MemberSerializationOptions.None)]
        public uint CallState;
        [ProtoMember(48, Options = MemberSerializationOptions.None)]
        public uint KeyGuardSecure;
        [ProtoMember(50, Options = MemberSerializationOptions.None)]
        public uint WifiOn;
        [ProtoMember(51, Options = MemberSerializationOptions.None)]
        public uint XposeCall;
        [ProtoMember(53, Options = MemberSerializationOptions.None)]
        public uint AdbEnable;
        [ProtoMember(54, Options = MemberSerializationOptions.None)]
        public uint Monkey;
        [ProtoMember(55, Options = MemberSerializationOptions.None)]
        public string SplashName;
        [ProtoMember(56, Options = MemberSerializationOptions.None)]
        public string OsBinderProxy;
        [ProtoMember(57, Options = MemberSerializationOptions.None)]
        public string StubProxy;
        [ProtoMember(58, Options = MemberSerializationOptions.None)]
        public uint VirtualNet;
        [ProtoMember(59, Options = MemberSerializationOptions.None)]
        public uint Vpn;
        [ProtoMember(60, Options = MemberSerializationOptions.None)]
        public string SubScriberId;
        [ProtoMember(61, Options = MemberSerializationOptions.None)]
        public string GsmSimSate;
        [ProtoMember(62, Options = MemberSerializationOptions.None)]
        public string GsmSimOperator;
        [ProtoMember(63, Options = MemberSerializationOptions.None)]
        public string GsmSimOperatorNumber;
        [ProtoMember(64, Options = MemberSerializationOptions.None)]
        public string SoterId;
        [ProtoMember(65, Options = MemberSerializationOptions.None)]
        public string KernelReleaseNumber;
        [ProtoMember(66, Options = MemberSerializationOptions.None)]
        public uint UsbState;
        [ProtoMember(67, Options = MemberSerializationOptions.None)]
        public string Sign;
        [ProtoMember(68, Options = MemberSerializationOptions.None)]
        public uint PackageFlag;
        [ProtoMember(69, Options = MemberSerializationOptions.None)]
        public uint AccessFlag;
        [ProtoMember(70, Options = MemberSerializationOptions.None)]
        public uint Unkonwn;
        [ProtoMember(71, Options = MemberSerializationOptions.None)]
        public uint TbVersionCrc;
        [ProtoMember(72, Options = MemberSerializationOptions.None)]
        public string SfMD5;
        [ProtoMember(73, Options = MemberSerializationOptions.None)]
        public string SfArmMD5;
        [ProtoMember(74, Options = MemberSerializationOptions.None)]
        public string SfArm64MD5;
        [ProtoMember(75, Options = MemberSerializationOptions.None)]
        public string SbMD5;
        [ProtoMember(76, Options = MemberSerializationOptions.None)]
        public string SoterId2;
        [ProtoMember(77, Options = MemberSerializationOptions.None)]
        public string WidevineDeviceID;
        [ProtoMember(78, Options = MemberSerializationOptions.None)]
        public string FSID;
        [ProtoMember(79, Options = MemberSerializationOptions.None)]
        public string Oaid;
        [ProtoMember(80, Options = MemberSerializationOptions.None)]
        public uint TimeCheck;
        [ProtoMember(81, Options = MemberSerializationOptions.None)]
        public uint NanoTime;
        [ProtoMember(83, Options = MemberSerializationOptions.None)]
        public uint Refreshtime;
        [ProtoMember(84, Options = MemberSerializationOptions.None)]
        public byte[] SoftConfig;
        [ProtoMember(85, Options = MemberSerializationOptions.None)]
        public byte[] SoftData;
    }
    [Serializable, ProtoContract]
    public class ClientCheckData
    {
        [ProtoMember(1, Options = MemberSerializationOptions.Required)]
        public long C32Cdata;
        [ProtoMember(2, Options = MemberSerializationOptions.Required)]
        public long TimeStamp;
        [ProtoMember(3, Options = MemberSerializationOptions.Required)]
        public byte[] Databody;
    }
    public static partial class WCAES
    {
        public static uint CheckSoftType5()
        {
            int sec = new Random().Next(999) * 1000;
            uint v79 = (uint)sec & 0xe | 1;
            uint key = v79;

            uint v77 = 134217728;
            uint n = 4;

            while (true)
            {
                uint dwTmp = n & 3;
                if (dwTmp == 0)
                {
                    v79 = (3877 * v79 + 5) & 0xf;
                }

                dwTmp = (uint)(((int)v79 >> (int)dwTmp) & 1) << (int)n;
                v77 ^= dwTmp;
                n++;
                if (n == 24)
                {
                    break;
                }
            }
            return v77 | key;
        }

        public static int makeKeyHash(int key)
        {
            int a = 0, b = 0;
            int a_result = 0, b_result = 0;

            for (int i = 0; i < 16; i++)
            {
                a = 1 << (2 * i);
                b = 1 << (2 * i + 1);

                a &= key;
                b &= key;

                a = a << (2 * i);
                b = b << (2 * i + 1);

                a_result |= a;
                b_result |= b;
            }
            return a_result | b_result;
        }

        public static void getsecvaluefinal(ref byte[] encryptrecordbuf, byte[] saetablefinal)
        {
            var resultPtr = 0;           // lr

            var encryptrecordbufPtr = 0; // r3

            var saetablefinalPtr = 0;    // r4

            byte value;
            byte[] result = new byte[16]; // [sp+0h] [bp-1Ch]//结果缓冲区
            for (int v3 = 0; v3 < 4; v3++)
            {
                for (int v6 = 0; v6 < 4; v6++)
                {
                    value = saetablefinal[saetablefinalPtr + (int)(encryptrecordbuf[encryptrecordbufPtr + v6])];

                    saetablefinalPtr += 0x100;

                    result[resultPtr + v6] = value;

                }
                resultPtr += 4;

                encryptrecordbufPtr += 4;

            }
            Buffer.BlockCopy(result, 0, encryptrecordbuf, 0, result.Length);
        }

        public static void Shiftrows(ref byte[] data)
        {
            Circshift(ref data, 4, 1);

            Circshift(ref data, 8, 2);

            Circshift(ref data, 12, 3);
        }

        public static void Circshift(ref byte[] srcbuffer, int offset, int pos)
        {
            switch (pos)
            {
                case 3:
                    var v4 = srcbuffer[3 + offset];

                    srcbuffer[3 + offset] = srcbuffer[2 + offset];

                    srcbuffer[2 + offset] = srcbuffer[1 + offset];

                    srcbuffer[1 + offset] = srcbuffer[0 + offset];

                    srcbuffer[0 + offset] = v4;
                    break;

                case 2:
                    var a = srcbuffer[0 + offset];
                    srcbuffer[0 + offset] = srcbuffer[2 + offset];
                    srcbuffer[2 + offset] = a;

                    var b = srcbuffer[1 + offset];
                    srcbuffer[1 + offset] = srcbuffer[3 + offset];
                    srcbuffer[3 + offset] = b;
                    break;

                case 1:
                    var v2 = srcbuffer[0 + offset];

                    var v3 = srcbuffer[1 + offset];

                    srcbuffer[1 + offset] = srcbuffer[2 + offset];

                    srcbuffer[2 + offset] = srcbuffer[3 + offset];

                    srcbuffer[0 + offset] = v3;

                    srcbuffer[3 + offset] = v2;
                    break;

            }
        }

        public static void getsectable(byte[] sectable, ref byte[] encryptrecordbuf, byte[] saedattablekey, int keyOffset)
        {
            var outbuffer = 0;        // r8

            int ptrsattable_1; // lr
            int ptrsattables;  // r6
            byte tempbyte;     // r3
            var sectablePtr = 0;

            var saedattablekeyPtr = 0;

            for (int localindex3 = 0; localindex3 < 4; localindex3++)
            {
                outbuffer = sectablePtr;

                ptrsattable_1 = saedattablekeyPtr;

                for (int localindex = 0; localindex < 4; localindex++)
                {
                    ptrsattables = ptrsattable_1;

                    for (int localindex2 = 0; localindex2 < 0x40; localindex2 += 16)
                    {
                        var temp = 4 * (int)(encryptrecordbuf[+4 * localindex3 + localindex]);

                        tempbyte = saedattablekey[keyOffset + ptrsattables + temp];

                        ptrsattables++;

                        sectable[outbuffer + localindex2] = tempbyte;

                    }
                    outbuffer += 4;

                    ptrsattable_1 += 0x400;

                }
                sectablePtr++;

                saedattablekeyPtr += 0x1000;

            }
        }

        public static void getsecvalue(ref byte[] encryptrecordbuf, byte[] sectable, byte[] saedatatable, int valueOffset)
        {
            int ptrtable64_offset2;  // r3
            int ptrtable64_offset2_1; // lr
            int saetablePtr1;         // r11
            int innerindex;          // r6
            byte tempbytevalue;       // r5
            var outbufferptr = 0;            // r3

            var out16buf_1 = 0;              // r10

            int ptrtable64_offset2_3; // r3
            byte v13;                  // r4
            byte v14;                 // r4
            byte v15;                 // r2
            byte v16;                 // r5
            int ptrtable64_offset2_2; // [sp+0h] [bp-20h]
            var saetableptr = valueOffset;             // [sp+4h] [bp-1Ch]


            ptrtable64_offset2 = 2; // sectable + 2;

            for (int outlocalindex = 0; outlocalindex < 4; outlocalindex++)
            {
                ptrtable64_offset2_1 = ptrtable64_offset2;

                ptrtable64_offset2_2 = (byte)ptrtable64_offset2;

                saetablePtr1 = saetableptr;

                for (int localindex = 0; localindex < 4; localindex++)
                {
                    tempbytevalue = sectable[16 * outlocalindex + 3 + 4 * localindex];

                    outbufferptr = 4 * outlocalindex + localindex; // &encryptrecordbuf[4 * outlocalindex + localindex];

                    out16buf_1 = outbufferptr;

                    encryptrecordbuf[outbufferptr] = tempbytevalue;

                    ptrtable64_offset2_3 = ptrtable64_offset2_1;

                    innerindex = 0;

                    for (int i = 0; i < 3; i++)
                    {

                        v13 = (byte)((sectable[ptrtable64_offset2_3] & 0xF0) | (tempbytevalue & 0xF0) >> 4);


                        if ((v13 & 0x80) != 0)
                        { // 大于128
                            v14 = (byte)(saedatatable[saetablePtr1 + (int)(v13 & 0x7F) + 0x200 + innerindex] >> 4);

                        }
                        else
                        {
                            v14 = (byte)(saedatatable[saetablePtr1 + (int)v13 + 0x200 + innerindex] & 0xF);


                        }
                        v15 = (byte)(tempbytevalue & 0xF | 16 * sectable[ptrtable64_offset2_3]);


                        if ((v15 & 0x80) != 0)
                        { // 大于128
                            v16 = (byte)(saedatatable[saetablePtr1 + (v15 & 0x7F) + 0x280 + innerindex] >> 4);

                        }
                        else
                        {
                            v16 = (byte)(saedatatable[saetablePtr1 + v15 + 0x280 + innerindex] & 0xF);


                        }
                        //////Debug.WriteLine("ptrtable64_offset2_3",ptrtable64_offset2_3,v13,v14,v15,v16)
                        tempbytevalue = (byte)(v16 | 16 * v14);

                        innerindex -= 0x100;

                        ptrtable64_offset2_3--;

                        encryptrecordbuf[out16buf_1] = tempbytevalue;

                    }
                    ptrtable64_offset2_1 += 4;

                    saetablePtr1 += 0x300;

                }
                ptrtable64_offset2 = ptrtable64_offset2_2 + 0x10;

                saetableptr = saetableptr + 0xC00;

            }
        }
    }
}
