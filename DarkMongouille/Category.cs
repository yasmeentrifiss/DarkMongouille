using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMongouille
{
    public class Category
    {

        [BsonElement("category_id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("last_update")]
        public string LastUpdate { get; set; }

        [BsonElement("film_id")]
        public int FilmId { get; set; }



  
    }
}
