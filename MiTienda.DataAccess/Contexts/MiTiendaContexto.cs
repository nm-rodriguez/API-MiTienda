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
        }

    }
}
