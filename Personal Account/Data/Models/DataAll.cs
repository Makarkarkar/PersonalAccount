using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Personal_Account
{
    public partial class DataAll
    {
        public long? OperationId { get; set; }
        public string? Type { get; set; }
        public DateTime? Time { get; set; }
        public string? Place { get; set; }
        public string? Sender { get; set; }

        public DateTime? TransactionTime { get; set; }

        public string? ValidationStatus { get; set; }
     
        public short? OperationTimeTimezone { get; set; }
      
        public long? PassengerId { get; set; }
        
        public string? Surname { get; set; }
        
        public string? Name { get; set; }
        
        public string? Patronymic { get; set; }
    
        public string? Birthdate { get; set; }
        
        public decimal? GenderId { get; set; }
       
        public long? PassengerDocumentId { get; set; }
        
        public string? PassengerDocumentType { get; set; }
        
        public string? PassengerDocumentNumber { get; set; }
       
        public string? PassengerDocumentDisabledNumber { get; set; }
        public string? PassengerDocumentLargeNumber { get; set; }
        public decimal? PassengerTypeId { get; set; }
        public string? PassengerTypeName { get; set; }
        public string? PassengerTypeType { get; set; }
        public string? RaCategory { get; set; }
        public string? Description { get; set; }
        public bool? IsQuota { get; set; }
        public long? TicketId { get; set; }
        public string? TicketNumber { get; set; }
        public decimal? TicketType { get; set; }
        public long? AirlineRouteId { get; set; }
        public string? AirlineCode { get; set; }
        public string? DepartPlace { get; set; }
        public DateTime? DepartDatetime { get; set; }
        public string? ArrivePlace { get; set; }
        public DateTime? ArriveDatetime { get; set; }
        public string? PnrId { get; set; }
        public string? OperatingAirlineCode { get; set; }
        public short? DepartDatetimeTimezone { get; set; }
        public short? ArriveDatetimeTimezone { get; set; }
        public string? CityFromCode { get; set; }
        public string? CityFromName { get; set; }
        public string? AirportFromIcaoCode { get; set; }
        public string? AirportFromRfCode { get; set; }
        public string? AirportFromName { get; set; }
        public string? CityToCode { get; set; }
        public string? CityToName { get; set; }
        public string? AirportToIcaoCode { get; set; }
        public string? AirportToRfCode { get; set; }
        public string? AirportToName { get; set; }
        public string? FlightNums { get; set; }
        public string? FareCode { get; set; }
        public int? FarePrice { get; set; }
    }
}
