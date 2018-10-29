using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommodityManagement.Repository.Entity
{
    /// <summary>
    /// 商品状态表
    /// </summary>
    [Table("commodity_status")]
    public class StatusRepo
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
        /// 商品状态
        /// </summary>
        [Required,MaxLength(10)]
        public string Name
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
