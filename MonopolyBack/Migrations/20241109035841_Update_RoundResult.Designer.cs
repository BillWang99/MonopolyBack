﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonopolyBack.Data;

#nullable disable

namespace MonopolyBack.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20241109035841_Update_RoundResult")]
    partial class Update_RoundResult
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MonopolyBack.Models.GameHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GameToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("PlayersCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GameHistory");
                });

            modelBuilder.Entity("MonopolyBack.Models.Players", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GameHistoryId")
                        .HasColumnType("int");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsTarget")
                        .HasColumnType("bit");

                    b.Property<string>("Order")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoundResultId")
                        .HasColumnType("int");

                    b.Property<int>("money")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameHistoryId");

                    b.HasIndex("RoundResultId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("MonopolyBack.Models.RoundResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("OptionMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("RoundResult");
                });

            modelBuilder.Entity("MonopolyBack.Models.Players", b =>
                {
                    b.HasOne("MonopolyBack.Models.GameHistory", null)
                        .WithMany("players")
                        .HasForeignKey("GameHistoryId");

                    b.HasOne("MonopolyBack.Models.RoundResult", null)
                        .WithMany("players")
                        .HasForeignKey("RoundResultId");
                });

            modelBuilder.Entity("MonopolyBack.Models.GameHistory", b =>
                {
                    b.Navigation("players");
                });

            modelBuilder.Entity("MonopolyBack.Models.RoundResult", b =>
                {
                    b.Navigation("players");
                });
#pragma warning restore 612, 618
        }
    }
}
