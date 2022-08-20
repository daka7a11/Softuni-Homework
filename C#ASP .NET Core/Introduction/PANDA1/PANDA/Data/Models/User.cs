using Microsoft.AspNetCore.Identity;
using PANDA.Data.Models.Enumerable;
using System;
using System.ComponentModel.DataAnnotations;

namespace PANDA.Data.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Role Role { get; set; }
    }
}
