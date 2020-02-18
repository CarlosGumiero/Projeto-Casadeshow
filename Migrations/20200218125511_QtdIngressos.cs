using Microsoft.EntityFrameworkCore.Migrations;

namespace Casadeshow.Migrations
{
    public partial class QtdIngressos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QtdIngressos",
                table: "Compra",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtdIngressos",
                table: "Compra");
        }
    }
}
