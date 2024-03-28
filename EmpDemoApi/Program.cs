using API.Data;
using API.Testing;
using EmpDemoApi;
using Shared.Global;
using Shared.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDataAccess, MockDataAccess>(); //Mocking data service for now
builder.Services.AddTransient<IEmployeeFactory, MockEmployeeFactory>(); //Mocking employee for now
builder.Services.AddTransient<Defaults>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureAPI();

app.Run();

