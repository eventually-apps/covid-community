using Abp.Application.Services.Dto;

namespace CovidCommunity.Api.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

