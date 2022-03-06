using chatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace chatAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Status> Statuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Status>().HasData(
            new Status {ID = -1, StatusName = "ON BREAK"},
            new Status {ID = -2, StatusName = "ON CALL"},
            new Status {ID = -3, StatusName = "IN MEETING"}
        );
    }
}