using System;

namespace TrainReservationSystem.Util
{
    /// <summary>
    /// Custom exception thrown when seats are not available
    /// </summary>
    public class SeatNotAvailableException : Exception
    {
        public SeatNotAvailableException() : base("SEAT NOT AVAILABLE")
        {
        }

        public SeatNotAvailableException(string message) : base(message)
        {
        }

        public SeatNotAvailableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}