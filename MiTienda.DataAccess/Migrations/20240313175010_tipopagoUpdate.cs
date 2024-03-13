using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiTienda.DataAccess.Migrations
{
    public partial class tipopagoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Marca_MarcaId",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Pago_DetallePagoTarjeta_DetallePagoTarjetaId",
                table: "Pago");

            migrationBuilder.DropTable(
                name: "DetallePagoTarjeta");

            migrationBuilder.DropIndex(
                name: "IX_Pago_DetallePagoTarjetaId",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "DetallePagoTarjetaId",
                table: "Pago");

            migrationBuilder.AddColumn<string>(
                name: "TipoTarjeta",
                table: "Pago",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MarcaId",
                table: "Articulo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Marca_MarcaId",
                table: "Articulo",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Marca_MarcaId",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "TipoTarjeta",
                table: "Pago");

            migrationBuilder.AddColumn<int>(
                name: "DetallePagoTarjetaId",
                table: "Pago",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MarcaId",
                table: "Articulo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DetallePagoTarjeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePagoTarjeta", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pago_DetallePagoTarjetaId",
                table: "Pago",
                column: "DetallePagoTarjetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Marca_MarcaId",
                table: "Articulo",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_DetallePagoTarjeta_DetallePagoTarjetaId",
                table: "Pago",
                column: "DetallePagoTarjetaId",
                principalTable: "DetallePagoTarjeta",
                principalColumn: "Id");
        }
    }
}
