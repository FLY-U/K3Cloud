using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace K3Cloud.Utils
{
    public class CheckFieldTypeUtil
    {
        /**/
        /// <summary>  
        /// 判断给定的字符串(strNumber)是否是数值型  
        /// </summary>  
        /// <param name="strNumber">要确认的字符串</param>  
        /// <returns>是则返加true 不是则返回 false</returns>  
        public static bool IsNumber(string strNumber)
        {
            return new Regex(@"^([0-9])[0-9]*(\.\w*)?$").IsMatch(strNumber);
        }


        /**/
        /// <summary>  
        /// 检测是否符合email格式  
        /// </summary>  
        /// <param name="strEmail">要判断的email字符串</param>  
        /// <returns>判断结果</returns>  
        public static bool IsValidEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^([\w-\.]+)@((
[0−9]1,3\.[0−9]1,3\.[0−9]1,3\.)|(([\w−]+\.)+))([a−zA−Z]2,4|[0−9]1,3)(
[0−9]1,3\.[0−9]1,3\.[0−9]1,3\.)|(([\w−]+\.)+))([a−zA−Z]2,4|[0−9]1,3)(
?)$");
        }


        /**/
        /// <summary>  
        /// 检测是否符合url格式,前面必需含有http://  
        /// </summary>  
        /// <param name="url"></param>  
        /// <returns></returns>  
        public static bool IsURL(string url)
        {
            return Regex.IsMatch(url, @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$");
        }

        /**/
        /// <summary>  
        /// 检测是否符合电话格式  
        /// </summary>  
        /// <param name="phoneNumber"></param>  
        /// <returns></returns>  
        public static bool IsPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^(\d3\d3|\d{3}-)?\d{7,8}$");
        }



        /**/
        /// <summary>  
        /// 检测是否符合身份证号码格式  
        /// </summary>  
        /// <param name="num"></param>  
        /// <returns></returns>  
        public static bool IsIdentityNumber(string num)
        {
            return Regex.IsMatch(num, @"^\d{17}[\d|X]|\d{15}$");
        }

    }
}
