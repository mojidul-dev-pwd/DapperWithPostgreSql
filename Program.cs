using Dapper;
using DapperWithPostgreSql.Repositories;
using DapperWithPostgreSql.Services;
using Microsoft.OpenApi.Models;
DefaultTypeMap.MatchNamesWithUnderscores = true;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISarkarRepository, SarkarRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc(
    "v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Swagger API",
        Description = "A simple api test appliction.",
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger(x =>
{
    x.SerializeAsV2 = true;
});

app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
});

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();