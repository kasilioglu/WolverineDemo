using DemoApi.Application.Messaging;

namespace DemoApi.Application.Tasks.Events;

public record TaskCreated(Guid TaskId, string Title, DateTime CreatedAt) : IIntegrationEvent; //IDomainEvent;
