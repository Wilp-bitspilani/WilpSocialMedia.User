﻿using System;
using System.Collections.Generic;
using System.Linq;
using WilpSocialMedia.Common.DTO;
using WilpSocialMedia.User.Application.DTO;
using WilpSocialMedia.User.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WilpSocialMedia.User.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Users(List<Guid> id)
        {
            try
            {
                var responAPI = _userService.ListUser(id);
                return Ok(new ApiOkResponse(responAPI, responAPI.Count));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
       
    }
}
