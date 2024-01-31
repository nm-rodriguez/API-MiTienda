namespace MiTienda.Domain.Entities
{
    public class Stock
    {
        public int Cantidad { get; set; }
        public Talle Talle { get; set; }
        public Color Color { get; set; }
        public Articulo Articulo { get; set; }

        private double GetPrecio()
        {
            throw new NotImplementedException();
        }
    }
}
