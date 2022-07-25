using AspNetCoreCsvImportExport.Formatters;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using NLog.Web;
using Personal_Account;
using Personal_Account.Middleware;
using Personal_Account.Middleware.MiddlewareException;
using Personal_Account.Repository;
using Personal_Account.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddApiVersioning();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IDataAllService, DataAllService>();
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

    
    //app.UseMiddleware<ReaquestSIZLogMiddleware>();
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
