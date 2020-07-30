using System.Collections.Generic;
using App.DTOs;
using App.Helpers.Attributes;
using App.Repos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Models
{
    [ApiController]
    [Route("api/characters")]
    public class CharactersController : ControllerBase
    {
        private readonly CharacterRepo _chars;
        private IMapper _mapper;

        public CharactersController(CharacterRepo CharacterRepo, IMapper mapper)
        {
            _chars = CharacterRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<CharacterReadDto> CreateCharacter(CharacterCreateDto character)
        {
            var CreatedCharacter = _mapper.Map<Character>(character);
            _chars.Create(CreatedCharacter);

            var CharacterRead = _mapper.Map<CharacterReadDto>(CreatedCharacter);

            return Ok(new {
                Message = "Character Created!",
                Character = CharacterRead
            });

            // return CreatedAtRoute(nameof(GetCharacter), new {id = CharacterRead.Id}, CharacterRead);
        }

        [HttpPost("attack")]
        public ActionResult AttackCharacter(CharacterAttackInputDto attacking)
        {
            var attacker = _chars.GetById(attacking.AttackerId);
            var victim = _chars.GetById(attacking.VictimId);

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
                    Attacker = _mapper.Map<CharacterReadDto>(attacker),
                    Victim = _mapper.Map<CharacterReadDto>(victim)
                }
            );
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Character>> GetAllCharacters()
        {
            var chars = _mapper.Map<IEnumerable<CharacterReadDto>>(
                _chars.GetAll()
            );

            return Ok(chars);
        }

        [HttpGet("{id}")]
        public ActionResult<CharacterReadDto> GetCharacter(int id)
        {
            var character = _chars.GetById(id);

            if (character == null) {
                return NotFound();
            }

            return Ok(
                _mapper.Map<CharacterReadDto> (character)
            );
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
