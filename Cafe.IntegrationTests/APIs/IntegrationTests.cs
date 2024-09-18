namespace GICCafe.IntegrationTests.APIs
{
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.VisualStudio.TestPlatform.TestHost;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class IntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public IntegrationTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();

        }

        [Fact]
        public async Task GetCafes_ShouldReturnOk()
        {
            var response = await _client.GetAsync("/cafes?location=Downtown");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Assert.Contains("Cafe Mocha", responseBody);
        }

        [Fact]
        public async Task GetEmployeesByCafe_ShouldReturnEmployees()
        {
            // Arrange
            var response = await _client.GetAsync("/employees?cafe=cafe1");

            // Act
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("John Doe", content); // Adjust based on actual response structure
        }
    }

}
