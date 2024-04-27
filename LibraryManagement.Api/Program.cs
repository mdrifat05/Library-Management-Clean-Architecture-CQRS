using LibraryManagement.Api.Middleware;
using LibraryManagement.Application;
using LibraryManagement.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
        .AddHttpContextAccessor()
        .ConfigureApplicationServices()
        .ConfigureInfrastructureService(builder.Configuration);

//Serilog configuration
builder.Host.UseSerilog((HostBuilderContext context,
    IServiceProvider services,
    LoggerConfiguration loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services);
});

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();
