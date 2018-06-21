using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace K3Cloud.Utils
{
    public class SqlUtil
    {
        #region Sql类  

        /**/
        /// <summary>  
        /// 检测是否有Sql危险字符  
        /// </summary>  
        /// <param name="str">要判断字符串</param>  
        /// <returns>判断结果</returns>  
        public static bool IsSafeSqlString(string str)
        {

            return !Regex.IsMatch(str, @"[-|;|,|\/||||
|
|
|\}|\{|%|@|\*|!|\']");
        }


        /**/
        /// <summary>  
        /// 替换sql语句中的单引号  
        /// </summary>  
        public static string ReplaceBadSQL(string str)
        {
            string str2;

            if (str == null)
            {
                str2 = "";
            }
            else
            {
                str = str.Replace("'", "''");
                str2 = str;
            }
            return str2;
        }



        #endregion
    }
}
