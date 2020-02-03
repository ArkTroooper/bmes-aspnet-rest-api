using BmesRestApi.Models.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BmesRestApi.Database
{
    public class BmesIdentityDbContext : IdentityDbContext<User>
    {
        public BmesIdentityDbContext(DbContextOptions<BmesIdentityDbContext> options) : base(options) { }
    }
}
