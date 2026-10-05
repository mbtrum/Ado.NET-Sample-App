using AdoDotNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AdoDotNet.Controllers
{
    public class FriendsController : Controller
    {
        private readonly IConfiguration _config;

        // Constructor
        public FriendsController(IConfiguration config)
        {
            _config = config;
        }

        // GET: FriendsController
        public ActionResult Index()
        {
            List<Friend> friends = GetFriendsFromDatabase();

            //List<Friend> friends = new List<Friend>
            //{
            //    new Friend { Id = 1, FirstName = "Han", LastName = "Solo" },
            //    new Friend { Id = 2, FirstName = "Luke", LastName = "Skywalker" },
            //    new Friend { Id = 3, FirstName = "Leia", LastName = "Organa" }
            //};

            return View(friends);
        }

        private List<Friend> GetFriendsFromDatabase()
        {
            // Create a list of friends objects to store records from database

            List<Friend> friends = new List<Friend>();

            // Get the connection string from appsettings.json
            string connectionString = _config.GetConnectionString("FriendsDb") ?? throw new InvalidOperationException("Connection string 'SchoolDb' was not found.");

            // Create a SqlConnection object using the connection string
            SqlConnection connection = new SqlConnection(connectionString);

            // Use the SqlConnection object in a using statement to ensure it is disposed of properly
            using (connection)
            {
                // Create a SqlCommand object to execute the SQL query
                SqlCommand command = new SqlCommand("SELECT Id, FirstName, LastName FROM Friend;", connection);

                // ***OPEN*** the connection to the database
                connection.Open();

                // Execute the command and get a SqlDataReader object to read the results
                SqlDataReader reader = command.ExecuteReader();

                // If rows are returned, read the data and create Friend objects to add to the list
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // For each row, create a new Friend object and set its properties from the reader
                        Friend friend = new Friend();

                        friend.Id = reader.GetInt32(0);
                        friend.FirstName = reader.GetString(1);
                        friend.LastName = reader.GetString(2);

                        // Add the Friend object to the list
                        friends.Add(friend);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                // Close the reader
                reader.Close();
            }
            // connection closed automatically when exiting the using block

            // Return the list of friends
            return friends;
        }
    }
}
