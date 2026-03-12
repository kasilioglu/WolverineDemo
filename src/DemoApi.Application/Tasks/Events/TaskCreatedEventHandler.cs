using DemoApi.Application;
using DemoApi.Domain;

namespace DemoApi.Application.Tasks.Events;

public static class TaskCreatedEventHandler
{
    public static async Task Handle(TaskCreated message, ITaskAuditRepository auditRepository, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
    {
        var audit = new TaskAuditEntity
        {
            Id = Guid.NewGuid(),
            TaskId = message.TaskId,
            Action = "Created"
        };
        await auditRepository.AddAsync(audit, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
