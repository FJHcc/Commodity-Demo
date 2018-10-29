using CommodityManagement.Repository;
using CommodityManagement.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommodityManagement.Service
{
    /// <summary>
    /// 标签方法具体实现
    /// </summary>
    public class TagService : BaseService<TagRepo>,ITagService
    {
       /// <summary>
       /// 服务声明
       /// </summary>
       private MyDbContext _db;

       /// <summary>
       /// 构造函数依赖注入
       /// </summary>
       /// <param name="db"></param>
       public TagService(MyDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool DeleteTag(string name)
        {
            var deleteTag = _db.TagRepos.FirstOrDefault(d => d.Name == name);
            if (deleteTag != null)
            {
                //这里只改变删除状态字段，并没有真正删除。
                deleteTag.IsDeleted = true; 
                return _db.SaveChanges() > 0;
            }
            else
                return false;
        }

        /// <summary>
        /// 修改标签
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool EditTag(EditTagDto tag,string name)
        {
            //先将原标签行找出。
            var editTag = _db.TagRepos.FirstOrDefault(u => u.Name == name);
            if (editTag != null)
            {
                //再将新标签名与其他行进行匹配，如果重复就返回false。
                var tagCount = _db.TagRepos.Where(u => u.Name == tag.Name).ToArray();
                if (tagCount.Length >= 1)
                {
                    return false;
                }
                else
                {
                    editTag.Name = name;
                    editTag.LastEditAt = DateTime.Now;
                    return _db.SaveChanges() >= 0;
                }
            }
            else
                return false;
        }

        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public bool NewTag(NewTagDto tag)
        {
            var newTag = _db.TagRepos.FirstOrDefault(n => n.Name == tag.Name);
            //如果标签名不存在，直接新增
            if (newTag == null)
            {
                _db.TagRepos.Add(new TagRepo()
                {
                    Name = tag.Name,
                    IsDeleted = false,
                    CreateAt = DateTime.Now,
                    LastEditAt = DateTime.Now
                });
                return _db.SaveChanges() > 0;
            }
            //标签名存在，判断标签的删除状态，如果已经删除，则改变删除状态
            else if (newTag.IsDeleted == true)
            {
                newTag.IsDeleted = false;
                return _db.SaveChanges() >= 0;
            }
            else
                return false;
           
        }

        /// <summary>
        /// 标签列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TagListDto> TagList()
        {
            //将删除状态为false的所有标签取出
            var tagList = _db.TagRepos.Where(l => l.IsDeleted == false).Select(s=> new TagListDto()
            {
                Name = s.Name
            });
            return tagList;
        }
    }
}
