using DemoApi.Domain;

namespace DemoApi.Application.Tasks;

public interface ITaskAuditRepository
{
    Task AddAsync(TaskAuditEntity entity, CancellationToken cancellationToken = default);
}
