using ForceDotNetJwtCompanion;
using ForceDotNetJwtCompanion.Util;
using System;
using System.Threading.Tasks;

namespace SalesforceForceDotNetJwtCompanion
{
    public static class SalesforceAccessTokenGenerator
    {
        public static async Task<string> GetProductionAccessToken()
        {
            var clientIdProductionEnvVar = Environment.GetEnvironmentVariable(Constants.SFProductionClientId);
            var privateKeyProductionEnvVarPath = Environment.GetEnvironmentVariable(Constants.SFProductionPrivateKeyPath);
            var usernameProductionEnvVarPath = Environment.GetEnvironmentVariable(Constants.SFProductionUsername);
            var secretProductionEnvVarPath = Environment.GetEnvironmentVariable(Constants.SFProductionSecret);
            var apiUriEnvVarPath = Environment.GetEnvironmentVariable(Constants.SFProductionPath);

            return await GetAccessToken(clientIdProductionEnvVar, privateKeyProductionEnvVarPath, usernameProductionEnvVarPath, secretProductionEnvVarPath, apiUriEnvVarPath);
        }

        public static async Task<string> GetSandboxAccessToken()
        {
            var clientIdSandBoxEnvVar = Environment.GetEnvironmentVariable(Constants.SFSandBoxClientId);
            var privateKeySandBoxEnvVarPath = Environment.GetEnvironmentVariable(Constants.SFSandboxPrivateKeyPath);
            var usernameSandBoxEnvVarPath = Environment.GetEnvironmentVariable(Constants.SFSandboxUsername);
            var secretSandBoxEnvVarPath = Environment.GetEnvironmentVariable(Constants.SFSandboxSecret);
            var apiUriEnvVarPath = Environment.GetEnvironmentVariable(Constants.SFSandboxUri);

            return await GetAccessToken(clientIdSandBoxEnvVar, privateKeySandBoxEnvVarPath, usernameSandBoxEnvVarPath, secretSandBoxEnvVarPath, apiUriEnvVarPath);
        }


        public static async Task<string> GetAccessToken(string clientId, string privateKeyPath, string username, string secret, string apiUri)
        {
            var privateKey = CommonHelpers.LoadFromFile(privateKeyPath);
            var authClient = new JwtAuthenticationClient(apiVersion: Constants.JwtAuthenticationClientAPIVersion, isProd: false);
            var endpoint = string.Format(Constants.ApiUriFormatting, apiUri, clientId);

            await authClient.JwtPrivateKeyAsync(
                            clientId,
                            privateKey,
                            secret,
                            username,
                            endpoint);

            var accessToken = authClient.AccessToken;

            return accessToken;
        }
    }
}
