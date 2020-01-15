using MediatR;
using Order.Domain;
using Order.Persistence.Database;
using Order.Service.EventHandlers.Commands;
using Order.Service.Proxies.Catalog;
using Order.Service.Proxies.Catalog.Commands;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Service.EventHandlers
{
    public class OrderCreateEventHandler :
        INotificationHandler<OrderCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICatalogProxy _catalogProxy;

        public OrderCreateEventHandler(
            ApplicationDbContext context,
            ICatalogProxy catalogProxy)
        {
            _context = context;
            _catalogProxy = catalogProxy;
        }

        public async Task Handle(OrderCreateCommand notification, CancellationToken cancellationToken)
        {
            var entry = new Domain.Order();

            using (var trx = await _context.Database.BeginTransactionAsync()) 
            {
                // 01. Prepare detail
                PrepareDetail(entry, notification);

                // 02. Prepare header
                PrepareHeader(entry, notification);

                // 03. Create order
                await _context.AddAsync(entry);
                await _context.SaveChangesAsync();
                 
                // 04. Update Stocks
                await _catalogProxy.UpdateStockAsync(new ProductInStockUpdateStockCommand
                {
                    Items = notification.Items.Select(x => new ProductInStockUpdate
                    {
                        ProductId = x.ProductId,
                        Stock = x.Quantity,
                        Action = ProductInStockAction.Substract
                    })
                });

                await trx.CommitAsync();
            }
        }

        private void PrepareDetail(Domain.Order entry, OrderCreateCommand notification) 
        {
            entry.Items = notification.Items.Select(x => new OrderDetail
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                UnitPrice = x.Price,
                Total = x.Price * x.Quantity
            }).ToList();
        }

        private void PrepareHeader(Domain.Order entry, OrderCreateCommand notification)
        {
            // Header information
            entry.Status = Common.Enums.OrderStatus.Pending;
            entry.PaymentType = notification.PaymentType;
            entry.ClientId = notification.ClientId;
            entry.CreatedAt = DateTime.UtcNow;

            // Sum
            entry.Total = entry.Items.Sum(x => x.Total);
        }
    }
}
