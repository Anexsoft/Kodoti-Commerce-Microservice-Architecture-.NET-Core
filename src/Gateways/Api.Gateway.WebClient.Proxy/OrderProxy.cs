using Api.Gateway.Models;
using Api.Gateway.Models.Order.DTOs;
using Api.Gateway.Models.Orders.Commands;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy
{
    public interface IOrderProxy
    {
        /// <summary>
        /// Este método no trae la información de los productos.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        Task<DataCollection<OrderDto>> GetAllAsync(int page, int take);

        /// <summary>
        /// Trae la información completa de la orden haciendo cruce con los diferentes microservicios.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OrderDto> GetAsync(int id);

        /// <summary>
        /// Creación de órdenes de compra
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task CreateAsync(OrderCreateCommand command);
    }

    public class OrderProxy : IOrderProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public OrderProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<DataCollection<OrderDto>> GetAllAsync(int page, int take)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}orders?page={page}&take={take}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<OrderDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<OrderDto> GetAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}orders/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<OrderDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task CreateAsync(OrderCreateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}orders", content);
            request.EnsureSuccessStatusCode();
        }
    }
}
