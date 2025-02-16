using DWMS.Inbound.Api.DataAccess.Common;
using MongoDB.Driver;

namespace DWMS.Inbound.Api.DataAccess.Mongo;

public class MongoRepository<T> : IRepository<T> where T : class, IHasGuidId
{
    private readonly IMongoCollection<T> _collection;

    public MongoRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<T>(typeof(T).Name);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<T?> GetById(Guid id)
    {
        return await _collection.Find(entity => entity.Id == id).FirstOrDefaultAsync();
    }

    public async Task Add(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task Update(T entity)
    {
        await _collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);
    }

    public async Task Delete(Guid id)
    {
        await _collection.DeleteOneAsync(entity => entity.Id == id);
    }

    public IQueryable<T> AsQueryable()
    {
        return _collection.AsQueryable();
    }
}