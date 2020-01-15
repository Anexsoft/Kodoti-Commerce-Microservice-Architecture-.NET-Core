using Catalog.Persistence.Database;
using Catalog.Service.Queries.DTOs;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Service.Queries
{
    public interface IProductInStockQueryService
    {
        Task<DataCollection<ProductInStockDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null);
    }

    public class ProductInStockQueryService : IProductInStockQueryService
    {
        private readonly ApplicationDbContext _context;

        public ProductInStockQueryService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<ProductInStockDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null)
        {
            var collection = await _context.Stocks
                .Where(x => products == null || products.Contains(x.ProductId))
                .OrderBy(x => x.ProductId)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ProductInStockDto>>();
        }
    }
}
