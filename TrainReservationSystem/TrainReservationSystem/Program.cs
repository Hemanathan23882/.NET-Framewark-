using System;
using TrainReservationSystem.Service;
using TrainReservationSystem.Util;

namespace TrainReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test database connection first
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine("TRAIN RESERVATION SYSTEM");
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine("\nTesting database connection...");

            if (!DBConnection.TestConnection())
            {
                Console.WriteLine("\nFailed to connect to database. Please check your connection settings.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            TrainReservationService service = new TrainReservationService();
            bool exit = false;

            while (!exit)
            {
                try
                {
                    DisplayMenu();
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            service.ViewTrainDetails();
                            break;

                        case "2":
                            ReserveTicket(service);
                            break;

                        case "3":
                            exit = true;
                            Console.WriteLine("\nThank you for using Train Reservation System!");
                            Console.WriteLine("Goodbye!");
                            break;

                        default:
                            Console.WriteLine("\nInvalid choice! Please select 1, 2, or 3.");
                            break;
                    }

                    if (!exit)
                    {
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nAn error occurred: " + ex.Message);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Display main menu
        /// </summary>
        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\n" + "=".PadRight(80, '='));
            Console.WriteLine("TRAIN RESERVATION SYSTEM - MAIN MENU");
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine();
            Console.WriteLine("1. View Train Details");
            Console.WriteLine("2. Reserve Train Ticket");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine();
        }

        /// <summary>
        /// Handle ticket reservation process
        /// </summary>
        /// <param name="service">Train reservation service</param>
        static void ReserveTicket(TrainReservationService service)
        {
            Console.WriteLine("\n--- Reserve Train Ticket ---\n");

            try
            {
                // Get Train ID
                Console.Write("Enter Train ID: ");
                string trainIdInput = Console.ReadLine();

                if (!int.TryParse(trainIdInput, out int trainId))
                {
                    Console.WriteLine("\nINVALID TRAIN ID");
                    return;
                }

                // Get Passenger Name
                Console.Write("Enter Passenger Name: ");
                string passengerName = Console.ReadLine();

                // Validate passenger name
                if (!service.ValidatePassengerName(passengerName))
                {
                    return;
                }

                // Confirm reservation
                Console.WriteLine($"\nConfirm reservation for {passengerName} on Train ID {trainId}?");
                Console.Write("Enter 'Y' to confirm or any other key to cancel: ");
                string confirm = Console.ReadLine();

                if (confirm.Trim().ToUpper() == "Y")
                {
                    service.ReserveTicket(trainId, passengerName);
                }
                else
                {
                    Console.WriteLine("\nReservation cancelled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError during reservation: " + ex.Message);
            }
        }
    }
}