using Kingdee.BOS.Core.Bill.PlugIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingdee.BOS.Core.DynamicForm.PlugIn.Args;
using Kingdee.BOS.Orm.DataEntity;
using Kingdee.BOS.ServiceHelper;

using System.Data;

namespace K3Cloud.Bill
{
    public class MyAbstractBillPlugIn: AbstractBillPlugIn//引入金蝶Kingdee.BOS.Core里的类AbstractBillPlugIn
    {
        StringBuilder str = new StringBuilder();//使用StringBuilder 拼接字符串
        public override void ButtonClick(ButtonClickEventArgs e)//重写ButtonClick方法
        {
            base.ButtonClick(e);
            switch (e.Key.ToUpper())//获取按钮的标识，并将按钮转为大写
            {
                case "BUTTON_NAME":
                    /*
                     将按钮标识转为大写，并在case块中处理逻辑，如果不符合条件则通过e.Cancel = true;方法取消按钮点击。
                     */
                    e.Cancel = true;
                    #region 字段的取值赋值
                    //获取普通字段的值
                    this.View.Model.GetValue("字段标识");
                    //三元式写法
                    string fbillno = this.View.Model.GetValue("FBillNo") == null ? "" : this.View.Model.GetValue("FBillNo").ToString();
                    //获取基础资料的ID的值,其中DynamicObject引入自Kingdee.BOS.Orm.DataEntity包
                    int FID = Convert.ToInt32((this.View.Model.GetValue("基础资料字段标识") as DynamicObject)["ID"]);
                    //获取基础资料的NAME的值,其中DynamicObject引入自Kingdee.BOS.Orm.DataEntity包
                    String NAME = (this.View.Model.GetValue("基础资料字段标识") as DynamicObject)["Name"].ToString();
                    /*
                     *其他基础资料属性同样的用法，只是数组里输入的不同的属性字段标识即可
                     */
                    #endregion
                    #region 界面提示框
                    //界面弹出提示框功能
                    this.View.ShowMessage("消息内容");
                    //界面弹出错误提示框内容,需要传三个参数1.msg 错误消息内容 2.title 错误简短标题 3.错误类型，总共有Advise、AskOK、AskYes、Error、Notice
                    //this.View.ShowErrMessage("错误内容","错误标题",Kingdee.BOS.Core.DynamicForm.MessageBoxType.Error);
                    #endregion
                    #region 执行数据库操作
                    str.Clear();//清除内容
                    str.Append("SELECT * FROM TABLE");//添加SQL语句，可以是存储过程
                    using (IDataReader reader = DBServiceHelper.ExecuteReader(this.View.Context, str.ToString()))
                    {
                        while (reader.Read())
                        {
                            /*
                            通过reader[0] 通过数组下标的方式
                            通过reader["SQL中的字段名"]方式
                            获取数据库中的数据，并将获取的数据赋值到变量里  
                         */
                        }
                    }
                    #endregion
                    break;
            }
        }
    }
}
