namespace Project.Infrastructure.Dapper
{
    public class DapperOptions
    {
        /// <summary>
        /// connection string
        /// </summary>
        public string ConnectionString { set; get; }

        /// <summary>
        /// database type
        /// </summary>
        public DatabaseType DatabaseType { get; set; } = DatabaseType.SqlServer;

    }

    public enum DatabaseType
    {
        SqlServer,
        MySQL,
        SQLite
    }
}