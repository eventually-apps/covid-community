using System.ComponentModel.DataAnnotations;

namespace CovidCommunity.Api.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}