using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMongouille
{
    class InventoryInfo : Inventory
    {

        [BsonElement("rented")]
        public List<Rental> Rented { get; set; }
    }
}
