﻿// <auto-generated />
using System;
using MVC.Budget.K_MYR.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC.Budget.K_MYR.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC.Budget.K_MYR.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Budget")
                        .HasPrecision(19, 4)
                        .HasColumnType("decimal(19,4)");

                    b.Property<int>("CategoryType")
                        .HasColumnType("int");

                    b.Property<int>("FiscalPlanId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasDiscriminator<int>("CategoryType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MVC.Budget.K_MYR.Models.CategoryBudget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Budget")
                        .HasPrecision(19, 4)
                        .HasColumnType("decimal(19,4)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Month")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryBudgets", (string)null);
                });

            modelBuilder.Entity("MVC.Budget.K_MYR.Models.FiscalPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("FiscalPlans", (string)null);
                });

            modelBuilder.Entity("MVC.Budget.K_MYR.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(19, 4)
                        .HasColumnType("decimal(19,4)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsEvaluated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHappy")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNecessary")
                        .HasColumnType("bit");

                    b.Property<bool>("PreviousIsHappy")
                        .HasColumnType("bit");

                    b.Property<bool>("PreviousIsNecessary")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DateTime");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("MVC.Budget.K_MYR.Models.ExpenseCategory", b =>
                {
                    b.HasBaseType("MVC.Budget.K_MYR.Models.Category");

                    b.HasIndex("FiscalPlanId");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("MVC.Budget.K_MYR.Models.IncomeCategory", b =>
                {
                    b.HasBaseType("MVC.Budget.K_MYR.Models.Category");

                    b.HasIndex("FiscalPlanId");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("MVC.Budget.K_MYR.Models.CategoryBudget", b =>
                {
                    b.HasOne("MVC.Budget.K_MYR.Models.Category", "Category")
                        .WithMany("PreviousBudgets")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MVC.Budget.K_MYR.Models.Transaction", b =>
                {
                    b.HasOne("MVC.Budget.K_MYR.Models.Category", "Category")
                        .WithMany("Transactions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MVC.Budget.K_MYR.Models.ExpenseCategory", b =>
                {
                    b.HasOne("MVC.Budget.K_MYR.Models.FiscalPlan", "FiscalPlan")
                        .WithMany("ExpenseCategories")
                        .HasForeignKey("FiscalPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FiscalPlan");
                });

            modelBuilder.Entity("MVC.Budget.K_MYR.Models.IncomeCategory", b =>
                {
                    b.HasOne("MVC.Budget.K_MYR.Models.FiscalPlan", "FiscalPlan")
                        .WithMany("IncomeCategories")
                        .HasForeignKey("FiscalPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FiscalPlan");
                });

            modelBuilder.Entity("MVC.Budget.K_MYR.Models.Category", b =>
                {
                    b.Navigation("PreviousBudgets");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("MVC.Budget.K_MYR.Models.FiscalPlan", b =>
                {
                    b.Navigation("ExpenseCategories");

                    b.Navigation("IncomeCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
