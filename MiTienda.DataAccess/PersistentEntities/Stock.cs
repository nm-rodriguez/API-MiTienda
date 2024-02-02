namespace MiTienda.DataAccess.Entities
{
    public class Stock
    {
        public int Cantidad { get; set; }
        public TalleDTO Talle { get; set; }
        public ColorDB Color { get; set; }
        public ArticuloDB Articulo { get; set; }

        private double GetPrecio()
        {
            throw new NotImplementedException();
        }
    }
}
