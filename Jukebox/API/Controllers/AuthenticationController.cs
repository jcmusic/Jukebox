using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jcm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost("Authenticate")]
        public ActionResult<string> Authenticate(
            [FromBody] AuthenticationRequestBody authenticationRequestBody)
        {
            // step 1.  Validate the username/password
            var user = ValidateUserCredentials(
                authenticationRequestBody.UserName, authenticationRequestBody.Password);

            if (user == null) { return Unauthorized(); }

            // Secret for key should be stored in Key Vault or other trusted/protected location
            // place in appsettings for now for develepment purposes

            // step 2.
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));

            var signingCredentials = new SigningCredentials(
                securityKey,SecurityAlgorithms.HmacSha256);

            // Claims
            var claimsForToken =  new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
            claimsForToken.Add(new Claim("given-name", user.FirstName));
            claimsForToken.Add(new Claim("family-name", user.LastName));

            var jwtSecutityToken = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecutityToken);

            return Ok(tokenToReturn);

        }

        private LoginUser ValidateUserCredentials(string? userName, string? password)
        {
            // mock w/hardcoded user for develepment purposes.
            return new LoginUser(1, userName ?? "", "John", "Maloney");
        }

        /// <summary>
        /// username and password
        /// </summary>
        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }

        private class LoginUser
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public LoginUser(int userId, string userName, string firstName, string lastName)
            {
                UserId = userId;
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;
            }
        }
    }
}
