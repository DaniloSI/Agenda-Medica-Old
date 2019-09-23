using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaMedica.Data.Migrations
{
    public partial class ConsultaSemEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Endereco_EnderecoId",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_EnderecoId",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Consulta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Consulta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_EnderecoId",
                table: "Consulta",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Endereco_EnderecoId",
                table: "Consulta",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
