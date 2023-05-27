using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CofeeBreak3.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CoffeType> CoffeTypes{ get; set; }
        public virtual DbSet<Cofee> Cofees { get; set; }
        public virtual DbSet<Order > Orders { get; set; }
        
    }
}