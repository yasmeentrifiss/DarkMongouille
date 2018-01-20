using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMongouille
{
    public class DataManager
    {
        private static DataManager instance;
        private static string connectionString = "mongodb://127.0.0.1:27017";
        private static string databaseName = "sakila";
        private IMongoDatabase database;


        // Initialize connection
        private DataManager()
        {
            Console.WriteLine("Connect...");
            try
            {
                MongoClient client = new MongoClient(connectionString);
                this.database = client.GetDatabase(databaseName);

                Console.WriteLine("Connected");
            }
            catch(Exception e)
            {
                Console.WriteLine("Connectio failed.");
                Console.WriteLine(e.ToString());
            }
            
        }

        public static DataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataManager();
                }
                return instance;
            }
        }

        // Do requests here
        // HERE IS AN EXAMPLE WITH THE STORE TABLE

        public void DisplayFirstStore()
        {
            IMongoCollection<BsonDocument> store = database.GetCollection<BsonDocument>("store");
            var document = store.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(document.ToString());
        }

        public void InsertOneStore(Store newStore)
        {
            IMongoCollection<BsonDocument> store = database.GetCollection<BsonDocument>("store");
            store.InsertOne(newStore.ToBsonDocument());
            Console.WriteLine("Request sent.");
        }

        public void DeleteOneStore(Store newStore)
        {
            IMongoCollection<BsonDocument> store = database.GetCollection<BsonDocument>("store");
            store.DeleteOne(newStore.ToBsonDocument());
            Console.WriteLine("Request sent.");
        }


    }
}
