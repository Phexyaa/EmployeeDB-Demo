using API.Data;
using EmpDemoApi;
using Shared.Global;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDataAccess, DataAccess>();
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

