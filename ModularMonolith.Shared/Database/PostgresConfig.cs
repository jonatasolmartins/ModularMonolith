namespace ModularMonolith.Shared.Database;

public record PostgresConfig
{
    public string ConnectionString { get; set; }
    public static string SectionName = "connectionString";
    public static string ConfigName = "Postgres";
}