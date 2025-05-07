using backend.DTOs;

namespace backend.Services
{
    public interface IPostsService
    {
        public Task<IEnumerable<PostDTO>> Get();
    }
}
