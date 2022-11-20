using Microsoft.EntityFrameworkCore.Migrations;

namespace dataBase.Migrations
{
    public partial class slikaURL_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "slikaUrl",
                table: "proizvod",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slikaUrl",
                table: "proizvod");
        }
    }
}
