using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommodityManagement.Repository.Entity;
using CommodityManagement.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommodityManagement.WebApi.Api
{
    /// <summary>
    /// 标签Api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        /// <summary>
        /// 新建标签
        /// </summary>
        /// <param name="TagService"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("NewTag")]
        public bool NewTag([FromServices]ITagService TagService,[FromBody]NewTagDto tag)
        {
            return TagService.NewTag(tag);
        }
        /// <summary>
        /// 编辑标签
        /// </summary>
        /// <param name="TagService"></param>
        /// <param name="tag"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("EditTag")]
        public bool EditTag([FromServices]ITagService TagService, [FromBody]EditTagDto tag,string name)
        {
            //这里如果标签名未改变，直接返回，name为原标签名。
            if(tag.Name == name)
            {
                return true;
            }
            else
            {
                return TagService.EditTag(tag, name);
            }
        }
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="tagService"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteTag")]
        public bool DeleteTag([FromServices]ITagService tagService,string name)
        {
            return tagService.DeleteTag(name);
        }
        /// <summary>
        /// 标签列表
        /// </summary>
        /// <param name="tagService"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("TagList")]
        public IEnumerable<TagListDto> Taglist([FromServices]ITagService tagService)
        {
            return tagService.TagList();
        }
    }
}