using System;

namespace TrainReservationSystem.Bean
{
    /// <summary>
    /// Entity class representing a Train
    /// </summary>
    public class Train
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int AvailableSeats { get; set; }

        // Default constructor
        public Train()
        {
        }

        // Parameterized constructor
        public Train(int trainId, string trainName, string source, string destination, int availableSeats)
        {
            TrainId = trainId;
            TrainName = trainName;
            Source = source;
            Destination = destination;
            AvailableSeats = availableSeats;
        }

        // Override ToString for easy display
        public override string ToString()
        {
            return $"Train ID: {TrainId}, Name: {TrainName}, From: {Source} To: {Destination}, Available Seats: {AvailableSeats}";
        }
    }
}