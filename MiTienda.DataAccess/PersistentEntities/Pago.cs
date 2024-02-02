namespace MiTienda.DataAccess.PersistenceEntities
{
    public class Pago
    {

        public DateTime FechaPago { get; set; }
        public double Monto { get; set; }


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
