﻿using System;
using System.Collections.Generic;

namespace JobHunt.DTO.Identity
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ProfilePictureDataUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<string> UserRoles { get; set; } = new();
        public List<string> UserPermissions { get; set; } = new();
        public List<string> Roles { get; internal set; }
    }
}
