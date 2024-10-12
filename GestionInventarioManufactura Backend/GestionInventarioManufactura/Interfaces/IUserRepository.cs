using GestionInventarioManufactura.Dtos;
using GestionInventarioManufactura.Models;

namespace GestionInventarioManufactura.Interfaces
{
    public interface IUserRepository
    {
         Task Add(User user );

    }
}
