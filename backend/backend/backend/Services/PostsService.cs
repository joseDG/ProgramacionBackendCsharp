using backend.DTOs;
using System.Text.Json;

namespace backend.Services
{
    public class PostsService : IPostsService
    {
        private HttpClient _httpClient;

        public PostsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PostDTO>> Get()
        {

            //aqui puedes utilizar httpCliente todos los metodos Http
            var result = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var body = await result.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var post =
                JsonSerializer.Deserialize<IEnumerable<PostDTO>>(body, options);

            return post;
        }
    }
}
