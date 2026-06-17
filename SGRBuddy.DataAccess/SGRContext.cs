using Microsoft.EntityFrameworkCore;

using SGRBuddy.Domain;

namespace SGRBuddy.DataAccess;  

public class SGRContext (DbContextOptions options) : DbContext(options)
{
    public DbSet<SGRItem> SGRItem => Set<SGRItem>();
    public DbSet<SGRSession> SGRSession => Set<SGRSession>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SGRItem>()
            .HasKey(i => i.Id);
        
        // Configure foreign key relationship
        modelBuilder.Entity<SGRItem>()
            .HasOne(i => i.SGRSession)
            .WithMany(s => s.SGRItems)
            .HasForeignKey(i => i.SessionId);
            
        // Configure decimal precision to avoid silent truncation warnings
        modelBuilder.Entity<SGRItem>()
            .Property(i => i.Capacity)
            .HasPrecision(18, 3);

        modelBuilder.Entity<SGRSession>()
            .Property(s => s.TotalPrice)
            .HasPrecision(18, 2);
    }
    
}