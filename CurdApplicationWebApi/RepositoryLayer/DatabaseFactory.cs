namespace CurdApplicationWebApi.RepositoryLayer
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SqlAdapter> _logger;
        private readonly ILogger<ElasticSearchAdapter> _esLogger;
        public DatabaseFactory(IConfiguration configuration, ILogger<SqlAdapter> logger, ILogger<ElasticSearchAdapter> esLogger)
        {
            _configuration = configuration;
            _logger = logger;
            _esLogger = esLogger;

        }
        public IDatabaseAdapter GetDatabase()
        {
            string databaseName = _configuration.GetValue<string>("DatabaseName");
            
            switch(databaseName)
            {
                case "sql":
                    return new SqlAdapter(_configuration, _logger);
                    break;
                case "elastic-search":
                    return new ElasticSearchAdapter(_configuration, _esLogger);
                    break;
                default:
                    return new SqlAdapter(_configuration, _logger);
            }
        }
    }
}
