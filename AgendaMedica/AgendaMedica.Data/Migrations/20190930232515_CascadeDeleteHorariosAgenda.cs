using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaMedica.Data.Migrations
{
    public partial class CascadeDeleteHorariosAgenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horario_Agenda_AgendaId",
                table: "Horario");

            migrationBuilder.AddForeignKey(
                name: "FK_Horario_Agenda_AgendaId",
                table: "Horario",
                column: "AgendaId",
                principalTable: "Agenda",
                principalColumn: "AgendaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horario_Agenda_AgendaId",
                table: "Horario");

            migrationBuilder.AddForeignKey(
                name: "FK_Horario_Agenda_AgendaId",
                table: "Horario",
                column: "AgendaId",
                principalTable: "Agenda",
                principalColumn: "AgendaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
