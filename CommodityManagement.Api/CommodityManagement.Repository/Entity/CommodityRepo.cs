using CommodityManagement.Repository.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommodityManagement.Repository.Entity
{
    /// <summary>
    /// 商品表
    /// </summary>
    [Table("comodity")]
    public class CommodityRepo
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id
        {
            get; set;
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        [Required,MaxLength(100)]
        public string Number
        {
            get; set;
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required,MaxLength(100)]
        public string Name
        {
            get; set;
        }
        /// <summary>
        /// 商品价格
        /// </summary>
        [Required]
        public decimal Price
        {
            get; set;
        }
        /// <summary>
        /// 商品描述
        /// </summary>
        [Required, MaxLength(2000)]
        public string Description
        {
            get; set;
        }

        /// <summary>
        /// 商品状态
        /// </summary>
        public CommodityStatus StatusId
        {
            get; set;
        } = (CommodityStatus)1;
        [Required]
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateAt
        {
            get; set;
        }
        [Required]
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastEditAt
        {
            get; set;
        }
        [Required,MaxLength(200)]
        /// <summary>
        /// 商品名称拼音
        /// </summary>
        public string NameSpelling { get; set; }

    }
}
