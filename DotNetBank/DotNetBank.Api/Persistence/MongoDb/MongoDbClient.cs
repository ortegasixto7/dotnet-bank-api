using MongoDB.Driver;

namespace DotNetBank.Api.Persistence.MongoDb
{
    public class MongoDbClient
    {
        private static MongoClient? mongoClient;

        private MongoDbClient() { }

        public static IMongoDatabase GetInstance()
        {
            var databaseConnectionUrl = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_URL");
            var databaseName = Environment.GetEnvironmentVariable("DATABASE_NAME");
            if (mongoClient == null)
            {
                if (string.IsNullOrEmpty(databaseConnectionUrl)) throw new Exception("CustomDatabaseError => No Database Connection Url set");
                mongoClient = new MongoClient(databaseConnectionUrl);
            }
            if (string.IsNullOrEmpty(databaseName)) throw new Exception("CustomDatabaseError => No Database Name set");
            return mongoClient.GetDatabase(databaseName);
        }
    }
}
