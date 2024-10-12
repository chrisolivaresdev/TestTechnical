using System.ComponentModel;

namespace GestionInventarioManufactura.Dtos
{
    public class ProductDto
    {
        public required string Name { get; set; }
        public required string TypeElaboration { get; set; }

        public required string Status { get; set; }
    }

    public class UpdateProductDto
    {
        public string? Name { get; set; }
        public string? TypeElaboration { get; set; }
        public string? Status { get; set; }
        
    }
}
