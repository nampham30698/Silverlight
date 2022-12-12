using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace silverlight.infrastructure.data.migrations
{
    public partial class nampv_add_tables_26112022_21h55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "Blog_Category_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Blog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UrlImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreationYear = table.Column<int>(type: "int", nullable: true),
                    CreationMonth = table.Column<int>(type: "int", nullable: true),
                    CreationDay = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs_Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: true),
                    TagName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TagNameShort = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs_Tags", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Blogs_Categories");

            migrationBuilder.DropTable(
                name: "Blogs_Tags");

            migrationBuilder.DropSequence(
                name: "Blog_Category_hilo");

            migrationBuilder.DropSequence(
                name: "Blog_hilo");
        }
    }
}
