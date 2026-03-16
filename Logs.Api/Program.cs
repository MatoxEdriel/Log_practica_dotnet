using Application.Services;
using Infrastructure.Repositories;
using Infrastructure.Settings;
using Intercore.shared.Constans.KAFKA.topics;
using Intercore.shared.Constans.KAFKA.groups;
using Intercore.shared.DTOs;
using Logs.Api.Consumers;
using MassTransit;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings")
);

builder.Services.Scan(scan => scan
    .FromAssembliesOf(typeof(MongoLogRepository), typeof(LogService))
    .AddClasses(classes => classes
        .Where(c => c.Name.EndsWith("Service") || c.Name.EndsWith("Repository")))
    .AsImplementedInterfaces()
    .WithScopedLifetime()
);

//masstransit kafka


builder.Services.AddMassTransit(x =>
{
    x.UsingInMemory((context, cfg) => cfg.ConfigureEndpoints(context));

    x.AddRider(rider =>
    {
        rider.AddConsumer<LogEventConsumer>();

        rider.UsingKafka((context, k) =>
        {
            k.Host(builder.Configuration["Kafka:BootstrapServers"]);

            k.TopicEndpoint<CreateAppLogDto>(KafkaTopics.AppLogs, LogsKafkaConstant.Id, e =>
            {
                e.ConfigureConsumer<LogEventConsumer>(context);
            });

            k.TopicEndpoint<CreateAccessLogDto>(KafkaTopics.AccessLogs, LogsKafkaConstant.Id, e =>
            {
                e.ConfigureConsumer<LogEventConsumer>(context);
            });

            k.TopicEndpoint<CreateExceptionLogDto>(KafkaTopics.ExceptionLogs, LogsKafkaConstant.Id, e =>
            {
                e.ConfigureConsumer<LogEventConsumer>(context);
            });
        });
    });
});

builder.Services.AddHealthChecks();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    
}

app.UseHttpsRedirection();


app.MapControllers();

app.MapHealthChecks("/health");

app.Run();

