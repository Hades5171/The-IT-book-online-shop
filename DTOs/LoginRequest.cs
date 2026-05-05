using System.ComponentModel.DataAnnotations;

namespace The_IT_book_online_shop.DTOs
{
    public class LoginRequest
    {
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    }
}