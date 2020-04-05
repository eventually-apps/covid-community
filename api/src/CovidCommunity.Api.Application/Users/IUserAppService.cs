using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CovidCommunity.Api.Roles.Dto;
using CovidCommunity.Api.Users.Dto;

namespace CovidCommunity.Api.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
