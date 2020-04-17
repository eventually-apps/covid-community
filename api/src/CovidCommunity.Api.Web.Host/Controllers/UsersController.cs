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
using CovidCommunity.Api.Users.Dto;

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

        [HttpPost("request-verification")]
        public async Task<NoContentResult> RequestVerification(NewUserRequest model)
        {
            if (!model.IsPasswordValid())
            {
                throw new UserFriendlyException("Passwords do not match");
            }

            var isUniqueUser = await _userAppService.IsUserUnique(model.EmailAddress);

            if(!isUniqueUser)
            {
                throw new UserFriendlyException("There seems to be a user with this email already.");
            }

            await _twiioVerificationService.StartVerification(model.GetFullPhoneNumber(), "sms");

            return NoContent();
        }

        [HttpPost("new")]
        public async Task<NewUserResult> CreateUser(VerifyUserRequest model)
        {
            await _twiioVerificationService.ConfirmVerification(model.User.GetFullPhoneNumber(), model.Code);
            var userResult = await _userAppService.CreateAsync(model.User.ConvertToDto());
            var accessToken = CreateAccessToken(CreateJwtClaims(userResult.Identity));

            return new NewUserResult() { Token = accessToken };
        }

        [HttpGet("config")]
        public async Task<ActionResult> GetUserConfig()
        {
            var userConfig = await _userConfigBuilder.GetAll();
            var sessionInfo = await _sessionAppService.GetCurrentLoginInformations();

            return Ok(new { userConfig, sessionInfo });
        }

        [HttpGet("{id}")]
        public async Task<UserDto> GetUser(long id)
        {
            var user = await _userAppService.GetAsync(new EntityDto<long>(id));
            return user;
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
