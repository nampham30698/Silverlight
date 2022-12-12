using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace silverlight.infrastructure.data.migrations
{
    public partial class nampv_add_field_26112022_22h00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameShort",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleShort",
                table: "Blogs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameShort",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "TitleShort",
                table: "Blogs");
        }
    }
}
