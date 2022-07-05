using ForceDotNetJwtCompanion;
using ForceDotNetJwtCompanion.Util;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SalesforceForceDotNetJwtCompanion
{
    public class JwtAuthTests
    {
        private const string JwtAuthenticationClientAPIVersion = "v50.0";

        private const string ApiUriFormatting = @"https://{0}/services/oauth2/token?response_type=token&client_id={1}&redirect_uri=https://{0}";

        [Fact]
        public async Task Generate_Validate_JWT_Simulate_Production_By_ClientId_Secret()
        {
            var clientIdProductionEnvVar = Environment.GetEnvironmentVariable("CDX_SF_PRODUCTION_API_CLIENT_ID");
            var privateKeyProductionEnvVarPath = Environment.GetEnvironmentVariable("CDX_SF_PRODUCTION_API_PRIVATE_KEY_PATH");
            var usernameProductionEnvVarPath = Environment.GetEnvironmentVariable("CDX_SF_PRODUCTION_API_USER");
            var secretProductionEnvVarPath = Environment.GetEnvironmentVariable("CDX_SF_PRODUCTION_API_SECRET");
            var apiUriEnvVarPath = Environment.GetEnvironmentVariable("CDX_SF_PRODUCTION_API_URI");

            var privateKey = CommonHelpers.LoadFromFile(privateKeyProductionEnvVarPath);

            var authClient = new JwtAuthenticationClient(apiVersion: JwtAuthenticationClientAPIVersion, isProd: true);

            var endpoint = string.Format(ApiUriFormatting, apiUriEnvVarPath, clientIdProductionEnvVar);

            await authClient.JwtPrivateKeyAsync(
                            clientIdProductionEnvVar,
                            privateKey,
                            secretProductionEnvVarPath,
                            usernameProductionEnvVarPath,
                            endpoint);

            var accessToken = authClient.AccessToken;

            Assert.NotNull(accessToken);
        }

        [Fact]
        public async Task Generate_Validate_JWT_SandBox_By_ClientId_Secret()
        {
            var clientIdProductionEnvVar = Environment.GetEnvironmentVariable("CDX_SF_SANDBOX_API_CLIENT_ID");
            var privateKeyProductionEnvVarPath = Environment.GetEnvironmentVariable("CDX_SF_SANDBOX_API_PRIVATE_KEY_PATH");
            var usernameProductionEnvVarPath = Environment.GetEnvironmentVariable("CDX_SF_SANDBOX_API_USER");
            var secretProductionEnvVarPath = Environment.GetEnvironmentVariable("CDX_SF_SANDBOX_API_SECRET");
            var apiUriEnvVarPath = Environment.GetEnvironmentVariable("CDX_SF_SANDBOX_API_URI");

            var privateKey = CommonHelpers.LoadFromFile(privateKeyProductionEnvVarPath);

            var authClient = new JwtAuthenticationClient(apiVersion: JwtAuthenticationClientAPIVersion, isProd: false);

            var endpoint = string.Format(ApiUriFormatting, apiUriEnvVarPath, clientIdProductionEnvVar);

            await authClient.JwtPrivateKeyAsync(
                            clientIdProductionEnvVar,
                            privateKey,
                            secretProductionEnvVarPath,
                            usernameProductionEnvVarPath,
                            endpoint);

            var accessToken = authClient.AccessToken;

            Assert.NotNull(accessToken);
        }
    }
}