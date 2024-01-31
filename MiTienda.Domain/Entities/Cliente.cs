namespace MiTienda.Domain.Entities
{
    public class Cliente
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
