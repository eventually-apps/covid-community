using Abp.Application.Services.Dto;
using Abp.UI;
using CovidCommunity.Api.Controllers;
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

        public UsersController(ITwilioVerificationService twiioVerificationService, IUserAppService userAppService)
        {
            _twiioVerificationService = twiioVerificationService;
            _userAppService = userAppService;
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
    }
}
