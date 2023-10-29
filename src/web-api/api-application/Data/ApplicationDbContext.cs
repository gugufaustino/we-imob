using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiApplication.Data
{
    public class ApplicationDbContext  : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApiApplication.Data.ApplicationDbContext> options) : base (options)
        {

        }
    }
}
