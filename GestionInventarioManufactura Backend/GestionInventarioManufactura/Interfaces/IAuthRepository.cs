using GestionInventarioManufactura.Models;

namespace GestionInventarioManufactura.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> FindUserByEmail(string email);
    }
}
