using CMA.Model;
using ContactMangement.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ContactManagement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly IConfiguration Configuration;
        public HomeController(IConfiguration setting)
        {
            Configuration = setting;
        }
        [HttpPost("ValidateUserAndGetToken")]
        public async Task<object> ValidateUserAndGetToken(UserDTO userCredential)
        {
            if (string.IsNullOrEmpty(userCredential.Email) || string.IsNullOrEmpty(userCredential.Password))
            {
                return Ok(new
                {
                    Status = false,
                    Message = "NotExists"
                });
            }

            var token = GenerateJwtToken(userCredential.Email);
            TokenDto responseObj = new TokenDto();
            responseObj.Token = token.Item1;
            responseObj.ExpiresIn = getDateTimeInSpecficFormat(token.Item2);

            return Ok(new
            {
                Status = true,
                Message = "Success",
                Result = userCredential,
                TokenResult = responseObj
            });
        }


        [NonAction]
        private string getDateTimeInSpecficFormat(DateTime dateTime)
        {
            return dateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
        }
        [NonAction]
        private (string, DateTime, List<Claim>) GenerateJwtToken(string emailId)
        {
            var securityKey = Configuration["G9-JWT:SecretKey"];
            var mySecurityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey));

            var credentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256);

            var tokenIssuer = Configuration["G9-JWT:Issuer"];
            var tokenAudience = Configuration["G9-JWT:Audience"];

            var claims = new List<Claim>
                    {

                        new Claim(ClaimTypes.Email, emailId)

                    };

            DateTime expiry = DateTime.UtcNow.AddMinutes(7000000);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiry,
                issuer: tokenIssuer,
                audience: tokenAudience,
                signingCredentials: credentials);

            return (new JwtSecurityTokenHandler().WriteToken(token), expiry, claims);
        }
    }
}
