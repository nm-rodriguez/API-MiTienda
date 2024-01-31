namespace MiTienda.Domain.Entities
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
