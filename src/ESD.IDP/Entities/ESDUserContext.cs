using Microsoft.EntityFrameworkCore;

namespace ESD.IDP.Entities
{
    public class ESDUserContext : DbContext
    {
        public ESDUserContext(DbContextOptions<ESDUserContext> options)
           : base(options)
        {
           
        }

        public DbSet<User> Users { get; set; }
    }
}
