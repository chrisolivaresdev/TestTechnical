using GestionInventarioManufactura.DataAccess;
using GestionInventarioManufactura.Dtos;
using GestionInventarioManufactura.Models;

namespace GestionInventarioManufactura.Interfaces
{
    public interface IProductRepository{

        Task<int> FindAll();
        Task<Product> FindByName(string name);
        Task<Product> FindById(int id);
        Task AddProducts(IEnumerable<Product> products);
        Task Update(Product product);
        Task Delete(Product product);

    }
}
