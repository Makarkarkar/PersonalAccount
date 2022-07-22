using OfficeOpenXml;
using Personal_Account.Middleware.MiddlewareException;
using Personal_Account.Repository;

namespace Personal_Account.Services;

public class DataAllService: IDataAllService
{
    private readonly IRepository _repository;
    private readonly IConfiguration _configuration;
    
    public DataAllService( IRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }
    
    public async Task<ICollection<DataAll>> ByDocNumberServiceAsync(ByDocNumber byDocNumber)
    {
        var transaction = _repository.ByDocNumberAsync(byDocNumber);
        if (await Task.WhenAny(transaction, Task.Delay(60000)) == transaction)
        {
            return await transaction;
        }
        throw new LockTimeOutException("Too long request");
    }

    public async Task<ICollection<DataAll>> ByTicketNumberServiceAsync(ByTicketNumber byTicketNumber)
    {
        var transaction =  _repository.ByTicketNumberAsync(byTicketNumber);
        if (await Task.WhenAny(transaction, Task.Delay(60000)) == transaction)
        {
            return await transaction;
        }
        throw new LockTimeOutException("Too long request");
    }

    public async Task<MemoryStream> ByDocNumberPrintServiceAsync(ByDocNumberPrint byDocNumberPrint)
    {
        var transaction =  _repository.ByDocNumberPrintAsync(byDocNumberPrint);
        if (await Task.WhenAny(transaction, Task.Delay(60000)) == transaction)
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Report1");
            StreamReader russianColumnNames = new StreamReader(_configuration["RussianNamingRoute"]);
            string russianColumnNamesLine = await russianColumnNames.ReadToEndAsync();
            workSheet.Cells[1, 1].LoadFromArrays(new[] { russianColumnNamesLine.Split(", ").ToArray() });
            workSheet.Cells[2, 1].LoadFromCollection(await  transaction, false);
            
            var memoryStream = new MemoryStream();
            await excel.SaveAsAsync(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }
        throw new LockTimeOutException("Too long request");
    }

    public async Task<MemoryStream> ByTicketNumberPrintServiceAsync(ByTicketNumberPrint byTicketNumberPrint)
    {
        var transaction =  _repository.ByTicketNumberPrintAsync(byTicketNumberPrint);
        if (await Task.WhenAny(transaction, Task.Delay(60000)) == transaction)
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Report1");
            StreamReader russianColumnNames = new StreamReader(_configuration["RussianNamingRoute"]);
            string russianColumnNamesLine = await russianColumnNames.ReadToEndAsync();
            workSheet.Cells[1, 1].LoadFromArrays(new[] { russianColumnNamesLine.Split(", ").ToArray() });
            workSheet.Cells[2, 1].LoadFromCollection(await  transaction, false);
            var memoryStream = new MemoryStream();
            await excel.SaveAsAsync(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }
        throw new LockTimeOutException("Too long request");
    }

    public async Task<ICollection<AirlineCompany>> ListAirlineCompaniesServiceAsync()
    {
        var transaction = _repository.ListAirlineCompaniesAsync();
        if (await Task.WhenAny(transaction, Task.Delay(60000)) == transaction)
        {
            return await transaction;
        }
        throw new LockTimeOutException("Too long request");
    }
}