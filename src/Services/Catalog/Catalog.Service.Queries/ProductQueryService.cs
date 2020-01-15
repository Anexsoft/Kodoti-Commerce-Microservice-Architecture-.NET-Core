using Catalog.Persistence.Database;
using Catalog.Service.Queries.DTOs;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Service.Queries
{
    public interface IProductQueryService
    {
        Task<DataCollection<ProductDto>> GetAllAsync(int page, int take);
    }

    public class ProductQueryService : IProductQueryService
    {
        private readonly ApplicationDbContext _context;

        public ProductQueryService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<ProductDto>> GetAllAsync(int page, int take) 
        {
            var collection = await _context.Products
                .OrderBy(x => x.Name)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ProductDto>>();
        }
    }
}
