using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ShortDescription = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    FullPost = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Category", "CreatedAt", "CreatedBy", "FullPost", "ShortDescription", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2bd3da40-4dc9-496f-99fd-b18f0b5e1e26"), 2, new DateTime(2024, 8, 22, 0, 59, 41, 901, DateTimeKind.Utc).AddTicks(644), null, "A IA está transformando o mundo...", "Impacto da IA na tecnologia.", "O Futuro da IA", null, null },
                    { new Guid("45cd14e3-8ddc-4407-8fc0-a9a65404be14"), 7, new DateTime(2024, 8, 22, 0, 59, 41, 901, DateTimeKind.Utc).AddTicks(672), null, "Nesta semana, grandes eventos...", "As principais notícias de tecnologia.", "Notícias da Semana", null, null },
                    { new Guid("4a61398a-8beb-43d8-b53c-d48e91381f51"), 4, new DateTime(2024, 8, 22, 0, 59, 41, 901, DateTimeKind.Utc).AddTicks(649), null, "O desenvolvimento mobile está evoluindo...", "Tendências em desenvolvimento mobile.", "Desenvolvimento Mobile", null, null },
                    { new Guid("4be6a619-75cc-4ac7-8790-7564439f3f54"), 1, new DateTime(2024, 8, 22, 0, 59, 41, 901, DateTimeKind.Utc).AddTicks(629), null, "O desenvolvimento de software é...", "Práticas para um software eficiente.", "Melhores Práticas de Software", null, null },
                    { new Guid("9f1966a7-8a39-4249-816c-5b6a2a97507f"), 6, new DateTime(2024, 8, 22, 0, 59, 41, 901, DateTimeKind.Utc).AddTicks(671), null, "Comece com os fundamentos do C#...", "Aprenda C# do zero com este tutorial.", "Tutorial de C# para Iniciantes", null, null },
                    { new Guid("a2e72f4c-373f-4b46-bcd0-465e20dc6e9d"), 5, new DateTime(2024, 8, 22, 0, 59, 41, 901, DateTimeKind.Utc).AddTicks(665), null, "DevOps está mudando a forma como...", "Como aplicar DevOps em seu projeto.", "DevOps na Prática", null, null },
                    { new Guid("f8bd94ac-2db1-4129-b35c-594dbf761c26"), 3, new DateTime(2024, 8, 22, 0, 59, 41, 901, DateTimeKind.Utc).AddTicks(647), null, "Novas tecnologias estão surgindo...", "As maiores tendências em hardware.", "Tendências de Hardware em 2024", null, null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "IsActive", "Name", "Password", "UpdatedAt" },
                values: new object[] { new Guid("46c807d5-08df-4cd0-a4ae-d51703ce8a4d"), new DateTime(2023, 10, 10, 12, 0, 0, 0, DateTimeKind.Utc), null, "admin@meta.com", true, "Admin", "a7Pcd61p6sVyDK6pamAZ/g==.lcxFnFWwFC/a3Hyxx2WbKT6GIDmEIBixOcd5n0vkxTI=", null });

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
