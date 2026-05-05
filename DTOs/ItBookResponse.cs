using System.Text.Json.Serialization;

namespace The_IT_book_online_shop.DTOs
{
    public class ItBookResponse
    {
        [JsonPropertyName("books")]
        public List<BookDto> Books { get; set; } = new();
    }

    public class BookDto
{
    public string Title { get; set; } = string.Empty;
    public string Isbn13 { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
}