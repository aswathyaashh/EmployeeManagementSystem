using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions dboptions) : base(dboptions)
        {

        }
        public DbSet<ModelLayer.EmployeeDetails> Details { get; set; }
        public DbSet<ModelLayer.AdminVerify> AdminDetails{ get; set; }
        public DbSet<ModelLayer.Designation> DesignationDetails { get; set; }
    }
   
}