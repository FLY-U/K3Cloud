using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K3Cloud.Utils
{
    public class DateTimeUtil
    {
        #region DateTime类  
        /**/
        /// <summary>  
        /// 返回当前服务器时间的 yyyy-MM-dd 日期格式string    
        /// </summary>  
        public static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        /**/
        /// <summary>  
        ///返回当前服务器时间的标准时间格式string HH:mm:ss  
        /// </summary>  
        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
        /**/
        /// <summary>  
        /// 返回当前服务器时间的标准时间格式string yyyy-MM-dd HH:mm:ss  
        /// </summary>  
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /**/
        /// <summary>  
        /// 返回当前服务器时间的标准时间格式string yyyy-MM-dd HH:mm:ss:fffffff  
        /// </summary>  
        public static string GetDateTimeF()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        /**/
        /// <summary>  
        /// 将string类型的fDateTime转换为formatStr格式的日期类型  
        /// </summary>        
        public static string GetStandardDateTime(string fDateTime, string formatStr)
        {
            DateTime s = Convert.ToDateTime(fDateTime);
            return s.ToString(formatStr);
        }

        /**/
        /// <summary>  
        ///将string类型的fDateTime转换为日期类型 yyyy-MM-dd HH:mm:ss  
        /// </sumary>  
        public static string GetStandardDateTime(string fDateTime)
        {
            return GetStandardDateTime(fDateTime, "yyyy-MM-dd HH:mm:ss");
        }
        /**/
        /// <summary>  
        /// 返回相差的秒数  
        /// </summary>  
        /// <param name="Time"></param>  
        /// <param name="Sec"></param>  
        /// <returns></returns>  
        public static int StrDateDiffSeconds(string Time, int Sec)
        {
            TimeSpan ts = DateTime.Now - DateTime.Parse(Time).AddSeconds(Sec);
            if (ts.TotalSeconds > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (ts.TotalSeconds < int.MinValue)
            {
                return int.MinValue;
            }
            return (int)ts.TotalSeconds;
        }

        /**/
        /// <summary>  
        /// 返回相差的分钟数  
        /// </summary>  
        /// <param name="time"></param>  
        /// <param name="minutes"></param>  
        /// <returns></returns>  
        public static int StrDateDiffMinutes(string time, int minutes)
        {
            if (time == "" || time == null)
                return 1;
            TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddMinutes(minutes);
            if (ts.TotalMinutes > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (ts.TotalMinutes < int.MinValue)
            {
                return int.MinValue;
            }
            return (int)ts.TotalMinutes;
        }

        /**/
        /// <summary>  
        /// 返回相差的小时数  
        /// </summary>  
        /// <param name="time"></param>  
        /// <param name="hours"></param>  
        /// <returns></returns>  
        public static int StrDateDiffHours(string time, int hours)
        {
            if (time == "" || time == null)
                return 1;
            TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddHours(hours);
            if (ts.TotalHours > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (ts.TotalHours < int.MinValue)
            {
                return int.MinValue;
            }
            return (int)ts.TotalHours;
        }

        #endregion
    }
}
