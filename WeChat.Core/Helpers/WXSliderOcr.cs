using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using WeChat.Core.Protocol.Protos;

namespace WeChat.Core
{
    public class WXSliderOcr
    {
        #region 全局变量
        /// <summary>
        /// UserAgent
        /// </summary>
        private string UserAgent { get; }

        /// <summary>
        /// 腾讯滑块业务场景
        /// </summary>
        private string AID { get; }

        /// <summary>
        /// 滑块SID
        /// </summary>
        private string SID { get; set; }

        /// <summary>
        /// 滑块SESS
        /// </summary>
        private string SESS { get; set; }

        /// <summary>
        /// 滑块X坐标
        /// </summary>
        private int POSTION_X { get; set; }

        /// <summary>
        /// 滑块Y坐标
        /// </summary>
        private int POSTION_Y { get; set; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public WXSliderOcr()
        {
            UserAgent = "Mozilla/5.0 (iPhone; CPU iPad iPhone OS 14.2.1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 MicroMessenger/7.0.18 (0x1700120B) NetType/4G Language/zh_CN";
        }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="aid">腾讯滑块业务场景</param>
        public WXSliderOcr(string aid) : this()
        {
            AID = aid;
        }
        #endregion

        #region 业务逻辑
        /// <summary>
        /// 滑块识别
        /// </summary>
        /// <param name="ranstr">滑块结果标识</param>
        /// <param name="ticket">滑块结果票据</param>
        /// <param name="msg">验证结果描述</param>
        /// <returns>识别状态 0成功,50失败,9过期,202异常,-1未知</returns>
        public int SliderOCR(out SliderResponse result)
        {
            result = new SliderResponse();
            result.Message = "滑块识别失败[未知错误]";
            try
            {
                //1.拉取滑块
                if (!Pull(out byte[] bigImg, out string pullMsg))
                {
                    result.Message = pullMsg;
                    return -1;
                }
                File.WriteAllBytes("d:/1.png", bigImg);
                Bitmap bitmap = BytesToBitmap(bigImg);
                //2.计算坐标
                GetXCoordinate(out int leftX, out int rightX, bitmap);
                POSTION_X = leftX - 24; //这里减24是因为块这个图有个边框，要减掉边框宽度

                //3.验证滑块
                SliderVerifyResult verifyResult = Verify();
                result.RandStr = verifyResult.randstr;
                result.Ticket = verifyResult.ticket;
                result.Message = verifyResult.errMessage;
                result.Status = verifyResult.errorCode;
                return verifyResult.errorCode;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                System.Diagnostics.Debug.WriteLine($"{ex.Message}\r\n{ex.StackTrace}");
                return -1;
            }
        }

        /// <summary>
        /// 滑块识别
        /// </summary>
        /// <param name="aid">腾讯滑块业务场景</param>
        /// <param name="ranstr">滑块结果标识</param>
        /// <param name="ticket">滑块结果票据</param>
        /// <param name="msg">验证结果描述</param>
        /// <returns>识别状态 0成功,50失败,9过期,202异常,-1未知</returns>
        public static int TrySliderOCR(string aid, out SliderResponse result)
        {
            WXSliderOcr slider = new WXSliderOcr(aid);
            return slider.SliderOCR(out result);
        }

        /// <summary>
        /// 拉取滑块
        /// </summary>
        /// <param name="bigImg"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private bool Pull(out byte[] bigImg, out string msg)
        {
            bigImg = default;
            msg = string.Empty;
            try
            {
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem
                {
                    URL = $"https://t.captcha.qq.com/cap_union_prehandle?aid={AID}&captype=7&curenv=inner&protocol=https&clientype=1&disturblevel=1&apptype=null&noheader=1&color=1AAD19&showtype=&fb=1&theme=&lang=2052&ua={UserAgent.Base64Encode()}&enableDarkMode=0&grayscale=1&cap_cd=&uid=&wxLang=&subsid=1&callback=_aq_834667&sess=",
                    UserAgent = UserAgent
                };
                string result = (http.GetHtml(item))?.Html ?? "";
                SID = result.Between("\"sid\":\"", "\"}");
                SESS = result.Between("\"sess\":\"", "\",\"randstr");
                if (string.IsNullOrEmpty(SID) || string.IsNullOrEmpty(SESS))
                {
                    msg = "拉取滑块失败";
                    return false;
                }
                item = new HttpItem
                {
                    URL = $"https://t.captcha.qq.com/cap_union_new_getsig",
                    UserAgent = UserAgent,
                    Method = "POST",
                    ContentType = "application/x-www-form-urlencoded",
                    Postdata = $"aid={AID}&captype=7&curenv=inner&protocol=https&clientype=1&disturblevel=1&apptype=null&noheader=1&color=1AAD19&showtype=&fb=1&theme=&lang=2052&ua={UserAgent.Base64Encode()}&enableDarkMode=0&grayscale=1&subsid=2&sess={SESS}&fwidth=0&sid={SID}&forcestyle=undefined&wxLang=&tcScale=1&uid=&cap_cd=&rnd=321653&TCapIframeLoadTime=20&prehandleLoadTime=57&rand=65773805"
                };
                item.Header.Add("content-type", "application/x-www-form-urlencoded");
                var ssss = http.GetHtml(item);
                result = ssss?.Html ?? "";
                SESS = result.Between("\"sess\":\"", "\",\"cdnPic1");
                POSTION_X = int.Parse(result.Between("\"initx\":\"", "\",\"inity"));
                POSTION_Y = int.Parse(result.Between("\"inity\":\"", "\"}"));
                item = new HttpItem
                {
                    URL = $"https://t.captcha.qq.com/cap_union_new_getcapbysig?aid={AID}&sess={SESS}&sid={SID}&img_index=1&subsid=6",
                    ResultType = ResultType.Byte
                };
                bigImg = http.GetHtml(item).ResultByte;
                if (bigImg?.Length > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                System.Diagnostics.Debug.WriteLine($"{ex.Message}\r\n{ex.StackTrace}");
            }
            return false;
        }

        /// <summary>
        /// 验证滑块
        /// </summary>
        /// <returns></returns>
        private SliderVerifyResult Verify()
        {
            SliderVerifyResult response = new SliderVerifyResult();
            try
            {

                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = "https://t.captcha.qq.com/cap_union_new_verify",
                    Method = "POST",
                    //Postdata = $"{{\"aid\":\"{AID}\",\"ua\":\"{UserAgent.Base64Encode()}\",\"subsid\":2,\"sess\":\"{SESS}\",\"sid\":\"{SID}\",\"ans\":\"{POSTION_X},{POSTION_Y};\"}}",
                    Postdata = $"aid={AID}&ua={UserAgent.Base64Encode()}&subsid=2&sess={SESS}&sid={SID}&ans={POSTION_X},{POSTION_Y};",
                    UserAgent = UserAgent,
                    ContentType = "application/x-www-form-urlencoded"
                };
                string result = (http.GetHtml(item))?.Html;
                if (string.IsNullOrEmpty(result))
                {
                    response.errorCode = 202;
                    response.errMessage = "滑块验证失败[返回null]";
                    return response;
                }
                response = result.ToJObject<SliderVerifyResult>();
                SESS = response.sess;
            }
            catch (Exception ex)
            {
                response.errorCode = -1;
                response.errMessage = $"滑块验证失败[{ex.Message}]";
                System.Diagnostics.Debug.WriteLine($"滑块验证失败,原因：{ex.Message}\r\n{ex.StackTrace}");
            }
            return response;
        }

        #endregion

        #region 滑块核心算法

        /// <summary>
        /// bytes转位图（.bmp）
        /// </summary>
        /// <param name="Bytes"></param>
        /// <returns></returns>
        private Bitmap BytesToBitmap(byte[] Bytes)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(Bytes))
                {
                    return (Bitmap)Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"{ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
        }

