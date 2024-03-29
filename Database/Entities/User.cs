﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JobHunt.Database.Entities
{
    public class User : IdentityUser<int>
    {
        [MaxLength(256)]
        public string FirstName { get; set; }

        [MaxLength(256)]
        public string LastName { get; set; }
        public bool IsActive { get; set; } 


        //public string CreatedBy { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public string LastModifiedBy { get; set; }
        //public DateTime? LastModifiedOn { get; set; }
        //public DateTime? ProfileDate { get; set; }
        //public DateTime? InvitationDate { get; set; }
        //public DateTime? ExpiryDate { get; set; }
        //public bool IsDeleted { get; set; }
        //public DateTime? DeletedOn { get; set; }



        //public string RefreshToken { get; set; }
        //public DateTime RefreshTokenExpiryTime { get; set; }
        //

    }
}

