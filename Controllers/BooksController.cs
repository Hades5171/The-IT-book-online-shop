using Microsoft.AspNetCore.Mvc;
using The_IT_book_online_shop.Services;

namespace The_IT_book_online_shop.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                var books = await _bookService.GetBooks();
                return Ok(books);
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}