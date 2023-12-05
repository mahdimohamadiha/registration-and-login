using Microsoft.EntityFrameworkCore;
using Registration_and_Login.Models;

namespace Registration_and_Login.Data
{
	public class ApplicationDbContext: DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Users> Users { get; set; }
    }
}
