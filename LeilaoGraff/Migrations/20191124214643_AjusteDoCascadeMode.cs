using Microsoft.EntityFrameworkCore.Migrations;

namespace LeilaoGraff.Migrations
{
    public partial class AjusteDoCascadeMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CascadeMode",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CascadeMode",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "CascadeMode",
                table: "Lances");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CascadeMode",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CascadeMode",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CascadeMode",
                table: "Lances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
