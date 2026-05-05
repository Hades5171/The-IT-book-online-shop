namespace The_IT_book_online_shop.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Fullname { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<LikedBook> LikedBooks { get; set; } = new();
    }
}