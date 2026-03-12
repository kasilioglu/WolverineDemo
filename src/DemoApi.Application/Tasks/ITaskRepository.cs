using DemoApi.Domain;

namespace DemoApi.Application.Tasks;

public interface ITaskRepository
{
    Task<IReadOnlyList<TaskEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TaskEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<TaskEntity> AddAsync(TaskEntity task, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
