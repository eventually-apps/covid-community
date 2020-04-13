namespace CovidCommunity.Api.Web.Host.Models.User
{
    public class VerifyUserRequest
    {
        public NewUserRequest User { get; set; }
        public string Code { get; set; }
    }
}
