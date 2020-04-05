using CovidCommunity.Api.Twilio.Results;
using System.Threading.Tasks;

namespace CovidCommunity.Api.Twilio
{
    public interface ITwilioVerificationService
    {
        Task<VerificationResult> StartVerification(string phonenumber, string channel);

        Task<VerificationResult> ConfirmVerification(string phonenumber, string code);
    }
}
