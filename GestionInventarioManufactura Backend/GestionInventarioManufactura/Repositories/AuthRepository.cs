using GestionInventarioManufactura.DataAccess;
using GestionInventarioManufactura.Interfaces;
using GestionInventarioManufactura.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionInventarioManufactura.Repositories
{
    public class AuthRepository: IAuthRepository
    {

        private readonly DbTechnicalTest _dbTechnicalTest;
        public AuthRepository( DbTechnicalTest dbTechnicalTest)
        {
            _dbTechnicalTest = dbTechnicalTest;
        }

        public async Task<User> FindUserByEmail(string email)
        {
            return await _dbTechnicalTest.User.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
