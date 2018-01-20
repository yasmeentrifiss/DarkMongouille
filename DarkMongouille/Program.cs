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

            var store = new Store
            {
                Id = 3,
                ManagerStaffId = 3,
                LastUpdate = "03/03/1999",
                Address = "NA",
                District = "",
                City = "",
                PostalCode = "",
                Country = "",
                Phone = ""
            };

            // Insert a store in db and then delete it
            DataManager.Instance.InsertOneStore(store);
            DataManager.Instance.DeleteOneStore(store);



            Console.ReadKey();


        }
    }
}
