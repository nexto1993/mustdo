using Microsoft.AspNetCore.Mvc;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;
using API.DTOs;
namespace API.Controllers
{
    //[Authorize]
    public class UsersController(IUserRepository userRepository) : BaseApiController
    {
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> Get()
        {
            var users = await userRepository.GetMembersAsync();
            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> Get(string username)
        {
            var user = await userRepository.GetMemberAsync(username);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
    
    
}