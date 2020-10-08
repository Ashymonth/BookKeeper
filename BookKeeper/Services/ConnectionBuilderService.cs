﻿using System.Data.SqlClient;
using System.IO;

namespace BookKeeper.Data.Services
{
    public static class ConnectionBuilderService
    {
        public static string BuildConnectionString(string connection)
        {
            var builder = new SqlConnectionStringBuilder(connection)
            {
             
                InitialCatalog = "BookKeeper"
            };

            return builder.ConnectionString;
        }
    }
}
    