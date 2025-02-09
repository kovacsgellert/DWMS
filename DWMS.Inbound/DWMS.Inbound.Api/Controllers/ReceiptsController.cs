using DWMS.Inbound.Sdk.Contracts.Api;
using DWMS.ServiceDefaults;
using Microsoft.AspNetCore.Mvc;

namespace DWMS.Inbound.Api.Controllers;

public class ReceiptsController : DwmsControllerBase
{
    private readonly ILogger<ReceiptsController> _logger;
    private static readonly List<ReceiptDto> Receipts = [];

    public ReceiptsController(ILogger<ReceiptsController> logger)
    {
        _logger = logger;
    }

    // GET: api/receipts
    [HttpGet]
    public ActionResult<IEnumerable<ReceiptDto>> Get()
    {
        return Ok(Receipts);
    }

    // GET: api/receipts/{id}
    [HttpGet("{id}")]
    public ActionResult<ReceiptDto> Get(Guid id)
    {
        var receipt = Receipts.FirstOrDefault(r => r.Id == id);
        if (receipt == null)
        {
            return NotFound();
        }
        return Ok(receipt);
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
    public IActionResult Delete(Guid id)
    {
        var receipt = Receipts.FirstOrDefault(r => r.Id == id);
        if (receipt == null)
        {
            return NotFound();
        }

        Receipts.Remove(receipt);
        return NoContent();
    }
}
