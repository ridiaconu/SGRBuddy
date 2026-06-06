using Microsoft.EntityFrameworkCore;

using SGRBuddy.Domain;

namespace SGRBuddy.DataAccess;  

public class SGRContext (DbContextOptions options) : DbContext(options)
{
    public DbSet<SGRItem> SGRItems => Set<SGRItem>();
    public DbSet<SGRSession> SGRSessions => Set<SGRSession>();

    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
    */
}