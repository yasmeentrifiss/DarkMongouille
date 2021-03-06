﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMongouille
{
    public class Staff
    {

        [BsonElement("staff_id")]
        public int Id { get; set; }

        [BsonElement("first_name")]
        public string FirstName { get; set; }

        [BsonElement("last_name")]
        public string LastName { get; set; }

        [BsonElement("picture")]
        public string Picture { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("store_id")]
        public string StoreId { get; set; }

        [BsonElement("active")]
        public string Active { get; set; }

        [BsonElement("username")]
        public string UserName { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

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
