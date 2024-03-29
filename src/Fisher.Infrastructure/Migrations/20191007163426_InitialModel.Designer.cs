﻿// <auto-generated />
using System;
using Fisher.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fisher.Infrastructure.Migrations
{
    [DbContext(typeof(FisherDbContext))]
    [Migration("20191007163426_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fisher.Core.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Fisher.Core.Domain.FavoriteNotePackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<int>("NotePackageId");

                    b.Property<string>("Title");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("NotePackageId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoriteNotePackage");
                });

            modelBuilder.Entity("Fisher.Core.Domain.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Back");

                    b.Property<string>("Definition");

                    b.Property<string>("Front");

                    b.Property<int?>("NotePackageId");

                    b.HasKey("Id");

                    b.HasIndex("NotePackageId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("Fisher.Core.Domain.NotePackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<long>("FollowersAmount");

                    b.Property<bool>("IsPublic");

                    b.Property<int?>("OwnerId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OwnerId");

                    b.ToTable("NotePackage");
                });

            modelBuilder.Entity("Fisher.Core.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Fisher.Core.Domain.FavoriteNotePackage", b =>
                {
                    b.HasOne("Fisher.Core.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Fisher.Core.Domain.NotePackage", "NotePackage")
                        .WithMany()
                        .HasForeignKey("NotePackageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fisher.Core.Domain.User")
                        .WithMany("FavoriteNotePackages")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Fisher.Core.Domain.Note", b =>
                {
                    b.HasOne("Fisher.Core.Domain.NotePackage")
                        .WithMany("Notes")
                        .HasForeignKey("NotePackageId");
                });

            modelBuilder.Entity("Fisher.Core.Domain.NotePackage", b =>
                {
                    b.HasOne("Fisher.Core.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Fisher.Core.Domain.User", "Owner")
                        .WithMany("NotePackages")
                        .HasForeignKey("OwnerId");
                });
#pragma warning restore 612, 618
        }
    }
}
