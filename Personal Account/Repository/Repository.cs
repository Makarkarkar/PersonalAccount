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

    public Repository(SIZContext context)
    {
        _context = context;
    }

    public async Task<ICollection<DataAll>> ByDocNumberAsync(ByDocNumber byDocNumber)
    {
        StreamReader sr = new StreamReader("SqlRows\\ByDocNumberSql.txt");
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
            StreamReader srByTicketNumberAll = new StreamReader("SqlRows\\ByTicketNumberAllTicketSql.txt");
            string? lineByTicketNumberAll = await srByTicketNumberAll.ReadToEndAsync();
            sqlRow = string.Format(lineByTicketNumberAll,byTicketNumber.TicketNumber) ;
        }
        else
        {
           StreamReader srByTicketNumberSelected = new StreamReader("SqlRows\\ByTicketNumberSelectedTicketSql.txt");
            string? lineByTicketNumberSelected = await srByTicketNumberSelected.ReadToEndAsync();
            sqlRow = string.Format(lineByTicketNumberSelected, byTicketNumber.TicketNumber) ; 
        }

        
        var PassengerTickets = await _context.DataAlls.FromSqlRaw(sqlRow).ToListAsync();
        return PassengerTickets;
    }

    public async Task<ICollection<DataAll>> ByDocNumberPrintAsync(ByDocNumberPrint byDocNumberPrint)
    {
        StreamReader sr = new StreamReader("SqlRows\\ByDocNumberPrintSql.txt");
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
            StreamReader srByTicketNumberAll = new StreamReader("SqlRows\\ByTicketNumberPrintAllTicketSql.txt");
            string? lineByTicketNumberAll = await srByTicketNumberAll.ReadToEndAsync();
            sqlRow = string.Format(lineByTicketNumberAll,byTicketNumberPrint.AirlineCompanyIataCode, byTicketNumberPrint.TicketNumber) ;
            
        }
        else
        {
            StreamReader srByTicketNumberSelected = new StreamReader("SqlRows\\ByTicketNumberPrintSelectedTicketSql.txt");
            string? lineByTicketNumberSelected = await srByTicketNumberSelected.ReadToEndAsync();
            sqlRow = string.Format(lineByTicketNumberSelected,byTicketNumberPrint.AirlineCompanyIataCode, byTicketNumberPrint.TicketNumber) ;
        }
         
        var PassengerTickets = await _context.DataAlls.FromSqlRaw(sqlRow).ToListAsync();
        return PassengerTickets;
    }
}