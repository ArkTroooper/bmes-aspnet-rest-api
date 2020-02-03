using Microsoft.AspNetCore.Identity;

namespace BmesRestApi.Models.Shared
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
