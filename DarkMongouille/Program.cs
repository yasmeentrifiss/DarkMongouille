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
            Console.WriteLine(db.ToString());
            IMongoCollection<BsonDocument> staff = db.GetCollection<BsonDocument>("staff");

            var document = staff.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(document.ToString());
            Console.ReadKey();


        }
    }
}
