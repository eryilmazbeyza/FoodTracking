using Microsoft.EntityFrameworkCore;

namespace foodtrackingcodefirst.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>dbContext):base(dbContext)
        {

        }

        public DbSet<Clinic> clinics { get; set; }
        public DbSet<Diet> diets { get; set; }
        public DbSet<Disease> diseases { get; set; }
        public DbSet<Meal> meals { get; set; }
        public DbSet<Nutrition> nutritions { get; set;}
        public DbSet<Patient> patients { get; set; }

    }
}
