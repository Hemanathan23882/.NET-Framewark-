// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

// --- Base Class: Notification ---
public class Notification
{
    // 1 & 2. Define a virtual method 'Send' that derived classes can override.
    public virtual void Send(string message)
    {
        Console.WriteLine($"Sending notification: {message}");
    }
}

// --- Derived Class: EmailNotification (3) ---
public class EmailNotification : Notification
{
    // 4. Override the Send method with Email-specific output.
    public override void Send(string message)
    {
        Console.WriteLine($"Email sent to registered address: '{message}'");
    }
}

// --- Derived Class: SmsNotification (3) ---
public class SmsNotification : Notification
{
    // 4. Override the Send method with SMS-specific output.
    public override void Send(string message)
    {
        Console.WriteLine($"SMS sent to mobile number: '{message}'");
    }
}

// --- Derived Class: PushNotification (3) ---
public class PushNotification : Notification
{
    // 4. Override the Send method with Push Notification-specific output.
    public override void Send(string message)
    {
        Console.WriteLine($"Push notification delivered to device: '{message}'");
    }
}

// --- Main Program Class ---
class Program
{
    static void Main(string[] args)
    {
        // 5. Declare a base class reference of type Notification.
        Notification notificationSender;

        Console.WriteLine("--- Demonstrating Polymorphic Notification System ---");

        // Assign EmailNotification object to the base reference and call Send()
        notificationSender = new EmailNotification();
        notificationSender.Send("Your password reset link is here.");

        // Assign SmsNotification object to the base reference and call Send()
        notificationSender = new SmsNotification();
        notificationSender.Send("Your 2FA code is 12345.");

        // Assign PushNotification object to the base reference and call Send()
        notificationSender = new PushNotification();
        notificationSender.Send("A new message has arrived in your inbox.");

        Console.WriteLine("\n--- Demonstration Complete ---");

        // 6. Extensibility Demonstration (Developers can add new types seamlessly)
        // We can define a list of different notification types and process them in a single loop:
        List<Notification> allChannels = new List<Notification>
        {
            new EmailNotification(),
            new SmsNotification(),
            new PushNotification()
            // If we added new types like 'WhatsAppNotification', we could add them here without changing the loop logic.
        };

        Console.WriteLine("\n--- Processing all channels using a single loop (Uniform handling) ---");
        foreach (var channel in allChannels)
        {
            // The runtime determines which specific Send() method to call
            channel.Send("Urgent system alert!");
        }
    }
}
