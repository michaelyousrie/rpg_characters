using App.DTOs;
using App.DTOs.Requests;
using App.DTOs.Responses;
using App.Models;
using AutoMapper;

namespace App.Profiles
{
    public class CharactersProfile : Profile
    {
        public CharactersProfile()
        {
            CreateMap<Character, CharacterResponse>();
            CreateMap<Character, UpdateCharacterRequest>();
            CreateMap<UpdateCharacterRequest, Character>();
            CreateMap<CreateCharacterRequest, Character>();
        }
    }
}
