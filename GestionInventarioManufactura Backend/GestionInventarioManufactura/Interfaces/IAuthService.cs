using GestionInventarioManufactura.Dtos;
using GestionInventarioManufactura.Models;
using GestionInventarioManufactura.Utils;

namespace GestionInventarioManufactura.Interfaces
{
    public interface IAuthService
    {
        Task<bool> ValidatePassword(User user, string password);
        Task<AuthReponse> Login(LoginDto loginDto);
        Task<ApiResponse> Register(RegisterDto registerDto);
    }
}
