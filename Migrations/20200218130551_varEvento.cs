using Microsoft.EntityFrameworkCore.Migrations;

namespace Casadeshow.Migrations
{
    public partial class varEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "Compra",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compra_EventoId",
                table: "Compra",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Evento_EventoId",
                table: "Compra",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "EventoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Evento_EventoId",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_EventoId",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Compra");
        }
    }
}
