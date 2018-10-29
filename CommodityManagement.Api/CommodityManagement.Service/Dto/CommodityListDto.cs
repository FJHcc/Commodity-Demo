using CommodityManagement.Repository.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommodityManagement.Service
{
    public class CommodityListDto
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 上架状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime DbCreateAt { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime DbUpdateAt { get; set; }
    }
}
