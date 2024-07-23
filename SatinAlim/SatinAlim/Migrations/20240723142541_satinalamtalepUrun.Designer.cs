﻿// <auto-generated />
using System;
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
    [Migration("20240723142541_satinalamtalepUrun")]
    partial class satinalamtalepUrun
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

            modelBuilder.Entity("SatinAlim.Entities.Personel", b =>
                {
                    b.Property<int>("PersonelKod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonelKod"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Pozisyon")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("PersonelKod");

                    b.ToTable("Personel", "satinAlma");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaBirim", b =>
                {
                    b.Property<int>("SatinAlmaBirimKod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SatinAlmaBirimKod"));

                    b.Property<string>("BirimAd")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<int>("OnaySayi")
                        .HasColumnType("int");

                    b.HasKey("SatinAlmaBirimKod");

                    b.ToTable("SatinAlmaBirim", "satinAlma");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaBirimHizmet", b =>
                {
                    b.Property<int>("SatinAlmaBirimHizmetKod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SatinAlmaBirimHizmetKod"));

                    b.Property<int>("SatinAlmaBirimKod")
                        .HasColumnType("int");

                    b.Property<int>("SatinAlmaHizmetKod")
                        .HasColumnType("int");

                    b.Property<int?>("SatınAlmaBirimSatinAlmaBirimKod")
                        .HasColumnType("int");

                    b.HasKey("SatinAlmaBirimHizmetKod");

                    b.HasIndex("SatinAlmaHizmetKod");

                    b.HasIndex("SatınAlmaBirimSatinAlmaBirimKod");

                    b.ToTable("SatinAlmaBirimHizmet", "satinAlma");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaBirimOnayci", b =>
                {
                    b.Property<int>("SatinAlmaBirimOnayciKod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SatinAlmaBirimOnayciKod"));

                    b.Property<DateTime>("BaslangicTarih")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("BitisTarih")
                        .HasColumnType("datetime");

                    b.Property<int>("OnayPersonelKod")
                        .HasColumnType("int");

                    b.Property<int>("OnaySıra")
                        .HasColumnType("int");

                    b.Property<int>("SatinAlmaBirimKod")
                        .HasColumnType("int");

                    b.Property<bool>("Sureli")
                        .HasColumnType("bit");

                    b.HasKey("SatinAlmaBirimOnayciKod");

                    b.HasIndex("OnayPersonelKod");

                    b.HasIndex("SatinAlmaBirimKod");

                    b.ToTable("SatinAlmaBirimOnayci", "satinAlma");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaBirimPersonel", b =>
                {
                    b.Property<int>("SatınAlmaBirimPersonelKod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SatınAlmaBirimPersonelKod"));

                    b.Property<int>("PersonelKod")
                        .HasColumnType("int");

                    b.Property<int>("SatinAlmaBirimKod")
                        .HasColumnType("int");

                    b.Property<int>("SatınAlmaBirimSatinAlmaBirimKod")
                        .HasColumnType("int");

                    b.HasKey("SatınAlmaBirimPersonelKod");

                    b.HasIndex("PersonelKod");

                    b.HasIndex("SatınAlmaBirimSatinAlmaBirimKod");

                    b.ToTable("SatinAlmaBirimPersonel", "satinAlma");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaBirimUrun", b =>
                {
                    b.Property<int>("SatinAlmaBirimUrunKod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SatinAlmaBirimUrunKod"));

                    b.Property<int>("SatinAlmaBirimKod")
                        .HasColumnType("int");

                    b.Property<int>("SatinAlmaUrunKod")
                        .HasColumnType("int");

                    b.Property<int>("SatınAlmaBirimSatinAlmaBirimKod")
                        .HasColumnType("int");

                    b.HasKey("SatinAlmaBirimUrunKod");

                    b.HasIndex("SatinAlmaUrunKod");

                    b.HasIndex("SatınAlmaBirimSatinAlmaBirimKod");

                    b.ToTable("SatinAlmaBirimUrun", "satinAlma");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaHizmet", b =>
                {
                    b.Property<int>("SatinAlmaHizmetKod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SatinAlmaHizmetKod"));

                    b.Property<string>("Aciklama")
                        .HasColumnType("VARCHAR(2000)");

                    b.Property<string>("Birim")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Tanim")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("SatinAlmaHizmetKod");

                    b.ToTable("SatinAlmaHizmet", "satinAlma");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaTalep", b =>
                {
                    b.Property<long>("SatinAlmaTalepKod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SatinAlmaTalepKod"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("VARCHAR(8000)");

                    b.Property<DateTime>("IslemTarih")
                        .HasColumnType("datetime");

                    b.Property<int>("OnaySira")
                        .HasColumnType("int");

                    b.Property<string>("OngorulenTutarPbKod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SatinAlmaBirimKod")
                        .HasColumnType("int");

                    b.Property<int>("TalepPersonelKod")
                        .HasColumnType("int");

                    b.Property<DateTime>("TalepTarih")
                        .HasColumnType("datetime");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SatinAlmaTalepKod");

                    b.HasIndex("SatinAlmaBirimKod");

                    b.HasIndex("TalepPersonelKod");

                    b.ToTable("SatinAlmaTalep", "satinAlma");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaTalepHizmet", b =>
                {
                    b.Property<long>("SatinAlmaHizmetKod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SatinAlmaHizmetKod"));

                    b.Property<decimal>("BirimFiyat")
                        .HasColumnType("NUMERIC(18,2)");

                    b.Property<decimal>("Miktar")
                        .HasColumnType("NUMERIC(18,2)");

                    b.Property<string>("PbKod")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)");

                    b.Property<long>("SatinAlmaTalepKod")
                        .HasColumnType("bigint");

                    b.HasKey("SatinAlmaHizmetKod");

                    b.HasIndex("SatinAlmaTalepKod");

                    b.ToTable("SatinAlmaTalepHizmet", "satinAlma");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaTalepTarihce", b =>
                {
                    b.Property<long>("SatinAlmaTalepTarihceKod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SatinAlmaTalepTarihceKod"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("VARCHAR(2000)");

                    b.Property<DateTime>("IslemTarih")
                        .HasColumnType("datetime");

                    b.Property<int>("OnaySira")
                        .HasColumnType("int");

                    b.Property<int>("PersonelKod")
                        .HasColumnType("int");

                    b.Property<long>("SatinAlmaTalepKod")
                        .HasColumnType("bigint");

                    b.HasKey("SatinAlmaTalepTarihceKod");

                    b.HasIndex("PersonelKod");

                    b.HasIndex("SatinAlmaTalepKod");

                    b.ToTable("SatinAlmaTalepTarihce", "satinAlma");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaTalepUrun", b =>
                {
                    b.Property<long>("SatinAlmaTalepUrunKod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SatinAlmaTalepUrunKod"));

                    b.Property<decimal>("BirimFiyat")
                        .HasColumnType("NUMERIC(18,2)");

                    b.Property<decimal>("Miktar")
                        .HasColumnType("NUMERIC(18,2)");

                    b.Property<string>("PbKod")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)");

                    b.Property<long>("SatinAlmaTalepKod")
                        .HasColumnType("bigint");

                    b.HasKey("SatinAlmaTalepUrunKod");

                    b.HasIndex("SatinAlmaTalepKod");

                    b.ToTable("SatinAlmaTalepUrun", "satinAlma");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaUrun", b =>
                {
                    b.Property<int>("SatinAlmaUrunKod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SatinAlmaUrunKod"));

                    b.Property<string>("Aciklama")
                        .HasColumnType("VARCHAR(2000)");

                    b.Property<string>("Birim")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Tanim")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("SatinAlmaUrunKod");

                    b.ToTable("SatinAlmaUrun", "satinAlma");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaBirimHizmet", b =>
                {
                    b.HasOne("SatinAlim.Entities.SatinAlmaHizmet", "SatinAlmaHizmet")
                        .WithMany("SatinAlmaBirimHizmet")
                        .HasForeignKey("SatinAlmaHizmetKod")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SatinAlim.Entities.SatinAlmaBirim", "SatınAlmaBirim")
                        .WithMany("SatinAlmaBirimHizmet")
                        .HasForeignKey("SatınAlmaBirimSatinAlmaBirimKod")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("SatinAlmaHizmet");

                    b.Navigation("SatınAlmaBirim");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaBirimOnayci", b =>
                {
                    b.HasOne("SatinAlim.Entities.Personel", "Personel")
                        .WithMany("SatinAlmaBirimOnaycilar")
                        .HasForeignKey("OnayPersonelKod")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SatinAlim.Entities.SatinAlmaBirim", "SatinAlmaBirim")
                        .WithMany("SatinAlmaBirimOnaycilar")
                        .HasForeignKey("SatinAlmaBirimKod")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Personel");

                    b.Navigation("SatinAlmaBirim");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaBirimPersonel", b =>
                {
                    b.HasOne("SatinAlim.Entities.Personel", "Personel")
                        .WithMany("SatinAlmaBirimPersonel")
                        .HasForeignKey("PersonelKod")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SatinAlim.Entities.SatinAlmaBirim", "SatınAlmaBirim")
                        .WithMany("SatinAlmaBirimPersonel")
                        .HasForeignKey("SatınAlmaBirimSatinAlmaBirimKod")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Personel");

                    b.Navigation("SatınAlmaBirim");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaBirimUrun", b =>
                {
                    b.HasOne("SatinAlim.Entities.SatinAlmaUrun", "SatinAlmaUrun")
                        .WithMany("SatinAlmaBirimUrun")
                        .HasForeignKey("SatinAlmaUrunKod")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SatinAlim.Entities.SatinAlmaBirim", "SatınAlmaBirim")
                        .WithMany("SatinAlmaBirimUrun")
                        .HasForeignKey("SatınAlmaBirimSatinAlmaBirimKod")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SatinAlmaUrun");

                    b.Navigation("SatınAlmaBirim");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaTalep", b =>
                {
                    b.HasOne("SatinAlim.Entities.SatinAlmaBirim", "SatinAlmaBirim")
                        .WithMany("SatinAlmaTalep")
                        .HasForeignKey("SatinAlmaBirimKod")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SatinAlim.Entities.Personel", "Personel")
                        .WithMany("SatinAlmaTalep")
                        .HasForeignKey("TalepPersonelKod")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Personel");

                    b.Navigation("SatinAlmaBirim");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaTalepHizmet", b =>
                {
                    b.HasOne("SatinAlim.Entities.SatinAlmaTalep", "SatinAlmaTalep")
                        .WithMany("SatinAlmaTalepHizmet")
                        .HasForeignKey("SatinAlmaTalepKod")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SatinAlmaTalep");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaTalepTarihce", b =>
                {
                    b.HasOne("SatinAlim.Entities.Personel", "Personel")
                        .WithMany("SatinAlmaTalepTarihce")
                        .HasForeignKey("PersonelKod")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SatinAlim.Entities.SatinAlmaTalep", "SatinAlmaTalep")
                        .WithMany("SatinAlmaTalepTarihce")
                        .HasForeignKey("SatinAlmaTalepKod")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Personel");

                    b.Navigation("SatinAlmaTalep");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaTalepUrun", b =>
                {
                    b.HasOne("SatinAlim.Entities.SatinAlmaTalep", "SatinAlmaTalep")
                        .WithMany()
                        .HasForeignKey("SatinAlmaTalepKod")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SatinAlmaTalep");
                });

            modelBuilder.Entity("SatinAlim.Entities.Personel", b =>
                {
                    b.Navigation("SatinAlmaBirimOnaycilar");

                    b.Navigation("SatinAlmaBirimPersonel");

                    b.Navigation("SatinAlmaTalep");

                    b.Navigation("SatinAlmaTalepTarihce");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaBirim", b =>
                {
                    b.Navigation("SatinAlmaBirimHizmet");

                    b.Navigation("SatinAlmaBirimOnaycilar");

                    b.Navigation("SatinAlmaBirimPersonel");

                    b.Navigation("SatinAlmaBirimUrun");

                    b.Navigation("SatinAlmaTalep");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaHizmet", b =>
                {
                    b.Navigation("SatinAlmaBirimHizmet");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaTalep", b =>
                {
                    b.Navigation("SatinAlmaTalepHizmet");

                    b.Navigation("SatinAlmaTalepTarihce");
                });

            modelBuilder.Entity("SatinAlim.Entities.SatinAlmaUrun", b =>
                {
                    b.Navigation("SatinAlmaBirimUrun");
                });
#pragma warning restore 612, 618
        }
    }
}
