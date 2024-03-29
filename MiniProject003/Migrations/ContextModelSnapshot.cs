﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniProject003.Models;

#nullable disable

namespace MiniProject003.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiniProject003.Models.Nationality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NationalityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MiniProject003_Nationalities");
                });

            modelBuilder.Entity("MiniProject003.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MiniProject003_Persons");
                });

            modelBuilder.Entity("MiniProject003.Models.PersonNationality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("NationalityId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NationalityId");

                    b.HasIndex("PersonId");

                    b.ToTable("MiniProject003_PersonsNationalities");
                });

            modelBuilder.Entity("MiniProject003.Models.PersonNationality", b =>
                {
                    b.HasOne("MiniProject003.Models.Nationality", "Nationality")
                        .WithMany("PersonsNationalities")
                        .HasForeignKey("NationalityId");

                    b.HasOne("MiniProject003.Models.Person", "Person")
                        .WithMany("PersonsNationalities")
                        .HasForeignKey("PersonId");

                    b.Navigation("Nationality");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MiniProject003.Models.Nationality", b =>
                {
                    b.Navigation("PersonsNationalities");
                });

            modelBuilder.Entity("MiniProject003.Models.Person", b =>
                {
                    b.Navigation("PersonsNationalities");
                });
#pragma warning restore 612, 618
        }
    }
}
