using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using The_IT_book_online_shop.Data;
using The_IT_book_online_shop.DTOs;
using The_IT_book_online_shop.Models;

namespace The_IT_book_online_shop.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("/user/like")]
        public async Task<IActionResult> Like(LikeRequest req)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _context.Users.FindAsync(req.UserId);
            if (user == null)
                return NotFound("User not found");

            var exists = await _context.LikedBooks
                .AnyAsync(x => x.UserId == req.UserId && x.BookId == req.BookId);

            if (exists)
                return BadRequest("Already liked");

            var like = new LikedBook
            {
                UserId = req.UserId,
                BookId = req.BookId
            };

            _context.LikedBooks.Add(like);
            await _context.SaveChangesAsync();

            return Ok("Liked successfully");
        }
    }
}