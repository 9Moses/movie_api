using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore;
using Movie_API.Data;

var builder = WebApplication.CreateBuilder(args);

//add service to the container
builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("MovieAppDB"));
builder.Services.AddControllers();

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//configure the HTTP request pipeline
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
