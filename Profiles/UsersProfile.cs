using App.DTOs;
using App.Models;
using AutoMapper;

namespace App.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<User, CreateUserRequest>();
            CreateMap<User, UserResponse>();
        }
    }
}
