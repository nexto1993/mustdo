using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Entities;
using API.Data;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers
{
    public class UsersController(ApplicationDbContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await context.Appusers.ToListAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await context.Appusers.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(user);
        }
    }
    
    
}