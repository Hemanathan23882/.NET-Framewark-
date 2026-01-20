using System;
using System.Collections.Generic;
using TrainReservationSystem.Bean;
using TrainReservationSystem.DAO;
using TrainReservationSystem.Util;

namespace TrainReservationSystem.Service
{
    /// <summary>
    /// Service layer containing business logic for train reservation
    /// </summary>
    public class TrainReservationService
    {
        private TrainDAO trainDAO;

        public TrainReservationService()
        {
            trainDAO = new TrainDAO();
        }

        /// <summary>
        /// View all available trains
        /// </summary>
        public void ViewTrainDetails()
        {
            try
            {
                List<Train> trains = trainDAO.GetAllTrains();

                if (trains.Count > 0)
                {
                    Console.WriteLine("\n" + "=".PadRight(80, '='));
                    Console.WriteLine("TRAIN DETAILS FOUND");
                    Console.WriteLine("=".PadRight(80, '='));
                    Console.WriteLine();

                    foreach (Train train in trains)
                    {
                        Console.WriteLine(train);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("\nNo trains found in the system.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nINVALID");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Reserve a train ticket
        /// </summary>
        /// <param name="trainId">Train ID</param>
        /// <param name="passengerName">Passenger Name</param>
        public void ReserveTicket(int trainId, string passengerName)
        {
            try
            {
                // Step 1: Check if train exists
                Train train = trainDAO.GetTrainById(trainId);

                if (train == null)
                {
                    Console.WriteLine("\nINVALID TRAIN ID");
                    return;
                }

                // Step 2: Check if seats are available
                if (!trainDAO.CheckSeatAvailability(trainId))
                {
                    throw new SeatNotAvailableException();
                }

                // Step 3: Create reservation object
                Reservation reservation = new Reservation(trainId, passengerName);
                reservation.ReservationDate = DateTime.Now;

                // Step 4: Update available seats
                bool seatsUpdated = trainDAO.UpdateAvailableSeats(trainId);

                if (!seatsUpdated)
                {
                    throw new SeatNotAvailableException();
                }

                // Step 5: Insert reservation
                int reservationId = trainDAO.InsertReservation(reservation);

                // Step 6: Display success message
                Console.WriteLine("\n" + "=".PadRight(80, '='));
                Console.WriteLine("SUCCESS");
                Console.WriteLine("=".PadRight(80, '='));
                Console.WriteLine($"Reservation ID: {reservationId}");
                Console.WriteLine($"Train: {train.TrainName} ({trainId})");
                Console.WriteLine($"Passenger: {passengerName}");
                Console.WriteLine($"Date: {reservation.ReservationDate:yyyy-MM-dd HH:mm:ss}");
                Console.WriteLine($"Route: {train.Source} to {train.Destination}");
                Console.WriteLine("=".PadRight(80, '='));
                Console.WriteLine();
            }
            catch (SeatNotAvailableException)
            {
                Console.WriteLine("\nSEAT NOT AVAILABLE");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nINVALID");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Validate passenger name
        /// </summary>
        /// <param name="name">Passenger name</param>
        /// <returns>True if valid</returns>
        public bool ValidatePassengerName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Passenger name cannot be empty!");
                return false;
            }

            if (name.Length < 2)
            {
                Console.WriteLine("Passenger name must be at least 2 characters!");
                return false;
            }

            return true;
        }
    }
}