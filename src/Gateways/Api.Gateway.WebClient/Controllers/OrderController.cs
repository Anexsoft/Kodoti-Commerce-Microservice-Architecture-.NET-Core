using Api.Gateway.Models;
using Api.Gateway.Models.Order.DTOs;
using Api.Gateway.Proxies.Order;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Controllers
{
    [ApiController]
    [Route("v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderProxy _orderProxy;

        public OrderController(
            IOrderProxy orderProxy
        ) 
        {
            _orderProxy = orderProxy;
        }

        [HttpGet]
        public async Task<DataCollection<OrderDto>> GetAll(int page, int take) 
        {
            return await _orderProxy.GetAllAsync(page, take);
        }
    }
}
