using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.Collections;
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

        #region Store Example
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

        #endregion



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
                Console.WriteLine(document.ToJson(new JsonWriterSettings { Indent = true }));
                Console.Write("\n");
            }

        }
        #endregion



        #region Business User/Analyst
        // 	Afficher, pour un id de film donné, chaque inventaire pour ce film et la liste des locations
        public void InventoryRequestById(string filmId)
        {
            IMongoCollection<BsonDocument> inventory = database.GetCollection<BsonDocument>("inventory");
            var rental = database.GetCollection<Rental>("rental");
            try
            {
                int id = Convert.ToInt32(filmId);
                var match = new BsonDocument
                {
                { "film_id", id}
                };

                var aggregate = inventory.Aggregate().Match(match).Lookup("rental", "inventory_id", "inventory_id", "rented");
                var res = aggregate.ToListAsync().Result;

                int count = 0;
                foreach (var doc in res)
                {
                    try
                    {
                        count++;
                        Console.WriteLine(doc.ToJson(new JsonWriterSettings { Indent = true }));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ex :" + ex);
                    }
                }
                Console.WriteLine("Number of results :"+count);
            }
            catch
            {
                Console.WriteLine("Error in entry format");
            }

        }
        // Affiche la liste des locations dans chaque inventaire
        public void InventoryRequest()
        {
            IMongoCollection<BsonDocument> inventory = database.GetCollection<BsonDocument>("inventory");
            var rental = database.GetCollection<Rental>("rental");

            var match = new BsonDocument
                {
                { "film_id", 1}
                };

            var aggregate = inventory.Aggregate().Lookup("rental", "inventory_id", "inventory_id", "rented"); ;
            var res = aggregate.ToListAsync().Result;

            int count = 0;
            foreach (var doc in res)
            {
                try
                {
                    count++;
                    Console.WriteLine(doc.ToJson(new JsonWriterSettings { Indent = true }));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ex :"+ ex);
                }
            }
            Console.WriteLine("Number of results :" + count);

        }

        public void CategoryRatingRequest()
        {
            var map = "function() {" +
                            "categories={};" +
                            "for(var i=0; i<this.category.length; i++){" +
                                "categories[this.category[i].name]={'name':this.category[i].name,'avg':this.rental_rate,'sum':this.rental_rate, 'nb':1};" +
                            "}" +
                            "for(k in categories){" +
                                "emit(null, categories[k]);" +
                            "}" +
                            "}";

            var reduce = "function(key, values) {"+
                                "tab = {}; sum=0; avg=0; nb=0;"+
                                "for(i=0;i<values.length;i++){"+
                                   " name=values[i].name;"+
                                   " if(tab[name]){" +
                                       " update = {'name':name,'avg':tab[name].avg+values[i].avg,'sum':tab[name].sum+values[i].sum, 'nb':tab[name].nb+values[i].nb};" +
                                        "tab[name] = update;" +
                                    "}" +
                                    "else{" +
                                        "tab[name]={'name':name,'avg':values[i].avg,'sum':values[i].sum, 'nb':values[i].nb };" +
                                    "} " +
                               " }" +
                                "for(k in tab){" +
                                      "update = {'name':tab[k].name,'avg':tab[k].sum/tab[k].nb,'sum':tab[k].sum, 'nb':tab[k].nb};" +
                                    "tab[k] = update; }" +
                                "return {'categories':tab };"+
                                "};";
            
            IMongoCollection<BsonDocument> film = database.GetCollection<BsonDocument>("film");

            var results = film.MapReduce<BsonDocument>(map, reduce);

            var res = results.ToListAsync().Result;
            int count = 0;
            foreach (var doc in res)
            {
                try
                {
                    count++;
                    Console.WriteLine(doc.ToJson(new JsonWriterSettings { Indent = true }));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ex :" + ex);
                }
            }
        }
        #endregion



        #region Admin
        public void ServerStatus()
        {
            var serverStatus = new BsonDocument
                {
                    { "serverStatus", "1" },
                };


            Console.WriteLine(database.RunCommand<BsonDocument>(serverStatus).ToJson(new JsonWriterSettings { Indent = true }));
        }
        #endregion

    }
}
