using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Settings
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString =
                @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=BookKeeper;Integrated Security=True;";

            var read = File.ReadAllText("Scripts\\login.sql");

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var createUser = string.Format(read, Environment.UserDomainName, Environment.UserName);

                using (var command = new SqlCommand(createUser,connection))
                {
                    command.ExecuteReader();
                }
            }
        }
    }
}
