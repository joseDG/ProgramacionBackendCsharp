using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostsService _titlesService;

        public PostsController(IPostsService titlesService)
        {
            _titlesService = titlesService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDTO>> Get() =>
            await _titlesService.Get();
    }
}
