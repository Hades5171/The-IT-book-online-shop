using System.Net.Http.Json;
using The_IT_book_online_shop.DTOs;

namespace The_IT_book_online_shop.Services
{
    public class BookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BookDto>> GetBooks()
        {
            try
            {
                var response = await _httpClient
                    .GetFromJsonAsync<ItBookResponse>(
                        "https://api.itbook.store/1.0/search/mysql");

                if (response == null)
                    return new List<BookDto>();

                return response.Books
                    .OrderBy(b => b.Title)
                    .ToList();
            }
            catch
            {
                return new List<BookDto>();
            }
        }
    }
}