using Api.Gateway.Proxies.Order;
using Api.Gateway.Proxy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Gateway.WebClient.Config
{
    public static class StartUpConfiguration
    {
        public static IServiceCollection AddAppsettingBinding(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<ApiUrls>(opts => configuration.GetSection("ApiUrls").Bind(opts));
            return service;
        }

        public static IServiceCollection AddProxiesRegistration(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddHttpClient<IOrderProxy, OrderProxy>();
            return service;
        }
    }
}
