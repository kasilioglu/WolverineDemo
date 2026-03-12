using DemoApi.Domain;
using Microsoft.EntityFrameworkCore;
using Wolverine.EntityFrameworkCore;

namespace DemoApi.Infrastructure.Persistence;

public sealed class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

    public DbSet<TaskEntity> TaskEntities => Set<TaskEntity>();
    public DbSet<TaskAuditEntity> TaskAudits => Set<TaskAuditEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.MapWolverineEnvelopeStorage("wolverine");
        modelBuilder.Entity<TaskEntity>(entity =>
        {
            entity.ToTable("TaskEntities");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).HasMaxLength(500);
        });
        modelBuilder.Entity<TaskAuditEntity>(entity =>
        {
            entity.ToTable("TaskAudits");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Action).HasMaxLength(100);
        });
    }
}
