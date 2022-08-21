using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWinForms.Migrations
{
    public partial class Addcategoryimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "tblCategories",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "tblCategories");
        }
    }
}
