using Microsoft.EntityFrameworkCore.Migrations;

namespace AppMercado.Migrations
{
    public partial class AjusteProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "srcImage",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "srcImage",
                table: "Produto");
        }
    }
}
