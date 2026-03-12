using DemoApi.Application;
using DemoApi.Infrastructure.Persistence;
using Wolverine.EntityFrameworkCore;

namespace DemoApi.Infrastructure.Persistence;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly IDbContextOutbox<TaskDbContext> _outbox;

    public UnitOfWork(IDbContextOutbox<TaskDbContext> outbox)
    {
        _outbox = outbox;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _outbox.SaveChangesAndFlushMessagesAsync(cancellationToken);

    public async Task EnqueueForPublishAsync(object message, CancellationToken cancellationToken = default)
    {
        await _outbox.PublishAsync(message);
    }
}
