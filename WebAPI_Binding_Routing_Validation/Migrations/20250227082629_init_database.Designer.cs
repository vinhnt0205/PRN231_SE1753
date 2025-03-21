﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI_Binding_Routing_Validation.Models;

#nullable disable

namespace WebAPI_Binding_Routing_Validation.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20250227082629_init_database")]
    partial class init_database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebAPI_Binding_Routing_Validation.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CompanyId");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("44b72866-168a-41c0-83d9-1e92f10cdb4c"),
                            Address = "Thanh Xuan",
                            Country = "VN",
                            Name = "SMAC"
                        },
                        new
                        {
                            Id = new Guid("4477411b-6651-4a20-b3e4-bfd11937c515"),
                            Address = "Hoa Lac",
                            Country = "VN",
                            Name = "FPT"
                        });
                });

            modelBuilder.Entity("WebAPI_Binding_Routing_Validation.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EmployeeId");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bc08debb-2262-40b6-9a28-d6ca57ca95b6"),
                            Age = 30,
                            CompanyId = new Guid("44b72866-168a-41c0-83d9-1e92f10cdb4c"),
                            Name = "Vinh",
                            Position = "Software Developer"
                        },
                        new
                        {
                            Id = new Guid("9aaa5867-5e62-41fb-93e7-0329c5e20045"),
                            Age = 25,
                            CompanyId = new Guid("4477411b-6651-4a20-b3e4-bfd11937c515"),
                            Name = "Tien",
                            Position = "Software Developer"
                        },
                        new
                        {
                            Id = new Guid("94b7c3db-0782-4b69-b2fd-55f74109984d"),
                            Age = 35,
                            CompanyId = new Guid("44b72866-168a-41c0-83d9-1e92f10cdb4c"),
                            Name = "Hai",
                            Position = "Software Developer"
                        });
                });

            modelBuilder.Entity("WebAPI_Binding_Routing_Validation.Models.Employee", b =>
                {
                    b.HasOne("WebAPI_Binding_Routing_Validation.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("WebAPI_Binding_Routing_Validation.Models.Company", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
