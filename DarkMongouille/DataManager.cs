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
            catch (Exception e)
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


        public void DisplayFirstCustomer()
        {
            // Display first store
            IMongoCollection<BsonDocument> customer = database.GetCollection<BsonDocument>("customer");
            var document = customer.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(document.ToString());
        }

        #region Standard User Request
        // Quels sont les titres de films dont la classification cinématographique est "..."
        // https://www.thoughtco.com/how-does-a-movie-get-its-rating-2423408
        public void RateRequest(string rate)
        {
            IMongoCollection<BsonDocument> film = database.GetCollection<BsonDocument>("film");
            var filter = Builders<BsonDocument>.Filter.Eq("rating", rate); // filter applied
            int result = 0; // number of results
            try
            {
                var cursor = film.Find(filter).ToCursor();
                // Print all values in data
                foreach (var document in cursor.ToEnumerable()) 
                {
                    Console.WriteLine(document.ToJson());
                    Console.Write("\n");
                    result++;
                }
                Console.WriteLine("Number of results :" + result);
            }
            catch 
            {
                Console.WriteLine("Error in rating format");
            }
        }

        //	Quels sont les titres de films dont le genre est « » 
        //	Quels sont les titres de films dont l'acteur est « » 
        //	Donner la liste de tous les films disponibles.

        // Tous les films
        public void DisplayAllFilms()
        {
            IMongoCollection<BsonDocument> film = database.GetCollection<BsonDocument>("film");
            var cursor = film.Find(new BsonDocument()).ToCursor();
            foreach (var document in cursor.ToEnumerable())
            {
                Console.WriteLine(document.ToJson());
                Console.Write("\n");
            }
        }
        #endregion



    }
}
