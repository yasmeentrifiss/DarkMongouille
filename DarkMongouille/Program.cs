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
    public class Program
    {
        static Connection connection = null;

        static void Main(string[] args)
        {
            // Initialize db, users

            Server server = new Server();

            // Initialize current user

            string username = "";
            string password = "";
            bool isConnected = false;

            // While user is not connected, run authentification

            while (!isConnected)
            {
                // Authentification
                Console.Write("username : ");
                username = Console.ReadLine();
                Console.Write("password : ");
                password = Console.ReadLine();

                // Connection
                connection = new Connection(username, password);
                isConnected = connection.isConnected;
            }

            // If user is connected, display menu

            if (isConnected)
            {
                switch (username)
                {
           
                    case "standard":
                        DisplayStandardMenu();
                        break;
                    case "business":
                        DisplayBusinessMenu();
                        break;
                    case "admin":
                        DisplayAdminMenu();
                        break;
                    default:
                        Console.WriteLine("Unknown username.");
                        break;
                }
            }


            Console.ReadKey();


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

        static void DisplayStandardMenu()
        {
            string menu = "\n" + "******************** Standard Menu ********************" + "\n"
                            + "1. requete 1" + "\n"
                            + "2. requete 2" + "\n"
                            + "3. requete 3" + "\n"
                            + "4. requete 4" + "\n"
                            + "5. exit " + "\n";
            bool loop = true;
            string choice = "";
            while (loop)
            {
                Console.WriteLine(menu);
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        // do req1
                        break;
                    case "2":
                        //doreq2
                        break;
                    case "3":
                        // do req1
                        break;
                    case "4":
                        //doreq2
                        break;
                    case "5":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }

        static void DisplayBusinessMenu()
        {
            string menu = "\n" + "******************** Business Menu ********************" + "\n"
                            + "1. requete 1" + "\n"
                            + "2. requete 2" + "\n"
                            + "3. requete 3" + "\n"
                            + "4. requete 4" + "\n"
                            + "5. exit " + "\n";
            bool loop = true;
            string choice = "";
            while (loop)
            {
                Console.WriteLine(menu);
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        // do req1
                        break;
                    case "2":
                        //doreq2
                        break;
                    case "3":
                        // do req1
                        break;
                    case "4":
                        //doreq2
                        break;
                    case "5":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }

        }

        static void DisplayAdminMenu()
        {
            string menu = "\n" + "******************** Admin Menu ********************" + "\n"
                            + "1. requete 1" + "\n"
                            + "2. requete 2" + "\n"
                            + "3. requete 3" + "\n"
                            + "4. requete 4" + "\n"
                            + "5. exit " + "\n";
            bool loop = true;
            string choice = "";
            while (loop)
            {
                Console.WriteLine(menu);
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        // do req1
                        break;
                    case "2":
                        //doreq2
                        break;
                    case "3":
                        // do req1
                        break;
                    case "4":
                        //doreq2
                        break;
                    case "5":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }

        }

    }

}
