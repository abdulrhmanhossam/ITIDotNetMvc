using ITIDotNetMvc.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace ITIDotNetMvc.Models.Data;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public AppDbContext() : base()
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Server = .; DataBase = ITIDotNetMvc; Integrated Security = SSPI; TrustServerCertificate = True;");
    }

}
