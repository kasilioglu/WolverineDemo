using System.Text.RegularExpressions;

namespace DemoApi.Application.Messaging;

/// <summary>
/// Convention-based queue name for IIntegrationEvent types (type name to kebab-case).
/// </summary>
public static class IntegrationEventQueueName
{
    public static string For(Type eventType)
    {
        if (eventType == null) throw new ArgumentNullException(nameof(eventType));
        var name = eventType.Name;
        // PascalCase to kebab-case: insert hyphen before capitals (except first), then lowercase
        var kebab = Regex.Replace(name, @"([a-z0-9])([A-Z])", "$1-$2").ToLowerInvariant();
        return kebab;
    }

    public static string For<T>() where T : IIntegrationEvent => For(typeof(T));
}
