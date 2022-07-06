using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceForceDotNetJwtCompanion
{
    public class Constants
    {
        public const string JwtAuthenticationClientAPIVersion = "v50.0";

        public const string ApiUriFormatting = @"https://{0}/services/oauth2/token?response_type=token&client_id={1}&redirect_uri=https://{0}";

        public const string SFProductionClientId = "CDX_SF_PRODUCTION_API_CLIENT_ID";
        public const string SFProductionPrivateKeyPath = "CDX_SF_PRODUCTION_API_PRIVATE_KEY_PATH";
        public const string SFProductionUsername = "CDX_SF_PRODUCTION_API_USER";
        public const string SFProductionSecret = "CDX_SF_PRODUCTION_API_SECRET";
        public const string SFProductionPath = "CDX_SF_PRODUCTION_API_URI";

        public const string SFSandBoxClientId = "CDX_SF_SANDBOX_API_CLIENT_ID";
        public const string SFSandboxPrivateKeyPath = "CDX_SF_SANDBOX_API_PRIVATE_KEY_PATH";
        public const string SFSandboxUsername = "CDX_SF_SANDBOX_API_USER";
        public const string SFSandboxSecret = "CDX_SF_SANDBOX_API_SECRET";
        public const string SFSandboxUri = "CDX_SF_SANDBOX_API_URI";
    }
}
