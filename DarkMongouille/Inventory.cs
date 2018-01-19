using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMongouille
{
    public class Inventory
    {
        [BsonElement("inventory_id")]
        public int Id { get; set; }

        [BsonElement("film_id")]
        public int FilmId { get; set; }

        [BsonElement("store_id")]
        public string StoreId { get; set; }

        [BsonElement("last_update")]
        public string LastUpdate { get; set; }

    }
}
