﻿// <auto-generated />
using System;
using Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("FullPost")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Post", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("4be6a619-75cc-4ac7-8790-7564439f3f54"),
                            Category = 1,
                            CreatedAt = new DateTime(2024, 8, 22, 0, 59, 41, 901, DateTimeKind.Utc).AddTicks(629),
                            FullPost = "O desenvolvimento de software é...",
                            ShortDescription = "Práticas para um software eficiente.",
                            Title = "Melhores Práticas de Software"
                        },
                        new
                        {
                            Id = new Guid("2bd3da40-4dc9-496f-99fd-b18f0b5e1e26"),
                            Category = 2,
                            CreatedAt = new DateTime(2024, 8, 22, 0, 59, 41, 901, DateTimeKind.Utc).AddTicks(644),
                            FullPost = "A IA está transformando o mundo...",
                            ShortDescription = "Impacto da IA na tecnologia.",
                            Title = "O Futuro da IA"
                        },
                        new
                        {
                            Id = new Guid("f8bd94ac-2db1-4129-b35c-594dbf761c26"),
                            Category = 3,
                            CreatedAt = new DateTime(2024, 8, 22, 0, 59, 41, 901, DateTimeKind.Utc).AddTicks(647),
                            FullPost = "Novas tecnologias estão surgindo...",
                            ShortDescription = "As maiores tendências em hardware.",
                            Title = "Tendências de Hardware em 2024"
                        },
                        new
                        {
                            Id = new Guid("4a61398a-8beb-43d8-b53c-d48e91381f51"),
                            Category = 4,
                            CreatedAt = new DateTime(2024, 8, 22, 0, 59, 41, 901, DateTimeKind.Utc).AddTicks(649),
                            FullPost = "O desenvolvimento mobile está evoluindo...",
                            ShortDescription = "Tendências em desenvolvimento mobile.",
                            Title = "Desenvolvimento Mobile"
                        },
                        new
                        {
                            Id = new Guid("a2e72f4c-373f-4b46-bcd0-465e20dc6e9d"),
                            Category = 5,
                            CreatedAt = new DateTime(2024, 8, 22, 0, 59, 41, 901, DateTimeKind.Utc).AddTicks(665),
                            FullPost = "DevOps está mudando a forma como...",
                            ShortDescription = "Como aplicar DevOps em seu projeto.",
                            Title = "DevOps na Prática"
                        },
                        new
                        {
                            Id = new Guid("9f1966a7-8a39-4249-816c-5b6a2a97507f"),
                            Category = 6,
                            CreatedAt = new DateTime(2024, 8, 22, 0, 59, 41, 901, DateTimeKind.Utc).AddTicks(671),
                            FullPost = "Comece com os fundamentos do C#...",
                            ShortDescription = "Aprenda C# do zero com este tutorial.",
                            Title = "Tutorial de C# para Iniciantes"
                        },
                        new
                        {
                            Id = new Guid("45cd14e3-8ddc-4407-8fc0-a9a65404be14"),
                            Category = 7,
                            CreatedAt = new DateTime(2024, 8, 22, 0, 59, 41, 901, DateTimeKind.Utc).AddTicks(672),
                            FullPost = "Nesta semana, grandes eventos...",
                            ShortDescription = "As principais notícias de tecnologia.",
                            Title = "Notícias da Semana"
                        });
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("46c807d5-08df-4cd0-a4ae-d51703ce8a4d"),
                            CreatedAt = new DateTime(2023, 10, 10, 12, 0, 0, 0, DateTimeKind.Utc),
                            Email = "admin@meta.com",
                            IsActive = true,
                            Name = "Admin",
                            Password = "a7Pcd61p6sVyDK6pamAZ/g==.lcxFnFWwFC/a3Hyxx2WbKT6GIDmEIBixOcd5n0vkxTI="
                        });
                });

            modelBuilder.Entity("Domain.Models.Post", b =>
                {
                    b.HasOne("Domain.Models.User", null)
                        .WithMany("Posts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
