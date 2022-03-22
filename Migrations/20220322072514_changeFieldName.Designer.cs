﻿// <auto-generated />
using System;
using LoginMicroservice.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoginMicroservice.Migrations
{
    [DbContext(typeof(ProtfolioDbContext))]
    [Migration("20220322072514_changeFieldName")]
    partial class changeFieldName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("LoginMicroservice.Model.MutualFundDetails", b =>
                {
                    b.Property<int>("MutualFunBuyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("MutualFundId")
                        .HasColumnType("int");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.HasKey("MutualFunBuyId");

                    b.HasIndex("MutualFundId");

                    b.HasIndex("PortfolioId");

                    b.ToTable("MutualFundDetails");
                });

            modelBuilder.Entity("LoginMicroservice.Model.MutualFundPriceDetails", b =>
                {
                    b.Property<int>("MutualFundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("MutualFundName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MutualFundPrice")
                        .HasColumnType("int");

                    b.HasKey("MutualFundId");

                    b.ToTable("MutualFundPriceDetails");
                });

            modelBuilder.Entity("LoginMicroservice.Model.PortfolioDetails", b =>
                {
                    b.Property<int>("PortfolioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PortfolioId");

                    b.HasIndex("UserId");

                    b.ToTable("PortfolioDetails");
                });

            modelBuilder.Entity("LoginMicroservice.Model.StockDetails", b =>
                {
                    b.Property<int>("StockBuyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.HasKey("StockBuyId");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("StockId");

                    b.ToTable("StockDetails");
                });

            modelBuilder.Entity("LoginMicroservice.Model.StockPriceDetails", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("StockName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("StockPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("StockId");

                    b.ToTable("StockPriceDetails");
                });

            modelBuilder.Entity("LoginMicroservice.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LoginMicroservice.Model.MutualFundDetails", b =>
                {
                    b.HasOne("LoginMicroservice.Model.MutualFundPriceDetails", "MutualFundPriceDetails")
                        .WithMany()
                        .HasForeignKey("MutualFundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoginMicroservice.Model.PortfolioDetails", "PortfolioDetails")
                        .WithMany()
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MutualFundPriceDetails");

                    b.Navigation("PortfolioDetails");
                });

            modelBuilder.Entity("LoginMicroservice.Model.PortfolioDetails", b =>
                {
                    b.HasOne("LoginMicroservice.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LoginMicroservice.Model.StockDetails", b =>
                {
                    b.HasOne("LoginMicroservice.Model.PortfolioDetails", "PortfolioDetails")
                        .WithMany()
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoginMicroservice.Model.StockPriceDetails", "StockPriceDetails")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PortfolioDetails");

                    b.Navigation("StockPriceDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
