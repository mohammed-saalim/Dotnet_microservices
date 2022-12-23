using PlatformService.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(opt =>                                        //we set options to what type of DB we like to use //using in-memory db 
 opt.UseInMemoryDatabase("DbName_Something"));  

builder.Services.AddScoped<IPlatformRepo,PlatformRepo>();     
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());         //Auto Mapper                               
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

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app);

app.Run();
