namespace Personal_Account.Services;

public interface IDataAllService
{
    Task<ICollection<DataAll>> ByDocNumberServiceAsync(ByDocNumber byDocNumber);
    Task<ICollection<DataAll>> ByTicketNumberServiceAsync(ByTicketNumber byTicketNumber);
    Task<MemoryStream> ByDocNumberPrintServiceAsync(ByDocNumberPrint byDocNumberPrint);
    Task<MemoryStream> ByTicketNumberPrintServiceAsync(ByTicketNumberPrint byTicketNumberPrint);
    Task<ICollection<AirlineCompany>> ListAirlineCompaniesServiceAsync();
}