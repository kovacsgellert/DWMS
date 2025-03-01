using DWMS.Inbound.Api.DataAccess.Common;
using DWMS.Inbound.Api.Domain.Entities;
using MongoDB.Driver;

namespace DWMS.Inbound.Api.DataAccess.Mongo;

public class ReceiptRepository : IReceiptRepository
{
    private readonly 
    public ReceiptRepository(IMongoDatabase database)
    {
    }

    private class ReceiptDao
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public List<ReceiptLineDao> ReceiptLines { get; set; } = new List<ReceiptLineDao>();
    }


}
