using Microsoft.EntityFrameworkCore;
using MiTienda.DataAccess.PersistenceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.DataAccess.Contexts
{
    public class MiTiendaContexto : DbContext
    {
        public MiTiendaContexto(DbContextOptions <MiTiendaContexto> options): base(options)
        {

        }
        public DbSet<ArticuloDB> Articulos { get; set; }
        public DbSet<MarcaDB> Marcas { get; set; }
        public DbSet<CategoriaDB> Categorias { get; set; }
        public DbSet<StockDB> Stocks { get; set; }
        public DbSet<TipoTalleDB> TipoTalles { get; set; }
        public DbSet<TalleDB> Talles { get; set; }
        public DbSet<ColorDB> Colores { get; set; }

        public DbSet<ClienteDB> Cliente {get;set; }
        public DbSet<CondicionTributariaDB> CondicionTributaria {get;set; }
        public DbSet<LineaDeVentaDB> LineaDeVenta {get;set; }
        public DbSet<PagoDB> Pago {get;set; }
        public DbSet<PuntoDeVentaDB> PuntoDeVenta {get;set; }
        public DbSet<SucursalDB> Sucursal {get;set; }
        public DbSet<TiendaDB> Tienda {get;set; }
        public DbSet<TipoComprobanteDB> TipoComprobante {get;set; }
        public DbSet<TipoPagoDB> TipoPago {get;set; }
        public DbSet<VendedorDB> Vendedor {get;set; }
        public DbSet<VentaDB> Venta {get;set; }
        public DbSet<InventarioDB> Inventario {get;set; }


        //public DbSet<T> CreateSet<T>() where T : class
        //{
        //    return Set<T>();
        //}
        ////se puede declarar aqui el string connection en vez de la clase program
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (optionsBuilder.IsConfigured) return;
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ControlDeCalidad;Integrated Security=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticuloDB>().ToTable("Articulo");
            modelBuilder.Entity<MarcaDB>().ToTable("Marca");
            modelBuilder.Entity<CategoriaDB>().ToTable("Categoria");

            modelBuilder.Entity<StockDB>().ToTable("Stock");
            modelBuilder.Entity<TipoTalleDB>().ToTable("TipoTalle");
            modelBuilder.Entity<TalleDB>().ToTable("Talle");
            modelBuilder.Entity<ColorDB>().ToTable("Color");

            modelBuilder.Entity<ClienteDB>().ToTable("Cliente");
            modelBuilder.Entity<CondicionTributariaDB>().ToTable("CondicionTributaria");
            modelBuilder.Entity<LineaDeVentaDB>().ToTable("LineaDeVenta");
            modelBuilder.Entity<PagoDB>().ToTable("Pago");                                     
            modelBuilder.Entity<PuntoDeVentaDB>().ToTable("PuntoDeVenta");
            modelBuilder.Entity<SucursalDB>().ToTable("Sucursal");
            modelBuilder.Entity<TiendaDB>().ToTable("Tienda");
            modelBuilder.Entity<TipoComprobanteDB>().ToTable("TipoComprobante");
            modelBuilder.Entity<TipoPagoDB>().ToTable("TipoPago");
            modelBuilder.Entity<VendedorDB>().ToTable("Vendedor");
            modelBuilder.Entity<VentaDB>().ToTable("Venta");
            modelBuilder.Entity<InventarioDB>().ToTable("Inventario");


        }

    }
}
