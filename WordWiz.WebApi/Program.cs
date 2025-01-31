using Microsoft.EntityFrameworkCore;
using WordWiz.Infrastructure.Data.Context;
using WordWiz.Application.Common;
using WordWiz.Infrastructure;
using WordWiz.WebApi.Hubs;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WordWiz.Application.Common.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "WordWiz API", 
        Version = "v1",
        Description = "A simple API for WordWiz application"
    });
    
    // XML comments için
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Add DbContext
builder.Services.AddDbContext<WordWizDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(WordWizDbContext).Assembly.FullName));
});
builder.Services.AddAutoMapper(typeof(MappingProfile));
// Add SignalR
builder.Services.AddSignalR();

// Add Infrastructure Services
builder.Services.AddInfrastructureServices();

// Add Application Services
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WordWiz API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapHub<NotificationHub>("/notificationHub");

app.MapControllers();

app.Run(); 