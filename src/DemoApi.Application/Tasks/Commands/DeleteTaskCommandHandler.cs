using DemoApi.Application;
using DemoApi.Application.Tasks.Events;
using Microsoft.AspNetCore.Http;

namespace DemoApi.Application.Tasks.Commands;

public static class DeleteTaskCommandHandler
{
    public static async Task<IResult> Handle(DeleteTaskCommand command, ITaskRepository repository, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
    {
        var task = await repository.GetByIdAsync(command.TaskId, cancellationToken);
        if (task == null)
            return Results.NotFound();

        await repository.DeleteAsync(command.TaskId, cancellationToken);
        await unitOfWork.EnqueueForPublishAsync(new TaskDeleted(command.TaskId), cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Results.NoContent();
    }
}
