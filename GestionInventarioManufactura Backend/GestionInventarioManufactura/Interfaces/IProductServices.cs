using GestionInventarioManufactura.Dtos;
using GestionInventarioManufactura.Models;
using GestionInventarioManufactura.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionInventarioManufactura.Interfaces
{
    public interface IProductServices
    {
        Task<PageResult<Product>> GetAllProduct(int pageNumber, int pageSize);
        Task<Product> GetById(int id);

        Task<ApiResponse> ChangeStatus(int id);
        Task<ApiResponse> SaveProducts(IEnumerable<ProductDto> products);
        Task<ApiResponse> UpdateProduct(int id, UpdateProductDto updatePorductDto );
        Task<ApiResponse> DeleteProduct(int id);
    }
}
