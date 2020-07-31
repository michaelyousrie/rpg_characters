using App.DTOs.Requests;
using App.DTOs.Responses;
using App.Models;
using AutoMapper;

namespace App.Profiles
{
    public class UserPermissionProfile : Profile
    {
        public UserPermissionProfile()
        {
            CreateMap<UserPermission, UserPermissionResponse>();
            CreateMap<UserPermission, CreateUserPermissionRequest>();
            CreateMap<CreateUserPermissionRequest, UserPermission>();
            CreateMap<UserPermissionResponse, UserPermission>();
        }
    }
}
