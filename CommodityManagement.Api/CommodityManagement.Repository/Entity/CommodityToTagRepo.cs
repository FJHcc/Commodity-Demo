using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommodityManagement.Repository.Entity
{
    /// <summary>
    /// 商品标签映射表
    /// </summary>
    [Table("commodity_tag")]
    public class CommodityToTagRepo
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// 商品Id
        /// </summary>
        [Required]
        public long CommodityId
        {
            get; set;
        }
        /// <summary>
        /// 标签Id
        /// </summary>
        [Required]
        public int TagId
        {
            get; set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CreateAt
        {
            get; set;
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Required]
        public DateTime LastEditAt
        {
            get; set;
        }
    }
}
