using DemoApi.Application;
using DemoApi.Application.Tasks.Events;
using DemoApi.Domain;

namespace DemoApi.Application.Tasks.Commands;

public static class CreateTaskCommandHandler
{
    public static async Task<TaskEntity> Handle(CreateTaskCommand command, ITaskRepository repository, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
    {
        var task = new TaskEntity
        {
            Id = Guid.NewGuid(),
            Title = command.Title.Trim(),
            IsCompleted = command.IsCompleted,
            CreatedAt = DateTime.UtcNow
        };
        var created = await repository.AddAsync(task, cancellationToken);
        await unitOfWork.EnqueueForPublishAsync(new TaskCreated(created.Id, created.Title, created.CreatedAt), cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return created;
    }
}
