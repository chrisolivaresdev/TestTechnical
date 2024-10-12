namespace GestionInventarioManufactura.Utils
{
        public class PageResult<T>
        {
            public required List<T> Data { get; set; }
            public int TotalItems { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
        }
}
