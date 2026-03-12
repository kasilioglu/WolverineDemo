using DemoApi.Domain;
using Microsoft.AspNetCore.Http;
using Wolverine;
using Wolverine.Http;

namespace DemoApi.Application.Tasks;

public static class TaskEndpoints
{
    [WolverineGet("/tasks")]
    public static Task<IReadOnlyList<TaskEntity>> Get(IMessageBus bus, CancellationToken cancellationToken)
    {
        return bus.InvokeAsync<IReadOnlyList<TaskEntity>>(new Queries.GetTasksQuery(), cancellationToken);
    }

    [WolverinePost("/tasks")]
    public static async Task<IResult> Post(Commands.CreateTaskCommand command, IMessageBus bus, CancellationToken cancellationToken)
    {
        var task = await bus.InvokeAsync<TaskEntity>(command, cancellationToken);
        return Results.Created($"/tasks/{task.Id}", task);
    }

    [WolverineDelete("/tasks/{id}")]
    public static Task<IResult> Delete(Guid id, IMessageBus bus, CancellationToken cancellationToken)
    {
        return bus.InvokeAsync<IResult>(new Commands.DeleteTaskCommand(id), cancellationToken);
    }
}
