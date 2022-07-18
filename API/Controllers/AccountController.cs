using API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountRepository accountRepository;
        IConfiguration config;

        public AccountController(AccountRepository accountRepository, IConfiguration config)
        {
            this.accountRepository = accountRepository;
            this.config = config;
        }
        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] Logon logon)
        {
            var result = accountRepository.Post(logon.Email, logon.Password);
            var claims = new List<Claim>();

            if (result != null)
            {
                claims.Add(new Claim("Email", logon.Email));
                foreach (var item in result.Role)
                {
                    claims.Add(new Claim("roles", item.Name));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtConfig:secret"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    config["JwtConfig:Issuer"],
                    config["JwtConfig:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: signIn
                    );
                var idToken = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { status = 200, data = result, token = idToken });

            }
            else
            {
                return BadRequest(new { status = 400, message = "Request is invalid" });
            }
        }
    }
}
