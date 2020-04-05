using Abp.Dependency;
using Abp.UI;
using CovidCommunity.Api.Twilio.Results;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Verify.V2.Service;

namespace CovidCommunity.Api.Twilio
{
    public class TwilioVerificationService : ITwilioVerificationService, ITransientDependency
    {
        public TwilioVerificationService()
        {
            TwilioClient.Init(TwilioConfiguration.AccountSid, TwilioConfiguration.AuthToken);
        }
        public async Task<VerificationResult> ConfirmVerification(string phonenumber, string code)
        {
            var checkVerification = await VerificationCheckResource.CreateAsync(to: phonenumber, code: code, pathServiceSid: TwilioConfiguration.VerificationSid);

            if(checkVerification.Status == "approved")
            {
                return new VerificationResult
                {
                    Sid = checkVerification.Sid
                };
            }

            throw new UserFriendlyException("There was an issue confirming your code. Please try again.");

        }

        public async Task<VerificationResult> StartVerification(string phonenumber, string channel)
        {
            var resource = await VerificationResource.CreateAsync(to: phonenumber, channel: channel, pathServiceSid: TwilioConfiguration.VerificationSid);

            return new VerificationResult
            {
                Sid = resource.Sid
            };
        }
    }
}
