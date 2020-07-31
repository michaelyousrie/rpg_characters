using App.DTOs.Requests;
using App.Models;
using App.Repos;
using AutoMapper;

namespace App.Services
{
    public class CharacterService
    {
        private readonly CharacterRepo _chars;
        private readonly IMapper _mapper;

        public CharacterService(CharacterRepo CharacterRepo, IMapper mapper)
        {
            _chars = CharacterRepo;
            _mapper = mapper;
        }

        public Character Create(CreateCharacterRequest character)
        {
            var CreatedCharacter = _mapper.Map<Character>(character);
            _chars.Create(CreatedCharacter);

            return CreatedCharacter;
        }

        public bool NameExists(string name)
        {
            return _chars.NameExists(name);
        }
    }
}
