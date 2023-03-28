﻿using MicroNetSix.Services.IdentityAPI.Models;
using MicroNetSix.Services.IdentityAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace MicroNetSix.Services.IdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService identityService;

        public AuthController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel loginRequestModel)
        {
            var result = await identityService.Login(loginRequestModel);
            return Ok(result);
        }
    }
}
