﻿// <auto-generated />
using System;
using BudgetierApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BudgetierWeb.Migrations
{
    [DbContext(typeof(BudgetierContext))]
    partial class BudgetierContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("BudgetierApi.Data.Entities.BookingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BudgetierApi.Data.Entities.CategoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Budget")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BudgetierApi.Data.Entities.CategoryReportEntity", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Month")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Spent")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId", "Year", "Month");

                    b.ToTable("CategoryReports");
                });

            modelBuilder.Entity("BudgetierApi.Data.Entities.BookingEntity", b =>
                {
                    b.HasOne("BudgetierApi.Data.Entities.CategoryEntity", "Category")
                        .WithMany("Bookings")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BudgetierApi.Data.Entities.CategoryEntity", b =>
                {
                    b.HasOne("BudgetierApi.Data.Entities.CategoryEntity", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("BudgetierApi.Data.Entities.CategoryReportEntity", b =>
                {
                    b.HasOne("BudgetierApi.Data.Entities.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
