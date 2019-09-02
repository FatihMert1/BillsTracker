using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Tracker.Api;
using Tracker.Api.Context;

namespace Tracker.IntegrationTests
{
    public class BaseIntegration
    {
        protected HttpClient Client { get; set; }
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        protected BaseIntegration()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                    {
                        builder.ConfigureServices(services =>
                        {
//                            services.AddDbContext<ApplicationDbContext>(opt =>
//                            {
//                                opt.UseInMemoryDatabase("test_db");
//                            });
                        });
                    });

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testing")
                .Options;
            
            ApplicationDbContext = new ApplicationDbContext(options);

            Client = appFactory.CreateClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected async Task<HttpRequestMessage> RequestMessage(HttpMethod method, string uri, object content)
        {
            var message = new HttpRequestMessage(method,uri) { Content  = new StringContent(JsonConvert.SerializeObject(content)) };

            message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return message;
        }
        
        
        
    }
}