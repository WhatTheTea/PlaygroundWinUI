﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhatTheTea.MarketApp.Data;

#nullable disable

namespace WhatTheTea.MarketApp.Migrations
{
    [DbContext(typeof(MarketContext))]
    partial class MarketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("WhatTheTea.MarketApp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int?>("SellerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WhatTheTea.MarketApp.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<double>("Rating")
                        .HasColumnType("REAL");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("WhatTheTea.MarketApp.Models.Product", b =>
                {
                    b.HasOne("WhatTheTea.MarketApp.Models.Seller", null)
                        .WithMany("Products")
                        .HasForeignKey("SellerId");
                });

            modelBuilder.Entity("WhatTheTea.MarketApp.Models.Seller", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
