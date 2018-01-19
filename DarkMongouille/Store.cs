using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DarkMongouille
{
    public class Store
    {
        [BsonElement("store_id")]
        public int Id { get; set; }

        [BsonElement("manager_staff_id")]
        public int ManagerStaffId { get; set; }

        [BsonElement("last_update")]
        public string LastUpdate { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("district")]
        public string District { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("postal_code")]
        public string PostalCode { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }


    }
}
