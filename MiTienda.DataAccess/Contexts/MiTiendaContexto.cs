using Microsoft.EntityFrameworkCore;
using MiTienda.DataAccess.Contracts;
using MiTienda.DataAccess.PersistenceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.DataAccess.Contexts
{
    public class MiTiendaContexto : DbContext, IVentaEF
    {
        public MiTiendaContexto(){}
        public MiTiendaContexto(DbContextOptions <MiTiendaContexto> options): base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-17VUHHS;Database=MiTienda;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticuloDB>().ToTable("Articulo");
            modelBuilder.Entity<MarcaDB>().ToTable("Marca");
            modelBuilder.Entity<CategoriaDB>().ToTable("Categoria");

            modelBuilder.Entity<StockDB>().ToTable("Stock");
            modelBuilder.Entity<TipoTalleDB>().ToTable("TipoTalle");
            modelBuilder.Entity<TalleDB>().ToTable("Talle");
            modelBuilder.Entity<ColorDB>().ToTable("Color");

            modelBuilder.Entity<CondicionTributariaDB>().ToTable("CondicionTributaria");
            modelBuilder.Entity<SucursalDB>().ToTable("Sucursal");
            modelBuilder.Entity<TiendaDB>().ToTable("Tienda");
            modelBuilder.Entity<TipoPagoDB>().ToTable("TipoPago");

            modelBuilder.Entity<PuntoDeVentaDB>().ToTable("PuntoDeVenta");
            modelBuilder.Entity<TipoComprobanteDB>().ToTable("TipoComprobante");
            modelBuilder.Entity<PagoDB>().ToTable("Pago");                                     
            modelBuilder.Entity<VendedorDB>().ToTable("Vendedor");
            modelBuilder.Entity<ClienteDB>().ToTable("Cliente");
            modelBuilder.Entity<VentaDB>().ToTable("Venta");

            modelBuilder.Entity<InventarioDB>().ToTable("Inventario");
            modelBuilder.Entity<LineaDeVentaDB>().ToTable("LineaDeVenta");
        }

        public void Confirm()
        {   SaveChanges();  }

        public DbSet<T> CrearSet<T>() where T : class
        {   return Set<T>();    }

        public void Refrescar<T>(T item) where T : class
        {
            if (Entry(item).State != EntityState.Detached)
            {
                Attach(item);
            }
            base.Update(item);
        }

        public void SetModificado<T>(T item) where T : class
        {   Entry(item).State = EntityState.Modified;   }
    }
}
