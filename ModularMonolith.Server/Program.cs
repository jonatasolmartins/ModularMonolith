using ModularMonolith.Modules.Users.Api;
using Wolverine;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Host.UseWolverine(opts =>
{
    opts.UseRabbitMq(new Uri("amqps://"));
    
    opts.PublishAllMessages().ToRabbitQueue("owner");
});

builder.Services.AddUsersModule();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseUsersModule(app.MapGroup);

app.Run();