// uncompr.cs -- decompress a memory buffer
// Copyright (C) 1995-2003, 2010 Jean-loup Gailly.
// Copyright (C) 2007-2011 by the Authors
// For conditions of distribution and use, see copyright notice in License.txt

namespace System.Zlib
{
    public static partial class zlib
    {
        //   The following utility functions are implemented on top of the
        // basic stream-oriented functions. To simplify the interface, some
        // default options are assumed (compression level and memory usage,
        // standard memory allocation functions). The source code of these
        // utility functions can easily be modified if you need special options.

        // ===========================================================================
        //   Decompresses the source buffer into the destination buffer.  sourceLen is
        // the byte length of the source buffer. Upon entry, destLen is the total
        // size of the destination buffer, which must be large enough to hold the
        // entire uncompressed data. (The size of the uncompressed data must have
        // been saved previously by the compressor and transmitted to the decompressor
        // by some mechanism outside the scope of this compression library.)
        // Upon exit, destLen is the actual size of the compressed buffer.
        //
        //   uncompress returns Z_OK if success, Z_MEM_ERROR if there was not
        // enough memory, Z_BUF_ERROR if there was not enough room in the output
        // buffer, or Z_DATA_ERROR if the input data was corrupted.

        public static int uncompress(byte[] dest, ref uint destLen, byte[] source, uint sourceLen, uint sourceOffset = 0, uint destOffset = 0)
        {
            z_stream stream = new z_stream();

            stream.in_buf = source;
            stream.next_in = sourceOffset;
            stream.avail_in = sourceLen;
            // Check for source > 64K on 16-bit machine:
            if (stream.avail_in != sourceLen) return Z_BUF_ERROR;

            stream.out_buf = dest;
            stream.next_out = (int)destOffset;
            stream.avail_out = destLen;
            if (stream.avail_out != destLen) return Z_BUF_ERROR;

            int err = inflateInit(stream);
            if (err != Z_OK) return err;

            err = inflate(stream, Z_FINISH);
            if (err != Z_STREAM_END)
            {
                inflateEnd(stream);
                if (err == Z_NEED_DICT || (err == Z_BUF_ERROR && stream.avail_in == 0)) return Z_DATA_ERROR;
                return err;
            }
            destLen = stream.total_out;

            err = inflateEnd(stream);
            return err;
        }
    }
}
