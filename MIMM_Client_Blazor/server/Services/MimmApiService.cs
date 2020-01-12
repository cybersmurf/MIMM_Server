using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using MimmClientBlazor.Models.MimmApi;

namespace MimmClientBlazor
{
    public partial class MimmApiService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;

        public MimmApiService()
        {
            this.httpClient = new HttpClient();
            this.baseUri = new Uri("https://localhost:44305/api/");
        }

        partial void OnGet(HttpRequestMessage requestMessage);

        public async Task<Artists> Get()
        {
            var uri = new Uri(baseUri, $"artists");

            var message = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGet(message);

            var response = await httpClient.SendAsync(message);

            response.EnsureSuccessStatusCode();

            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                return await JsonSerializer.DeserializeAsync<Artists>(stream, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNameCaseInsensitive = true,
                });
            }
        }
    }
}