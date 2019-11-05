using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaMedica.Data.Migrations
{
    public partial class ValorConsultaPodeSerNulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoConsulta",
                table: "Agenda",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.UpdateData(
                table: "Agenda",
                keyColumn: "AgendaId",
                keyValue: 1,
                column: "PrecoConsulta",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoConsulta",
                table: "Agenda",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Agenda",
                keyColumn: "AgendaId",
                keyValue: 1,
                column: "PrecoConsulta",
                value: 0m);
        }
    }
}
