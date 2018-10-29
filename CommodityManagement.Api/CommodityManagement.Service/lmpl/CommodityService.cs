using CommodityManagement.Repository;
using CommodityManagement.Repository.Entity;
using CommodityManagement.Repository.Enum;
using CommodityManagement.Service.Common;
using NPinyin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommodityManagement.Service
{
    /// <summary>
    /// 商品方法具体实现
    /// </summary>
    public class CommodityService : BaseService<CommodityRepo>, ICommodityService
    {
        /// <summary>
        /// 服务声明
        /// </summary>
        private MyDbContext _db;

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="db"></param>
        public CommodityService(MyDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <returns></returns>
        public IEnumerable<CommodityListDto> CommodityList(PageArgument page)
        {
            //判断分页传参
           var realPage = page.IsTrue();
            //分页操作
           var commodityList = _db.CommodityRepos.Skip((realPage.PageIndex-1)* realPage.PageSize).Take(realPage.PageSize).Select(s=>
           new CommodityListDto
           {
               Number = s.Number,
               Name = s.Name,
               Price = s.Price,
               Status = Enum.GetName(typeof(CommodityStatus),s.StatusId),
               DbCreateAt = s.CreateAt,
               DbUpdateAt = s.LastEditAt
           }).OrderByDescending(s=>s.DbUpdateAt);
            return commodityList;
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        public bool DeleteCommodity(long id)
        {
            var deleteCommodity = _db.CommodityRepos.FirstOrDefault(d => d.Id == id);
            if(deleteCommodity != null)
            {
                _db.CommodityRepos.Remove(deleteCommodity);
                return _db.SaveChanges() > 0;
            }
            return false;
        }

        /// <summary>
        /// 商品详情
        /// </summary>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        public DetailCommodityDto DetailCommodity(long id)
        {
            var detailCommodity = _db.CommodityRepos.FirstOrDefault(d => d.Id == id);
            //从映射表中获取tag的id。
            var tagId = _db.CommodityToTagRepos.Where(c => c.CommodityId == id).Select(c=>c.TagId).ToList();
            //从标签表中取出tag的name
            var tagName = _db.TagRepos.Where(n => tagId.Contains(n.Id)).Select(s=> s.Name).ToArray();

            var commodity = new DetailCommodityDto()
            {
                Number = detailCommodity.Number,
                Name = detailCommodity.Name,
                Price = detailCommodity.Price,
                Description =detailCommodity.Description,
                Tag = tagName,
                StatusId = detailCommodity.StatusId,
                DbCreateAt = detailCommodity.CreateAt,
                DbUpdateAt = detailCommodity.LastEditAt 
            };
            return commodity;
        }

        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="commodity"></param>
        /// <returns></returns>
        public bool EditCommodity(EditCommodityDto commodity)
        {
            var editCommodity = _db.CommodityRepos.FirstOrDefault(e => e.Id == commodity.Id);
            if (editCommodity != null)
            {
                //1、删除（取到映射表里的数据并删除(这里的思路是修改时就将标签商品映射表里对应为修改商品id的所有行删除并重新插入))
                var cToT = _db.CommodityToTagRepos.Where(c => c.CommodityId == editCommodity.Id).ToArray();
                //删除行
                for(int d = 0;d <= cToT.Length - 1; d++)
                {
                    _db.CommodityToTagRepos.Remove(cToT[d]);
                }
                //2、修改(先获取商品名字拼音)
                var pinyin = GetSpelling.Spelling(editCommodity.Name);
                //修改商品
                editCommodity.Name = commodity.Name;
                editCommodity.Price = commodity.Price;
                editCommodity.Description = commodity.Description;
                editCommodity.NameSpelling = pinyin.ToString();
                editCommodity.LastEditAt = DateTime.Now;

                //定义一个List来获取标签名字集
                var tagName = commodity.Tag.ToList();
                //从标签表中获取标签id。
                var tagId = _db.TagRepos.Where(t => tagName.Contains(t.Name)).Select(t=>t.Id).ToArray();

                //循环将商品id和标签id存入商品标签映射表
                for (int j = 0; j <= tagId.Length - 1; j++)
                {
                    _db.CommodityToTagRepos.Add(new CommodityToTagRepo()
                    {
                        CommodityId = editCommodity.Id,
                        TagId = tagId[j],
                        CreateAt = DateTime.Now,
                        LastEditAt = DateTime.Now
                    });
                }

                return _db.SaveChanges() > 0;
            }
            else
                return false;

        }

        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="commodity"></param>
        /// <returns></returns>
        public bool NewCommodity(NewCommodityDto commodity)
        {
            var newCommodity = _db.CommodityRepos.FirstOrDefault(n => n.Number == commodity.Number);
           
            if (newCommodity == null)
            {
                //获取商品名字拼音
                var pinyin = GetSpelling.Spelling(commodity.Name);
                var goods = new CommodityRepo()
                {
                    Number = commodity.Number,
                    Name = commodity.Name,
                    Price = commodity.Price,
                    Description = commodity.Description,
                    //StatusId = CommodityStatus.OnTheShelf,
                    NameSpelling = pinyin.ToString(),
                    CreateAt = DateTime.Now,
                    LastEditAt = DateTime.Now
                };
                using(var tran = _db.Database.BeginTransaction())
                {
                    try
                    {
                        _db.CommodityRepos.Add(goods);
                        //savechanges之后获取增加的商品的id。
                        _db.SaveChanges();
                        var commodityId = goods.Id;
                        //定义一个List来获取标签名字集
                        var tagName = commodity.Tag.ToList();
                        //从标签表中获取标签id。
                        var tagId = _db.TagRepos.Where(t => tagName.Contains(t.Name)).Select(t=>t.Id).ToArray();
                        //将商品id和标签id循环加入映射表中
                        for (int j = 0; j <= tagId.Length - 1; j++)
                        {
                            _db.CommodityToTagRepos.Add(new CommodityToTagRepo()
                            {
                                CommodityId = commodityId,
                                TagId = tagId[j],
                                CreateAt = DateTime.Now,
                                LastEditAt = DateTime.Now
                            });
                        }
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }
                }
                return _db.SaveChanges() > 0;
            }
            else
                return false;   
        }

        /// <summary>
        /// 搜索商品
        /// </summary>
        /// <param name="parameter">搜索框参数</param>
        /// <param name="tagId">标签id</param>
        /// <param name="status">上架状态id</param>
        /// <returns></returns>
        public IEnumerable<CommodityListDto> SerachCommodity(string parameter,int tagId, CommodityStatus status)
        {
            //找到标签id对应的商品id
            var commodityId = _db.CommodityToTagRepos.Where(c => c.TagId == tagId).Select(c => c.CommodityId).ToList();
            //定义where语句内部条件值
            Func<CommodityRepo, bool> condition;

            //两个下拉框都有值
            if (tagId != 0 && status != 0)
            {
                //判断搜索框传过来的值的状态进行不同的搜索
                condition = s => s.StatusId == status && commodityId.Contains(s.Id);
                return Search(condition);
            }

            //标签下拉框为空
            else if (tagId == 0 && status != 0)
            {
                condition = s => s.StatusId == status;
                return Search(condition);
            }

            //上架状态下拉框为空
            else if(tagId !=0 && status == 0)
            {
                condition = s => commodityId.Contains(s.Id);
                return Search(condition);
            }

            //两个下拉框全为空的情况下
            else
            {
                condition = s => s.Number == parameter || s.Name.Contains(parameter) || s.NameSpelling.Contains(parameter);
                return Search(condition);
            }

            //将复用的部分抽出单独形成一个方法。
            IEnumerable<CommodityListDto> Search(Func<CommodityRepo,bool> conditions)
            {
                var SearchCommodity = _db.CommodityRepos
               .Where(conditions)
               .Where(s=>s.Number == parameter || s.Name.Contains(parameter) || s.NameSpelling.Contains(parameter))
               .Select(s => new CommodityListDto{
                   Number = s.Number,
                   Name = s.Name,
                   Price = s.Price,
                   Status = Enum.GetName(typeof(CommodityStatus),s.StatusId),
                   DbCreateAt = s.CreateAt,
                   DbUpdateAt = s.LastEditAt
               });
                return SearchCommodity;
            }

        }

        /// <summary>
        /// 上架商品
        /// </summary>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        public bool ShelfCommodity(long id)
        {
            try
            {
                var commodity = _db.CommodityRepos.FirstOrDefault(c => c.Id == id);
                //这里只做了简单的转换，如果点击了上架就将上架状态转化，下架也类似
                commodity.StatusId = CommodityStatus.OnTheShelf;
                return _db.SaveChanges() >=  0;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        /// <summary>
        /// 下架商品
        /// </summary>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        public bool LowerCommodity(long id)
        {
            try
            {
                var commodity = _db.CommodityRepos.FirstOrDefault(c => c.Id == id);
                commodity.StatusId = CommodityStatus.IsDown;
                return _db.SaveChanges() >= 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
