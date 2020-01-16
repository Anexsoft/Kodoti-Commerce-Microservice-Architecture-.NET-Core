using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Api.Gateway.WebClient.Proxy;
using Api.Gateway.Models.Order.DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Clients.WebClient.Pages.Orders
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class DetailModel : PageModel
    {
        private readonly ILogger<DetailModel> _logger;
        private readonly IOrderProxy _orderProxy;

        public OrderDto Order { get; set; }

        public DetailModel(
            ILogger<DetailModel> logger,
            IOrderProxy orderProxy
        )
        {
            _orderProxy = orderProxy;
            _logger = logger;
        }

        public async Task OnGet(int id)
        {
            Order = await _orderProxy.GetAsync(id);
        }
    }
}
