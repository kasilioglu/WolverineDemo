using DemoApi.Application;
using DemoApi.Application.Messaging;
using DemoApi.Application.Tasks;
using DemoApi.Infrastructure.Persistence;
using DemoApi.Infrastructure.Tasks;
using Microsoft.EntityFrameworkCore;
using Wolverine;
using Wolverine.FluentValidation;
using Wolverine.Http;
using Wolverine.Http.FluentValidation;
using Wolverine.RabbitMQ;
using Wolverine.SqlServer;
using Wolverine.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskAuditRepository, TaskAuditRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Host.UseWolverine(opts =>
{
    opts.Discovery.IncludeAssembly(typeof(ITaskRepository).Assembly);
    opts.UseFluentValidation();

    var sqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
    opts.PersistMessagesWithSqlServer(sqlConnection!, "wolverine");
    opts.UseEntityFrameworkCoreTransactions();

    var rabbitConnection = builder.Configuration.GetConnectionString("RabbitMQ")
        ?? "amqp://guest:guest@localhost:5672";
    opts.UseRabbitMq(new Uri(rabbitConnection))
        .AutoProvision();

    opts.ConfigureIntegrationEventPublishing();
    opts.UseTasksListen();
});

builder.Services.AddWolverineHttp();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapWolverineEndpoints(opts =>
{
    opts.UseFluentValidationProblemDetailMiddleware();
});

app.Run();
