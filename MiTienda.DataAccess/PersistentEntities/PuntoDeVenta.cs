﻿namespace MiTienda.DataAccess.PersistenceEntities
{
    public class PuntoDeVenta
    {
        public int Numero { get; set; }
        public Vendedor Vendedor { get; set; }

        private void AgregarVenta()
        {
            throw new NotImplementedException();
        }
    
    }
}
