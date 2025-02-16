using DWMS.Inbound.Api.Domain.Entities;
using MongoDB.Driver;

namespace DWMS.Inbound.Api.DataAccess.Mongo;

public class ReceiptRepository : MongoRepository<Receipt>, IReceiptRepository
{
    public ReceiptRepository(IMongoDatabase database) : base(database)
    {
    }
}
