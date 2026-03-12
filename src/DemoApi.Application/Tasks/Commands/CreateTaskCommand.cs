namespace DemoApi.Application.Tasks.Commands;

public record CreateTaskCommand(string Title, bool IsCompleted = false);
