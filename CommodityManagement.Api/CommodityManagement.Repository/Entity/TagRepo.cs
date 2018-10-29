using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommodityManagement.Repository.Entity
{
    /// <summary>
    /// 标签表
    /// </summary>
    [Table("tag")]
    public class TagRepo
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
        /// 标签名称
        /// </summary>
        [Required,MaxLength(10)]
        public string Name
        {
            get; set;
        }
        /// <summary>
        /// 标签是否删除
        /// </summary>
        [Required]
        public bool IsDeleted
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
