using MongoDB.Bson;
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
        private bool isConnected = false;


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


    }
}
