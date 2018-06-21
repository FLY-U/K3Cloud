using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace K3Cloud.Utils
{
    public class ConvertUtil
    {
        /**/
        /// <summary>  
        /// string型转换为int型  
        /// </summary>  
        /// <param name="strValue">要转换的字符串</param>  
        /// <returns>转换后的int类型结果.如果要转换的字符串是非数字,则返回-1.</returns>  
        public static int StrToInt(object strValue)
        {
            int defValue = -1;
            if ((strValue == null) || (strValue.ToString() == string.Empty) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }

            string val = strValue.ToString();
            string firstletter = val[0].ToString();

            if (val.Length == 10 && IsNumber(firstletter) && int.Parse(firstletter) > 1)
            {
                return defValue;
            }
            else if (val.Length == 10 && !IsNumber(firstletter))
            {
                return defValue;
            }


            int intValue = defValue;
            if (strValue != null)
            {
                bool IsInt = new Regex(@"^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString());
                if (IsInt)
                {
                    intValue = Convert.ToInt32(strValue);
                }
            }

            return intValue;
        }
        /**/
        /// <summary>  
        /// string型转换为int型  
        /// </summary>  
        /// <param name="strValue">要转换的字符串</param>  
        /// <param name="defValue">缺省值</param>  
        /// <returns>转换后的int类型结果</returns>  
        public static int StrToInt(object strValue, int defValue)
        {
            if ((strValue == null) || (strValue.ToString() == string.Empty) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }

            string val = strValue.ToString();
            string firstletter = val[0].ToString();

            if (val.Length == 10 && IsNumber(firstletter) && int.Parse(firstletter) > 1)
            {
                return defValue;
            }
            else if (val.Length == 10 && !IsNumber(firstletter))
            {
                return defValue;
            }


            int intValue = defValue;
            if (strValue != null)
            {
                bool IsInt = new Regex(@"^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString());
                if (IsInt)
                {
                    intValue = Convert.ToInt32(strValue);
                }
            }

            return intValue;
        }
        /**/
        /// <summary>  
        /// string型转换为时间型  
        /// </summary>  
        /// <param name="strValue">要转换的字符串</param>  
        /// <param name="defValue">缺省值</param>  
        /// <returns>转换后的时间类型结果</returns>  
        public static DateTime StrToDateTime(object strValue, DateTime defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 20))
            {
                return defValue;
            }

            DateTime intValue;

            if (!DateTime.TryParse(strValue.ToString(), out intValue))
            {
                intValue = defValue;
            }
            return intValue;
        }
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

    }
}
