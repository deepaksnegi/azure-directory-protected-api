using AzureAuthentication.API.DTO;
using System;
using System.Collections.Generic;

namespace AzureAuthentication.API.Helper.TestData
{
    public static class UserTestData
    {
        public static readonly IList<UserDto> users = new List<UserDto>
        {
            new UserDto
            {
                Email ="john.doe@example.com",
                Guid= new  Guid("7966551C-DC33-446F-9FB9-8D0899CC776D").ToString(),
                FirstName="John",
                LastName="Doe"
            },
            new UserDto
            {
                Email ="ervin.howell@example.com",
                Guid= new  Guid("60ef468d-440a-4d32-98a0-194b8b89b7c7").ToString(),
                FirstName="Ervin",
                LastName="Howell"
            }
        };
    }
}
