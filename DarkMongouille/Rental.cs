using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMongouille
{
    public class Rental
    {
        [BsonElement("rental_id")]
        public int Id { get; set; }

        [BsonElement("rental_date")]
        public string RentalDate { get; set; }

        [BsonElement("inventory_id ")]
        public int InventoryId { get; set; }

        [BsonElement("rental_customer_id ")]
        public int RentalCustomerId { get; set; }

        [BsonElement("return_date")]
        public string ReturnDate { get; set; }

        [BsonElement("rental_staff_id")]
        public int RentalStaffId { get; set; }

        [BsonElement("rental_last_update")]
        public string RentalLastUpdate { get; set; }

        [BsonElement("payment_customer_id")]
        public int PaymentCustomerId { get; set; }

        [BsonElement("payment_staff_id")]
        public int PaymentStaffId { get; set; }

        [BsonElement("amount")]
        public int Amount { get; set; }

        [BsonElement("payment_date")]
        public string PaymentDate { get; set; }

        [BsonElement("payment_last_update")]
        public string PaymentLastUpdate { get; set; }


    }
}
