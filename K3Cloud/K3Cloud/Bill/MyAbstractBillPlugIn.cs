using Kingdee.BOS.Core.Bill.PlugIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingdee.BOS.Core.DynamicForm.PlugIn.Args;
using Kingdee.BOS.Orm.DataEntity;

namespace K3Cloud.Bill
{
    public class MyAbstractBillPlugIn: AbstractBillPlugIn//引入金蝶Kingdee.BOS.Core里的类AbstractBillPlugIn
    {
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

                    break;
            }
        }
    }
}
