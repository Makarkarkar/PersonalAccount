namespace Personal_Account.Repository;

public interface IRepository
{
    Task<ICollection<DataAll>> ByDocNumberAsync(ByDocNumber byDocNumber);
    Task<ICollection<DataAll>> ByTicketNumberAsync(ByTicketNumber byTicketNumber);
    Task<ICollection<DataAll>> ByDocNumberPrintAsync(ByDocNumberPrint byDocNumberPrint);
    Task<ICollection<DataAll>> ByTicketNumberPrintAsync(ByTicketNumberPrint byTicketNumberPrint);
    Task<ICollection<AirlineCompany>> ListAirlineCompaniesAsync();
}