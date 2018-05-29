using Kingdee.BOS;
using Kingdee.BOS.Core.DynamicForm;
using Kingdee.BOS.Core.DynamicForm.PlugIn.Args;
using Kingdee.BOS.Core.DynamicForm.PlugIn.ControlModel;
using Kingdee.BOS.Core.Enums;
using Kingdee.BOS.Core.Metadata;
using Kingdee.BOS.Core.Metadata.ControlElement;
using Kingdee.BOS.Core.Metadata.EntityElement;
using Kingdee.BOS.Core.Metadata.FieldConverter;
using Kingdee.BOS.Core.Metadata.FieldElement;
using Kingdee.BOS.Core.Metadata.FormElement;
using Kingdee.BOS.Core.Metadata.Util;
using Kingdee.BOS.Orm.DataEntity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Kingdee.BOS.Core.Metadata.ElementMetadata;
using Kingdee.BOS.Core.List;
using Kingdee.BOS.Orm.Metadata.DataEntity;
using Kingdee.BOS.Orm;
using Kingdee.BOS.Orm.Exceptions;
using Kingdee.BOS.Resource;
using System.Collections;

namespace K3Cloud.Utils
{
    public static class CommonUtil
    {
        /// <summary>
        /// 两个对象比较大小
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static int Compare(this object o1, object o2)
        {
            if (o1 == null)
            {
                if (o2 != null)
                {
                    return -1;
                }
                return 0;
            }
            if (o2 == null)
            {
                return 1;
            }
            if ((o1 is string) && (o2 is string))
            {
                return string.Compare((string)o1, (string)o2, StringComparison.CurrentCultureIgnoreCase);
            }
            IComparable comparable = o1 as IComparable;
            if (comparable != null)
            {
                return comparable.CompareTo(o2);
            }
            return 0;
        }
        #region 显示一个表单或列表
        /// <summary>
        /// 显示表单
        /// </summary>
        /// <param name="view"></param>
        /// <param name="panelKey"></param>
        /// <returns></returns>
        public static void ShowForm(this IDynamicFormView view, string formId, string panelKey = null, string pageId = null, Action<FormResult> callback = null, Action<DynamicFormShowParameter> showParaCallback = null)
        {
            DynamicFormShowParameter showPara = new DynamicFormShowParameter();
            showPara.PageId = string.IsNullOrWhiteSpace(pageId) ? Guid.NewGuid().ToString() : pageId;
            showPara.ParentPageId = view.PageId;
            if (string.IsNullOrWhiteSpace(panelKey))
            {
                showPara.OpenStyle.ShowType = ShowType.Default;
            }
            else
            {
                showPara.OpenStyle.ShowType = ShowType.InContainer;
                showPara.OpenStyle.TagetKey = panelKey;
            }
            showPara.FormId = formId;
            showPara.OpenStyle.CacheId = pageId;
            if (showParaCallback != null)
            {
                showParaCallback(showPara);
            }

            view.ShowForm(showPara, callback);
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        /// <param name="view"></param>
        /// <param name="formId"></param>
        /// <param name="listType"></param>
        /// <param name="bMultiSel"></param>
        /// <param name="callback"></param>
        public static void ShowList(this IDynamicFormView view, string formId, BOSEnums.Enu_ListType listType, bool bMultiSel = true, string filter = "", Action<ListShowParameter> showPara = null, Action<FormResult> callback = null)
        {
            ListShowParameter listShowPara = new ListShowParameter();
            listShowPara.FormId = formId;
            listShowPara.PageId = Guid.NewGuid().ToString();
            listShowPara.ParentPageId = view.PageId;
            listShowPara.MultiSelect = bMultiSel;
            listShowPara.ListType = (int)listType;
            if (listType == BOSEnums.Enu_ListType.SelBill)
            {
                listShowPara.IsLookUp = true;
            }
            listShowPara.ListFilterParameter.Filter = listShowPara.ListFilterParameter.Filter.JoinFilterString(filter);
            listShowPara.IsShowUsed = true;
            listShowPara.IsShowApproved = false;
            if (showPara != null) showPara(listShowPara);

            view.ShowForm(listShowPara, callback);
        }
        #endregion

    }
}
