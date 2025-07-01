using InvoiceApp.Application.Features.Invoices.Commands.CreateInvoice;
using InvoiceApp.Application.Features.Invoices.Commands.DeleteInvoice;
using InvoiceApp.Application.Features.Invoices.Commands.UpdateInvoice;
using InvoiceApp.Application.Features.Invoices.Dtos;
using InvoiceApp.Application.Features.Invoices.Queries.GetInvoices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class InvoiceController : ControllerBase
{
    private readonly IMediator _mediator;

    public InvoiceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("InvoiceSave")]
    public async Task<IActionResult> SaveInvoice([FromBody] CreateInvoiceDto dto)
    {
        var invoiceId = await _mediator.Send(new CreateInvoiceCommand(dto));
        return Ok(invoiceId);
    }

    [HttpPut("InvoiceUpdate")]
    public async Task<IActionResult> UpdateInvoice([FromBody] UpdateInvoiceDto dto)
    {
        await _mediator.Send(new UpdateInvoiceCommand(dto));
        return NoContent();
    }

    [HttpDelete("InvoiceDelete/{invoiceId}")]
    public async Task<IActionResult> DeleteInvoice(int invoiceId)
    {
        await _mediator.Send(new DeleteInvoiceCommand(invoiceId));
        return NoContent();
    }

    [HttpGet("InvoiceList")]
    public async Task<IActionResult> GetInvoices([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
    {
        var result = await _mediator.Send(new GetInvoicesQuery(startDate, endDate));
        return Ok(result);
    }
}