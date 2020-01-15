using MediatR;
using System.Collections.Generic;
using static Catalog.Common.Enums;

namespace Catalog.Service.EventHandlers.Commands
{
    public class ProductInStockUpdateStockCommand : INotification
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
