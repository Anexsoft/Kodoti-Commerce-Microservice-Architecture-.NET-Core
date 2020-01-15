using System.Collections.Generic;

namespace Catalog.Service.Queries.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductInStockDto Stock { get; set; }
    }
}
