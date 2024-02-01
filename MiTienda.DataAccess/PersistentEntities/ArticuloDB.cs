
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiTienda.DataAccess.Entities
{
    public class Articulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string CodigoBarras { get; set; }
        public double Costo { get; set; }
        public double MargenGanancia { get; set; }
        public double PrecioFinal { get; set; }
        public double NetoGravado { get; set; }
        public double PorcentajeIVA { get; set; }
        [ForeignKey("Id")]
        public virtual Marca Marca { get; set; }
        [ForeignKey("Id")]
        public virtual Categoria Categoria { get; set; }


        private List<Color> GetColores()
        {
            throw new NotImplementedException();
        }
        private List<Talle> GetTalles()
        {
            throw new NotImplementedException();
        }
        private Categoria GetCategoria()
        {
            throw new NotImplementedException();
        }
        private Marca GetMarca()
        {
            throw new NotImplementedException();
        }
        private Stock GetStock()
        {
            throw new NotImplementedException();
        }

        public Articulo Buscar()
        {
            throw new NotImplementedException();
        }
    }
}
