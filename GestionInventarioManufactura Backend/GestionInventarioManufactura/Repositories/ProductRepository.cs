using GestionInventarioManufactura.DataAccess;
using GestionInventarioManufactura.Dtos;
using GestionInventarioManufactura.Interfaces;
using GestionInventarioManufactura.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionInventarioManufactura.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbTechnicalTest _dbTechnicalTest;
        public ProductRepository(DbTechnicalTest dbTechnicalTest)
        {
            _dbTechnicalTest = dbTechnicalTest;
        }

        public async Task Delete(Product product)
        {
             _dbTechnicalTest.Product.Remove(product);
            await _dbTechnicalTest.SaveChangesAsync();
        }

        public async Task<int> FindAll()
        {
           return await _dbTechnicalTest.Product.CountAsync();
        }

        public async Task<Product> FindById(int id)
        {
            return await _dbTechnicalTest.Product.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> FindByName(string name)
        {
            return await _dbTechnicalTest.Product.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task Update( Product product)
        {
            _dbTechnicalTest.Product.Update(product);
            await _dbTechnicalTest.SaveChangesAsync();
        }

        public async Task AddProducts(IEnumerable<Product> products)
        {
           await _dbTechnicalTest.Product.AddRangeAsync(products);
           await _dbTechnicalTest.SaveChangesAsync();
        }
    }
}

