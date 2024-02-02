namespace MiTienda.DataAccess.PersistenceEntities
{
    public class Sucursal
    {
        public int Numero { get; set; }
        public PuntoDeVenta PuntoDeVenta { get; set; }

        private int ObtenerCantidadStock()
        {
            throw new NotImplementedException();
        }
    }
}
