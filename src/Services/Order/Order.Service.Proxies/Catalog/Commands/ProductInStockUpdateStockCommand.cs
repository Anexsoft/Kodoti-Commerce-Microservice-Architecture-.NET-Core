using System.Collections.Generic;

namespace Order.Service.Proxies.Catalog.Commands
{
    public enum ProductInStockAction
    {
        Add,
        Substract
    }

    public class ProductInStockUpdateStockCommand
    {
        public IEnumerable<ProductInStockUpdate> Items { get; set; } = new List<ProductInStockUpdate>();
    }

    public class ProductInStockUpdate
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public ProductInStockAction Action { get; set; }
    }
}
