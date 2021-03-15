using MongoDB.Driver;

namespace OgrenciKayitSistemi.Services
{
    public class DBContext
    {
        protected readonly IMongoDatabase _database;
        public DBContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            if (client != null)
            {
                _database = client.GetDatabase("StudentRegSystDB");
            }
        }

        public IMongoDatabase Database => _database;

    }
}
