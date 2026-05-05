using System.ComponentModel.DataAnnotations;

namespace The_IT_book_online_shop.Models
{
    public class LikedBook
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        [MaxLength(13)]
        public string BookId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}