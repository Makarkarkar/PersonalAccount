using System.Data.Common;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Personal_Account.Middleware.MiddlewareException;
using CsvHelper;

namespace Personal_Account.Repository;

public class Repository : IRepository

{
    private SIZContext _context;
    private readonly IConfiguration _configuration;

    public Repository(SIZContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<ICollection<DataAll>> ByDocNumberAsync(ByDocNumber byDocNumber)
    {
        var sqlRoute = _configuration["SqlRows:ByDocNumberSqlRoute"];
        StreamReader sr = new StreamReader(sqlRoute);
        string? line = await sr.ReadToEndAsync();
        string? parameterizedSqlRow = string.Format(line,byDocNumber.DocNumber) ;
        var dataCollection = await _context.DataAlls.FromSqlRaw(parameterizedSqlRow).ToListAsync();
        return dataCollection;
    }

    public async Task<ICollection<DataAll>> ByTicketNumberAsync(ByTicketNumber byTicketNumber)
    {
        if (!Regex.Match(byTicketNumber.TicketNumber, "[a-zA-Z0-9]{13}").Success)
        {
            throw new TicketNumberValidateException(
                "Номер билета должен содержать 13 символов: цифры и латинские буквы");
        }
        
        string sqlRow = "";
        if (byTicketNumber.ByTicketNumberCheckBox)
        {
            var sqlRoute = _configuration["SqlRows:ByTicketNumberAllTicketSqlRoute"];
            StreamReader srByTicketNumberAll = new StreamReader(sqlRoute);
            string? lineByTicketNumberAll = await srByTicketNumberAll.ReadToEndAsync();
            sqlRow = string.Format(lineByTicketNumberAll,byTicketNumber.TicketNumber) ;
        }
        else
        {
            var sqlRoute = _configuration["SqlRows:ByTicketNumberSelectedTicketSqlRoute"];
            StreamReader srByTicketNumberSelected = new StreamReader(sqlRoute);
            string? lineByTicketNumberSelected = await srByTicketNumberSelected.ReadToEndAsync();
            sqlRow = string.Format(lineByTicketNumberSelected, byTicketNumber.TicketNumber) ; 
        }

        
        var passengerTickets = await _context.DataAlls.FromSqlRaw(sqlRow).ToListAsync();
        return passengerTickets;
    }

    public async Task<ICollection<DataAll>> ByDocNumberPrintAsync(ByDocNumberPrint byDocNumberPrint)
    {
        var sqlRoute = _configuration["SqlRows:ByDocNumberPrintSqlRoute"];
        StreamReader sr = new StreamReader(sqlRoute);
        string? line = await sr.ReadToEndAsync();
        string? parameterizedSqlRow = string.Format(line,byDocNumberPrint.AirlineCompanyIataCode, byDocNumberPrint.DocNumber) ;
        var dataCollection = await _context.DataAlls.FromSqlRaw(parameterizedSqlRow).ToListAsync();
        return dataCollection;
        
    }
    public async Task<ICollection<DataAll>> ByTicketNumberPrintAsync(ByTicketNumberPrint byTicketNumberPrint)
    {
        if (!Regex.Match(byTicketNumberPrint.TicketNumber, "[a-zA-Z0-9]{13}").Success)
        {
            throw new TicketNumberValidateException(
                "Номер билета должен содержать 13 символов: цифры и латинские буквы");
        }

        string sqlRow = "";
        if (byTicketNumberPrint.ByTicketNumberCheckBox)
        {
            var sqlRoute = _configuration["SqlRows:ByTicketNumberPrintAllTicketSqlRoute"];
            StreamReader srByTicketNumberAll = new StreamReader(sqlRoute);
            string? lineByTicketNumberAll = await srByTicketNumberAll.ReadToEndAsync();
            sqlRow = string.Format(lineByTicketNumberAll,byTicketNumberPrint.AirlineCompanyIataCode, byTicketNumberPrint.TicketNumber) ;
            
        }
        else
        {
            var sqlRoute = _configuration["SqlRows:ByTicketNumberPrintSelectedTicketSqlRoute"];
            StreamReader srByTicketNumberSelected = new StreamReader(sqlRoute);
            string? lineByTicketNumberSelected = await srByTicketNumberSelected.ReadToEndAsync();
            sqlRow = string.Format(lineByTicketNumberSelected,byTicketNumberPrint.AirlineCompanyIataCode, byTicketNumberPrint.TicketNumber) ;
        }
         
        var passengerTickets = await _context.DataAlls.FromSqlRaw(sqlRow).ToListAsync();
        return passengerTickets;
    }

    public async Task<ICollection<AirlineCompany>> ListAirlineCompaniesAsync()
    {
        var sqlRoute = _configuration["SqlRows:ListAirlineCompaniesSqlRoute"];
        string sqlRow = await new StreamReader(sqlRoute).ReadToEndAsync();
        var listAirlineCompanies = await _context.AirlineCompanies.FromSqlRaw(sqlRow).ToListAsync();
        return listAirlineCompanies;
    }
}