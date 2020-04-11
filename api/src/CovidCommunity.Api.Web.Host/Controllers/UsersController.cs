using Abp.Application.Services.Dto;
using Abp.UI;
using Abp.Web.Configuration;
using CovidCommunity.Api.Controllers;
using CovidCommunity.Api.Sessions;
using CovidCommunity.Api.Twilio;
using CovidCommunity.Api.Users;
using CovidCommunity.Api.Web.Host.Models.User;
using Microsoft.AspNetCore.Mvc;
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

        public UsersController(ITwilioVerificationService twiioVerificationService, IUserAppService userAppService, AbpUserConfigurationBuilder userConfigBuilder, ISessionAppService sessionAppService)
        {
            _twiioVerificationService = twiioVerificationService;
            _userAppService = userAppService;
            _userConfigBuilder = userConfigBuilder;
            _sessionAppService = sessionAppService;
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

            return new VerifyUserResult { IsVerified = true };
        }

        [HttpGet("config")]
        public async Task<ActionResult> GetUserConfig()
        {
            var userConfig = await _userConfigBuilder.GetAll();
            var sessionInfo = await _sessionAppService.GetCurrentLoginInformations();

            return Ok(new { userConfig, sessionInfo });
        }
    }
}
