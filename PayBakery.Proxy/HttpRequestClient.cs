using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PayBakery.Proxy
{
    public class HttpRequestClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public HttpRequestClient(HttpClient httpClient, IConfiguration configuration)
        {

            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<T> GetRequestAsync<T>(string requestUrl)
        {
            try
            {


                var responseObject = default(T);

                if (!string.IsNullOrEmpty(requestUrl))
                {
                    var auth = $"{_configuration["PaystackEndPoints:PaystackAPIKEY"]}";
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth);
                    var response = await _httpClient.GetAsync(requestUrl);

                    if (response != null)
                    {
                        responseObject = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    }
                }

                return responseObject;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<U> PostRequestAsync<T, U>(string requestUrl, T requestObject) where T : class
        {
            try
            {
                var responseObject = default(U);

                if (requestObject != null)
                {
                    var serializedRequest = JsonConvert.SerializeObject(requestObject);

                    var contentToSend = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
                    var auth = $"{_configuration["PaystackEndPoints:PaystackAPIKEY"]}";
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth);

                    var response = await _httpClient.PostAsync(requestUrl, contentToSend);

                    if (response != null)
                    {
                        responseObject = JsonConvert.DeserializeObject<U>(await response.Content.ReadAsStringAsync());
                    }
                }

                return responseObject;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
