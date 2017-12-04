﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApplication1.Entities;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20171201153015_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("WebApplication1.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CusineType")
                        .HasColumnType("int(11)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id")
                        .HasName("PK_Id");

                    b.ToTable("Restaurants");
                });
#pragma warning restore 612, 618
        }
    }
}