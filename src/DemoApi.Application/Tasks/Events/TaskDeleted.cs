using DemoApi.Application.Messaging;

namespace DemoApi.Application.Tasks.Events;

public record TaskDeleted(Guid TaskId) : IIntegrationEvent;
