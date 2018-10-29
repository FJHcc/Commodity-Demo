using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommodityManagement.Repository.Enum;
using CommodityManagement.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommodityManagement.WebApi.Api
{
    /// <summary>
    /// 商品Api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommodityController : ControllerBase
    {
        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="CommodityService"></param>
        /// <param name="commodity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("NewCommodity")]
        public bool NewCommodity([FromServices]ICommodityService CommodityService, [FromBody]NewCommodityDto commodity)
        {
            //判断标签个数是否大于5个
            if (commodity.Tag.Length > 5)
            {
                return false;
            }
            else
            {
                return CommodityService.NewCommodity(commodity);
            }
        }

        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="CommodityService"></param>
        /// <param name="commodity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("EditCommodity")]
        public bool EditCommodity([FromServices]ICommodityService CommodityService, EditCommodityDto commodity)
        {
            //判断标签个数是否大于5个
            if (commodity.Tag.Length > 5)
            {
                return false;
            }
            else
            {
                return CommodityService.EditCommodity(commodity);
            }
        }

        /// <summary>
        /// 商品列表
        /// </summary>
        /// <param name="CommodityService"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CommodityList")]
        public IEnumerable<CommodityListDto> CommodityList([FromServices]ICommodityService CommodityService,[FromBody]PageArgument page)
        {
            return CommodityService.CommodityList(page);
        }

        /// <summary>
        /// 搜索商品
        /// </summary>
        /// <param name="CommodityService"></param>
        /// <param name="parameter"></param>
        /// <param name="tagId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SearchCommodity")]
        public IEnumerable<CommodityListDto> SearchCommodity([FromServices]ICommodityService CommodityService, [FromBody]string parameter, int tagId, CommodityStatus status)
        {
            return CommodityService.SerachCommodity(parameter,tagId,status);
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="CommodityService"></param>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteCommodity")]
        public bool DeleteCommodity([FromServices]ICommodityService CommodityService,[FromBody]long id)
        {
            return CommodityService.DeleteCommodity(id);
        }

        /// <summary>
        /// 商品详情
        /// </summary>
        /// <param name="CommodityService"></param>
        /// <param name="commodity"></param>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("DetailCommodity")]
        public DetailCommodityDto DetailCommodity([FromServices]ICommodityService CommodityService, [FromBody]DetailCommodityDto commodity)
        {
            return CommodityService.DetailCommodity(commodity.Id);
        }

        /// <summary>
        /// 上架商品
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ShelfCommodity")]
        public bool ShelfGoods([FromServices]ICommodityService CommodityService,long id)
        {
            return CommodityService.ShelfCommodity(id);
        }

        /// <summary>
        /// 下架商品
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("LowerCommodity")]
        public bool LowerGoods([FromServices]ICommodityService CommodityService, long id)
        {
            return CommodityService.LowerCommodity(id);
        }
    }
}