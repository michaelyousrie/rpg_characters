using System.Collections.Generic;
using App.DTOs.Requests;
using App.DTOs.Responses;
using App.Helpers.Attributes;
using App.Repos;
using App.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Models
{
    [ApiController]
    [Route("api/characters")]
    public class CharactersController : ControllerBase
    {
        private IMapper _mapper;
        private readonly CharacterRepo _chars;
        private readonly CharacterService _charService;

        public CharactersController(CharacterService charService, IMapper mapper, CharacterRepo CharacterRepo)
        {
            _mapper = mapper;
            _chars = CharacterRepo;
            _charService = charService;
        }

        [HttpPost("attack")]
        public IActionResult AttackCharacter(AttackCharacterRequest request)
        {
            var attacker = _chars.GetById(request.AttackerId);
            var victim = _chars.GetById(request.VictimId);

            if (attacker == null || victim == null) {
                return NotFound();
            }

            if (! victim.CanTakeDamage(attacker.HitPoints)) {
                return ValidationProblem("The victim can't take this much damage :(");
            }

            victim.TakeDamage(attacker.HitPoints);
            _chars.Update(victim);

            return Ok(
                new {
                    Message = "Attack Successful!",
                    Attacker = _mapper.Map<CharacterResponse>(attacker),
                    Victim = _mapper.Map<CharacterResponse>(victim)
                }
            );
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Character>> GetAllCharacters()
        {
            var chars = _mapper.Map<IEnumerable<CharacterResponse>>(_chars.GetAll());

            return Ok(chars);
        }

        [HttpGet("{id}")]
        public ActionResult<CharacterResponse> GetCharacter(int id)
        {
            var character = _chars.GetById(id);

            if (character == null) {
                return NotFound();
            }

            return Ok(
                _mapper.Map<CharacterResponse> (character)
            );
        }
    }
}
