using App.DTOs;
using App.Helpers.Attributes;
using App.Models;
using App.Repos;
using App.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.Admin
{
    [ApiController]
    [Authorize, MustBeAdmin]
    [Route("api/admin/characters")]
    public class ChracterAdminstration : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CharacterRepo _chars;
        private readonly CharacterService _charService;
        private readonly User _user;

        public ChracterAdminstration(CharacterRepo characters, CharacterService charService, IMapper mapper, HttpContext http)
        {
            _mapper = mapper;
            _chars = characters;
            _charService = charService;
            _user = (User) http.Items["User"];
        }

        [HttpPost("character")]
        public IActionResult CreateCharacter(CreateCharacterRequest request)
        {
            var createdChar = _charService.Create(request);

            return Ok(new {
                Message = "Character created successfully!",
                Character = _mapper.Map<CharacterReadDto>(createdChar)
            });
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteCharacter(int id)
        {
            var character = _chars.GetById(id);

            if (character == null) {
                return NotFound();
            }

            _chars.Delete(character);

            return Ok(
                new {Message = "Deleted successfully!"}
            );
        }

        [HttpPatch("{id}")]
        public ActionResult<CharacterReadDto> UpdateCharacter(int id, CharacterUpdateDto UpdatedCharacter)
        {
            var character = _chars.GetById(id);

            if (character == null) {
                return NotFound();
            }

            var updated = _mapper.Map<Character>(UpdatedCharacter);
            _chars.Update(updated);

            return Ok(updated);
        }
    }
}
