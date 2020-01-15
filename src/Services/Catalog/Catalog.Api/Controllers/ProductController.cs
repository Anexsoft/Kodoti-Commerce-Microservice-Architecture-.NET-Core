using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.Queries;
using Catalog.Service.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductQueryService _productQueryService;
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;

        public ProductController(
            ILogger<ProductController> logger,
            IMediator mediator,
            IProductQueryService productQueryService)
        {
            _logger = logger;
            _mediator = mediator;
            _productQueryService = productQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<ProductDto>> GetAll(int page = 1, int take = 10) 
        {
            return await _productQueryService.GetAllAsync(page, take);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }
    }
}
