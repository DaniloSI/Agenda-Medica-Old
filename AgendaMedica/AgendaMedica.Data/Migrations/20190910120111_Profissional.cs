using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaMedica.Data.Migrations
{
    public partial class Profissional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Endereco",
                columns: new[] { "EnderecoId", "CEP", "Cidade", "Complemento", "Estado", "Numero", "Rua" },
                values: new object[] { 3, "29100-000", "Vila Velha", "Casa", "ES", 851, "Av. São Paulo" });

            migrationBuilder.InsertData(
                table: "Endereco",
                columns: new[] { "EnderecoId", "CEP", "Cidade", "Complemento", "Estado", "Numero", "Rua" },
                values: new object[] { 4, "29166-820", "Serra", "Casa", "ES", 711, "Av. Copacabana" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DataNascimento", "EnderecoId", "Nome", "SobreNome", "Cnpj", "Estado", "Orgao", "Registro" },
                values: new object[] { 3, 0, "d7d50895-1e1c-4582-8bd1-6badd9daea7e", "UsuarioProfissional", "rodrigo@teste.com", false, true, null, "RODRIGO@TESTE.COM", "RODRIGO@TESTE.COM", "AQAAAAEAACcQAAAAEEVjXvqjVsNgg//Kp2nmmIc8cVqwehn9NayYOAl6iqthSU3yClvT5iQDdDc4J5lKHg==", "99349-5462", false, "KRV4CMQKAQCZGZYKSMRW3L7NIJ7CTS6C", false, "rodrigo@teste.com", new DateTime(1971, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Rodrigo", "Vitor Kevin Ferreira", "63.029.660/0001-15", null, null, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DataNascimento", "EnderecoId", "Nome", "SobreNome", "Cnpj", "Estado", "Orgao", "Registro" },
                values: new object[] { 4, 0, "d7d50895-1e1c-4582-8bd1-6badd9daea7e", "UsuarioProfissional", "augusto@teste.com", false, true, null, "AUGUSTO@TESTE.COM", "AUGUSTO@TESTE.COM", "AQAAAAEAACcQAAAAEEVjXvqjVsNgg//Kp2nmmIc8cVqwehn9NayYOAl6iqthSU3yClvT5iQDdDc4J5lKHg==", "99598-2285", false, "KRV4CMQKAQCZGZYKSMRW3L7NIJ7CTS6C", false, "augusto@teste.com", new DateTime(1982, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Augusto", "Menezes da Costa", "35.172.039/0001-70", null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Endereco",
                keyColumn: "EnderecoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Endereco",
                keyColumn: "EnderecoId",
                keyValue: 4);
        }
    }
}
