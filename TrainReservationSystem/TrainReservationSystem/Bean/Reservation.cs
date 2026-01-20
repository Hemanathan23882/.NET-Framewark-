using System;

namespace TrainReservationSystem.Bean
{
    /// <summary>
    /// Entity class representing a Train Reservation
    /// </summary>
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int TrainId { get; set; }
        public string PassengerName { get; set; }
        public DateTime ReservationDate { get; set; }

        // Default constructor
        public Reservation()
        {
        }

        // Parameterized constructor
        public Reservation(int reservationId, int trainId, string passengerName, DateTime reservationDate)
        {
            ReservationId = reservationId;
            TrainId = trainId;
            PassengerName = passengerName;
            ReservationDate = reservationDate;
        }

        // Constructor without reservation ID (for new reservations)
        public Reservation(int trainId, string passengerName)
        {
            TrainId = trainId;
            PassengerName = passengerName;
            ReservationDate = DateTime.Now;
        }

        // Override ToString for easy display
        public override string ToString()
        {
            return $"Reservation ID: {ReservationId}, Train ID: {TrainId}, Passenger: {PassengerName}, Date: {ReservationDate:yyyy-MM-dd}";
        }
    }
}