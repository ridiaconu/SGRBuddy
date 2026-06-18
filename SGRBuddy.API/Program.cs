using SGRBuddy.DataAccess;
using SGRBuddy.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDataAccess(builder.Configuration.GetConnectionString("DefaultConnection")!);
builder.Services.AddBusinessLogic();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.EnableTryItOutByDefault();
    c.RoutePrefix = string.Empty;  // Set Swagger as root path
});

app.MapControllers();

app.Run();
