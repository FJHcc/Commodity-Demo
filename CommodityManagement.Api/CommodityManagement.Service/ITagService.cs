using CommodityManagement.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommodityManagement.Service
{
    public interface ITagService : IBaseService<TagRepo>
    {
        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        bool NewTag(NewTagDto tag);

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool DeleteTag(string name);

        /// <summary>
        /// 修改标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        bool EditTag(EditTagDto tag,string name);

        /// <summary>
        /// 标签列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<TagListDto> TagList();
    }
}