        /// <summary>
        /// 取两个点颜色的差异度
        /// 值越小，差异越小
        /// </summary>
        /// <param name="color1">颜色1</param>
        /// <param name="color2">颜色2</param>
        /// <returns></returns>
        private double PointColorDifferenceDegree(Color color1, Color color2)
        {
            double y1 = 0.299 * color1.R + 0.587 * color1.G + 0.114 * color1.B;
            double u1 = -0.14713 * color1.R - 0.28886 * color1.G + 0.436 * color1.B;
            double v1 = 0.615 * color1.R - 0.51498 * color1.G - 0.10001 * color1.B;

            double y2 = 0.299 * color2.R + 0.587 * color2.G + 0.114 * color2.B;
            double u2 = -0.14713 * color2.R - 0.28886 * color2.G + 0.436 * color2.B;
            double v2 = 0.615 * color2.R - 0.51498 * color2.G - 0.10001 * color2.B;

            return Math.Sqrt((y1 - y2) * (y1 - y2) + (u1 - u2) * (u1 - u2) + (v1 - v2) * (v1 - v2)); ;
        }

        /// <summary>
        /// 二值化(黑白模式)
        /// </summary>
        /// <param name="bitmap">位图数据</param>
        /// <param name="threshold">阀值</param>
        /// <returns></returns>
        private bool Binarization(Bitmap bitmap, int threshold)
        {
            //亮度
            int brightness = 0;
            LockBitmap lockbmp = new LockBitmap(bitmap);
            lockbmp.LockBits(); //锁定Bitmap
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    brightness = lockbmp.GetPixel(x, y).ToArgb() & 255;
                    if (brightness > threshold)
                    {
                        lockbmp.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        lockbmp.SetPixel(x, y, Color.Black);
                    }
                    Thread.Sleep(0);
                }
            }
            //从内存解锁Bitmap
            lockbmp.UnlockBits();
            return true;
        }

        /// <summary>
        /// 计算滑块X坐标
        /// </summary>
        /// <param name="leftX">定位到阴影块后返回块的左边X坐标</param>
        /// <param name="rightX">定位到阴影块后返回块的右边X坐标</param>
        /// <param name="bitmap">滑块背景图</param>
        /// <param name="shadow_width">验证码阴影快的宽度</param>
        /// <param name="threshold">将图片二值化时的阀值，默认150</param>
        /// <returns></returns>
        private bool GetXCoordinate(out int leftX, out int rightX, Bitmap bitmap, int shadow_width = 86, int threshold = 150)
        {
            leftX = 0;
            rightX = 0;
            int y = 0, lastX = 0, finalX, lastFinalX = 0, count = 0;
            Color currentColor, lastColor = Color.FromArgb(0, 0, 0);
            bool jump = false;
            //Binarization(bitmap, threshold);
            LockBitmap lockbmp = new LockBitmap(bitmap);
            lockbmp.LockBits(); //锁定Bitmap
            try
            {
                for (y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        currentColor = lockbmp.GetPixel(x, y);
                        if (PointColorDifferenceDegree(currentColor, lastColor) > 100)
                        {
                            int difference = x - lastX;
                            if (difference >= (shadow_width - 2) && shadow_width <= (shadow_width + 2))
                            {
                                finalX = lastX;
                                if (finalX == lastFinalX)
                                {
                                    count++;
                                    if (count > 5)
                                    {
                                        leftX = finalX;
                                        rightX = x - 1;
                                        jump = true;
                                        break;
                                    }
                                }
                                lastFinalX = finalX;
                            }
                            lastX = x;
                        }
                        lastColor = currentColor;
                    }
                    if (jump)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"{ex.Message}\r\n{ex.StackTrace}");
            }
            finally
            {
                //从内存解锁Bitmap
                lockbmp.UnlockBits();
            }
            if (y == bitmap.Width + 1 || leftX == 0)
            {
                return false;
            }
            return true;
        }
        #endregion
    }

    /// <summary>
    /// 识别结果模型
    /// </summary>
    public class SliderVerifyResult
    {
        /// <summary>
        /// 状态码
        /// 0：识别成功
        /// 9：滑块超时或已达错误上限2次
        /// 50：识别不准确
        /// 202：参数错误
        /// </summary>
        public int errorCode { get; set; }

        /// <summary>
        /// 滑块结果标识
        /// </summary>
        public string randstr { get; set; }

        /// <summary>
        /// 滑块结果票据
        /// </summary>
        public string ticket { get; set; }

        /// <summary>
        /// 验证结果描述
        /// </summary>
        public string errMessage { get; set; }

        /// <summary>
        /// 滑块SESS
        /// </summary>
        public string sess { get; set; }
    }

    /// <summary>
    /// Bitmap像素操作帮助
    /// </summary>
    public class LockBitmap
    {
        Bitmap source = null;
        IntPtr Iptr = IntPtr.Zero;
        BitmapData bitmapData = null;

        public byte[] Pixels { get; set; }
        public int Depth { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public LockBitmap(Bitmap source)
        {
            this.source = source;
        }

        /// <summary>
        /// Lock bitmap data
        /// </summary>
        public void LockBits()
        {
            try
            {
                // Get width and height of bitmap
                Width = source.Width;
                Height = source.Height;

                // get total locked pixels count
                int PixelCount = Width * Height;

                // Create rectangle to lock
                Rectangle rect = new Rectangle(0, 0, Width, Height);

                // get source bitmap pixel format size
                Depth = System.Drawing.Bitmap.GetPixelFormatSize(source.PixelFormat);

                // Check if bpp (Bits Per Pixel) is 8, 24, or 32
                if (Depth != 8 && Depth != 24 && Depth != 32)
                {
                    throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
                }

                // Lock bitmap and return bitmap data
                bitmapData = source.LockBits(rect, ImageLockMode.ReadWrite,
                                             source.PixelFormat);

                // create byte array to copy pixel values
                int step = Depth / 8;
                Pixels = new byte[PixelCount * step];
                Iptr = bitmapData.Scan0;

                // Copy data from pointer to array
                Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Unlock bitmap data
        /// </summary>
        public void UnlockBits()
        {
            try
            {
                // Copy data from byte array to pointer
                Marshal.Copy(Pixels, 0, Iptr, Pixels.Length);

                // Unlock bitmap data
                source.UnlockBits(bitmapData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Color GetPixel(int x, int y)
        {
            Color clr = Color.Empty;

            // Get color components count
            int cCount = Depth / 8;

            // Get start index of the specified pixel
            int i = ((y * Width) + x) * cCount;

            if (i > Pixels.Length - cCount)
                throw new IndexOutOfRangeException();

            if (Depth == 32) // For 32 bpp get Red, Green, Blue and Alpha
            {
                byte b = Pixels[i];
                byte g = Pixels[i + 1];
                byte r = Pixels[i + 2];
                byte a = Pixels[i + 3]; // a
                clr = Color.FromArgb(a, r, g, b);
            }
            if (Depth == 24) // For 24 bpp get Red, Green and Blue
            {
                byte b = Pixels[i];
                byte g = Pixels[i + 1];
                byte r = Pixels[i + 2];
                clr = Color.FromArgb(r, g, b);
            }
            if (Depth == 8)
            // For 8 bpp get color value (Red, Green and Blue values are the same)
            {
                byte c = Pixels[i];
                clr = Color.FromArgb(c, c, c);
            }
            return clr;
        }

        /// <summary>
        /// Set the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public void SetPixel(int x, int y, Color color)
        {
            // Get color components count
            int cCount = Depth / 8;

            // Get start index of the specified pixel
            int i = ((y * Width) + x) * cCount;

            if (Depth == 32) // For 32 bpp set Red, Green, Blue and Alpha
            {
                Pixels[i] = color.B;
                Pixels[i + 1] = color.G;
                Pixels[i + 2] = color.R;
                Pixels[i + 3] = color.A;
            }
            if (Depth == 24) // For 24 bpp set Red, Green and Blue
            {
                Pixels[i] = color.B;
                Pixels[i + 1] = color.G;
                Pixels[i + 2] = color.R;
            }
            if (Depth == 8)
            // For 8 bpp set color value (Red, Green and Blue values are the same)
            {
                Pixels[i] = color.B;
            }
        }
    }
}
