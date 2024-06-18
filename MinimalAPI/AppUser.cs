﻿using Microsoft.AspNetCore.Identity;
namespace MinimalAPI
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? AvatarURL { get; set; }
        public string? Description { get; set; }
    }
}