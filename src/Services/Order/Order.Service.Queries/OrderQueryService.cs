using Microsoft.EntityFrameworkCore;
using Order.Persistence.Database;
using Order.Service.Queries.DTOs;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Service.Queries
{
    public interface IOrderQueryService
    {
        Task<DataCollection<OrderDto>> GetAllAsync(int page, int take);
    }

    public class OrderQueryService : IOrderQueryService
    {
        private readonly ApplicationDbContext _context;

        public OrderQueryService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<OrderDto>> GetAllAsync(int page, int take) 
        {
            var collection = await _context.Orders
                .Include(x => x.Items)
                .OrderBy(x => x.OrderId)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<OrderDto>>();
        }
    }
}
