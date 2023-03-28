using MicroNetSix.Services.IdentityAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MicroNetSix.Services.IdentityAPI.Services
{
    public class IdentityService : IIdentityService
    {
        public Task<LoginResponseModel> Login(LoginRequestModel requestModel)
        {

            // DB Process will be here.


            var claims = new Claim[]
            {
              new Claim(ClaimTypes.NameIdentifier,requestModel.UserName),
              new Claim(ClaimTypes.Name,"Barbaros Gültekin"),              
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TechBuddySecretKeyShouldBeLong"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(10),
                signingCredentials: creds,
                notBefore: DateTime.Now);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

            LoginResponseModel response = new()
            {
                UserToken = encodedJwt,
                UserName = requestModel.UserName
            };
            return Task.FromResult(response);
        }
    }
}
