
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiTienda.DataAccess.PersistenceEntities
{
    public class ArticuloDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArticulo { get; set; }
        public string Descripcion { get; set; }
        public string CodigoBarras { get; set; }
        public double Costo { get; set; }
        public double MargenGanancia { get; set; }
        public double? PrecioFinal { get; set; }
        public double? NetoGravado { get; set; }
        public double PorcentajeIVA { get; set; }
        [ForeignKey("IdMarca")]
        public MarcaDB Marca { get; set; }
        [ForeignKey("IdCategoria")]
        public CategoriaDB Categoria { get; set; }


        private List<ColorDB> GetColores()
        {
            throw new NotImplementedException();
        }
        private List<TalleDB> GetTalles()
        {
            throw new NotImplementedException();
        }
        private CategoriaDB GetCategoria()
        {
            throw new NotImplementedException();
        }
        private MarcaDB GetMarca()
        {
            throw new NotImplementedException();
        }
        private StockDB GetStock()
        {
            throw new NotImplementedException();
        }

        public ArticuloDB Buscar()
        {
            throw new NotImplementedException();
        }
    }
}
