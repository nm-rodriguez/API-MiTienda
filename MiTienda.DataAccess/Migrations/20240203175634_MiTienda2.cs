using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiTienda.DataAccess.Migrations
{
    public partial class MiTienda2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Marca",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)");

            migrationBuilder.AlterColumn<double>(
                name: "PrecioFinal",
                table: "Articulo",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "NetoGravado",
                table: "Articulo",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Articulo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoBarras",
                table: "Articulo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)");

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    IdColor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.IdColor);
                });

            migrationBuilder.CreateTable(
                name: "CondicionTributaria",
                columns: table => new
                {
                    IdCondicionTributaria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abreviatura = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicionTributaria", x => x.IdCondicionTributaria);
                });

            migrationBuilder.CreateTable(
                name: "TipoComprobante",
                columns: table => new
                {
                    IdTipoComprobante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoComprobante", x => x.IdTipoComprobante);
                });

            migrationBuilder.CreateTable(
                name: "TipoPago",
                columns: table => new
                {
                    IdTipoPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPago", x => x.IdTipoPago);
                });

            migrationBuilder.CreateTable(
                name: "TipoTalle",
                columns: table => new
                {
                    IdTipoTalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descipcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTalle", x => x.IdTipoTalle);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Cuil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCondicionTributaria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_CondicionTributaria_IdCondicionTributaria",
                        column: x => x.IdCondicionTributaria,
                        principalTable: "CondicionTributaria",
                        principalColumn: "IdCondicionTributaria");
                });

            migrationBuilder.CreateTable(
                name: "Tienda",
                columns: table => new
                {
                    IdTienda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cuil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCondicionTributaria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tienda", x => x.IdTienda);
                    table.ForeignKey(
                        name: "FK_Tienda_CondicionTributaria_IdCondicionTributaria",
                        column: x => x.IdCondicionTributaria,
                        principalTable: "CondicionTributaria",
                        principalColumn: "IdCondicionTributaria");
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    IdTipoPago = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_Pago_TipoPago_IdTipoPago",
                        column: x => x.IdTipoPago,
                        principalTable: "TipoPago",
                        principalColumn: "IdTipoPago");
                });

            migrationBuilder.CreateTable(
                name: "Talle",
                columns: table => new
                {
                    IdTalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoTalle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talle", x => x.IdTalle);
                    table.ForeignKey(
                        name: "FK_Talle_TipoTalle_IdTipoTalle",
                        column: x => x.IdTipoTalle,
                        principalTable: "TipoTalle",
                        principalColumn: "IdTipoTalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    IdSucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTienda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.IdSucursal);
                    table.ForeignKey(
                        name: "FK_Sucursal_Tienda_IdTienda",
                        column: x => x.IdTienda,
                        principalTable: "Tienda",
                        principalColumn: "IdTienda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    IdStock = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTalle = table.Column<int>(type: "int", nullable: false),
                    IdColor = table.Column<int>(type: "int", nullable: false),
                    IdArticulo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.IdStock);
                    table.ForeignKey(
                        name: "FK_Stock_Articulo_IdArticulo",
                        column: x => x.IdArticulo,
                        principalTable: "Articulo",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Color_IdColor",
                        column: x => x.IdColor,
                        principalTable: "Color",
                        principalColumn: "IdColor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Talle_IdTalle",
                        column: x => x.IdTalle,
                        principalTable: "Talle",
                        principalColumn: "IdTalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PuntoDeVenta",
                columns: table => new
                {
                    IdPuntoDeVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoDeVenta", x => x.IdPuntoDeVenta);
                    table.ForeignKey(
                        name: "FK_PuntoDeVenta_Sucursal_IdSucursal",
                        column: x => x.IdSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    IdVendedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Legajo = table.Column<int>(type: "int", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.IdVendedor);
                    table.ForeignKey(
                        name: "FK_Vendedor_Sucursal_IdSucursal",
                        column: x => x.IdSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal");
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    IdInventario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IdStock = table.Column<int>(type: "int", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.IdInventario);
                    table.ForeignKey(
                        name: "FK_Inventario_Stock_IdStock",
                        column: x => x.IdStock,
                        principalTable: "Stock",
                        principalColumn: "IdStock",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventario_Sucursal_IdSucursal",
                        column: x => x.IdSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdVendedor = table.Column<int>(type: "int", nullable: true),
                    IdPago = table.Column<int>(type: "int", nullable: true),
                    IdCliente = table.Column<int>(type: "int", nullable: true),
                    IdTipoComprobante = table.Column<int>(type: "int", nullable: true),
                    IdPuntoDeVenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Venta_Pago_IdPago",
                        column: x => x.IdPago,
                        principalTable: "Pago",
                        principalColumn: "IdPago");
                    table.ForeignKey(
                        name: "FK_Venta_PuntoDeVenta_IdPuntoDeVenta",
                        column: x => x.IdPuntoDeVenta,
                        principalTable: "PuntoDeVenta",
                        principalColumn: "IdPuntoDeVenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_TipoComprobante_IdTipoComprobante",
                        column: x => x.IdTipoComprobante,
                        principalTable: "TipoComprobante",
                        principalColumn: "IdTipoComprobante");
                    table.ForeignKey(
                        name: "FK_Venta_Vendedor_IdVendedor",
                        column: x => x.IdVendedor,
                        principalTable: "Vendedor",
                        principalColumn: "IdVendedor");
                });

            migrationBuilder.CreateTable(
                name: "LineaDeVenta",
                columns: table => new
                {
                    IdLineaDeVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IdStock = table.Column<int>(type: "int", nullable: false),
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaDeVenta", x => x.IdLineaDeVenta);
                    table.ForeignKey(
                        name: "FK_LineaDeVenta_Stock_IdStock",
                        column: x => x.IdStock,
                        principalTable: "Stock",
                        principalColumn: "IdStock",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineaDeVenta_Venta_IdVenta",
                        column: x => x.IdVenta,
                        principalTable: "Venta",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdCondicionTributaria",
                table: "Cliente",
                column: "IdCondicionTributaria");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdStock",
                table: "Inventario",
                column: "IdStock");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdSucursal",
                table: "Inventario",
                column: "IdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeVenta_IdStock",
                table: "LineaDeVenta",
                column: "IdStock");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeVenta_IdVenta",
                table: "LineaDeVenta",
                column: "IdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_IdTipoPago",
                table: "Pago",
                column: "IdTipoPago");

            migrationBuilder.CreateIndex(
                name: "IX_PuntoDeVenta_IdSucursal",
                table: "PuntoDeVenta",
                column: "IdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_IdArticulo",
                table: "Stock",
                column: "IdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_IdColor",
                table: "Stock",
                column: "IdColor");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_IdTalle",
                table: "Stock",
                column: "IdTalle");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_IdTienda",
                table: "Sucursal",
                column: "IdTienda");

            migrationBuilder.CreateIndex(
                name: "IX_Talle_IdTipoTalle",
                table: "Talle",
                column: "IdTipoTalle");

            migrationBuilder.CreateIndex(
                name: "IX_Tienda_IdCondicionTributaria",
                table: "Tienda",
                column: "IdCondicionTributaria");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_IdSucursal",
                table: "Vendedor",
                column: "IdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdCliente",
                table: "Venta",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdPago",
                table: "Venta",
                column: "IdPago");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdPuntoDeVenta",
                table: "Venta",
                column: "IdPuntoDeVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdTipoComprobante",
                table: "Venta",
                column: "IdTipoComprobante");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdVendedor",
                table: "Venta",
                column: "IdVendedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "LineaDeVenta");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Talle");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "PuntoDeVenta");

            migrationBuilder.DropTable(
                name: "TipoComprobante");

            migrationBuilder.DropTable(
                name: "Vendedor");

            migrationBuilder.DropTable(
                name: "TipoTalle");

            migrationBuilder.DropTable(
                name: "TipoPago");

            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropTable(
                name: "Tienda");

            migrationBuilder.DropTable(
                name: "CondicionTributaria");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Marca",
                type: "nvarchar(35)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(35)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PrecioFinal",
                table: "Articulo",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "NetoGravado",
                table: "Articulo",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Articulo",
                type: "nvarchar(35)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoBarras",
                table: "Articulo",
                type: "nvarchar(35)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
