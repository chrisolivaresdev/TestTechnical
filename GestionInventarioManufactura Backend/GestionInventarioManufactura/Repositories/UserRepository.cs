using GestionInventarioManufactura.DataAccess;
using GestionInventarioManufactura.Dtos;
using GestionInventarioManufactura.Interfaces;
using GestionInventarioManufactura.Models;

namespace GestionInventarioManufactura.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DbTechnicalTest _dbTechnicalTest;
        public UserRepository(DbTechnicalTest dbTechnicalTest)
        {
            _dbTechnicalTest = dbTechnicalTest;
        }

        public async Task Add(User user)
        {
            _dbTechnicalTest.User.Add(user);
            await _dbTechnicalTest.SaveChangesAsync();
        }
    }
}
