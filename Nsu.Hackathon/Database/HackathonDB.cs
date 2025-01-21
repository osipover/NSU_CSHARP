namespace Nsu.HackathonProblem.Database;

using Microsoft.EntityFrameworkCore;
using Nsu.HackathonProblem.Model.Entity;

public class HackathonDB(DbContextOptions<HackathonDB> options): DbContext(options)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasKey(e => new { e.Id, e.Role });
        modelBuilder.Entity<Wishlist>()
        .HasKey(e =>
            new { e.Role, e.EmployeeId, e.HackathonId, e.PreferredEmployeeId }
        );
        modelBuilder.Entity<Hackathon>()
            .HasMany(h => h.Teams)
            .WithOne(t => t.Hackathon)
            .HasForeignKey(t => t.HackathonId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Hackathon> Hackathons { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }
    public DbSet<Employee> Employees { get; set; }

}