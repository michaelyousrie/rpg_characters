using App.DTOs;
using App.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/passwords")]
    public class PsaswordsController : ControllerBase
    {
        [HttpPost("hash")]
        public IActionResult GetHashedValue(PasswordHashRequest request)
        {
            return Ok(new {
                Text = request.Password,
                Hashed = Hasher.Hash(request.Password)
            });
        }
    }
}
