using DemoApi.Application.Tasks;
using DemoApi.Domain;
using DemoApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Infrastructure.Tasks;

public sealed class TaskAuditRepository : ITaskAuditRepository
{
    private readonly TaskDbContext _context;

    public TaskAuditRepository(TaskDbContext context)
    {
        _context = context;
    }

    public Task AddAsync(TaskAuditEntity entity, CancellationToken cancellationToken = default)
    {
        _context.TaskAudits.Add(entity);
        return Task.CompletedTask;
    }
}
