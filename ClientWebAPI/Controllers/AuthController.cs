using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClientWebAPI.Model;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ClientWebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuthenticationManager _authenticationManager;

        public AuthController(IConfiguration config, IAuthenticationManager authenticationManager)
        {
            _config = config;
            _authenticationManager = authenticationManager;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]LoginDto user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if(_authenticationManager.Authenticate(user.Username, user.Password))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:secretKey"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _config["jwt:issuer"],
                    audience: _config["jwt:audience"],
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(tokenString);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}