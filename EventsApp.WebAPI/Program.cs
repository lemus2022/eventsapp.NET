using EventApp.Services;
using EventsApp.AccessData;
using EventsApp.AccessData.Repositories;
using EventsApp.Common.Contracts.Repositories;
using EventsApp.Common.Contracts.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEventService, EventService>();
builder.Services.AddSingleton<IEventRepository, EventRepository>();
// Add more depedencies here

builder.Services.AddDbContext<EventsAppContext>(options => options.UseInMemoryDatabase("EventsDB"), ServiceLifetime.Singleton);

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

app.Run();
