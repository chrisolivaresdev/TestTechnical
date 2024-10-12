using System.ComponentModel;

namespace GestionInventarioManufactura.Models
{
    public class Product
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string TypeElaboration { get; set; }

            public string Status { get; set; } 
    }
}
