using App.DTOs;
using App.Models;
using AutoMapper;

namespace App.Profiles
{
    public class CharactersProfile : Profile
    {
        public CharactersProfile()
        {
            CreateMap<Character, CharacterReadDto>();
            CreateMap<Character, CharacterUpdateDto>();
            CreateMap<CharacterUpdateDto, Character>();
            CreateMap<CreateCharacterRequest, Character>();
        }
    }
}
