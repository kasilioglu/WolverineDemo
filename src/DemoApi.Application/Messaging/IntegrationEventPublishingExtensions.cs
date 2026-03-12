using DemoApi.Application.Tasks.Events;
using Wolverine;
using Wolverine.RabbitMQ;

namespace DemoApi.Application.Messaging;

/// <summary>
/// Configures publish routing for all IIntegrationEvent types to RabbitMQ (queue name by convention).
/// Add a new line here when adding an integration event.
/// </summary>
public static class IntegrationEventPublishingExtensions
{
    public static WolverineOptions ConfigureIntegrationEventPublishing(this WolverineOptions opts)
    {
        opts.PublishMessage<TaskDeleted>().ToRabbitQueue(IntegrationEventQueueName.For<TaskDeleted>());
        opts.PublishMessage<TaskCreated>().ToRabbitQueue(IntegrationEventQueueName.For<TaskCreated>());
        return opts;
    }
}
