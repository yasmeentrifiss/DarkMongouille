using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;

namespace DarkMongouille
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connect...");

            String uri = "mongodb://127.0.0.1:27017";

            MongoClient client = new MongoClient(uri);
            IMongoDatabase db = client.GetDatabase("sakila");

            Console.WriteLine("Connected");

            // Display first store
            IMongoCollection<BsonDocument> store = db.GetCollection<BsonDocument>("store");
            var document = store.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(document.ToString());

            // Create a store

            var newStore = new Store
            {
                Id = 3,
                ManagerStaffId = 3,
                LastUpdate="03/03/1999",
                Address="NA",
                District="",
                City="",
                PostalCode="",
                Country="",
                Phone=""
            };


            //store.InsertOne(newStore.ToBsonDocument());
            //store.DeleteOne(newStore.ToBsonDocument());

            Console.WriteLine("Request sent.");     

            Console.ReadKey();


        }
    }
}
