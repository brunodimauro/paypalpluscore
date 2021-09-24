using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ppp
{
    public class PayPalPlusBLL
    {
        static HttpClient client = null;
        public Integration integration = null;

        public PayPalPlusBLL()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("https://api.sandbox.paypal.com/v1/");
            }
            if (integration == null)
            {
                integration = new Integration()
                {
                    Account = "financeiro.pos-facilitator@meucurso.com.br",
                    ClientId = "AT7_lZD3xrwPPpJVgTuAzzWNhZlNNS2KgyFeZkn2C5XRFNOMWwV7-Q5Z0WfzqdVDzjTcW6QfOPZkcfip",
                    Token = "EK_5DJYwgdmvinpC9JMlKdpeDMmIZFdf2uHvyT6Zv_gkt9qSLvh6nQFxR5Z70DNj68VIymFVhyXHlke8",
                    EnvironmentId = eEnvironment.Development
                };
            }
        }

        public PayPalPlusAccessTokenResponse AccessToken()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                string path = $"oauth2/token";
                var token = $"{integration.ClientId}:{integration.Token}";
                var byteArray = Encoding.ASCII.GetBytes(token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");
                var response = client.PostAsync(path, content).Result;

                string responseJson;
                using (HttpContent resp = response.Content)
                {
                    responseJson = resp.ReadAsStringAsync().Result;
                }

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonConvert.DeserializeObject<PayPalPlusAccessTokenResponse>(responseJson);
                    errorResponse.method = $"{client.BaseAddress}{path}";
                    errorResponse.payloadRequest = token;
                    errorResponse.payloadResponse = responseJson;
                    errorResponse.success = false;
                    return errorResponse;
                }

                var _response = JsonConvert.DeserializeObject<PayPalPlusAccessTokenResponse>(responseJson);
                _response.method = $"{client.BaseAddress}{path}";
                _response.payloadRequest = token;
                _response.payloadResponse = responseJson;
                _response.success = true;
                return _response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PayPalPlusPaymentResponse CreatePayment(string token, PayPalPlusPaymentRequest model)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                string path = $"payments/payment";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var data = JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync(path, content).Result;

                string responseJson;
                using (HttpContent resp = response.Content)
                {
                    responseJson = resp.ReadAsStringAsync().Result;
                }

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonConvert.DeserializeObject<PayPalPlusPaymentResponse>(responseJson);
                    errorResponse.method = $"{client.BaseAddress}{path}";
                    errorResponse.payloadRequest = data;
                    errorResponse.payloadResponse = responseJson;
                    errorResponse.success = false;
                    return errorResponse;
                }

                var _response = JsonConvert.DeserializeObject<PayPalPlusPaymentResponse>(responseJson);
                _response.method = $"{client.BaseAddress}{path}";
                _response.payloadRequest = data;
                _response.payloadResponse = responseJson;
                _response.success = true;
                return _response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PayPalPlusExecutePaymentResponse ExecutePayment(string token, string payId/*, PayPalPlusExecutePaymentRequest model*/)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                string path = $"payments/payment/{payId}/execute";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //var data = JsonConvert.SerializeObject(model);
                var content = new StringContent("", Encoding.UTF8, "application/json");
                var response = client.PostAsync(path, content).Result;

                string responseJson;
                using (HttpContent resp = response.Content)
                {
                    responseJson = resp.ReadAsStringAsync().Result;
                }

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonConvert.DeserializeObject<PayPalPlusExecutePaymentResponse>(responseJson);
                    errorResponse.method = $"{client.BaseAddress}{path}";
                    errorResponse.payloadRequest = null;
                    errorResponse.payloadResponse = responseJson;
                    errorResponse.success = false;
                    return errorResponse;
                }

                var _response = JsonConvert.DeserializeObject<PayPalPlusExecutePaymentResponse>(responseJson);
                _response.method = $"{client.BaseAddress}{path}";
                _response.payloadRequest = null;
                _response.payloadResponse = responseJson;
                _response.success = true;
                return _response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
