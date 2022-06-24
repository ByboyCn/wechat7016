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
                //������ܷ�ʽ��03 ���߼��ܷ�ʽ��05 //������ܷ�ʽ�ݲ�֧��
                //��ֵ��0x3060,�ض��������ѭ��
                encryptdatalen = 16 - (srcbuffersize & 0xF) + srcbuffersize;
                encryptdatabuf = new byte[encryptdatalen];
                //������һ�μ�������Ժ�Ĵ�С�ڴ�
                Buffer.BlockCopy(srcbuffer, 0, encryptdatabuf, 0, srcbuffer.Length);
                //�������0x10���������ͺ��油��
                if (16 != (srcbuffersize & 0xF))
                {
                    for (int i = srcbuffersize; i < encryptdatalen; i++)
                    {
                        encryptdatabuf[i] = (byte)(16 - (srcbuffersize & 0xF));
                    }
                }
                //����һ��ͬ����С���ڴ���Ϊ��ѯ����
                outencryptdatabuf = new byte[encryptdatalen];
                //����һ��0x10���ڴ����м���ܻ�����
                if (encryptdatalen != 0)
                {
                    byte[] xorivbuffer = _sae.IV;                //������IV����xor
                    int uncryptdatalen = encryptdatalen; //���ж���û�м���
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
                        //�������
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
                        //Debug.WriteLine("��һ�������:" + outencryptdatabuf_temp.Take(16).ToArray().ToString(16, 2));
                        //�����м任����
                        //Debug.WriteLine("�м任�㿪ʼ:{0},�����:{1}", encryptrecordbuf.Take(16).ToArray().ToString(16, 2), outencryptdatabuf_temp.Take(16).ToArray().ToString(16, 2));
                        var outencryptdatabuf_temp_record = outencryptdatabuf_temp; //�����
                        var encryptrecordbuf_temp = encryptrecordbuf;               //ָ���м任��

                        for (int temprecordindex = 0; temprecordindex < 4; temprecordindex++)
                        {
                            for (int localindex2 = 0; localindex2 < 4; localindex2++)
                            {
                                encryptrecordbuf_temp[temprecordindex * 4 + localindex2] = outencryptdatabuf_temp_record[4 * localindex2];
                            }
                            //encryptrecordbuf_temp = encryptrecordbuf_temp.Skip(4).ToArray();
                            outencryptdatabuf_temp_record = outencryptdatabuf_temp_record.Skip(1).ToArray();
                        }
                        //Debug.WriteLine("�м任�����:" + encryptrecordbuf.Take(16).ToArray().ToString(16, 2));

                        destbufferptr = outencryptdatabuf_temp;
                        WCAES.Shiftrows(ref encryptrecordbuf); //����λ
                                                               //Debug.WriteLine("�м任����λ:" + encryptrecordbuf.Take(16).ToArray().ToString(16, 2));
                        var indexstep = 0xFFFDC000;
                        var psaedattablekey = 0;   //saedattablekey
                        var psaedattablevalue = 0; // saedattablevalue

                        for (int ix = 0; ix < 9; ix++)
                        {
                            //Debug.WriteLine("��Կ��չǰ:"+sectable.ToString(16, 2) + "," + encryptrecordbuf.ToString(16, 2));
                            WCAES.getsectable(sectable, ref encryptrecordbuf, _sae.tablekey, psaedattablekey); // ��Կ��չ    ������ֻ�ı�sectable
                            //Debug.WriteLine("��Կ��չ��:"+sectable.ToString(16, 2) + "," + encryptrecordbuf.ToString(16, 2));
                            //Debug.WriteLine("��Կ��չǰ:" + sectable.ToString(16, 2) + "," + encryptrecordbuf.ToString(16, 2));
                            WCAES.getsecvalue(ref encryptrecordbuf, sectable, _sae.tablevalue, psaedattablevalue); //������ֻ�ı�ecnryptrecordbuf
                            //Debug.WriteLine("��Կ��չ��:" + sectable.ToString(16, 2) + "," + encryptrecordbuf.ToString(16, 2));
                            WCAES.Shiftrows(ref encryptrecordbuf); //����λ
                            psaedattablevalue += 0x3000;
                            indexstep += 0x4000;
                            psaedattablekey = psaedattablekey + 0x4000;
                        }
                        //Debug.WriteLine("��Կ��չ����");
                        //Debug.WriteLine("�м任��Finalǰ:" + encryptrecordbuf.ToString(16, 2));
                        WCAES.getsecvaluefinal(ref encryptrecordbuf, _sae.unkown18); //���һ�μ���
                        //Debug.WriteLine("�м任��Final��:"+ encryptrecordbuf.ToString(16, 2));

                        destbuffer = destbufferptr;
                        var unkownresetdata_2 = 0; // encryptrecordbuf;
                        var destbuffer_1 = 0; //ָ�� destbufferptr;

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
                        //outencryptdatabuf_temp���ÿһ�ֵļ��ܽ��
                        //Debug.WriteLine("��" + i + "�ּ��ܽ��:" + outencryptdatabuf_temp.Take(16).ToArray().ToString(16, 2));
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