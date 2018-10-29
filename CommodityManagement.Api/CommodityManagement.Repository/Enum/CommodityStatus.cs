using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CommodityManagement.Repository.Enum
{
    /// <summary>
    /// 商品上架状态
    /// </summary>
    public enum CommodityStatus
    {
        /// <summary>
        /// 已上架
        /// </summary>
        [Description("已上架")]
        OnTheShelf = 1,

        /// <summary>
        /// 待上架
        /// </summary>
        [Description("待上架")]
        NotOnTheShelf = 2,


        /// <summary>
        /// 已下架
        /// </summary>
        [Description("已下架")]
        IsDown = 3,
    }
}
