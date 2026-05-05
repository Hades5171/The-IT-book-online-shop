using System.ComponentModel.DataAnnotations;

namespace The_IT_book_online_shop.DTOs
{
    public class LikeRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        public string BookId { get; set; } = string.Empty;
    }
}