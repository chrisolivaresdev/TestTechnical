using GestionInventarioManufactura.DataAccess;
using GestionInventarioManufactura.Dtos;
using GestionInventarioManufactura.Interfaces;
using GestionInventarioManufactura.Models;
using GestionInventarioManufactura.Utils;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace GestionInventarioManufactura.Services
{
    public class ProductService : IProductServices
    {

        private readonly DbTechnicalTest _dbTechnicalTest;
        private readonly IProductRepository _productRepository;
        public ProductService(DbTechnicalTest dbTechnicalTest, IProductRepository productoRepository)
        {
            _dbTechnicalTest = dbTechnicalTest;
            _productRepository = productoRepository;
        }

        public async Task<ApiResponse> DeleteProduct(int id)
        {
            try
            {
                var product = await _productRepository.FindById(id);
                if (product == null)
                {
                    throw new KeyNotFoundException("product not found");
                }

                await _productRepository.Delete(product);

                return new ApiResponse
                {
                    isSuccess = true,
                    msj = $"Product {product.Name} removed successfully"
                 };

            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        public async Task<PageResult<Product>> GetAllProduct(int pageNumber, int pageSize)
        {
            try
            {
                var count = await _productRepository.FindAll();

                var products = await _dbTechnicalTest.Product
              .Skip((pageNumber - 1) * pageSize)
              .Take(pageSize)
              .ToListAsync();

                return new PageResult<Product>
                {
                    Data = products,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalItems = count
                };

            }
            catch (ArgumentException ex)
            {
                throw ex;
            }

        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                var product = await _productRepository.FindById(id);

                if (product == null)
                {
                    throw new KeyNotFoundException("product not found");
                }
                return product;
             }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }



        public async Task<ApiResponse> UpdateProduct(int id, UpdateProductDto updatePorductDto)
        {
            try
            {
                var product = await _productRepository.FindById(id);

                if (product == null)
                {
                    throw new KeyNotFoundException("product not found");
                }

                product.Name = updatePorductDto.Name;
                product.TypeElaboration = updatePorductDto.TypeElaboration;
                product.Status = updatePorductDto.Status;

                await _productRepository.Update(product);

                return new ApiResponse
                {
                    isSuccess = true,
                    msj = $"Product {product.Name} updated successfully"
                };

            } catch (ArgumentException ex) {
                throw ex;
            }
        }
        public async Task<ApiResponse> ChangeStatus(int id)
        {
            try
            {
                var product = await _productRepository.FindById(id);

                if (product == null)
                {
                    throw new KeyNotFoundException("product not found");
                }

                if (product.Status == "Available")
                {
                    product.Status = "Defective";
                }
                else
                {
                    product.Status = "Available";
                }


                await _productRepository.Update(product);

                return new ApiResponse
                {
                    isSuccess = true,
                    msj = $"Product {product.Name} updated successfully"
                };

            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        public async Task<ApiResponse> SaveProducts(IEnumerable<ProductDto> productDtos)
        {
            try
            {

                var existingProducts = new List<Product>();
                var newProducts = new List<Product>();

                foreach (var dto in productDtos)
                {
                    var existingProduct = await _productRepository.FindByName(dto.Name);
                    if (existingProduct != null)
                    {
                            existingProducts.Add(existingProduct);
                        }
                    else
                    {
                        var product = new Product
                        {
                            Name = dto.Name,
                            TypeElaboration = dto.TypeElaboration,
                            Status = dto.Status
                        };
                        newProducts.Add(product);
                    }
                }
                string responseMessage = "";

                if (newProducts.Any())
                {
                    await _productRepository.AddProducts(newProducts);
                     responseMessage = "Products created successfully.";
                }


                if (existingProducts.Any())
                {
                    var existingProductNames = string.Join(", ", existingProducts.Select(p => p.Name));
                    responseMessage += $" The following products were not created because they already exist: {existingProductNames}.";
                }


                return new ApiResponse
                {
                    isSuccess = true,
                    msj = responseMessage
                };
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
    }
}
