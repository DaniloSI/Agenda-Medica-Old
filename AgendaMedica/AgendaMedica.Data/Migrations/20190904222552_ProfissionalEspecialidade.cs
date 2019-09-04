using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaMedica.Data.Migrations
{
    public partial class ProfissionalEspecialidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Especialidades",
                table: "Especialidades");

            migrationBuilder.RenameTable(
                name: "Especialidades",
                newName: "Especialidade");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Especialidade",
                table: "Especialidade",
                column: "EspecialidadeId");

            migrationBuilder.CreateTable(
                name: "UsuarioProfissionalEspecialidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EspecialidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioProfissionalEspecialidade", x => new { x.EspecialidadeId, x.Id });
                    table.ForeignKey(
                        name: "FK_UsuarioProfissionalEspecialidade_Especialidade_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidade",
                        principalColumn: "EspecialidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioProfissionalEspecialidade_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioProfissionalEspecialidade_Id",
                table: "UsuarioProfissionalEspecialidade",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioProfissionalEspecialidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Especialidade",
                table: "Especialidade");

            migrationBuilder.RenameTable(
                name: "Especialidade",
                newName: "Especialidades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Especialidades",
                table: "Especialidades",
                column: "EspecialidadeId");
        }
    }
}
