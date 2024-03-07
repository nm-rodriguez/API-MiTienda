using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiTienda.DataAccess.Contracts;
using MiTienda.Domain.Entities;
using System.Linq.Expressions;

namespace MiTienda.DataAccess.Contexts
{
    public class MiTiendaContexto : IdentityDbContext, ITiendaEF
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
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<TipoTalle>().ToTable("TipoTalle");
            modelBuilder.Entity<TipoPago>().ToTable("TipoPago");
            modelBuilder.Entity<TipoComprobante>().ToTable("TipoComprobante");
            modelBuilder.Entity<CondicionTributaria>().ToTable("CondicionTributaria");
            modelBuilder.Entity<Marca>().ToTable("Marca");
            modelBuilder.Entity<Articulo>().ToTable("Articulo");
            modelBuilder.Entity<Talle>().ToTable("Talle");
            modelBuilder.Entity<Color>().ToTable("Color");
            modelBuilder.Entity<Stock>().ToTable("Stock");
            modelBuilder.Entity<Tienda>().ToTable("Tienda");
            modelBuilder.Entity<Sucursal>().ToTable("Sucursal");
            modelBuilder.Entity<PuntoDeVenta>().ToTable("PuntoDeVenta");
            modelBuilder.Entity<Pago>().ToTable("Pago");
            modelBuilder.Entity<Vendedor>().ToTable("Vendedor");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<LineaDeVenta>().ToTable("LineaDeVenta");
            modelBuilder.Entity<Venta>().ToTable("Venta");
            modelBuilder.Entity<Inventario>().ToTable("Inventario");

            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<T> DbSet<T>() where T : class
        {   return Set<T>();    }

        public void SaveChangesDB()
        {
            SaveChanges();
        }

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

        public void RelacionarEntidad<T, E>(T item, Expression<Func<T, E>> entidad)
            where T : class
            where E : class
        {
            Entry<T>(item).Reference(entidad).Load();
        }

        //public void RelacionarColeccion<T, C>(T item, params string[] colecciones)
        public void RelacionarColeccion<T, C>(T item, Expression<Func<T, IEnumerable<C>>> coleccion)
            where T : class
            where C : class
        {
            Entry<T>(item).Collection(coleccion).Load();
        }

    }
}
