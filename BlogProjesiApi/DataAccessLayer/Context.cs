using Microsoft.EntityFrameworkCore;

namespace BlogProjesiApi.DataAccessLayer
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=BlogProjesiApi;uid=sa;password=Asd123asd.;trusted_connection=false;TrustServerCertificate=true");

        }

        public DbSet <Employee> Employees { get; set; }
    }
}
