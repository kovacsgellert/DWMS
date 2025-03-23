using DWMS.Inbound.Sdk.Contracts.Api.Commands;
using DWMS.Inbound.Sdk.Contracts.Api.Dto;
using DWMS.Inbound.Sdk.Contracts.Api.Queries;
using DWMS.ServiceDefaults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DWMS.Inbound.Api.Controllers;

public class ReceiptsController : DwmsControllerBase
{
    private readonly ILogger<ReceiptsController> _logger;
    private readonly IMongoClient _mongoClient;
    private readonly IMediator _mediator;
    private static readonly List<ReceiptDto> Receipts = [];

    public ReceiptsController(
        ILogger<ReceiptsController> logger,
        IMongoClient mongoClient,
        IMediator mediator
    )
    {
        _logger = logger;
        _mongoClient = mongoClient;
        _mediator = mediator;
    }

    // GET: api/receipts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReceiptDto>>> Get()
    {
        _mongoClient
            .GetDatabase("dwms-inbound-db")
            .GetCollection<ReceiptDto>("receipts")
            .InsertOne(
                new ReceiptDto
                {
                    Id = Guid.NewGuid(),
                    Code = "R001",
                    TripId = Guid.NewGuid(),
                }
            );
        var receipts = await _mongoClient
            .GetDatabase("dwms-inbound-db")
            .GetCollection<ReceiptDto>("receipts")
            .AsQueryable()
            .ToListAsync();
        return Ok(Receipts);
    }

    // GET: api/receipts/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ReceiptDto>> Get(Guid id)
    {
        var response = await _mediator.Send(new GetReceiptByIdQuery { ReceiptId = id });

        if (response.Receipt == null)
        {
            return NotFound();
        }

        return Ok(response.Receipt);
    }

    // POST: api/receipts
    [HttpPost]
    public ActionResult<ReceiptDto> Post([FromBody] ReceiptDto receipt)
    {
        receipt.Id = Guid.NewGuid();
        Receipts.Add(receipt);
        return CreatedAtAction(nameof(Get), new { id = receipt.Id }, receipt);
    }

    // PUT: api/receipts/{id}
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] ReceiptDto receipt)
    {
        var existingReceipt = Receipts.FirstOrDefault(r => r.Id == id);
        if (existingReceipt == null)
        {
            return NotFound();
        }

        existingReceipt.Code = receipt.Code;
        existingReceipt.TripId = receipt.TripId;

        return NoContent();
    }

    // DELETE: api/receipts/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteReceiptCommand { ReceiptId = id });

        return NoContent();
    }
}
