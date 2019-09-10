using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaMedica.Data.Migrations
{
    public partial class Especialidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "EspecialidadeId", "Codigo", "Nome" },
                values: new object[,]
                {
                    { 1, "ANSTSLG", "Anestesiologia" },
                    { 2, "CIRUR. PLAST.", "Cirurgia Plástica" },
                    { 3, "MED. ESP.", "Medicina Esportiva" },
                    { 4, "ORTOP. E TRAUM.", "Ortopedia e Traumatologia" }
                });

            migrationBuilder.InsertData(
                table: "UsuarioProfissionalEspecialidade",
                columns: new[] { "EspecialidadeId", "Id" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "UsuarioProfissionalEspecialidade",
                columns: new[] { "EspecialidadeId", "Id" },
                values: new object[] { 3, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Especialidade",
                keyColumn: "EspecialidadeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Especialidade",
                keyColumn: "EspecialidadeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UsuarioProfissionalEspecialidade",
                keyColumns: new[] { "EspecialidadeId", "Id" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "UsuarioProfissionalEspecialidade",
                keyColumns: new[] { "EspecialidadeId", "Id" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Especialidade",
                keyColumn: "EspecialidadeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Especialidade",
                keyColumn: "EspecialidadeId",
                keyValue: 3);
        }
    }
}
