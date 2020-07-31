using App.DTOs.Requests;
using App.DTOs.Responses;
using App.Helpers.Attributes;
using App.Models;
using App.Repos;
using App.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.Admin
{
    [ApiController]
    [Authorize]
    [Route("api/admin/characters")]
    public class ChracterAdminstrationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CharacterRepo _chars;
        private readonly CharacterService _charService;

        public ChracterAdminstrationController(CharacterRepo characters, CharacterService charService, IMapper mapper)
        {
            _mapper = mapper;
            _chars = characters;
            _charService = charService;
        }

        [HttpPost]
        [MustHavePermissionTo("create character")]
        public IActionResult CreateCharacter(CreateCharacterRequest request)
        {
            var createdChar = _charService.Create(request);

            return Ok(new {
                Message = "Character created successfully!",
                Character = _mapper.Map<CharacterResponse>(createdChar)
            });
        }

        [HttpDelete("{id}")]
        [MustHavePermissionTo("delete character")]
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
        public ActionResult<CharacterResponse> UpdateCharacter(int id, UpdateCharacterRequest UpdatedCharacter)
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
