using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaMedica.Data.Migrations
{
    public partial class DataSeedComHorariosAgendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Agenda",
                columns: new[] { "AgendaId", "DataHoraFim", "DataHoraInicio", "ProfissionalId" },
                values: new object[] { 1, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.InsertData(
                table: "Horario",
                columns: new[] { "HorarioId", "AgendaId", "DiaSemana", "HoraFim", "HoraInicio" },
                values: new object[,]
                {
                    { 1, 1, 1, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 2, 1, 1, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 3, 1, 1, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 4, 1, 2, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 5, 1, 2, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 6, 1, 3, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Agenda",
                keyColumn: "AgendaId",
                keyValue: 1);
        }
    }
}
