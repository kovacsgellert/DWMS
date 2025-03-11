using DWMS.Inbound.Api.DataAccess.Common;
using DWMS.Inbound.Api.Domain.Entities;
using MongoDB.Driver;

namespace DWMS.Inbound.Api.DataAccess.Mongo;

public class ReceiptRepository : IReceiptRepository
{
    private readonly IMongoCollection<ReceiptDao> _receiptsCollection;

    public ReceiptRepository(IMongoDatabase database)
    {
        _receiptsCollection = database.GetCollection<ReceiptDao>("receipts");
    }

    public async Task<Receipt?> GetByIdAsync(Guid id)
    {
        var filter = Builders<ReceiptDao>.Filter.Eq(r => r.Id, id);
        var receiptDao = await _receiptsCollection.Find(filter).FirstOrDefaultAsync();
        return receiptDao != null ? MapReceiptDaoToReceipt(receiptDao) : null;
    }

    public async Task<IEnumerable<Receipt>> GetAllAsync()
    {
        var receiptDaos = await _receiptsCollection.Find(Builders<ReceiptDao>.Filter.Empty).ToListAsync();
        return receiptDaos.Select(MapReceiptDaoToReceipt);
    }

    public async Task<Receipt> CreateAsync(Receipt receipt)
    {
        var receiptDao = MapReceiptToReceiptDao(receipt);
        await _receiptsCollection.InsertOneAsync(receiptDao);
        return receipt;
    }

    public async Task<bool> UpdateAsync(Receipt receipt)
    {
        var receiptDao = MapReceiptToReceiptDao(receipt);
        var filter = Builders<ReceiptDao>.Filter.Eq(r => r.Id, receipt.Id);
        var updateResult = await _receiptsCollection.ReplaceOneAsync(filter, receiptDao);
        
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var filter = Builders<ReceiptDao>.Filter.Eq(r => r.Id, id);
        var result = await _receiptsCollection.DeleteOneAsync(filter);
        
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    internal Receipt MapReceiptDaoToReceipt(ReceiptDao receiptDao)
    {
        return new Receipt
        {
            Id = receiptDao.Id,
            Code = receiptDao.Code,
            ReceiptLines = receiptDao.ReceiptLines.Select(MapReceiptLineDaoToReceiptLine).ToList()
        };
    }

    internal ReceiptLine MapReceiptLineDaoToReceiptLine(ReceiptLineDao lineDao)
    {
        return new ReceiptLine
        {
            Id = lineDao.Id,
            ReceiptId = lineDao.ReceiptId,
            ItemId = lineDao.ItemId,
            LineNumber = lineDao.LineNumber,
            Quantity = new Quantity
            {
                Value = lineDao.Quantity.Value,
                UnitOfMeasure = lineDao.Quantity.UnitOfMeasure
            }
        };
    }

    internal ReceiptDao MapReceiptToReceiptDao(Receipt receipt)
    {
        var receiptDao = new ReceiptDao
        {
            Id = receipt.Id,
            Code = receipt.Code,
            ReceiptLines = receipt.ReceiptLines.Select(MapReceiptLineToReceiptLineDao).ToList()
        };
        return receiptDao;
    }

    internal ReceiptLineDao MapReceiptLineToReceiptLineDao(ReceiptLine receiptLine)
    {
        var receiptLineDao = new ReceiptLineDao
        {
            Id = receiptLine.Id,
            ReceiptId = receiptLine.ReceiptId,
            ItemId = receiptLine.ItemId,
            LineNumber = receiptLine.LineNumber,
            Quantity = new QuantityDao
            {
                Value = receiptLine.Quantity.Value,
                UnitOfMeasure = receiptLine.Quantity.UnitOfMeasure
            }
        };
        return receiptLineDao;
    }

    internal class ReceiptDao : IGuidEntity
    {
        public required Guid Id { get; set; }
        public required string Code { get; set; }
        public List<ReceiptLineDao> ReceiptLines { get; set; } = new List<ReceiptLineDao>();
    }

    internal class ReceiptLineDao : IGuidEntity
    {
        public required Guid Id { get; set; }
        public required Guid ReceiptId { get; set; }
        public required Guid ItemId { get; set; }
        public required int LineNumber { get; set; }
        public required QuantityDao Quantity { get; set; }
    }

    internal class QuantityDao
    {
        public required decimal Value { get; set; }
        public required string UnitOfMeasure { get; set; }
    }
}
