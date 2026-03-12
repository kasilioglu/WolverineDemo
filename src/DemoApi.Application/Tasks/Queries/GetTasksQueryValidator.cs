using FluentValidation;

namespace DemoApi.Application.Tasks.Queries;

public class GetTasksQueryValidator : AbstractValidator<GetTasksQuery>
{
    public GetTasksQueryValidator()
    {
        // No parameters to validate for empty query; leave extensible for future filter params
    }
}
