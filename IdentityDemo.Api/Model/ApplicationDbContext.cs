using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.Api.Model
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
