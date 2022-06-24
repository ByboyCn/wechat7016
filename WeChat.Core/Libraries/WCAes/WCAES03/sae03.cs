using ProtoBuf;
using System.IO;
using System.Linq;
using System.Reflection;

namespace System
{
    [Serializable, ProtoContract]
    public partial class wcsae03
    {
        [ProtoMember(1, Options = MemberSerializationOptions.Required)]
        public byte[] type;
        [ProtoMember(2, Options = MemberSerializationOptions.Required)]
        public byte[] IV;
        [ProtoMember(3, Options = MemberSerializationOptions.Required)]
        public int len;
        [ProtoMember(4, Options = MemberSerializationOptions.Required)]
        public byte[] Mztkey;
        [ProtoMember(5, Options = MemberSerializationOptions.Required)]
        public byte[] Mztkeyvalue;
        [ProtoMember(6, Options = MemberSerializationOptions.Required)]
        public byte[] unkown6;
        [ProtoMember(7, Options = MemberSerializationOptions.Required)]
        public byte[] unkown7;
        [ProtoMember(8, Options = MemberSerializationOptions.Required)]
        public byte[] unkown8;
        [ProtoMember(9, Options = MemberSerializationOptions.Required)]
        public byte[] unkown9;
        [ProtoMember(10, Options = MemberSerializationOptions.Required)]
        public byte[] tablekey;
        [ProtoMember(11, Options = MemberSerializationOptions.Required)]
        public byte[] unkown11;
        [ProtoMember(12, Options = MemberSerializationOptions.Required)]
        public byte[] tablevalue;
        [ProtoMember(13, Options = MemberSerializationOptions.Required)]
        public byte[] unkown13;
        [ProtoMember(14, Options = MemberSerializationOptions.Required)]
        public byte[] unkown14;
        [ProtoMember(15, Options = MemberSerializationOptions.Required)]
        public byte[] unkown15;
        [ProtoMember(16, Options = MemberSerializationOptions.Required)]
        public byte[] unkown16;
        [ProtoMember(17, Options = MemberSerializationOptions.Required)]
        public byte[] unkown17;
        [ProtoMember(18, Options = MemberSerializationOptions.Required)]
        public byte[] unkown18;
        [ProtoMember(19, Options = MemberSerializationOptions.Required)]
        public byte[] unkown19;
        [ProtoMember(20, Options = MemberSerializationOptions.Required)]
        public byte[] unkown20;
        [ProtoMember(21, Options = MemberSerializationOptions.Required)]
        public byte[] unkown21;
        [ProtoMember(22, Options = MemberSerializationOptions.Required)]
        public byte[] unkown22;
        [ProtoMember(23, Options = MemberSerializationOptions.Required)]
        public byte[] unkown23;
        [ProtoMember(24, Options = MemberSerializationOptions.Required)]
        public byte[] unkown24;
        [ProtoMember(25, Options = MemberSerializationOptions.Required)]
        public byte[] unkown25;
    }

