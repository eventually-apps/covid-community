using Abp.Application.Services.Dto;
using Abp.UI;
using Abp.Web.Configuration;
using CovidCommunity.Api.Authentication.JwtBearer;
using CovidCommunity.Api.Controllers;
using CovidCommunity.Api.Sessions;
using CovidCommunity.Api.Twilio;
using CovidCommunity.Api.Users;
using CovidCommunity.Api.Web.Host.Models.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CovidCommunity.Api.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        private readonly ITwilioVerificationService _twiioVerificationService;
        private readonly IUserAppService _userAppService;
        private readonly AbpUserConfigurationBuilder _userConfigBuilder;
        private readonly ISessionAppService _sessionAppService; 
        private readonly TokenAuthConfiguration _configuration;

        public UsersController(ITwilioVerificationService twiioVerificationService, IUserAppService userAppService, AbpUserConfigurationBuilder userConfigBuilder, ISessionAppService sessionAppService, TokenAuthConfiguration configuration)
        {
            _twiioVerificationService = twiioVerificationService;
            _userAppService = userAppService;
            _userConfigBuilder = userConfigBuilder;
            _sessionAppService = sessionAppService;
            _configuration = configuration;
        }

        [HttpPost("new")]
        public async Task<NewUserResult> CreateUser(NewUserRequest model)
        {
            if (!model.IsPasswordValid())
            {
                throw new UserFriendlyException("Passwords do not match");
            }

            var user = await _userAppService.CreateAsync(model.ConvertToDto());
            await _twiioVerificationService.StartVerification(model.GetFullPhoneNumber(), "sms");

            return new NewUserResult() { User = user };
        }

        [HttpPost("verify")]
        public async Task<VerifyUserResult> VerifyUser(VerifyUserRequest model)
        {
            var user = await _userAppService.GetAsync(new EntityDto<long>(model.UserId));
            
            await _twiioVerificationService.ConfirmVerification(user.PhoneNumber, model.Code);
            var loginResult = await _userAppService.VerifyUser(new Users.Dto.VerifyUserInput(model.UserId));

            var accessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity));

            return new VerifyUserResult { IsVerified = true, AccessToken = accessToken };
        }

        [HttpGet("config")]
        public async Task<ActionResult> GetUserConfig()
        {
            var userConfig = await _userConfigBuilder.GetAll();
            var sessionInfo = await _sessionAppService.GetCurrentLoginInformations();

            return Ok(new { userConfig, sessionInfo });
        }

        private static List<Claim> CreateJwtClaims(ClaimsIdentity identity)
        {
            var claims = identity.Claims.ToList();
            var nameIdClaim = claims.First(c => c.Type == ClaimTypes.NameIdentifier);

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            claims.AddRange(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, nameIdClaim.Value),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            });

            return claims;
        }

        private string CreateAccessToken(IEnumerable<Claim> claims, TimeSpan? expiration = null)
        {
            var now = DateTime.UtcNow;

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(expiration ?? _configuration.Expiration),
                signingCredentials: _configuration.SigningCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
