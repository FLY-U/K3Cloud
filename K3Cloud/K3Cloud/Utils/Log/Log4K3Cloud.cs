using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K3Cloud.Utils.Log
{
    /// <summary>
    /// K3Cloud记录日志类
    /// </summary>
    public class Log4K3Cloud
    {
        #region  记录日志方法
        /// <summary>
        /// 记录日志方法
        /// </summary>
        /// <param name="ClassName">类名</param>
        /// <param name="ModelInfo">正确或错误实质信息</param>
        /// <param name="WhetherError">是否错误 例: false为错误信息，true为正确信息</param>
        public void RecordLogMethod(string ClassName, string ModelInfo, bool WhetherError)
        {
            FileModel model = new FileModel();
            if (!string.IsNullOrEmpty(ClassName))
            {
                if (WhetherError)
                {
                    model.Url = @"D:\Log4K3Cloud\" + ClassName;
                    model.FileName = "\\" + ClassName + DateTime.Now.ToString("yyyy-MM");
                    model.TxtName = "\\" + ClassName + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                    model.AppendContent = "SuccessInfo:" + ModelInfo + "\r\n" + " ///***********正确信息***********/// " + "\r\n";
                }
                else
                {

                    model.Url = @"D:\Log4K3Cloud\" + ClassName;
                    model.FileName = "\\" + ClassName + "Error" + DateTime.Now.ToString("yyyy-MM");
                    model.TxtName = "\\" + ClassName + "Error" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                    model.AppendContent = "Error:" + ModelInfo + "\r\n" + " ///***********错误信息***********/// " + "\r\n";
                }
                CreateDirectory(model);
            }

        }
        #endregion

        #region 记录日志方法加分隔时间
        /// <summary>
        /// 记录日志方法
        /// </summary>
        /// <param name="ClassName">类名</param>
        /// <param name="ModelInfo">正确或错误实质信息</param>
        /// <param name="WhetherError">是否错误 例: false为错误信息，true为正确信息</param>
        /// <param name="Time">时间,txt文本生成时间以小时为单位可传入多个时间，以分号隔开   例 12;15;20</param>
        public void RecordLogMethod(string ClassName, string ModelInfo, bool WhetherError, string Time)
        {
            FileModel model = new FileModel();
            if (!string.IsNullOrEmpty(ClassName))
            {
                if (WhetherError)
                {
                    model.Url = @"D:\Log4K3Cloud\" + ClassName + "\\" + ClassName + DateTime.Now.ToString("yyyy-MM");
                    model.FileName = "\\" + ClassName + DateTime.Now.ToString("yyyy-MM");
                    foreach (string item in DelimiterStr(Time))
                    {
                        model.TxtName = DateTime.Now.Hour.ToString() == item.ToString() ? "\\" + ClassName + DateTime.Now.ToString("yyyy-MM-dd") + item.ToString() + ".txt" : "\\" + ClassName + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                    }
                    model.AppendContent = " ///***********正确信息***********/// " + "\r\n" + "SuccessInfo:" + ModelInfo + "\r\n";
                }
                else
                {
                    model.Url = @"D:\Log4K3Cloud\" + ClassName + "\\" + ClassName + "Error" + DateTime.Now.ToString("yyyy-MM");
                    model.FileName = "\\" + ClassName + "Error" + DateTime.Now.ToString("yyyy-MM");
                    foreach (string item in DelimiterStr(Time))
                    {
                        model.TxtName = DateTime.Now.Hour.ToString() == item.ToString() ? "\\" + ClassName + "Error" + DateTime.Now.ToString("yyyy-MM-dd") + item.ToString() + ".txt" : "\\" + ClassName + "Error" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                    }
                    model.AppendContent = " ///***********错误信息***********/// " + "\r\n" + "Error:" + ModelInfo + "\r\n";
                }
                CreateDirectory(model);
            }

        }
        #endregion

        #region 创建文件目录公共方法
        /// <summary>
        /// 创建文件目录公共方法
        /// </summary>
        /// <param name="Model">实体类</param>
        void CreateDirectory(FileModel Model)
        {
            if (!FileHelper.IsExistDirectory(Model.Url + Model.FileName))//@"D:\Log4K3Cloud\ImplementationPlan" + DateTime.Now.ToString("yyyy-MM")
            {
                FileHelper.CreateDirectory(Model.Url + Model.FileName);//@"D:\Log4K3Cloud\ImplementationPlan" + DateTime.Now.ToString("yyyy-MM")

                CreateFile(Model);
            }
            else
            {
                CreateFile(Model);
            }
        }
        #endregion

        #region 创建文件并且追加信息
        /// <summary>
        /// 创建文件并且追加错误信息
        /// </summary>
        /// <param name="Error">错误信息</param>
        void CreateFile(FileModel Model)
        {
            if (!FileHelper.IsExistFile(Model.Url + Model.FileName + Model.TxtName))//文本名DateTime.Now.ToString("yyyy-MM-dd").txt
            {
                FileHelper.CreateFile(Model.Url + Model.FileName + Model.TxtName);
                FileHelper.AppendText((Model.Url + Model.FileName + Model.TxtName), Model.AppendContent.ToString());
            }
            else
                FileHelper.AppendText((Model.Url + Model.FileName + Model.TxtName), Model.AppendContent.ToString());
        }
        #endregion

        #region 分隔字符串方法
        string[] DelimiterStr(string Time)
        {
            string[] arr = null;
            if (!string.IsNullOrEmpty(Time))
                arr = Time.Split(';');
            else
                arr = null;
            return arr;
        }
        #endregion

    }
    public class FileModel
    {
        public string Url { get; set; }
        public string FileName { get; set; }
        public string TxtName { get; set; }
        public string AppendContent { get; set; }
    }
}
