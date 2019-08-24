using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaMedica.Data.Migrations
{
    public partial class InfoProfissional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "AspNetUsers",
                newName: "Registro");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Orgao",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Orgao",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Registro",
                table: "AspNetUsers",
                newName: "Telefone");
        }
    }
}
