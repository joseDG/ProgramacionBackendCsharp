namespace backend.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string? title { get; set; }
        public string? body { get; set; }
    }
}
