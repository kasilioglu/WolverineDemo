using DemoApi.Application.Messaging;
using DemoApi.Application.Tasks.Events;
using Wolverine;
using Wolverine.RabbitMQ;

namespace DemoApi.Application.Tasks;

/// <summary>
/// Tasks module: queues this module listens to (integration events from this or other modules).
/// </summary>
public static class WolverineTasksListenExtensions
{
    public static WolverineOptions UseTasksListen(this WolverineOptions opts)
    {
        opts.ListenToRabbitQueue(IntegrationEventQueueName.For<TaskDeleted>())
            .UseDurableInbox();

        opts.ListenToRabbitQueue(IntegrationEventQueueName.For<TaskCreated>())
            .UseDurableInbox();
        return opts;
    }
}
