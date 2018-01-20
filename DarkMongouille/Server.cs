using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMongouille
{
    public class Server
    {
        private static string connectionString = "mongodb://127.0.0.1";
        private static string databaseName = "sakila";
        private IMongoDatabase database;


        // Initialize connection
        public Server()
        {
            Console.WriteLine("Initialize DB...");
            try
            {

                MongoClient client = new MongoClient(connectionString);

                // get the database
                this.database = client.GetDatabase(databaseName);

                // init users 
                initUsers();

                Console.WriteLine("Initialization done \n\n");


            }
            catch (Exception e)
            {
                Console.WriteLine("Initialization failed. \n\n");
                //Console.WriteLine(e.ToString());
            }

        }

        // Initialize users
        private void initUsers()
        {
            // construct the usersInfo command and run the command
            var command = new BsonDocument("usersInfo", 1);
            var result = database.RunCommand<BsonDocument>(command);

           /* Console.WriteLine();
            Console.WriteLine("Display all users :");
            Console.WriteLine(command);
            Console.WriteLine(result);
            Console.WriteLine();*/

            // if there is no user --> create standard, business and admin
            if (result.GetElement("users").Value.AsBsonArray.Count == 0)
            {

                // Construct the createUser commands

                var createStandard = new BsonDocument
                {
                    { "createUser", "standard" },
                    { "pwd", "1234" },
                    { "roles", new BsonArray{
                        "read"
                    } },
                };

                var createBusiness = new BsonDocument
                {
                    { "createUser", "business" },
                    { "pwd", "business" },
                    { "roles", new BsonArray{
                        "readWrite"
                    } },
                };

                var createAdmin = new BsonDocument
                {
                    { "createUser", "admin" },
                    { "pwd", "admin" },
                    { "roles", new BsonArray{
                        "dbAdmin", "readWrite"//,"clusterAdmin"
                    } },
                };

                // Run commands 

                database.RunCommand<BsonDocument>(createStandard);
                database.RunCommand<BsonDocument>(createBusiness);
                database.RunCommand<BsonDocument>(createAdmin);


            }

        }
    }
}
