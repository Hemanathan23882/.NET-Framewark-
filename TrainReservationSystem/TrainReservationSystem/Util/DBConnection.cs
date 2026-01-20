using System;
using System.Data.SqlClient;

namespace TrainReservationSystem.Util
{
    public class DBConnection
    {
        // Connection string - UPDATE with your SQL Server details
        private static string connectionString =
    @"Server=localhost\SQLEXPRESS;
      Database=TrainReservationDB;
      Trusted_Connection=True;
      TrustServerCertificate=True;";




        // Alternative connection string with SQL Authentication:
        // "Data Source=localhost;Initial Catalog=TrainReservationDB;User Id=sa;Password=yourpassword";

        /// <summary>
        /// Gets a new SQL connection
        /// </summary>
        /// <returns>SqlConnection object</returns>
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Connection Error: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Tests the database connection
        /// </summary>
        /// <returns>True if connection successful</returns>
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    Console.WriteLine("Database connection successful!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection test failed: " + ex.Message);
                return false;
            }
        }
    }
}