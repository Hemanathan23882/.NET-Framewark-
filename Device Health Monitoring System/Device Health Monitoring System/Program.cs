// See https://aka.ms/new-console-template for more information
using System;

namespace DeviceMonitor
{
    // This class is the designated startup entry point
    class TemperatureModule
    {
        // This is the designated startup entry point signature
        public static void Main(string[] args)
        {
            Console.WriteLine("Temperature Module Starting...");

            // We can call the Vibration module's helper method from here
            VibrationModule.RunVibrationCheck();

            Console.WriteLine("Temperature Module Finished.");
        }
    }

    class VibrationModule
    {
        // Renamed from Main() to a normal helper method name (RunVibrationCheck)
        // This method can now be called by other classes, but is not an entry point itself.
        public static void RunVibrationCheck()
        {
            // Your helper code here
            Console.WriteLine("--> Running Vibration Check Helper Method...");
        }
    }
}
