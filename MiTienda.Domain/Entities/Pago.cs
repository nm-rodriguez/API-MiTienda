using MiTienda.Domain.Utilidades;

namespace MiTienda.Domain.Entities
{
    public class Pago : EntidadPersistible
    {

        public DateTime FechaPago { get; set; }
        public double Monto { get; set; }
        public TipoPago TipoPago { get; set; }


        private void RealizarPago()
        {
            throw new NotImplementedException();
        }
        //private void AgregarTarjeta()
        //{
        //    throw new NotImplementedException();
        //}
        //private void AgregarPago()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
