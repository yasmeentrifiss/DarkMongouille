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
        static void Main(string[] args)
        {
            // Initialize db, users

            Server server = new Server();

            // Initialize current user

            string username = "";
            string password = "";
            bool isConnected = false;
            Connection connection = null;

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
                        DisplayStandardMenu(connection);
                        break;
                    case "business":
                        DisplayBusinessMenu(connection);
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




            #endregion


            Console.ReadKey();


        }

        static void DisplayStandardMenu(Connection connection)
        {
            string menu = "\n" + "******************** Standard Menu ********************" + "\n"
                            + "1. requete 1 : Quels sont les titres de films dont la classification cinématographique est ... " + "\n"
                            + "2. requete 2 : Quels sont les informations du film dont le titre est ... " + "\n"
                            + "3. requete 3 : Quels sont les films dont le genre est ... " + "\n"
                            + "4. requete 4 : Quels sont les films dont le prénom de l’acteur/actrice est ... " + "\n"
                            + "5. Bonus : Donner la liste de tous les films  " + "\n"
                            +"6. exit " + "\n";
            bool loop = true;
            string userChoice = "";
            while (loop)
            {
                Console.WriteLine(menu);
                userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        // request 1
                        userChoice = "";
                        do
                        {
                            Console.WriteLine("Please enter a rate. Rates can be G, PG, PG-13, R, or NC-17.");
                            userChoice = Console.ReadLine();
                        } while (userChoice == "");
                        connection.RateRequest(userChoice);
                        break;
                    case "2":
                        userChoice = "";
                        do
                        {
                            Console.WriteLine("Please enter a film title all in CAPS");
                            userChoice = Console.ReadLine();
                        } while (userChoice == "");
                        connection.TitleRequest(userChoice);
                        break;
                    case "3":
                        // request 3
                        userChoice = "";
                        do
                        {
                            Console.WriteLine("Please enter a name of category. Category can be Documentary, Horror, Family, Foreign, Comedy, Sports, Music, Classics, Animation, Action, New, Sci-Fi, Drama, Travel, Games, Children ");
                            userChoice = Console.ReadLine();
                        } while (userChoice == "");
                        connection.CategoryRequest(userChoice);
                        break;
                    case "4":
                         userChoice = "";
                        do
                        {
                            Console.WriteLine("Please enter a first name actor all in CAPS");
                            userChoice = Console.ReadLine();
                        } while (userChoice == "");
                        connection.ActorRequest(userChoice);
                        break;
                    case "5":
                        connection.DisplayAllFilms();
                        break;
                    case "6":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }

        static void DisplayBusinessMenu(Connection connection)
        {
            string menu = "\n" + "******************** Business Menu ********************" + "\n"
                            + "1. requete 1 : Afficher, pour un id de film donné, chaque inventaire pour ce film et la liste des locations" + "\n"
                            + "2. requete 2" + "\n"
                            + "3. Bonus : Afficher pour chaque inventaire la liste des locations" + "\n"
                            + "4. exit " + "\n";
            bool loop = true;
            string choice = "";
            string userChoice = "";
            while (loop)
            {
                Console.WriteLine(menu);
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        // requete 1
                        userChoice = "";
                        do
                        {
                            Console.WriteLine("Please enter a film id.Have to be an integer");
                            userChoice = Console.ReadLine();
                        } while (userChoice == "");
                        connection.InventoryRequestById(userChoice);
                        break;
                    case "2":
                        //doreq2
                        break;
                    case "3":
                        // request 3
                        connection.InventoryRequest();
                        break;
                    case "4":
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
