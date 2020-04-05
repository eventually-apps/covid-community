using Abp.Authorization;
using CovidCommunity.Api.Authorization.Roles;
using CovidCommunity.Api.Authorization.Users;

namespace CovidCommunity.Api.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