    public static class WCAES03
    {
        private static wcsae03 _sae;
        static WCAES03()
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"WeChat.Core.Libraries.WCAes.WCAES03.sae03.dat"))
            {
                var content = new byte[stream.Length];
                stream.Read(content, 0, content.Length);

                _sae = content.DeserializeFromProtoBuf<wcsae03>();
            }
        }

        public static byte[] BuildClientCheckData(byte[] srcbuffer)
        {
            int encryptdatalen = 0;
            byte[] encryptdatabuf;
            byte[] outencryptdatabuf;
            byte[] encryptrecordbuf = new byte[16];

            byte[] sectable = new byte[64];
            byte[] destbufferptr;
            byte[] destbuffer = null;
            int srcbuffersize = srcbuffer.Length;
            if (srcbuffer != null && srcbuffer.Length != 0 && _sae.tablekey != null && _sae.tablevalue != null)
            {
                //如果加密方式是03 或者加密方式是05 //其余加密方式暂不支持
                //赋值是0x3060,必定进入这个循环
                encryptdatalen = 16 - (srcbuffersize & 0xF) + srcbuffersize;
                encryptdatabuf = new byte[encryptdatalen];
                //先申请一段加密完成以后的大小内存
                Buffer.BlockCopy(srcbuffer, 0, encryptdatabuf, 0, srcbuffer.Length);
                //如果不是0x10的整数倍就后面补齐
                if (16 != (srcbuffersize & 0xF))
                {
                    for (int i = srcbuffersize; i < encryptdatalen; i++)
                    {
                        encryptdatabuf[i] = (byte)(16 - (srcbuffersize & 0xF));
                    }
                }
                //申请一块同样大小的内存作为轮询数据
                outencryptdatabuf = new byte[encryptdatalen];
                //申请一个0x10的内存做中间加密换算用
                if (encryptdatalen != 0)
                {
                    byte[] xorivbuffer = _sae.IV;                //首先与IV进行xor
                    int uncryptdatalen = encryptdatalen; //还有多少没有加密
                    byte[] intdatadstptr_2_offse_1 = outencryptdatabuf.Skip(1).ToArray();
                    byte[] bytedatadstptr_2_offse_1;
                    //var bytedatadstptr_2_offse_1_1 []byte
                    var outencryptdatabuf_temp = new byte[16];// outencryptdatabuf;
                    var circle = encryptdatalen / 16;
                    ////Debug.WriteLine("iv:"+iv))
                    for (int i = 0; i < circle; i++)
                    {
                        var localindex = 0;
                        var islarge16 = false;
                        //Debug.WriteLine("Iv:{0}", xorivbuffer.ToString(16, 2));
                        //异域操作
                        while (true)
                        {
                            bytedatadstptr_2_offse_1 = intdatadstptr_2_offse_1;
                            outencryptdatabuf_temp[localindex] = (byte)(encryptdatabuf[localindex] ^ xorivbuffer[localindex]);
                            //Debug.WriteLine("{0:X},{1:X},{2:X}", outencryptdatabuf_temp[localindex], encryptdatabuf[localindex], xorivbuffer[localindex]);
                            //cout << b2hex(outencryptdatabuf_temp, 16) << endl;
                            localindex++;
                            islarge16 = localindex >= 0xF;
                            if (localindex <= 0xF)
                            {
                                intdatadstptr_2_offse_1 = bytedatadstptr_2_offse_1.Skip(1).ToArray();
                                islarge16 = localindex >= uncryptdatalen;
                            }
                            if (islarge16) { break; }
                        }
                        //Debug.WriteLine("第一轮异或结果:" + outencryptdatabuf_temp.Take(16).ToArray().ToString(16, 2));
                        //计算中间换算结果
                        //Debug.WriteLine("中间换算开始:{0},异或结果:{1}", encryptrecordbuf.Take(16).ToArray().ToString(16, 2), outencryptdatabuf_temp.Take(16).ToArray().ToString(16, 2));
                        var outencryptdatabuf_temp_record = outencryptdatabuf_temp; //异或结果
                        var encryptrecordbuf_temp = encryptrecordbuf;               //指向中间换算

                        for (int temprecordindex = 0; temprecordindex < 4; temprecordindex++)
                        {
                            for (int localindex2 = 0; localindex2 < 4; localindex2++)
                            {
                                encryptrecordbuf_temp[temprecordindex * 4 + localindex2] = outencryptdatabuf_temp_record[4 * localindex2];
                            }
                            //encryptrecordbuf_temp = encryptrecordbuf_temp.Skip(4).ToArray();
                            outencryptdatabuf_temp_record = outencryptdatabuf_temp_record.Skip(1).ToArray();
                        }
                        //Debug.WriteLine("中间换算结束:" + encryptrecordbuf.Take(16).ToArray().ToString(16, 2));

                        destbufferptr = outencryptdatabuf_temp;
                        WCAES.Shiftrows(ref encryptrecordbuf); //行移位
                                                               //Debug.WriteLine("中间换算移位:" + encryptrecordbuf.Take(16).ToArray().ToString(16, 2));
                        var indexstep = 0xFFFDC000;
                        var psaedattablekey = 0;   //saedattablekey
                        var psaedattablevalue = 0; // saedattablevalue

                        for (int ix = 0; ix < 9; ix++)
                        {
                            //Debug.WriteLine("密钥扩展前:"+sectable.ToString(16, 2) + "," + encryptrecordbuf.ToString(16, 2));
                            WCAES.getsectable(sectable, ref encryptrecordbuf, _sae.tablekey, psaedattablekey); // 密钥扩展    本操作只改变sectable
                            //Debug.WriteLine("密钥扩展后:"+sectable.ToString(16, 2) + "," + encryptrecordbuf.ToString(16, 2));
                            //Debug.WriteLine("密钥扩展前:" + sectable.ToString(16, 2) + "," + encryptrecordbuf.ToString(16, 2));
                            WCAES.getsecvalue(ref encryptrecordbuf, sectable, _sae.tablevalue, psaedattablevalue); //本操作只改变ecnryptrecordbuf
                            //Debug.WriteLine("密钥扩展后:" + sectable.ToString(16, 2) + "," + encryptrecordbuf.ToString(16, 2));
                            WCAES.Shiftrows(ref encryptrecordbuf); //行移位
                            psaedattablevalue += 0x3000;
                            indexstep += 0x4000;
                            psaedattablekey = psaedattablekey + 0x4000;
                        }
                        //Debug.WriteLine("密钥扩展结束");
                        //Debug.WriteLine("中间换算Final前:" + encryptrecordbuf.ToString(16, 2));
                        WCAES.getsecvaluefinal(ref encryptrecordbuf, _sae.unkown18); //最后一次加密
                        //Debug.WriteLine("中间换算Final后:"+ encryptrecordbuf.ToString(16, 2));

                        destbuffer = destbufferptr;
                        var unkownresetdata_2 = 0; // encryptrecordbuf;
                        var destbuffer_1 = 0; //指向 destbufferptr;

                        for (int v694 = 0; v694 < 4; v694++)
                        {
                            for (int index = 0; index < 4; index++)
                            {
                                outencryptdatabuf_temp[destbuffer_1 + 4 * index] = encryptrecordbuf[unkownresetdata_2 + index];
                            }
                            unkownresetdata_2 += 4;
                            destbuffer_1++;
                        }

                        Buffer.BlockCopy(outencryptdatabuf_temp, 0, outencryptdatabuf, i * 16, 16);
                        if (uncryptdatalen < 0x11) { break; }
                        //outencryptdatabuf_temp存放每一轮的加密结果
                        //Debug.WriteLine("第" + i + "轮加密结果:" + outencryptdatabuf_temp.Take(16).ToArray().ToString(16, 2));
                        uncryptdatalen -= 16;
                        xorivbuffer = destbuffer;
                        encryptdatabuf = encryptdatabuf.Skip(16).ToArray();
                        //outencryptdatabuf_temp = outencryptdatabuf_temp.Skip(16).ToArray();
                    }
                    return outencryptdatabuf;
                }
            }
            return null;
        }
    }
}