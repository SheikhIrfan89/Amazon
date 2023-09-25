using API.Helpers;
using API.Middleware;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add database connection as a service
builder.Services.AddDbContext<DataContext> (options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductBrandService, ProductBrandService>();
builder.Services.AddScoped<IProductTypesService, ProductTypeService>();

builder.Services.AddAutoMapper(typeof(MappingProfiles));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.//Middleware

app.UseMiddleware<ExceptionMiddleware>();

///if we get error, redirect to error controller(adding not found endpoint controller)
app.UseStatusCodePagesWithReExecute("/errors/{0}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
 //   app.UseSwaggerDocumentation();
}

//to make the static files run on the programme



app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
