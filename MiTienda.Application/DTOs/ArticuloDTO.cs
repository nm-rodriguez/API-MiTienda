using MiTienda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.DTOs
{
    public class ArticuloDTO
    {
        public ArticuloDTO(Articulo articulo)
        {
            Id = articulo.Id;
            Descripcion = articulo.Descripcion;
            CodigoBarras = articulo.CodigoBarras;
            Costo = articulo.Costo;
            MargenGanancia = articulo.MargenGanancia;
            PrecioFinal = articulo.PrecioFinal;
            NetoGravado = articulo.NetoGravado;
            PorcentajeIVA = articulo.PorcentajeIVA;
            CategoriaId = articulo.Categoria.Id;
            CategoriaDescripcion = articulo.Categoria.Descripcion;
            MarcaId = articulo.Marca.Id;
            MarcaNombre = articulo.Marca.Nombre;
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string CodigoBarras { get; set; }
        public double Costo { get; set; }
        public double MargenGanancia { get; set; }
        public double? PrecioFinal { get; set; }
        public double? NetoGravado { get; set; }
        public double PorcentajeIVA { get; set; }

        public int CategoriaId { get; set; }
        public int MarcaId { get; set; }
        public string MarcaNombre { get; set; }

        public string CategoriaDescripcion { get; set; }



    }
}

