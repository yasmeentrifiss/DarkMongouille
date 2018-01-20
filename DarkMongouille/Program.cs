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
            // DataManager.Instance.InsertOneStore(store);
            // DataManager.Instance.DeleteOneStore(store);

            #region Standard User test

            /* // request 1
            string choice = "";
            do
            {
                Console.WriteLine("Please enter a rate. Rates can be G, PG, PG-13, R, or NC-17.");
                choice = Console.ReadLine();
            } while (choice == "");
            DataManager.Instance.RateRequest(choice);*/

            /* // request 2 
            string choice = "";
            do
            {
                Console.WriteLine("Please enter a film title all in CAPS");
                choice = Console.ReadLine();
            } while (choice == "");
            DataManager.Instance.TitleRequest(choice); */

           /* // request 3
           string choice = "";
           do
           {
               Console.WriteLine("Please enter a name of category. Category can be Documentary, Horror, Family, Foreign, Comedy, Sports, Music, Classics, Animation, Action, New, Sci-Fi, Drama, Travel, Games, Children ");
               choice = Console.ReadLine();
           } while (choice == "");
           DataManager.Instance.CategoryRequest(choice);*/

            /* // request 4
            string choice = "";
            do
            {
                Console.WriteLine("Please enter a first name actor all in CAPS");
                choice = Console.ReadLine();
            } while (choice == "");
            DataManager.Instance.ActorRequest(choice);*/

            // DataManager.Instance.DisplayAllFilms();
            #endregion


            Console.ReadKey();


        }
    }
}
