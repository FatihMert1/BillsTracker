using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Tracker.Api.Context;
using Tracker.Entity.Entities;
using Xunit;

namespace Tracker.IntegrationTests
{
    public class CategoryControllerTests : BaseIntegration
    {
        public CategoryControllerTests() : base()
        {
            DataSeeder.Seed(ApplicationDbContext);
        }
        
        
        [Fact]
        public async Task Add_ReturnTrueData()
        {
            var requestMessage = await RequestMessage(HttpMethod.Post, "category/add", new Category {Title = "Marked"});

            var response = await Client.SendAsync(requestMessage);

            var result = await response.Content.ReadAsAsync<ApiResponse<bool>>();

            result.Data.Should().Be(true);

        }

        [Fact]
        public async Task GetAll_ShouldReturn_List()
        {

            var requestMessage = await RequestMessage(HttpMethod.Get, "category/all", "");

            var response = await Client.SendAsync(requestMessage);

            var result = await response.Content.ReadAsAsync<ApiResponse<List<Category>>>();

            result.Data.Should().NotBeEmpty();
            result.Data.Should().NotBeNull();
            result.Data.Should().BeOfType<List<Category>>();
        }

        [Fact]
        public async Task Get_ReturnOneCategory()
        {
            var requestMessage = await RequestMessage(HttpMethod.Get, "category/get/1", "");

            var response = await Client.SendAsync(requestMessage);

            var result = await response.Content.ReadAsAsync<ApiResponse<Category>>();

            result.Data.Should().NotBeNull();
        }

}
}