using CovidCommunity.Api.Controllers;
using CovidCommunity.Api.Twilio;
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

        public UsersController(ITwilioVerificationService twiioVerificationService)
        {
            _twiioVerificationService = twiioVerificationService;
        }

        [HttpPost("new")]
        public async Task<NewUserResult> CreateUser(NewUserRequest model)
        {
            var response = await _twiioVerificationService.StartVerification(model.PhoneNumber, "sms");

            return new NewUserResult() { Id = 1 };
        }

        [HttpPost("verify")]
        public async Task<VerifyUserResult> VerifyUser(VerifyUserRequest model)
        {
            var result = await _twiioVerificationService.ConfirmVerification("+12147296420", model.Code);

            return new VerifyUserResult { IsVerified = true };
        }
    }
}
