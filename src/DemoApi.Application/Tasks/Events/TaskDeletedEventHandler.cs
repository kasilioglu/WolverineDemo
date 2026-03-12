using DemoApi.Application;
using DemoApi.Domain;

namespace DemoApi.Application.Tasks.Events;

public static class TaskDeletedEventHandler
{
    public static async Task Handle(TaskDeleted message, ITaskAuditRepository auditRepository, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
    {
        var audit = new TaskAuditEntity
        {
            Id = Guid.NewGuid(),
            TaskId = message.TaskId,
            Action = "Deleted"
        };
        await auditRepository.AddAsync(audit, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
