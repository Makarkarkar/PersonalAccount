using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Personal_Account
{
    public partial class SIZContext : DbContext
    {
        public SIZContext()
        {
        }

        public SIZContext(DbContextOptions<SIZContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirlineCompany> AirlineCompanies { get; set; } = null!;
        public virtual DbSet<DataAll> DataAlls { get; set; } = null!;
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirlineCompany>(entity =>
            {
                entity.ToTable("airline_company");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Country)
                    .HasColumnType("character varying")
                    .HasColumnName("country");

                entity.Property(e => e.IataCode)
                    .HasColumnType("character varying")
                    .HasColumnName("iata_code");

                entity.Property(e => e.IcaoCode)
                    .HasColumnType("character varying")
                    .HasColumnName("icao_code");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.NameEn)
                    .HasColumnType("character varying")
                    .HasColumnName("name_en");

                entity.Property(e => e.RfCode)
                    .HasColumnType("character varying")
                    .HasColumnName("rf_code");
            });

            modelBuilder.Entity<DataAll>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("data_all");

                entity.Property(e => e.AirlineCode)
                    .HasColumnType("character varying")
                    .HasColumnName("airline_code");

                entity.Property(e => e.AirlineRouteId).HasColumnName("airline_route_id");

                entity.Property(e => e.AirportFromIcaoCode)
                    .HasColumnType("character varying")
                    .HasColumnName("airport_from_icao_code");

                entity.Property(e => e.AirportFromName)
                    .HasColumnType("character varying")
                    .HasColumnName("airport_from_name");

                entity.Property(e => e.AirportFromRfCode)
                    .HasColumnType("character varying")
                    .HasColumnName("airport_from_rf_code");

                entity.Property(e => e.AirportToIcaoCode)
                    .HasColumnType("character varying")
                    .HasColumnName("airport_to_icao_code");

                entity.Property(e => e.AirportToName)
                    .HasColumnType("character varying")
                    .HasColumnName("airport_to_name");

                entity.Property(e => e.AirportToRfCode)
                    .HasColumnType("character varying")
                    .HasColumnName("airport_to_rf_code");

                entity.Property(e => e.ArriveDatetime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("arrive_datetime");

                entity.Property(e => e.ArriveDatetimeTimezone).HasColumnName("arrive_datetime_timezone");

                entity.Property(e => e.ArrivePlace)
                    .HasColumnType("character varying")
                    .HasColumnName("arrive_place");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("character varying")
                    .HasColumnName("birthdate");

                entity.Property(e => e.CityFromCode)
                    .HasColumnType("character varying")
                    .HasColumnName("city_from_code");

                entity.Property(e => e.CityFromName)
                    .HasColumnType("character varying")
                    .HasColumnName("city_from_name");

                entity.Property(e => e.CityToCode)
                    .HasColumnType("character varying")
                    .HasColumnName("city_to_code");

                entity.Property(e => e.CityToName)
                    .HasColumnType("character varying")
                    .HasColumnName("city_to_name");

                entity.Property(e => e.DepartDatetime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("depart_datetime");

                entity.Property(e => e.DepartDatetimeTimezone).HasColumnName("depart_datetime_timezone");

                entity.Property(e => e.DepartPlace)
                    .HasColumnType("character varying")
                    .HasColumnName("depart_place");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.FareCode)
                    .HasColumnType("character varying")
                    .HasColumnName("fare_code");

                entity.Property(e => e.FarePrice).HasColumnName("fare_price");

                entity.Property(e => e.FlightNums).HasColumnName("flight_nums");

                entity.Property(e => e.GenderId)
                    .HasPrecision(1)
                    .HasColumnName("gender_id");

                entity.Property(e => e.IsQuota).HasColumnName("is_quota");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.OperatingAirlineCode)
                    .HasColumnType("character varying")
                    .HasColumnName("operating_airline_code");

                entity.Property(e => e.OperationId).HasColumnName("operation_id");

                entity.Property(e => e.OperationTimeTimezone).HasColumnName("operation_time_timezone");

                entity.Property(e => e.PassengerDocumentDisabledNumber)
                    .HasColumnType("character varying")
                    .HasColumnName("passenger_document_disabled_number");

                entity.Property(e => e.PassengerDocumentId).HasColumnName("passenger_document_id");

                entity.Property(e => e.PassengerDocumentLargeNumber)
                    .HasColumnType("character varying")
                    .HasColumnName("passenger_document_large_number");

                entity.Property(e => e.PassengerDocumentNumber)
                    .HasColumnType("character varying")
                    .HasColumnName("passenger_document_number");

                entity.Property(e => e.PassengerDocumentType)
                    .HasColumnType("character varying")
                    .HasColumnName("passenger_document_type");

                entity.Property(e => e.PassengerId).HasColumnName("passenger_id");

                entity.Property(e => e.PassengerTypeId)
                    .HasPrecision(2)
                    .HasColumnName("passenger_type_id");

                entity.Property(e => e.PassengerTypeName)
                    .HasColumnType("character varying")
                    .HasColumnName("passenger_type_name");

                entity.Property(e => e.PassengerTypeType)
                    .HasColumnType("character varying")
                    .HasColumnName("passenger_type_type");

                entity.Property(e => e.Patronymic)
                    .HasColumnType("character varying")
                    .HasColumnName("patronymic");

                entity.Property(e => e.Place)
                    .HasColumnType("character varying")
                    .HasColumnName("place");

                entity.Property(e => e.PnrId)
                    .HasColumnType("character varying")
                    .HasColumnName("pnr_id");

                entity.Property(e => e.RaCategory)
                    .HasColumnType("character varying")
                    .HasColumnName("ra_category");

                entity.Property(e => e.Sender)
                    .HasColumnType("character varying")
                    .HasColumnName("sender");

                entity.Property(e => e.Surname)
                    .HasColumnType("character varying")
                    .HasColumnName("surname");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.TicketNumber)
                    .HasColumnType("character varying")
                    .HasColumnName("ticket_number");

                entity.Property(e => e.TicketType)
                    .HasPrecision(1)
                    .HasColumnName("ticket_type");

                entity.Property(e => e.Time)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("time");

                entity.Property(e => e.TransactionTime).HasColumnName("transaction_time");

                entity.Property(e => e.Type)
                    .HasColumnType("character varying")
                    .HasColumnName("type");

                entity.Property(e => e.ValidationStatus)
                    .HasColumnType("character varying")
                    .HasColumnName("validation_status");
            });

            modelBuilder.HasSequence("airline_company_id_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
