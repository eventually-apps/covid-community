using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;

namespace CovidCommunity.Api.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string username, string emailAddress, string firstname, string lastname)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = username,
                Name = firstname,
                Surname = lastname,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}
