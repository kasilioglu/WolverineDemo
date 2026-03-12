using DemoApi.Application.Tasks;
using DemoApi.Domain;
using DemoApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Infrastructure.Tasks;

public sealed class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<TaskEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.TaskEntities
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<TaskEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.TaskEntities
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public Task<TaskEntity> AddAsync(TaskEntity task, CancellationToken cancellationToken = default)
    {
        _context.TaskEntities.Add(task);
        return Task.FromResult(task);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.TaskEntities.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (entity != null)
            _context.TaskEntities.Remove(entity);
    }
}
