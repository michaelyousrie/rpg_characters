using System;
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
        public ActionResult<CharacterResponse> UpdateCharacter(int id, UpdateCharacterRequest request)
        {
            var character = _chars.GetById(id);

            if (character == null) {
                return NotFound();
            }

            User user = (User) HttpContext.Items["User"];

            foreach (var property in request.GetType().GetProperties()) {
                var propertyName = property.Name;
                var propertyValue = character.GetType().GetProperty(propertyName).GetValue(character, null);
                var updatedPropertyValue = request.GetType().GetProperty(propertyName).GetValue(request, null);

                if (updatedPropertyValue == null) {
                    request.GetType().GetProperty(propertyName).SetValue(request, propertyValue, null);
                    continue;
                }

                if (!user.HasPermissionTo($"edit {propertyName.ToLower()}")) {
                    return Unauthorized(new {
                        Message = $"You do NOT have permission to edit the property ({propertyName})"
                    });
                }
            }

            var UpdatedCharacter = _mapper.Map(request, character);
            _chars.Update(UpdatedCharacter);

            return Ok(new {
                Message = "Updated successfully!",
                Character = _mapper.Map<CharacterResponse>(UpdatedCharacter)
            });
        }
    }
}
