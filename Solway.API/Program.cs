using Solway.Helpers;
using Solway.Extensions; 
using Solway.Middlewares;
using Solway.DAC;

using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(
        "C:\\Projects\\solway\\Solway.API\\Logs\\log-.log", 
        rollingInterval: RollingInterval.Minute,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose)
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    Log.Information("Starting Web Application");

    // Add SeriLog
    builder.Host.UseSerilog();

    // Add services to the container.
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Add AutoMapper
    builder.Services.AddAutoMapper(typeof(MappingProfilesHelper));

    // Add SolwayDbContext
    builder.Services.AddDbContext<SolwayDbContext>(config =>
    {
        config.UseLazyLoadingProxies();
        config.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
    // Add IdentityDbContext
    builder.Services.AddDbContext<IdentityDbContext>(config =>
    {
        config.UseLazyLoadingProxies();
        config.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    // Add Application Services (Dependency Injection)
    builder.Services.AddApplicationServices();

    // Add Identity configuration
    //builder.Services.AddIdentityService(builder.Configuration);

    // Add Validations Errors
    builder.Services.AddValidationErrorMiddleware();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Add Exception Middleware
    app.UseMiddleware<ExceptionMiddleware>();

    app.UseStatusCodePagesWithReExecute("errors/{0}");

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.UseAuthentication();

    app.UseStaticFiles();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    await Log.CloseAndFlushAsync();
}