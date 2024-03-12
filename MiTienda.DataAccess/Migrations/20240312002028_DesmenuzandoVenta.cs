using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiTienda.DataAccess.Migrations
{
    public partial class DesmenuzandoVenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Marca_MarcaId",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_LineaDeVenta_Venta_VentaId",
                table: "LineaDeVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Articulo_ArticuloId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Color_ColorId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Talle_TalleId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Cliente_ClienteId",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Pago_PagoId",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_TipoComprobante_TipoComprobanteId",
                table: "Venta");

            migrationBuilder.RenameColumn(
                name: "VentaId",
                table: "LineaDeVenta",
                newName: "VentaID");

            migrationBuilder.RenameIndex(
                name: "IX_LineaDeVenta_VentaId",
                table: "LineaDeVenta",
                newName: "IX_LineaDeVenta_VentaID");

            migrationBuilder.AlterColumn<int>(
                name: "TipoComprobanteId",
                table: "Venta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PagoId",
                table: "Venta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Importe",
                table: "Venta",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Venta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TalleId",
                table: "Stock",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "Stock",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ArticuloId",
                table: "Stock",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "State",
                table: "Articulo",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<double>(
                name: "PorcentajeIVA",
                table: "Articulo",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "MargenGanancia",
                table: "Articulo",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "MarcaId",
                table: "Articulo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Marca_MarcaId",
                table: "Articulo",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LineaDeVenta_Venta_VentaID",
                table: "LineaDeVenta",
                column: "VentaID",
                principalTable: "Venta",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Articulo_ArticuloId",
                table: "Stock",
                column: "ArticuloId",
                principalTable: "Articulo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Color_ColorId",
                table: "Stock",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Talle_TalleId",
                table: "Stock",
                column: "TalleId",
                principalTable: "Talle",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Cliente_ClienteId",
                table: "Venta",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Pago_PagoId",
                table: "Venta",
                column: "PagoId",
                principalTable: "Pago",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_TipoComprobante_TipoComprobanteId",
                table: "Venta",
                column: "TipoComprobanteId",
                principalTable: "TipoComprobante",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Marca_MarcaId",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_LineaDeVenta_Venta_VentaID",
                table: "LineaDeVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Articulo_ArticuloId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Color_ColorId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Talle_TalleId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Cliente_ClienteId",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Pago_PagoId",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_TipoComprobante_TipoComprobanteId",
                table: "Venta");

            migrationBuilder.RenameColumn(
                name: "VentaID",
                table: "LineaDeVenta",
                newName: "VentaId");

            migrationBuilder.RenameIndex(
                name: "IX_LineaDeVenta_VentaID",
                table: "LineaDeVenta",
                newName: "IX_LineaDeVenta_VentaId");

            migrationBuilder.AlterColumn<int>(
                name: "TipoComprobanteId",
                table: "Venta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PagoId",
                table: "Venta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Importe",
                table: "Venta",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Venta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TalleId",
                table: "Stock",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "Stock",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArticuloId",
                table: "Stock",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "State",
                table: "Articulo",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PorcentajeIVA",
                table: "Articulo",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MargenGanancia",
                table: "Articulo",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_LineaDeVenta_Venta_VentaId",
                table: "LineaDeVenta",
                column: "VentaId",
                principalTable: "Venta",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Articulo_ArticuloId",
                table: "Stock",
                column: "ArticuloId",
                principalTable: "Articulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Color_ColorId",
                table: "Stock",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Talle_TalleId",
                table: "Stock",
                column: "TalleId",
                principalTable: "Talle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Cliente_ClienteId",
                table: "Venta",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Pago_PagoId",
                table: "Venta",
                column: "PagoId",
                principalTable: "Pago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_TipoComprobante_TipoComprobanteId",
                table: "Venta",
                column: "TipoComprobanteId",
                principalTable: "TipoComprobante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
