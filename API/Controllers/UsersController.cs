using Microsoft.AspNetCore.Mvc;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace API.Controllers
{
    public class UsersController(ApplicationDbContext context) : BaseApiController
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await context.Appusers.ToListAsync();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await context.Appusers.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(user);
        }
    }
    
    
}