using System;
using System.Collections.Generic;
using System.Linq;

namespace WeChat.Core
{
    public class PackOperate
    {
        private readonly List<byte> packList;

        /// <summary>
        /// 字节数组
        /// </summary>
        public byte[] Array {
            get {
                return packList.ToArray();
            }
        }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length {
            get {
                return packList.Count;
            }
        }

        public PackOperate(byte[] data = null)
        {
            if(data != null) {
                packList = data.ToList();
            } else {
                packList = new List<byte>();
            }
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            packList.Clear();
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public byte[] GetBytes(int index = 0,int count = 1)
        {
            return packList.Skip(index).Take(count).ToArray();
        }

        /// <summary>
        /// 获取并删除值
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public byte[] CutBytes(int index = 0,int count = 1)
        {
            var data = GetBytes(index,count);
            packList.RemoveRange(index,count);
            return data;
        }

        /// <summary>
        /// 获取字节
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public byte GetByte(int index = 0)
        {
            return packList[index];
        }

        /// <summary>
        /// 获取并删除字节
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public byte CutByte(int index = 0)
        {
            byte num = packList[index];
            packList.RemoveAt(index);
            return num;
        }

        /// <summary>
        /// 尾部插入字节数组
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public PackOperate SetBytes(byte[] data)
        {
            packList.AddRange(data);
            return this;
        }

        /// <summary>
        /// 尾部插入字节
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public PackOperate SetByte(byte data)
        {
            packList.Add(data);
            return this;
        }

        /// <summary>
        /// 拆入Int（2字节）
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public PackOperate SetWord(ushort num)
        {
            packList.AddRange(BitConverter.GetBytes(num).Reverse());
            return this;
        }

        /// <summary>
        /// 拆入Int（4字节）
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public PackOperate SetDword(int num)
        {
            packList.AddRange(BitConverter.GetBytes(num).Reverse());
            return this;
        }

        /// <summary>
        /// 拆入Int（4字节）
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public PackOperate SetDword(uint num)
        {
            packList.AddRange(BitConverter.GetBytes(num).Reverse());
            return this;
        }

        /// <summary>
        /// 插入Token（2字节）
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public PackOperate SetWordToken(byte[] bytes)
        {
            if(bytes != null) {
                SetWord((ushort)bytes.Length);
                SetBytes(bytes);
            }
            return this;
        }

        /// <summary>
        /// 插入Token（2字节）
        /// </summary>
        /// <param name="operate"></param>
        /// <returns></returns>
        public PackOperate SetWordToken(PackOperate operate)
        {
            return SetWordToken(operate.Array);
        }

        /// <summary>
        /// 插入Token（4字节）
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public PackOperate SetDwordToken(byte[] bytes)
        {
            if(bytes != null) {
                SetDword(bytes.Length);
                SetBytes(bytes);
            }

            return this;
        }

        /// <summary>
        /// 插入Token（4字节）
        /// </summary>
        /// <param name="operate"></param>
        /// <returns></returns>
        public PackOperate SetDwordToken(PackOperate operate)
        {
            return SetDwordToken(operate.Array);
        }

        /// <summary>
        /// 获取Token长度
        /// </summary>
        /// <returns></returns>
        public int CountToken(int index = 0)
        {
            var buffers = GetBytes(3 + index,2);
            short count = (short)((buffers[0] << 8) + buffers[1]);
            return count;
        }

        /// <summary>
        /// 获取Token长度
        /// </summary>
        /// <returns></returns>
        public int CountToken(uint index = 0)
        {
            var buffers = GetBytes(3 + (int)index,2);
            short count = (short)((buffers[0] << 8) + buffers[1]);
            return count;
        }

        ///// <summary>
        ///// 计算总长度
        ///// </summary>
        ///// <returns></returns>
        //public int CountLength()
        //{
        //    var length = 0;

        //    try
        //    {
        //        var head = CutBytes(0, 3);
        //        if (head[0] == 0x16 || head[0] == 0x17)
        //        {
        //            var tokenLen = (int)CutBytes(0, 2).GetUInt16(Endian.Big);
        //            try
        //            {
        //                var token = CutBytes(0, tokenLen);
        //                if (Length > 0)
        //                {
        //                    length += CountLength();
        //                }
        //            }
        //            catch { }

        //            length += tokenLen + 5;
        //        }
        //        else
        //        {
        //            length += Length + 3;
        //        }
        //    }
        //    catch { }

        //    return length;
        //}

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <returns></returns>
        public byte[] GetToken()
        {
            var buffers = GetBytes(0,2);
            short count = (short)((buffers[0] << 8) + buffers[1]);
            return GetBytes(0,count);
        }

        /// <summary>
        /// 获取并删除Token
        /// </summary>
        /// <returns></returns>
        public byte[] CutToken()
        {
            var buffers = GetBytes(0,2);
            int count = (buffers[0] << 8) + buffers[1];

            if(Array.Length >= count + 2) {
                CutBytes(0,2);
                return CutBytes(0,count);
            } else {
                return null;
            }
        }

        /// <summary>
        /// 获取所有Token，并删除
        /// </summary>
        /// <returns></returns>
        public List<byte[]> CutTokens()
        {
            var tokenList = new List<byte[]>();

            var flag = CutBytes(0,3);
            if(flag[0] == 0x16 || flag[0] == 0x17 || flag[0] == 0x15 || flag[0] == 0x19) {
                var token = CutToken();
                if(token != null) {
                    tokenList.Add(token);

                    if(Length > 0) {
                        tokenList.AddRange(CutTokens());
                    }
                }
            }

            return tokenList;
        }

        public List<Token> GetTokens()
        {
            var tokens = new List<Token>();

            var type = CutBytes(0,3);
            var body = CutToken();

            var token = new Token {
                Type = type[0],
                Length = body.Length,
                Body = body
            };

            tokens.Add(token);

            if(Length > 0) {
                tokens.AddRange(GetTokens());
            }

            return tokens;
        }

        public class Token
        {
            public byte Type { get; set; }

            public int Length { get; set; }

            public byte[] Body { get; set; }
        }
    }
}