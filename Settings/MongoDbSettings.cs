// Settings/MongoDbSettings.cs
namespace MyCqrsMongoApi.Settings
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
