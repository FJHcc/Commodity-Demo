using CommodityManagement.Repository.Entity;
using CommodityManagement.Repository.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommodityManagement.Service
{
    public interface ICommodityService :IBaseService<CommodityRepo>
    {
        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="commodity"></param>
        /// <returns></returns>
        bool NewCommodity(NewCommodityDto commodity);

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        bool DeleteCommodity(long id);

        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="commodity"></param>
        /// <returns></returns>
        bool EditCommodity(EditCommodityDto commodity);

        /// <summary>
        /// 搜索商品
        /// </summary>
        /// <param name="parameter">搜索框参数</param>
        /// <param name="tagId">标签id</param>
        /// <param name="status">上架状态id</param>
        /// <returns></returns>
        IEnumerable<CommodityListDto> SerachCommodity(string parameter,int tagId, CommodityStatus status);

        /// <summary>
        /// 商品列表
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <returns></returns>
        IEnumerable<CommodityListDto> CommodityList(PageArgument page);

        /// <summary>
        /// 商品详情
        /// </summary>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        DetailCommodityDto DetailCommodity(long id);

        /// <summary>
        /// 上架商品
        /// </summary>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        bool ShelfCommodity(long id);

        /// <summary>
        /// 下架商品
        /// </summary>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        bool LowerCommodity(long id);




    }
}
