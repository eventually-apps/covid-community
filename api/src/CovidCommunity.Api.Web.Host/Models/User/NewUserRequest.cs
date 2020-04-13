using CovidCommunity.Api.Users.Dto;
using System.ComponentModel.DataAnnotations;

namespace CovidCommunity.Api.Web.Host.Models.User
{
    public class NewUserRequest
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordConfirm { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public string GetFullPhoneNumber()
        {
            return $"+1{PhoneNumber}";
        }

        public bool IsPasswordValid()
        {
            if(Password == PasswordConfirm)
            {
                return true;
            }

            return false;
        }

        public CreateUserDto ConvertToDto()
        {
            return new CreateUserDto
            {
                UserName = EmailAddress,
                EmailAddress = EmailAddress,
                Name = FirstName,
                Surname = LastName,
                Address = Address,
                City = City,
                State = State,
                ZipCode = ZipCode,
                Password = Password,
                PhoneNumber = GetFullPhoneNumber(),
                IsActive = true
            };
        }
    }
}
