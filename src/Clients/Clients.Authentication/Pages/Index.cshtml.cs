using Clients.Authentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Clients.Authentication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly string _identityUrl;

        [BindProperty(SupportsGet = true)]
        public string ReturnBaseUrl { get; set; }
        [BindProperty]
        public LoginViewModel model { get; set; }

        public bool HasInvalidAccess { get; set; }

        public IndexModel(
            ILogger<IndexModel> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _identityUrl = configuration.GetValue<string>("IdentityUrl");
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost() 
        {
            using (var client = new HttpClient()) 
            {
                var content = new StringContent(
                    JsonSerializer.Serialize(model),
                    Encoding.UTF8,
                    "application/json"
                );

                var request = await client.PostAsync(_identityUrl + "v1/identity/authentication", content);

                if (!request.IsSuccessStatusCode)
                {
                    HasInvalidAccess = true;
                    return Page();
                }

                var result = JsonSerializer.Deserialize<IdentityAccess>(
                    await request.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );

                return Redirect(ReturnBaseUrl + $"account/connect?access_token={result.AccessToken}");
            }
        }
    }
}
