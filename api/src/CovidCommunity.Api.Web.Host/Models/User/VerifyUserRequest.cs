using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCommunity.Api.Web.Host.Models.User
{
    public class VerifyUserRequest
    {
        public long UserId { get; set; }
        public string Code { get; set; }
    }
}
