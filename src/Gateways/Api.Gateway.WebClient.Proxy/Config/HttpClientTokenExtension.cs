using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net.Http;

namespace Api.Gateway.WebClient.Proxy.Config
{
    public static class HttpClientTokenExtension
    {
        public static void AddBearerToken(this HttpClient client, IHttpContextAccessor context) 
        {
            if (context.HttpContext.User.Identity.IsAuthenticated) 
            {
                var token = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("access_token"))?.Value;

                if (!string.IsNullOrEmpty(token)) 
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
                }
            }
        }
    }
}
