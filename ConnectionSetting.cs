using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonEx
{
    public static class ConnectionSetting
    {
        internal static string CONNECTION_STRING
        {
            get
            {
                string _connectionString = string.Format("Data Source={0},{4}; Initial Catalog=MVCPersonDB; User ID=sa; Password={3}", SQLDB_SERVER, SQLDB_DATABASE, SQLDB_USER, SQLDB_PASSWORD, SQLDB_PORT);

                return _connectionString;
            }
        }

        private static string SQLDB_SERVER
        {
            get
            {
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SQLDB_SERVER")))
                {
                    return Environment.GetEnvironmentVariable("SQLDB_SERVER");
                }

                return string.Empty;
            }
        }

        private static string SQLDB_USER
        {
            get
            {
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SQLDB_USER")))
                {
                    return Environment.GetEnvironmentVariable("SQLDB_USER");
                }

                return string.Empty;
            }
        }

        private static string SQLDB_PASSWORD
        {
            get
            {
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SQLDB_PASSWORD")))
                {
                    return Environment.GetEnvironmentVariable("SQLDB_PASSWORD");
                }

                return string.Empty;
            }
        }

        internal static string SQLDB_DATABASE
        {
            get
            {
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SQLDB_DATABASE")))
                {
                    return Environment.GetEnvironmentVariable("SQLDB_DATABASE");
                }

                return string.Empty;
            }
        }

        internal static string SQLDB_PORT
        {
            get
            {
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SQLDB_PORT")))
                {
                    return Environment.GetEnvironmentVariable("SQLDB_PORT");
                }

                return string.Empty;
            }
        }
    }
}
