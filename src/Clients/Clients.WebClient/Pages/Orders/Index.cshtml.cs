using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Api.Gateway.WebClient.Proxy;
using Api.Gateway.Models;
using Api.Gateway.Models.Order.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Clients.WebClient.Pages.Orders
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IOrderProxy _orderProxy;

        public DataCollection<OrderDto> Orders { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

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
            Orders = await _orderProxy.GetAllAsync(CurrentPage, 10);
        }
    }
}
