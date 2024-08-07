﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManager.Data;

#nullable disable

namespace TaskManager.Migrations
{
    [DbContext(typeof(TaskDb))]
    [Migration("20240707024728_addedlogging")]
    partial class addedlogging
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("TaskManager.Models.Folder", b =>
                {
                    b.Property<int>("FolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FolderId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("TaskManager.Models.TaskObj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FolderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManager.Models.TaskObj", b =>
                {
                    b.HasOne("TaskManager.Models.Folder", "Folder")
                        .WithMany("Tasks")
                        .HasForeignKey("FolderId");

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("TaskManager.Models.Folder", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
