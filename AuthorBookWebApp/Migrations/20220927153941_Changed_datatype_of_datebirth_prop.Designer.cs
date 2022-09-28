﻿// <auto-generated />
using System;
using AuthorBookWebApp.DbData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuthorBookWebApp.Migrations
{
    [DbContext(typeof(AbDbContext))]
    [Migration("20220927153941_Changed_datatype_of_datebirth_prop")]
    partial class Changed_datatype_of_datebirth_prop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AuthorBookWebApp.DbData.DbModel.AuthorDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("AuthorBookWebApp.DbData.DbModel.BookDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("authorDbModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("authorDbModelId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("AuthorBookWebApp.Models.AuthorViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuthorViewModel");
                });

            modelBuilder.Entity("AuthorBookWebApp.Models.BookViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("authorViewModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("authorViewModelId");

                    b.ToTable("BookViewModel");
                });

            modelBuilder.Entity("AuthorBookWebApp.DbData.DbModel.BookDbModel", b =>
                {
                    b.HasOne("AuthorBookWebApp.DbData.DbModel.AuthorDbModel", "authorDbModel")
                        .WithMany("Books")
                        .HasForeignKey("authorDbModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("authorDbModel");
                });

            modelBuilder.Entity("AuthorBookWebApp.Models.BookViewModel", b =>
                {
                    b.HasOne("AuthorBookWebApp.Models.AuthorViewModel", "authorViewModel")
                        .WithMany("Books")
                        .HasForeignKey("authorViewModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("authorViewModel");
                });

            modelBuilder.Entity("AuthorBookWebApp.DbData.DbModel.AuthorDbModel", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("AuthorBookWebApp.Models.AuthorViewModel", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}