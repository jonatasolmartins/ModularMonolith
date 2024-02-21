using ModularMonolith.Modules.Users.Api;
using ModularMonolith.Modules.Wallets.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddUsersModule();
builder.Services.AddWalletsModule();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseUsersModule(app.MapGroup);
app.UseWalletsModule();

app.Run();