using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiTienda.DataAccess.Migrations
{
    public partial class AgregoEstadoArticuloyVendedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Vendedor",
                newName: "UsuarioId");

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Vendedor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Articulo",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Vendedor");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Articulo");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Vendedor",
                newName: "Usuario");
        }
    }
}
