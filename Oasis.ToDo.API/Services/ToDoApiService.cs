using Newtonsoft.Json;
using Oasis.ToDoAPP.API.Interfaces;

namespace Oasis.ToDoAPP.API.Services
{
    public class ToDoApiService : IToDoApiService
    {
        private readonly HttpClient _httpClient;
        string BaseUrl = "https://jsonplaceholder.typicode.com/todos";
        public ToDoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<string> ConsumeToDoApiAsync()
        {
            var response = await _httpClient.GetAsync(BaseUrl);

            var responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
            
        }
    }
}
