using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace silverlight.infrastructure.data.migrations
{
    public partial class nampv_insert_table_settings_update_category_20112022_15h56 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "Settings_hilo",
                incrementBy: 10);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropSequence(
                name: "Settings_hilo");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Categories");
        }
    }
}
