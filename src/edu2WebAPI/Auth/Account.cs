using edu2Model.Domain;
using Microsoft.AspNetCore.Identity;
using System;

namespace edu2WebAPI.Auth
{
    public class Account : IdentityUser<int>
    {
        public UserAccountType UserAccountType { get; set; }

        public Account()
        {

        }
    }
}