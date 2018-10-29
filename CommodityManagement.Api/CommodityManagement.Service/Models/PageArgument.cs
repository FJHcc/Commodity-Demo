using System;
using System.Collections.Generic;
using System.Text;

namespace CommodityManagement.Service
{
    /// <summary>
    /// 分页模型
    /// </summary>
    public class PageArgument
    {
        /// <summary>
        /// 请求页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize { get; set; }
    }
}
