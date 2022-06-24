namespace System
{
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// 转换成时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int ToTimeStamp(this DateTime time)
        {
            return Convert.ToInt32(time.Subtract(DateTime.Parse("1970-1-1")).TotalSeconds);
        }

        public static DateTime ToDateTime(this int timestamp)
        {
            return TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Utc).AddTicks(timestamp * 10000000);
        }
    }
}
