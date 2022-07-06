using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SalesforceForceDotNetJwtCompanion
{
    /*
     For example, to retrieve basic information about an Account object in version 55.0 use
    
        https://MyDomainName.my.salesforce.com/services/data/v55.0/sobjects/Account.
     */
    public class SalesforceDataConnectionTests
    {
        private const string TrialDomainUriBase = "https://d5i000006jgpdea0.my.salesforce.com/";
        private const string SandboxDomainUri = "https://countdown-crm--authapi.sandbox.my.salesforce.com/";
        private const string VersionsUri = "/services/data";
        private readonly HttpClient _client = new HttpClient();

        [Fact]
        public async Task Version_Production_connection_test()
        {
            string bearerAccessToken = await SalesforceAccessTokenGenerator.GetProductionAccessToken();
            Assert.NotNull(bearerAccessToken);

            _client.SetBearerToken(bearerAccessToken);

            var versionFullUri = TrialDomainUriBase + VersionsUri;
            var response = await _client.GetAsync(versionFullUri);
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(dataAsString);
        }

        [Fact]
        public async Task Version_Sandbox_connection_test()
        {
            string bearerAccessToken = await SalesforceAccessTokenGenerator.GetSandboxAccessToken();
            Assert.NotNull(bearerAccessToken);

            _client.SetBearerToken(bearerAccessToken);

            var versionFullUri = SandboxDomainUri + VersionsUri;
            var response = await _client.GetAsync(versionFullUri);
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(dataAsString);
        }


    }
}
