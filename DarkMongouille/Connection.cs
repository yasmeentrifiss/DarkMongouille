using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMongouille
{
    public class Connection
    {
        private static string databaseName = "sakila";
        private IMongoDatabase database;
        public bool isConnected = false;


        // Initialize connection
        public Connection(string username, string password)
        {
            Console.WriteLine("Connect...");
            try
            {

                MongoClient client = new MongoClient("mongodb://"+username+":"+password+"@127.0.0.1/"+databaseName);

                // get the database
                this.database = client.GetDatabase(databaseName);


                Console.WriteLine("Connected");
                isConnected = true;


            }
            catch (Exception e)
            {
                Console.WriteLine("Connection failed.");
                //Console.WriteLine(e.ToString());
                isConnected = false;
            }

        }



        // Do requests here
        // HERE IS AN EXAMPLE WITH THE STORE TABLE

        public void DisplayFirstStore()
        {
            if (isConnected)
            {
                IMongoCollection<BsonDocument> store = database.GetCollection<BsonDocument>("store");
                var document = store.Find(new BsonDocument()).FirstOrDefault();
                Console.WriteLine(document.ToString());
            }

        }

        public void InsertOneStore(Store newStore)
        {
            if (isConnected)
            {
                IMongoCollection<BsonDocument> store = database.GetCollection<BsonDocument>("store");
                store.InsertOne(newStore.ToBsonDocument());
                Console.WriteLine("Request sent.");
            }
        }

        public void DeleteOneStore(Store newStore)
        {
            if (isConnected)
            {
                IMongoCollection<BsonDocument> store = database.GetCollection<BsonDocument>("store");
                store.DeleteOne(newStore.ToBsonDocument());
                Console.WriteLine("Request sent.");
            }
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
                    Console.WriteLine(document.ToJson(new JsonWriterSettings { Indent = true }));
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

        // Quels sont les informations du film dont le titre est « »
        public void TitleRequest(string title)
        {
            IMongoCollection<BsonDocument> film = database.GetCollection<BsonDocument>("film");
            var filter = Builders<BsonDocument>.Filter.Eq("title", title); // filter applied
            int result = 0; // number of results
            try
            {
                var cursor = film.Find(filter).ToCursor();
                // Print all values in data
                foreach (var document in cursor.ToEnumerable())
                {
                    Console.WriteLine(document.ToJson(new JsonWriterSettings { Indent = true }));
                    Console.Write("\n");
                    result++;
                }
                Console.WriteLine("Number of results :" + result);
            }
            catch
            {
                Console.WriteLine("Error in Title format");
            }
        }

        //	Quels sont les films dont le genre est « » 
        public void CategoryRequest(string category)
        {
            IMongoCollection<BsonDocument> film = database.GetCollection<BsonDocument>("film");
            var filter = Builders<BsonDocument>.Filter.Eq("category.name", category); // filter applied 
            int result = 0; // number of results
            try
            {
                var cursor = film.Find(filter).ToCursor();
                // Print all values in data
                foreach (var document in cursor.ToEnumerable())
                {
                    Console.WriteLine(document.ToJson(new JsonWriterSettings { Indent = true }));
                    Console.Write("\n");
                    result++;
                }
                Console.WriteLine("Number of results :" + result);
            }
            catch
            {
                Console.WriteLine("Error in first name format");
            }
        }


        //	Quels sont les films dont le prénom de l’acteur/actrice est « » 
        public void ActorRequest(string fname)
        {
            IMongoCollection<BsonDocument> film = database.GetCollection<BsonDocument>("film");
            var filter = Builders<BsonDocument>.Filter.Eq("actors.first_name", fname); // filter applied 
            int result = 0; // number of results
            try
            {
                var cursor = film.Find(filter).ToCursor();
                // Print all values in data
                foreach (var document in cursor.ToEnumerable())
                {
                    Console.WriteLine(document.ToJson(new JsonWriterSettings { Indent = true }));
                    Console.Write("\n");
                    result++;
                }
                Console.WriteLine("Number of results :" + result);
            }
            catch
            {
                Console.WriteLine("Error in first name format");
            }
        }


        //	Donner la liste de tous les films.
        public void DisplayAllFilms()
        {
            IMongoCollection<BsonDocument> film = database.GetCollection<BsonDocument>("film");
            var cursor = film.Find(new BsonDocument()).ToCursor();
            foreach (var document in cursor.ToEnumerable())
            {
                Console.WriteLine(document.ToJson(new 
                    JsonWriterSettings { Indent = true }));
                Console.Write("\n");
            }

        }
        #endregion
        
        #region Business User/Analyst
        public void Test()
        {
            var inventory = database.GetCollection<Inventory>("inventory");
            var rental = database.GetCollection<Rental>("rental");

            var query = from p in inventory.AsQueryable()
                        join o in rental.AsQueryable() on p.Id equals o.InventoryId into joinedrequest
                        select new InventoryInfo();
            Console.WriteLine(query.ToJson());
        }
        #endregion
    



    }
}
