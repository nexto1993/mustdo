using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController(ApplicationDbContext context) : ControllerBase
    {
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetAuth()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<Appuser> GetNotFound()
        {
            var thing = context.Appusers.Find(-1);

            if (thing == null) return NotFound();
            return thing;
        }

        [HttpGet("server-error")]
        public ActionResult<Appuser> GetServerError()
        {
            
                var thing = context.Appusers.Find(-1) ?? throw new Exception("A bad thing has happened");

                return thing;
            
           
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
}
