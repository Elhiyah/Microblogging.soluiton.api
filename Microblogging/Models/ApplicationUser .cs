using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Microblogging.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateOnly? FechaNacimiento { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Follow> FollowFollowers { get; set; } = new List<Follow>();
        public virtual ICollection<Follow> FollowUsers { get; set; } = new List<Follow>();
        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
        public virtual ICollection<Tweet> Tweets { get; set; } = new List<Tweet>();
    }
}
