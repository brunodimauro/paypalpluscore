using System.Collections.Generic;

namespace ppp
{
    public enum eIntegrations
    {
        PayPal = 2
    }

    public enum eEnvironment
    {
        Development = 1,
        Staging = 2,
        Production = 3
    }

    public class Integration
    {
        public eIntegrations IntegrationId { get; set; }
        public string Name { get; set; }

        public List<IntegrationToken> Tokens { get; set; }

        public eEnvironment EnvironmentId { get; set; }

        public string Account { get; set; }
        public string ClientId { get; set; }
        public string Token { get; set; }
    }

    public class IntegrationToken
    {
        public int IntegrationTokenId { get; set; }
        public eIntegrations IntegrationId { get; set; }
        public eEnvironment EnvironmentId { get; set; }
        public string Token { get; set; }
    }
}
