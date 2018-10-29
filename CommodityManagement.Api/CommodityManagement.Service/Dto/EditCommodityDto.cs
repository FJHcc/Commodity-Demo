using System;
using System.Collections.Generic;
using System.Text;

namespace CommodityManagement.Service
{
    public class EditCommodityDto
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 商品标签
        /// </summary>
        public string[] Tag { get; set; }
    }
}
