using AspNetCoreCsvImportExport.Formatters;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using NLog;
using NLog.Web;
using Personal_Account;
using Personal_Account.Logger;
using Personal_Account.Middleware;
using Personal_Account.Middleware.MiddlewareException;
using Personal_Account.Repository;

var builder = WebApplication.CreateBuilder(args);

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

var csvFormatterOptions = new CsvFormatterOptions();
csvFormatterOptions.CsvDelimiter = ",";

builder.Services.AddResponseCompression(options => 
{
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "text/csv" });
});

builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddControllers(options =>
{
    options.OutputFormatters.Add(new CsvOutputFormatter(csvFormatterOptions));
    options.FormatterMappings.SetMediaTypeMappingForFormat("csv", MediaTypeHeaderValue.Parse("text/csv"));
}).AddNewtonsoftJson();

builder.Services.AddApiVersioning();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSwaggerGen();
string connection = builder.Configuration.GetConnectionString("SIZConnection");
builder.Services.AddDbContext<SIZContext>(options =>
    options.UseNpgsql(connection));

    var app = builder.Build();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger(); 
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    
    app.UseMiddleware<ReaquestSIZLogMiddleware>();
    //app.UseMiddleware<ResponseSIZLogMiddleware>();
    
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.UseAuthorization();

    app.UseCors(options =>
    {
        options.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .Build();
    });

    app.MapControllers();

    app.Run();
