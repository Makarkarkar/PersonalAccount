using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Personal_Account.Middleware.MiddlewareException;
using Personal_Account.Repository;

namespace Personal_Account.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]/")]
[ApiVersion("1.0")]
[RequestSizeLimit(2048)]
public class TransactionController: ControllerBase
{
    private readonly IRepository _repository;
    public TransactionController( IRepository repository)
    {
        _repository = repository;
    }
    [HttpPost("by_doc_number")]
    public async Task<ActionResult> ByDocNumber(ByDocNumber byDocNumber)
    {
        
        var transaction =  _repository.ByDocNumberAsync(byDocNumber);
        if (await Task.WhenAny(transaction, Task.Delay(60000)) == transaction)
        {
            return Ok(await transaction);
        }
        throw new LockTimeOutException("Too long request");
        
    }
        
    [HttpPost("by_ticket_number")]
    public async Task<ActionResult> ByTicketNumber(ByTicketNumber byTicketNumber)
    {
        var transaction =  _repository.ByTicketNumberAsync(byTicketNumber);
        if (await Task.WhenAny(transaction, Task.Delay(60000)) == transaction)
        {
            return Ok(await transaction);
        }
        throw new LockTimeOutException("Too long request");
        
    }
    
    [HttpPost("by_doc_number_print")]
    public async Task<ActionResult> ByDocNumberPrint(ByDocNumberPrint byDocNumberPrint)
    {
        var transaction =  _repository.ByDocNumberPrintAsync(byDocNumberPrint);
        if (await Task.WhenAny(transaction, Task.Delay(60000)) == transaction)
        {
            var cd = new ContentDisposition()
            {
                FileName = $"{byDocNumberPrint.AirlineCompanyIataCode}airlineReport.csv",
                Inline = false
            };
            Response.Headers.Add("Content-Disposition",cd.ToString());
            Response.Headers.Add("Content-Type","text/csv");
            return Ok(await transaction);
        }
        throw new LockTimeOutException("Too long request");
        
    }
    
    [HttpPost("by_ticket_number_print")]
    public async Task<ActionResult> ByTicketNumberPrint(ByTicketNumberPrint byTicketNumberPrint)
    {
        var transaction =  _repository.ByTicketNumberPrintAsync(byTicketNumberPrint);
        if (await Task.WhenAny(transaction, Task.Delay(60000)) == transaction)
        {
            var cd = new ContentDisposition()
            {
                FileName = $"{byTicketNumberPrint.AirlineCompanyIataCode}airlineReport_.csv",
                Inline = false
            };
            Response.Headers.Add("Content-Disposition",cd.ToString());
            Response.Headers.Add("Content-Type","text/csv");
            return Ok(await transaction);
        }
        throw new LockTimeOutException("Too long request");
        
    }
}