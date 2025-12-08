// See https://aka.ms/new-console-template for more information
using System;

public class TransactionAnalyzer
{
    public static void Main(string[] args)
    {
        // Declare variables with sample values
        string transactionId = "TXN123456789";
        decimal amount = 1000000.75M; // 'M' suffix denotes a decimal literal
        bool isInternational = true;
        float customerRating = 4.50f; // 'f' suffix denotes a float literal
        DateTime transactionTimestamp = DateTime.Now; // Assigns current date and time
        int rewardPoints = 5000000;

        // Optional: Print details to console for verification
        Console.WriteLine($"Transaction ID: {transactionId}");
        Console.WriteLine($"Amount: ₹{amount}");
        Console.WriteLine($"International Transaction: {isInternational}");
        Console.WriteLine($"Customer Rating: {customerRating}");
        Console.WriteLine($"Timestamp: {transactionTimestamp}");
        Console.WriteLine($"Reward Points: {rewardPoints}");
    }
}

