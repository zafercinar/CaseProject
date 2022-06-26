﻿// <auto-generated />
using System;
using CaseProject.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CaseProject.DataAccess.Migrations
{
    [DbContext(typeof(CaseProjectDbContext))]
    [Migration("20220625120826_DatabaseInitialize")]
    partial class DatabaseInitialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CaseProject.Core.Entities.Word", b =>
                {
                    b.Property<Guid>("Value")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Value")
                        .HasName("PK_CaseProject_Words");

                    b.ToTable("Words", "case");
                });
#pragma warning restore 612, 618
        }
    }
}
