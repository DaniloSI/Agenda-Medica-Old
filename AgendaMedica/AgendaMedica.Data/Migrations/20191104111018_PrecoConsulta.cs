using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaMedica.Data.Migrations
{
    public partial class PrecoConsulta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecoConsulta",
                table: "Agenda",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoConsulta",
                table: "Agenda");
        }
    }
}
