using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMongouille
{
    public class Actor
    {
        [BsonElement("actor_id")]
        public int Id { get; set; }

        [BsonElement("actor_first_name ")]
        public string FirstName { get; set; }

        [BsonElement("actor_last_name ")]
        public string LastName { get; set; }

        [BsonElement("actor_last_update")]
        public string Email { get; set; }

        
    }
}
