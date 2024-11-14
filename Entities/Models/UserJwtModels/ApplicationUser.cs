﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.JwtModels
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }  
        public string LastName { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}