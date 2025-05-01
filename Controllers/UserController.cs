using Microsoft.AspNetCore.Mvc;
using DotNetSqlApp.Models;
using DotNetSqlApp.Data;
using System.Linq;

namespace DotNetSqlApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
    }
}
