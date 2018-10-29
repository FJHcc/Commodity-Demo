﻿// <auto-generated />
using System;
using CommodityManagement.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CommodityManagement.WebApi.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20181023103200_updatedb")]
    partial class updatedb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CommodityManagement.Repository.Entity.CommodityRepo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<DateTime>("LastEditAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NameSpelling")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Price");

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.ToTable("comodity");
                });

            modelBuilder.Entity("CommodityManagement.Repository.Entity.CommodityToTagRepo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CommodityId");

                    b.Property<DateTime>("CreateAt");

                    b.Property<DateTime>("LastEditAt");

                    b.Property<int>("TagId");

                    b.HasKey("Id");

                    b.ToTable("commodity_tag");
                });

            modelBuilder.Entity("CommodityManagement.Repository.Entity.StatusRepo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateAt");

                    b.Property<DateTime>("LastEditAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("commodity_status");
                });

            modelBuilder.Entity("CommodityManagement.Repository.Entity.TagRepo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateAt");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastEditAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("tag");
                });
#pragma warning restore 612, 618
        }
    }
}