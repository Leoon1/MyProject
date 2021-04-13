using Microsoft.AspNetCore.Identity;

namespace MyProject.Domain.Entities.Identity
{
    public class Role : IdentityRole
    {
        public const string Administrator = "Administrators";
        public const string User = "Users";

        public string Description { get; set; }
    }
}