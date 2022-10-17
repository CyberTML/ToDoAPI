// Added Using Statement
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


// Added Cors Functionality
builder.Services.AddCors( options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("OriginPolicy", "http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
    });
}); 


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Added Service for Data Connection
builder.Services.AddDbContext<ToDoAPI.Models.ToDoContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoDB"));
    }
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Added Cors Below:
app.UseCors();


app.UseAuthorization();

app.MapControllers();

app.Run();
