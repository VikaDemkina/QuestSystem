using System.Reflection;
using Confluent.Kafka;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuestSystem.Application.DTOs;
using QuestSystem.Application.Services;
using QuestSystem.Domain.Events;
using QuestSystem.Domain.Messages;
using QuestSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QuestDbContext>(options =>
{
    options.UseNpgsql("Host=localhost;Port=5432;Database=QuestSystem;Username=postgres;Password=cde32wsx");
});

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IQuestService, QuestService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var producerConfig = new ProducerConfig
{
    BootstrapServers = $"localhost:9092",
    ClientId = "QuestSystem"
};

builder.Services.AddSingleton(new ProducerBuilder<Null, string>(producerConfig).Build());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("api/addUser", async (UserInputDto userDto, IUserService service) =>
{
    await service.AddUser(userDto);
});

app.MapPost("api/addQuest", async (QuestInputDto questDto, IQuestService service) =>
{
    await service.AddQuest(questDto);
});

app.MapPost("api/addBooking", async (BookingDto bookingDto, IMediator mediator) =>
{
    await mediator.Send(new GeneratorQuestCommand(bookingDto));
});

app.UseHttpsRedirection();

app.Run();

