using Microsoft.EntityFrameworkCore;

namespace ReservationAPP.Models
{
    public class Context : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;Database=ReservationAppDb; Integrated Security=True; Trust Server Certificate=True;");
        }
        public DbSet<Menu> Menu {  get; set; }


	}

}
