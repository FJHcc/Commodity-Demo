using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommodityManagement.Repository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Entity.CommodityRepo> CommodityRepos { set; get; }
        public DbSet<Entity.TagRepo> TagRepos { set; get; }
        public DbSet<Entity.StatusRepo> StatusRepos { set; get; }
        public DbSet<Entity.CommodityToTagRepo> CommodityToTagRepos { set; get; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Entity.CommodityRepo>().Property(commodity => commodity.price).;
        //}

}
}
