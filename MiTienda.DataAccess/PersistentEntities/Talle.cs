using MiTienda.Domain.Enums;

namespace MiTienda.DataAccess.Entities
{
    public class Talle
    {
        public string Medida { get; set; }
        public TipoTalle TipoTalle { get; set; }
    }
}
