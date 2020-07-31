using System.Collections.Generic;
using App.DTOs;
using App.Helpers.Attributes;
using App.Models;
using App.Repos;
using App.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/users")]
    [Authorize, MustBeAdmin]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CharacterRepo _chars;
        private readonly CharacterService _charService;
        private readonly IUserService _userService;

        public UsersController(CharacterRepo characters, CharacterService charService, IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _chars = characters;
            _charService = charService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(
                _mapper.Map<IEnumerable<UserResponse>>(
                    _userService.GetAll()
                )
            );
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserRequest request)
        {
            var user = _userService.Create(_mapper.Map<User>(request));

            return Ok(new {
                Message = "User created successfully!",
                User = _mapper.Map<UserResponse>(user)
            });
        }
    }
}
