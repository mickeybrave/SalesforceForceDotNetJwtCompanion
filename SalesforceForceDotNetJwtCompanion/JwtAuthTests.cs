using System.Threading.Tasks;
using Xunit;

namespace SalesforceForceDotNetJwtCompanion
{
    public class JwtAuthTests
    {
        [Fact]
        public async Task Generate_Validate_JWT_Simulate_Production_By_ClientId_Secret()
        {
            string bearerAccessToken = await SalesforceAccessTokenGenerator.GetProductionAccessToken();
            Assert.NotNull(bearerAccessToken);
        }

        [Fact]
        public async Task Generate_Validate_JWT_SandBox_By_ClientId_Secret()
        {
            string bearerAccessToken = await SalesforceAccessTokenGenerator.GetSandboxAccessToken();
            Assert.NotNull(bearerAccessToken);
        }
    }
}