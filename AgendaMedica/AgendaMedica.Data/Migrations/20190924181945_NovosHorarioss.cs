using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaMedica.Data.Migrations
{
    public partial class NovosHorarioss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 1,
                column: "DiaSemana",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 2,
                column: "DiaSemana",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 3,
                column: "DiaSemana",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 4,
                columns: new[] { "DiaSemana", "HoraFim", "HoraInicio" },
                values: new object[] { 0, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 5,
                columns: new[] { "DiaSemana", "HoraFim", "HoraInicio" },
                values: new object[] { 0, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 6,
                columns: new[] { "DiaSemana", "HoraFim", "HoraInicio" },
                values: new object[] { 0, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 12, 30, 0, 0) });

            migrationBuilder.InsertData(
                table: "Horario",
                columns: new[] { "HorarioId", "AgendaId", "DiaSemana", "HoraFim", "HoraInicio" },
                values: new object[,]
                {
                    { 30, 1, 4, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 31, 1, 4, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 32, 1, 4, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 33, 1, 4, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 34, 1, 4, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 35, 1, 4, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 36, 1, 5, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 37, 1, 5, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 38, 1, 5, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 41, 1, 5, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 40, 1, 5, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 29, 1, 4, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 42, 1, 5, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 43, 1, 6, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 44, 1, 6, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 45, 1, 6, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 46, 1, 6, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 47, 1, 6, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 39, 1, 5, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 28, 1, 3, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 25, 1, 3, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 26, 1, 3, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 7, 1, 0, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 8, 1, 1, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 9, 1, 1, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 10, 1, 1, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 11, 1, 1, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 12, 1, 1, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 13, 1, 1, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 14, 1, 1, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 15, 1, 2, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 16, 1, 2, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 17, 1, 2, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 18, 1, 2, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 19, 1, 2, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 20, 1, 2, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 21, 1, 2, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 22, 1, 3, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 23, 1, 3, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 24, 1, 3, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 48, 1, 6, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 27, 1, 3, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 49, 1, 6, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 13, 30, 0, 0) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 49);

            migrationBuilder.UpdateData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 1,
                column: "DiaSemana",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 2,
                column: "DiaSemana",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 3,
                column: "DiaSemana",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 4,
                columns: new[] { "DiaSemana", "HoraFim", "HoraInicio" },
                values: new object[] { 2, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 5,
                columns: new[] { "DiaSemana", "HoraFim", "HoraInicio" },
                values: new object[] { 2, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 6,
                columns: new[] { "DiaSemana", "HoraFim", "HoraInicio" },
                values: new object[] { 3, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) });
        }
    }
}
