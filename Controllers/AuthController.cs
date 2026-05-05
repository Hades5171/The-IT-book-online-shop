using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using The_IT_book_online_shop.Data;
using The_IT_book_online_shop.DTOs;
using The_IT_book_online_shop.Models;

namespace The_IT_book_online_shop.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterRequest req)
        {
            if (_context.Users.Any(x => x.Username == req.Username))
                return BadRequest("Username already exists");

            var hashed = BCrypt.Net.BCrypt.HashPassword(req.Password);

            var user = new User
            {
                Username = req.Username,
                Password = hashed,
                Fullname = req.Fullname
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                user.Id,
                user.Username,
                user.Fullname
            });
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginRequest req)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Username == req.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
                return Unauthorized();

            return Ok(new
            {
                user.Id,
                user.Username,
                user.Fullname
            });
        }
    }
}