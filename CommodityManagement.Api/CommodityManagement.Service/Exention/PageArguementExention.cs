using System;
using System.Collections.Generic;
using System.Text;

namespace CommodityManagement.Service
{
    /// <summary>
    /// 分页的拓展方法
    /// </summary>
    public static class PageArguementExention
    {
        /// <summary>
        /// 判断传入的page参数是否合法
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static PageArgument IsTrue(this PageArgument page)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }
            if (page.PageIndex <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(page), "PageIndex必须是大于0的正整数");
            }
            if (page.PageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(page), "PageSize必须是大于0的正整数");
            }
            return page;
        }
        
    }
}
