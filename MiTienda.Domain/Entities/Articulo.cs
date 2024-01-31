
namespace MiTienda.Domain.Entities
{
    public class Articulo 
    {
        public string Descripcion{ get; set; }
        public string CodigoBarras { get; set; }
        public double Costo { get; set; }
        public double MargenGanancia { get; set; }
        public double PrecioFinal { get; set; }
        public double NetoGravado { get; set; }
        public double PorcentajeIVA { get; set; }
        public Marca  Marca { get; set; }
        public Categoria Categoria { get; set; }
        

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
