using K3Cloud.Bill;
using Kingdee.BOS.Core.Bill;
using Kingdee.BOS.Core.Bill.PlugIn;
using Kingdee.BOS.Core.Metadata.FieldElement;
using Kingdee.BOS.Orm.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K3Cloud.Utils
{
    public class BillPlugInUtils
    {
        /// <summary>
        /// 获取表单上的除了基础资料字段以外的字段值
        /// </summary>
        /// <param name="bill">插件类的实例</param>
        /// <param name="fieldKey">字段唯一标识</param>
        /// <returns>返回string类型</returns>
        public String GetValueOfString(AbstractBillPlugIn bill,string fieldKey)
        {
           return bill.View.Model.GetValue(fieldKey).ToString();
        }
        /// <summary>
        /// 获取表单上的除了基础资料字段以外的字段值
        /// </summary>
        /// <param name="bill">插件类的实例</param>
        /// <param name="fieldKey">字段唯一标识</param>
        /// <returns>返回Int类型</returns>
        public int GetValueOfInt(AbstractBillPlugIn bill, string fieldKey)
        {
            return Convert.ToInt32(bill.View.Model.GetValue(fieldKey).ToString());
        }
        /// <summary>
        /// 获取表单上的除了基础资料字段以外的字段值
        /// </summary>
        /// <param name="bill">插件类的实例</param>
        /// <param name="fieldKey">字段唯一标识</param>
        /// <returns>返回Decimal类型</returns>
        public decimal GetValueOfDecimal(AbstractBillPlugIn bill, string fieldKey)
        {
            return Convert.ToDecimal(bill.View.Model.GetValue(fieldKey).ToString());
        }
        /// <summary>
        /// 获取基础资料值
        /// </summary>
        /// <param name="bill">要获取单据的类实例</param>
        /// <param name="retType">返回字段值类型</param>
        /// <param name="fieldKey">要获取的字段的唯一标识</param>
        /// <returns></returns>
        public string GetBaseValue(AbstractBillPlugIn bill, string retType, string fieldKey)
        {
            string result = "";
            string baseDataNumber = "", baseDataName = "";
            string baseDataId = "";
            DynamicObject billObj = bill.Model.DataObject;
            BaseDataField fldBaseData = bill.View.BusinessInfo.GetField(fieldKey) as BaseDataField;
            DynamicObject baseDataValue = fldBaseData.DynamicProperty.GetValue(billObj) as DynamicObject;

            if (baseDataValue != null)
            {
                baseDataId = baseDataValue[0].ToString();
                baseDataNumber = fldBaseData.GetRefPropertyValue(baseDataValue, "FNumber").ToString();
                baseDataName = fldBaseData.GetRefPropertyValue(baseDataValue, "FName").ToString();
            }

            switch (retType)
            {
                case "Id":
                    result = baseDataId.ToString();
                    break;
                case "FNumber":
                    result = baseDataNumber;
                    break;
                case "FName":
                    result = baseDataName;
                    break;
                default:
                    break;
            }
            return result;
        }
        public void ShowMessage(AbstractBillPlugIn bill, string Msg)
        {
            bill.View.ShowMessage(Msg);
        }
    }
}
