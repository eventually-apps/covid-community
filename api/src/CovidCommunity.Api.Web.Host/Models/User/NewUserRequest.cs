using CovidCommunity.Api.Users.Dto;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCommunity.Api.Web.Host.Models.User
{
    public class NewUserRequest
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
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
                IsActive = false
            };
        }
    }
}
