using ModularMonolith.Modules.Users.Api;
using ModularMonolith.Shared;
using ModularMonolith.Shared.Database;
using Wolverine;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddErrorHandling();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.Configure<PostgresConfig>(builder.Configuration.GetSection(PostgresConfig.ConfigName));

builder.Host.UseWolverine(opts =>
{
    var rabbitMqSettings = builder.Configuration.GetSection(RabbitMqSettings.ConfigName).Get<RabbitMqSettings>();
    
    opts.UseRabbitMq(new Uri(rabbitMqSettings.ConnectionString));
    opts.PublishAllMessages().ToRabbitQueue("owner");
});

builder.Services.AddUsersModule();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandling();

app.UseHttpsRedirection();

app.UseRouting();

app.UseUsersModule(app.MapGroup);

app.Run();