using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Api.Gateway.WebClient.Proxy;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Api.Gateway.Models;
using Api.Gateway.Models.Catalog.DTOs;
using Api.Gateway.Models.Customer.DTOs;
using Api.Gateway.Models.Orders.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Clients.WebClient.Pages.Orders
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly IOrderProxy _orderProxy;
        private readonly IClientProxy _clientProxy;
        private readonly IProductProxy _productProxy;

        public DataCollection<ProductDto> Products { get; set; }
        public DataCollection<ClientDto> Clients { get; set; }

        public CreateModel(
            ILogger<DetailModel> logger,
            IOrderProxy orderProxy,
            IClientProxy clientProxy,
            IProductProxy productProxy
        )
        {
            _orderProxy = orderProxy;
            _clientProxy = clientProxy;
            _productProxy = productProxy;
        }

        public async Task OnGet()
        {
            // *** Lo ideal sería implementar un Autocomplete para buscar los productos y cliente a demanda
            Products = await _productProxy.GetAllAsync(1, 100);
            Clients = await _clientProxy.GetAllAsync(1, 100);
        }

        public async Task<IActionResult> OnPost([FromBody] OrderCreateCommand command)
        {
            await _orderProxy.CreateAsync(command);
            return this.StatusCode(200);
        }
    }
}
