namespace MiTienda.DataAccess.Entities
{
    public class ClienteDB
    {
        public int Dni { get; set; }
        public string Cuil { get; set; }
        public string Nombre{ get; set; }

        private void AsociarCliente()
        {
            throw new NotImplementedException();
        }
    }
}
