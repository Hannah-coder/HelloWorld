﻿// <auto-generated />
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(MetricsDbContext))]
    [Migration("20211019203505_Whatever")]
    partial class Whatever
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("API.Models.MerchandiseFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime");

                    b.Property<int>("NumberRecordsReturned")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MerchandiseFilter");
                });

            modelBuilder.Entity("API.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Page_Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("API.Models.PageSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("End_Time")
                        .HasColumnType("timestamp");

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.Property<decimal>("PageLoadTime")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Start_Time")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.HasIndex("SessionId");

                    b.ToTable("PageSession");
                });

            modelBuilder.Entity("API.Models.PageView", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Parameter1")
                        .HasColumnType("text");

                    b.Property<string>("Parameter2")
                        .HasColumnType("text");

                    b.Property<string>("URLSection1")
                        .HasColumnType("text");

                    b.Property<string>("URLSection2")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PageView");
                });

            modelBuilder.Entity("API.Models.PetFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime");

                    b.Property<string>("FilterCriteria")
                        .HasColumnType("text");

                    b.Property<int>("NumberRecordsReturned")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PetFilter");
                });

            modelBuilder.Entity("API.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("Response")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("API.Models.ServerInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime");

                    b.Property<string>("OSVersion")
                        .HasColumnType("text");

                    b.Property<string>("RuntimeVersion")
                        .HasColumnType("text");

                    b.Property<long>("Uptime")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("ServerInformation");
                });

            modelBuilder.Entity("API.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("API.Models.UserAccounts", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserUserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("API.Models.PageSession", b =>
                {
                    b.HasOne("API.Models.Page", "Page")
                        .WithMany("PageSessions")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Session", "Session")
                        .WithMany("PageSessions")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Page");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("API.Models.Page", b =>
                {
                    b.Navigation("PageSessions");
                });

            modelBuilder.Entity("API.Models.Session", b =>
                {
                    b.Navigation("PageSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
