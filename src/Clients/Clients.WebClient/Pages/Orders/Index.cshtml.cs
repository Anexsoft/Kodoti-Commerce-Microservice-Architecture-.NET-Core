using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Api.Gateway.WebClient.Proxy;
using Api.Gateway.Models;
using Api.Gateway.Models.Order.DTOs;

namespace Clients.WebClient.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IOrderProxy _orderProxy;

        public DataCollection<OrderDto> Orders { get; set; }

        public IndexModel(
            ILogger<IndexModel> logger,
            IOrderProxy orderProxy
        )
        {
            _orderProxy = orderProxy;
            _logger = logger;
        }

        public async Task OnGet()
        {
            Orders = await _orderProxy.GetAllAsync(1, 100);
        }
    }
}
