﻿// <auto-generated />
using System;
using Bookify.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookify.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241004122038_MakeOneToManyRelationshipAuthorBook")]
    partial class MakeOneToManyRelationshipAuthorBook
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bookify.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Bookify.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("Bookify.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Genres", (string)null);
                });

            modelBuilder.Entity("Bookify.Entities.Book", b =>
                {
                    b.HasOne("Bookify.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Bookify.Entities.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Bookify.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Bookify.Entities.Genre", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
