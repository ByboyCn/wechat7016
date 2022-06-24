using System.Threading.Tasks;
using System.Zlib;

namespace System.IO
{
    public static partial class StreamExtensions
    {
        /// <summary>
        /// ZIP压缩
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Stream ZIPCompress(this Stream source)
        {
            MemoryStream result = new MemoryStream();
            ZStreamWriter output = new ZStreamWriter(result);
            source.CopyToStream(output);
            output.WriteToEnd();
            return result;
        }

        /// <summary>
        /// ZIP解压
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Stream ZIPDECompress(this Stream source)
        {
            MemoryStream result = new MemoryStream();
            ZLibStreamReader output = new ZLibStreamReader(source);
            output.CopyToStream(result);
            return result;
        }

        public static byte[] ToBuffer(this Stream sm)
        {
            sm.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[sm.Length];
            sm.Read(buffer, 0, buffer.Length);
            sm.Seek(0, SeekOrigin.Begin);
            return buffer;
        }

        public static async Task<byte[]> ToBufferAsync(this Stream sm)
        {
            sm.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[sm.Length];
            await sm.ReadAsync(buffer, 0, buffer.Length);
            sm.Seek(0, SeekOrigin.Begin);
            return buffer;
        }

        /// <summary>
        /// 拷贝Stream
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void CopyToStream(this Stream source, Stream target)
        {
            int num;
            byte[] buffer = new byte[2048];
            while ((num = source.Read(buffer, 0, 2048)) > 0) { target.Write(buffer, 0, num); }
            target.Flush();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static bool ReadBoolean(this Stream stream)
        {
            return stream.ReadByte() == 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="endian"></param>
        /// <returns></returns>
        public static char ReadChar(this Stream stream, Endian endian)
        {
            return (char)stream.ReadUInt16(endian);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="endian"></param>
        /// <returns></returns>
        public static short ReadInt16(this Stream stream, Endian endian)
        {
            return (short)stream.ReadUInt16(endian);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="endian"></param>
        /// <returns></returns>
        public static ushort ReadUInt16(this Stream stream, Endian endian)
        {
            if (endian == Endian.Little)
            {
                return (ushort)(stream.ReadByte() | (stream.ReadByte() << 8));
            }
            return (ushort)((stream.ReadByte() << 8) | stream.ReadByte());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="endian"></param>
        /// <returns></returns>
        public static int ReadInt32(this Stream stream, Endian endian)
        {
            return (int)stream.ReadUInt32(endian);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="endian"></param>
        /// <returns></returns>
        public static uint ReadUInt32(this Stream stream, Endian endian)
        {
            if (endian == Endian.Little)
            {
                return (uint)(stream.ReadUInt16(endian) | (stream.ReadUInt16(endian) << 16));
            }
            return (uint)((stream.ReadUInt16(endian) << 16) | stream.ReadUInt16(endian));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="endian"></param>
        /// <returns></returns>
        public static long ReadInt64(this Stream stream, Endian endian)
        {
            return (long)stream.ReadUInt64(endian);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="endian"></param>
        /// <returns></returns>
        public static ulong ReadUInt64(this Stream stream, Endian endian)
        {
            if (endian == Endian.Little)
            {
                return stream.ReadUInt32(endian) | ((ulong)stream.ReadUInt32(endian) << 32);
            }
            return ((ulong)stream.ReadUInt32(endian) << 32) | stream.ReadUInt32(endian);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static byte[] ReadBytes(this Stream stream, int count)
        {
            byte[] array = new byte[count];
            int num;
            for (int i = 0; i < array.Length; i += num)
            {
                num = stream.Read(array, i, array.Length - i);
                if (num == 0)
                {
                    return array.Resize(i);
                }
            }
            return array;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="endian"></param>
        /// <returns></returns>
        public unsafe static float ReadSingle(this Stream stream, Endian endian)
        {
            uint num = stream.ReadUInt32(endian);
            return *(float*)(&num);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="endian"></param>
        /// <returns></returns>
        public unsafe static double ReadDouble(this Stream stream, Endian endian)
        {
            ulong num = stream.ReadUInt64(endian);
            return *(double*)(&num);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        public static void Write(this Stream stream, bool value)
        {
            stream.WriteByte((byte)(value ? 1 : 0));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        public static void Write(this Stream stream, byte value)
        {
            stream.WriteByte(value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        /// <param name="endian"></param>
        public static void Write(this Stream stream, char value, Endian endian)
        {
            stream.Write((ushort)value, endian);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        /// <param name="endian"></param>
        public static void Write(this Stream stream, short value, Endian endian)
        {
            stream.Write((ushort)value, endian);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        /// <param name="endian"></param>
        public static void Write(this Stream stream, ushort value, Endian endian)
        {
            if (endian == Endian.Little)
            {
                stream.WriteByte((byte)value);
                stream.WriteByte((byte)(value >> 8));
            }
            else
            {
                stream.WriteByte((byte)(value >> 8));
                stream.WriteByte((byte)value);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        /// <param name="endian"></param>
        public static void Write(this Stream stream, int value, Endian endian)
        {
            stream.Write((uint)value, endian);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        /// <param name="endian"></param>
        public static void Write(this Stream stream, uint value, Endian endian)
        {
            if (endian == Endian.Little)
            {
                stream.WriteByte((byte)value);
                stream.WriteByte((byte)(value >> 8));
                stream.WriteByte((byte)(value >> 16));
                stream.WriteByte((byte)(value >> 24));
            }
            else
            {
                stream.WriteByte((byte)(value >> 24));
                stream.WriteByte((byte)(value >> 16));
                stream.WriteByte((byte)(value >> 8));
                stream.WriteByte((byte)value);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        /// <param name="endian"></param>
        public static void Write(this Stream stream, long value, Endian endian)
        {
            stream.Write((ulong)value, endian);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        /// <param name="endian"></param>
        public static void Write(this Stream stream, ulong value, Endian endian)
        {
            if (endian == Endian.Little)
            {
                stream.WriteByte((byte)value);
                stream.WriteByte((byte)(value >> 8));
                stream.WriteByte((byte)(value >> 16));
                stream.WriteByte((byte)(value >> 24));
                stream.WriteByte((byte)(value >> 32));
                stream.WriteByte((byte)(value >> 40));
                stream.WriteByte((byte)(value >> 48));
                stream.WriteByte((byte)(value >> 56));
            }
            else
            {
                stream.WriteByte((byte)(value >> 56));
                stream.WriteByte((byte)(value >> 48));
                stream.WriteByte((byte)(value >> 40));
                stream.WriteByte((byte)(value >> 32));
                stream.WriteByte((byte)(value >> 24));
                stream.WriteByte((byte)(value >> 16));
                stream.WriteByte((byte)(value >> 8));
                stream.WriteByte((byte)value);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        /// <param name="endian"></param>
        public unsafe static void Write(this Stream stream, float value, Endian endian)
        {
            stream.Write(*(uint*)(&value), endian);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        /// <param name="endian"></param>
        public unsafe static void Write(this Stream stream, double value, Endian endian)
        {
            stream.Write((ulong)(*(long*)(&value)), endian);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="bytes"></param>
        public static void Write(this Stream stream, byte[] bytes)
        {
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}
