using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Amazon.SellingPartnerAPIAA;
using RestSharp;
namespace Signer
{
    public class AuthHelper
    {
        #region Prop
        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }
        public string RefreshToken { get; private set; }
        public Uri Endpoint { get; private set; }
        public string AccessKeyId { get; private set; }
        public string SecretKey { get; private set; }
        public string Region { get; private set; }
        public string Resource { get; private set; }
        #endregion
        public AuthHelper(string clientId,string clientSecret,string refreshToken,Uri endPoint,string accessKeyId,string secretKey,string region)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RefreshToken = refreshToken;
            Endpoint = endPoint;
            AccessKeyId = accessKeyId;
            SecretKey = secretKey;
            Region = region;
        }

        public IRestRequest SignRequest(IRestRequest restRequest, RestClient restClient, string contentType)
        {
            // Seller APIs
            LWAAuthorizationCredentials lwaAuthorizationCredentials = new LWAAuthorizationCredentials
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                RefreshToken = RefreshToken,
                Endpoint = Endpoint
            };
            AWSAuthenticationCredentials awsAuthenticationCredentials = new AWSAuthenticationCredentials
            {
                AccessKeyId = AccessKeyId,
                SecretKey = SecretKey,
                Region = Region
            };

            restRequest = new AWSSigV4Signer(awsAuthenticationCredentials)
                .Sign(restRequest, restClient.BaseUrl.Host);

            restRequest.AddHeader("Content-type", contentType);

            restRequest.AddHeader("user-agent", "My YouTube App 1.0 (Language=csharp;Platform=Windows/10)");

            return restRequest;
        }

        public string GetToken()
        {
            LWAAuthorizationCredentials lwaAuthorizationCredentials = new LWAAuthorizationCredentials
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                RefreshToken = RefreshToken,
                Endpoint = Endpoint
            };

            var requestTokenClient = new LWAClient(lwaAuthorizationCredentials);

            return requestTokenClient.GetAccessToken();

        }
    }
}
