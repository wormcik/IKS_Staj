﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SatinAlim.Entities;

#nullable disable

namespace SatinAlim.Migrations
{
    [DbContext(typeof(SatinAlimDbContext))]
    [Migration("20240712140555_deneme3")]
    partial class deneme3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("satinAlma")
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SatinAlim.Entities.TestProduct", b =>
                {
                    b.Property<int>("TestProductID")
                        .HasColumnType("int");

                    b.HasKey("TestProductID");

                    b.ToTable("TestProducts", "satinAlma");
                });
#pragma warning restore 612, 618
        }
    }
}
