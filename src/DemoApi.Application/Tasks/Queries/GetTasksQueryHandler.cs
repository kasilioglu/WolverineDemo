using DemoApi.Domain;

namespace DemoApi.Application.Tasks.Queries;

public static class GetTasksQueryHandler
{
    public static Task<IReadOnlyList<TaskEntity>> Handle(GetTasksQuery query, ITaskRepository repository, CancellationToken cancellationToken)
    {
        return repository.GetAllAsync(cancellationToken);
    }
}
