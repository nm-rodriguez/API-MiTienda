using Microsoft.EntityFrameworkCore;
using MiTienda.DataAccess.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticuloDB>().ToTable("Articulo");
            modelBuilder.Entity<MarcaDB>().ToTable("Marca");
            modelBuilder.Entity<CategoriaDB>().ToTable("Categoria");
        }

    }
}
