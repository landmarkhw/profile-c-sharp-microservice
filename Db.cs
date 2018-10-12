using System;
using System.Collections.Generic;
using Npgsql;

namespace Profile.CSharp.Microservice
{
    public static class Db
    {
        private const string host = "profile-postgres";
        private const int port = 5432;
        private const string user = "profiler";
        private const string password = "profile-test";
        private const string dbname = "test";

        /// <summary>
        /// Gets a connection string suitable to connect to the database.
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                var connectionString = string.Format(
                    "Host={0};Port={1};Username={2};Password={3};Database={4}",
                    host,
                    port,
                    user,
                    password,
                    dbname);
                return connectionString;
            }
        }

        /// <summary>
        /// Executes an action with a database command that's
        /// already been initialized and a connection to the
        /// database opened.
        /// </summary>
        /// <remarks>
        /// The connection to the database is closed automatically
        /// after the function is executed.
        /// </remarks>
        /// <param name="fn">A function to execute against the database.</param>
        public static TResult Command<TResult>(Func<NpgsqlCommand, TResult> fn)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                try
                {
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        return fn(cmd);
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Test a connection to the database.
        /// </summary>
        /// <returns>True if successful, false otherwise.</returns>
        public static bool Test()
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
