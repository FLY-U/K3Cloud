using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace K3Cloud.Utils
{
    public class StringUtil
    {
        /**/
        /// <summary>  
        /// 过滤字符  
        /// </summary>  

        public static string Replace(string strOriginal, string oldchar, string newchar)
        {
            if (string.IsNullOrEmpty(strOriginal))
                return "";
            string tempChar = strOriginal;
            tempChar = tempChar.Replace(oldchar, newchar);

            return tempChar;
        }
        /**/
        /// <summary>  
        /// 过滤非法字符  
        /// </summary>  
        /// <param name="str"></param>  
        /// <returns></returns>  
        public static string ReplaceBadChar(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            string strBadChar, tempChar;
            string[] arrBadChar;
            strBadChar = "@@,+,',--,%,^,&,?,(,),<,>,[,],{,},/,\\,;,:,\",\"\",";
            arrBadChar = SplitString(strBadChar, ",");
            tempChar = str;
            for (int i = 0; i < arrBadChar.Length; i++)
            {
                if (arrBadChar[i].Length > 0)
                    tempChar = tempChar.Replace(arrBadChar[i], "");
            }
            return tempChar;
        }
        /**/
        /// <summary>  
        /// 检查是否含有非法字符  
        /// </summary>  
        /// <param name="str">要检查的字符串</param>  
        /// <returns></returns>  
        public static bool ChkBadChar(string str)
        {
            bool result = false;
            if (string.IsNullOrEmpty(str))
                return result;
            string strBadChar, tempChar;
            string[] arrBadChar;
            strBadChar = "@@,+,',--,%,^,&,?,(,),<,>,[,],{,},/,\\,;,:,\",\"\"";
            arrBadChar = SplitString(strBadChar, ",");
            tempChar = str;
            for (int i = 0; i < arrBadChar.Length; i++)
            {
                if (tempChar.IndexOf(arrBadChar[i]) >= 0)
                    result = true;
            }
            return result;
        }
        /**/
        /// <summary>  
        /// 分割字符串  
        /// </summary>  
        public static string[] SplitString(string strContent, string strSplit)
        {
            if (string.IsNullOrEmpty(strContent))
            {
                return null;
            }
            int i = strContent.IndexOf(strSplit);
            if (strContent.IndexOf(strSplit) < 0)
            {
                string[] tmp = { strContent };
                return tmp;
            }
            //return Regex.Split(strContent, @strSplit.Replace(".", @"\."), RegexOptions.IgnoreCase);  

            return Regex.Split(strContent, @strSplit.Replace(".", @"\."));
        }

    }
}
