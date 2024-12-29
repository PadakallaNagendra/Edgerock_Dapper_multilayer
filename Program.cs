using EdgeRock_Dapper_BusinessLogic.Interface;
using Edgerock_Dapper_DatabaseLogic.Data;
using EdgeRock_Dapper_EmployeeRepositary;
using EdgeRock_Dapper_EmployeeServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeerepositary, EmployeeRepositary>();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
builder.Services.AddScoped<IConfigurationFactory, ConfigurationFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
oiugfdxz
app.MapControllers();

app.Run();
