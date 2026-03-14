using Application.Services;
using Infrastructure.Repositories;
using Infrastructure.Settings;

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


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();

