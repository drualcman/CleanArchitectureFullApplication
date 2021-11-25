using CleanArchitectureFullApplication.BlazorClient.Exceptions;
using CleanArchitectureFullApplication.Dto.CreateOrder;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.BlazorClient.Services
{
    public class CleanArchitectureApiClient
    {
        readonly HttpClient Client;

        public CleanArchitectureApiClient(HttpClient client)
        {
            Client = client;
        }

        public async Task<int> CreateOrder(CreateOrderDto order)
        {
            int orderId = 0;

            HttpResponseMessage response = await Client.PostAsJsonAsync("create", order);
            if (response.IsSuccessStatusCode)
            {
                orderId = await response.Content.ReadFromJsonAsync<int>();
            }
            else
            {
                throw await GetException(response);
            }

            return orderId;
        }

        private async Task<Exception> GetException(HttpResponseMessage response)
        {
            var jsonContent = await response.Content.ReadFromJsonAsync<JsonElement>();

            ProblemDetails problemDetail = JsonSerializer
                .Deserialize<ProblemDetails>(jsonContent.GetRawText(), 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (jsonContent.TryGetProperty("invalid-params", out JsonElement invalidParams))
            {
                problemDetail.InvalidParams =
                    JsonSerializer.Deserialize<Dictionary<string, string>>
                    (invalidParams.GetRawText());
            }

            return new HttpCustomException(problemDetail);
        }
    }
}
