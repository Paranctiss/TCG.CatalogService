using System.Linq.Expressions;
using MongoDB.Driver;
using TCG.CatalogService.Application.Contracts;
using TCG.CatalogService.Domain;

namespace TCG.CatalogService.Persitence.Repositories;

public class MongoRepository<T> : IMongoRepository<T> where T: class, IEntity
{
    private readonly IMongoCollection<T> _collection;
    public MongoRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<T>(collectionName);
    }
    
    public Task<IReadOnlyCollection<T>> GetAllAsync()
    {
        return Task.FromResult<IReadOnlyCollection<T>>(new List<T>());
    }

    public Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetAsync(string id)
    {
        return await _collection.Find(x => x.IdCard == id).FirstOrDefaultAsync();
    }

    public Task<T> GetAsync(Expression<Func<T, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(string id)
    {
        throw new NotImplementedException();
    }
    
    public async Task CreateManyAsync(IEnumerable<T> items)
    {
        await _collection.InsertManyAsync(items);
    }
}

public static class ExtentionRepo
{
    public static bool IsOk(this MongoRepository<Item> test)
    {
        return test.Equals(null);
    }
}