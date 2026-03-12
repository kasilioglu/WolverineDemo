namespace DemoApi.Application;

/// <summary>
/// Transaction boundary for the current unit of work. All persistence (entity changes and optional outbox messages) is committed via SaveChangesAsync.
/// </summary>
public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Enqueues a message to be published in the same transaction when SaveChangesAsync is called (outbox).
    /// </summary>
    Task EnqueueForPublishAsync(object message, CancellationToken cancellationToken = default);
}
