﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yetki.Entites;

#nullable disable

namespace Yetki.Migrations
{
    [DbContext(typeof(YetkiDbContext))]
    [Migration("20240716105503_UserRoles")]
    partial class UserRoles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("yetki")
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Yetki.Entites.User", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<Guid?>("ProcessCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("RegistrationUserCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RegistrationUserName")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.Property<Guid?>("UpdateUserCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdateUserName")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("UserID");

                    b.ToTable("Users", "yetki");
                });

            modelBuilder.Entity("Yetki.Entites.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles", "yetki");
                });

            modelBuilder.Entity("Yetki.Entites.UserType", b =>
                {
                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("TypeId");

                    b.ToTable("UserTypes", "yetki");
                });
#pragma warning restore 612, 618
        }
    }
}
