using Microsoft.AspNetCore.Mvc;
using Personal_Account.Services;

namespace Personal_Account.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]/")]
[ApiVersion("1.0")]
[RequestSizeLimit(2048)]
public class TransactionController: ControllerBase
{
    private readonly IDataAllService _service;
    public TransactionController(IDataAllService service)
    {
        _service = service;
    }
    [HttpPost("by_doc_number")]
    public async Task<ActionResult> ByDocNumber(ByDocNumber byDocNumber)
    {
        return Ok(await _service.ByDocNumberServiceAsync(byDocNumber));
    }
        
    [HttpPost("by_ticket_number")]
    public async Task<ActionResult> ByTicketNumber(ByTicketNumber byTicketNumber)
    {
        return Ok(await _service.ByTicketNumberServiceAsync(byTicketNumber));
    }
    
    [HttpPost("by_doc_number_print")]
    public async Task<ActionResult> ByDocNumberPrint(ByDocNumberPrint byDocNumberPrint)
    {
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.Headers.Add("content-disposition", $"attachment;  filename={byDocNumberPrint.AirlineCompanyIataCode}airlineReport.xlsx");
        return Ok(await _service.ByDocNumberPrintServiceAsync(byDocNumberPrint));
    }
    
    [HttpPost("by_ticket_number_print")]
    public async Task<ActionResult> ByTicketNumberPrint(ByTicketNumberPrint byTicketNumberPrint)
    {
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.Headers.Add("content-disposition", $"attachment;  filename={byTicketNumberPrint.AirlineCompanyIataCode}airlineReport.xlsx");
        return Ok(await _service.ByTicketNumberPrintServiceAsync(byTicketNumberPrint));
    }
    [HttpPost("list_airline_companies")]
    public async Task<ActionResult> ListAirlineCompanies()
    {
        return Ok(await _service.ListAirlineCompaniesServiceAsync());
    }
}