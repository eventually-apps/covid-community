using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCommunity.Api.Web.Host.Models.User
{
    public class NewUserRequest
    {
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
    }
}
