using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaMedica.Data.Migrations
{
    public partial class UsuarioAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioAdminId",
                table: "Consulta",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DataNascimento", "EnderecoId", "Nome", "SobreNome" },
                values: new object[] { 5, 0, "d7d50895-1e1c-4582-8bd1-6badd9daea7e", "UsuarioAdmin", "admin@teste.com", false, true, null, "ADMIN@TESTE.COM", "ADMIN@TESTE.COM", "AQAAAAEAACcQAAAAEEVjXvqjVsNgg//Kp2nmmIc8cVqwehn9NayYOAl6iqthSU3yClvT5iQDdDc4J5lKHg==", null, false, "KRV4CMQKAQCZGZYKSMRW3L7NIJ7CTS6C", false, "admin@teste.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", "" });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_UsuarioAdminId",
                table: "Consulta",
                column: "UsuarioAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_AspNetUsers_UsuarioAdminId",
                table: "Consulta",
                column: "UsuarioAdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_AspNetUsers_UsuarioAdminId",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_UsuarioAdminId",
                table: "Consulta");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "UsuarioAdminId",
                table: "Consulta");
        }
    }
}
