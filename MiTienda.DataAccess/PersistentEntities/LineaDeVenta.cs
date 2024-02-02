namespace MiTienda.DataAccess.PersistenceEntities
{
    public class LineaDeVenta
    {
        public int Cantidad { get; set; }
        public StockDB Stock { get; set; }
        private void Crear()
        {
            throw new NotImplementedException();

        }
        private double GetPrecio()
        {
            throw new NotImplementedException();
        }
    }
}
