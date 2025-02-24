using Microsoft.AspNetCore.Identity;

namespace Barberia.Core.Entities
{
    public class AppUser : IdentityUser
    {

        public DateTime CreatedAt { get; set; }

        public Guid? CreatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedById { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
