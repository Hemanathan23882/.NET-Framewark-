using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TrainReservationSystem.Bean;
using TrainReservationSystem.Util;

namespace TrainReservationSystem.DAO
{
    /// <summary>
    /// Data Access Object for Train operations
    /// </summary>
    public class TrainDAO
    {
        /// <summary>
        /// Get all trains from database
        /// </summary>
        /// <returns>List of Train objects</returns>
        public List<Train> GetAllTrains()
        {
            List<Train> trains = new List<Train>();

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Train_ID, Train_Name, Source, Destination, Available_Seats FROM TRAIN_TBL";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Train train = new Train
                                {
                                    TrainId = reader.GetInt32(0),
                                    TrainName = reader.GetString(1),
                                    Source = reader.GetString(2),
                                    Destination = reader.GetString(3),
                                    AvailableSeats = reader.GetInt32(4)
                                };
                                trains.Add(train);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching trains: " + ex.Message);
                throw;
            }

            return trains;
        }

        /// <summary>
        /// Get train by ID
        /// </summary>
        /// <param name="trainId">Train ID</param>
        /// <returns>Train object or null if not found</returns>
        public Train GetTrainById(int trainId)
        {
            Train train = null;

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Train_ID, Train_Name, Source, Destination, Available_Seats FROM TRAIN_TBL WHERE Train_ID = @TrainId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TrainId", trainId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                train = new Train
                                {
                                    TrainId = reader.GetInt32(0),
                                    TrainName = reader.GetString(1),
                                    Source = reader.GetString(2),
                                    Destination = reader.GetString(3),
                                    AvailableSeats = reader.GetInt32(4)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching train: " + ex.Message);
                throw;
            }

            return train;
        }

        /// <summary>
        /// Check if seats are available for a train
        /// </summary>
        /// <param name="trainId">Train ID</param>
        /// <returns>True if seats available</returns>
        public bool CheckSeatAvailability(int trainId)
        {
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Available_Seats FROM TRAIN_TBL WHERE Train_ID = @TrainId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TrainId", trainId);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            int availableSeats = Convert.ToInt32(result);
                            return availableSeats > 0;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking seat availability: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Decrease available seats by 1
        /// </summary>
        /// <param name="trainId">Train ID</param>
        /// <returns>True if update successful</returns>
        public bool UpdateAvailableSeats(int trainId)
        {
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE TRAIN_TBL SET Available_Seats = Available_Seats - 1 WHERE Train_ID = @TrainId AND Available_Seats > 0";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TrainId", trainId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating seats: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Insert a new reservation
        /// </summary>
        /// <param name="reservation">Reservation object</param>
        /// <returns>Generated Reservation ID</returns>
        public int InsertReservation(Reservation reservation)
        {
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO TRAIN_RESERVATION_TBL (Train_ID, Passenger_Name, Reservation_Date) 
                                   VALUES (@TrainId, @PassengerName, @ReservationDate);
                                   SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TrainId", reservation.TrainId);
                        cmd.Parameters.AddWithValue("@PassengerName", reservation.PassengerName);
                        cmd.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate);

                        int reservationId = (int)cmd.ExecuteScalar();
                        return reservationId;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting reservation: " + ex.Message);
                throw;
            }
        }
    }
}