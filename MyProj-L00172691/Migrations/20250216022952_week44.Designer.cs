﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyProj.DataAccess.DataAccess;

#nullable disable

namespace MyProj_L00172691.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20250216022952_week44")]
    partial class week44
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyProj.Models.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hiro Arikawa"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Gabrielle Zevin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Jane Austen"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Stephen King"
                        },
                        new
                        {
                            Id = 5,
                            Name = "George R. R. Martin"
                        });
                });

            modelBuilder.Entity("MyProj.Models.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            GenreId = 4,
                            ImageName = "tcat.jpg",
                            Title = " The Traveling Cat Chronicles"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            GenreId = 2,
                            ImageName = "tomorrow.jpg",
                            Title = "Tomorrow, and Tomorrow and Tomorrow"
                        });
                });

            modelBuilder.Entity("MyProj.Models.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Contemporary"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Horror"
                        });
                });

            modelBuilder.Entity("MyProj.Models.Models.Book", b =>
                {
                    b.HasOne("MyProj.Models.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyProj.Models.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
