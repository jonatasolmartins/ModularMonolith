namespace ModularMonolith.Shared.Database;

public record RabbitMqSettings(string ConnectionString)
{
    public string ConnectionString { get; set; } = ConnectionString;
    public static string ConfigName = "RabbitMqSettings";
}