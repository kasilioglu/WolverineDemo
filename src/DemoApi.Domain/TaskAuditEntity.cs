namespace DemoApi.Domain;

public class TaskAuditEntity
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public string Action { get; set; } = string.Empty;
}
