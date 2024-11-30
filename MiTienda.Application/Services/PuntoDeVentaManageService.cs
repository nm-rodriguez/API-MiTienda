using Microsoft.EntityFrameworkCore;
using MiTienda.Application.Contracts;
using MiTienda.Application.DTOs;
using MiTienda.DataAccess.Repositories;
using MiTienda.Domain.Contracts;
using MiTienda.Domain.Entities;

namespace MiTienda.Application.Services
{
    public class PuntoDeVentaManageService : IManagePuntoDeVentaService
    {
        private IRepository<PuntoDeVenta> _puntoDeVentaRepo;

        public PuntoDeVentaManageService(IRepository<PuntoDeVenta> puntoDeVentaRepo)
        {
            _puntoDeVentaRepo = puntoDeVentaRepo;

        }
        public List<PuntoDeVentaDTO> GetPuntoDeVentas()
        {
            List<PuntoDeVentaDTO> puntoDeVentaes = new List<PuntoDeVentaDTO>();

            foreach (PuntoDeVenta puntoDeVenta in _puntoDeVentaRepo.GetAll())
            {
                PuntoDeVentaDTO PuntoDeVentaDTO = new PuntoDeVentaDTO(puntoDeVenta);
                puntoDeVentaes.Add(PuntoDeVentaDTO);
            }
            return puntoDeVentaes;
        }

        public PuntoDeVenta GetPuntoDeVentaById(int id)
        {
            var puntoDeVenta = _puntoDeVentaRepo.GetByID(id).FirstOrDefault();
            return (puntoDeVenta == null) ? null : new PuntoDeVenta();

        }


    }
}
