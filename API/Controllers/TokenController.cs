using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("{roles}")]
        public string GetRandomToken(string roles)
        {
            var jwt = new JwtServices(_config);
            var token = jwt.GenerateSecurityToken("fake@email.com", roles);
            return token;
        }
    }
}
