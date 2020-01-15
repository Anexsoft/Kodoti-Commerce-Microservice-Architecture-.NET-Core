using Api.Gateway.Models;
using Api.Gateway.Models.Order.DTOs;
using Api.Gateway.WebClient.Proxy.Config;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy
{
    public interface IOrderProxy
    {
        Task<DataCollection<OrderDto>> GetAllAsync(int page, int take);
    }

    public class OrderProxy : IOrderProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public OrderProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl)
        {
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<DataCollection<OrderDto>> GetAllAsync(int page, int take)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}v1/orders?page={page}&take={take}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<OrderDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
