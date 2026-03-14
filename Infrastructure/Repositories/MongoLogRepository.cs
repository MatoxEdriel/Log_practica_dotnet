using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Constant;
using Infrastructure.Settings;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repositories;

public class MongoLogRepository : ILogRepository 
{
    private readonly IMongoDatabase _database;



    public MongoLogRepository(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public async Task InsertAppLogAsync(AppLog log)
    {
        var collection = _database.GetCollection<AppLog>(MongoCollections.AppLogs);
        await collection.InsertOneAsync(log);
    }

    public async Task InsertAccessLogAsync(AccessLog log)
    {
        var collection = _database.GetCollection<AccessLog>(MongoCollections.AccessLogs);
        await collection.InsertOneAsync(log);
    }

    public async Task InsertExceptionLogAsync(ExceptionLog log)
    {
        var collection = _database.GetCollection<ExceptionLog>(MongoCollections.ExceptionLogs);
        await collection.InsertOneAsync(log);
    }

    public async Task<IEnumerable<AppLog>> GetAppLogsByModuleAsync(string module)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<AccessLog>> GetFailedLoginsAsync(int lastHours)
    {
        throw new NotImplementedException();
    }
}