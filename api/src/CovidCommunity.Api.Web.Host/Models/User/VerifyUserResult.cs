﻿namespace CovidCommunity.Api.Web.Host.Models.User
{
    public class VerifyUserResult
    {
        public bool IsVerified { get; set; }
        public string AccessToken { get; set; }
    }
}
