namespace CovidCommunity.Api.Users.Dto
{
    public class VerifyUserInput
    {
        public VerifyUserInput(long id)
        {
            UserId = id;
        }
        public long UserId { get; set; }
    }
}
