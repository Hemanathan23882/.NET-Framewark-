// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class Consumer
{
    public string ConsumerID { get; set; }
    public int Units { get; set; }
    public int Type { get; set; }

    public double BaseCharge { get; set; }
    public double Surcharge { get; set; }
    public double Penalty { get; set; }
    public double Discount { get; set; }
    public double FinalBill { get; set; }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter number of consumers: ");
        int N = int.Parse(Console.ReadLine());

        List<Consumer> list = new List<Consumer>();

        double totalRevenue = 0;
        double highestBill = 0;
        string highestBillConsumer = "";

        int domesticCount = 0, commercialCount = 0;

        for (int i = 0; i < N; i++)
        {
            Console.WriteLine($"\n--- Consumer {i + 1} ---");

            Console.Write("Consumer ID: ");
            string id = Console.ReadLine();

            Console.Write("Units Consumed: ");
            int units = int.Parse(Console.ReadLine());

            Console.Write("Connection Type (1 = Domestic, 2 = Commercial): ");
            int type = int.Parse(Console.ReadLine());

            Consumer c = new Consumer()
            {
                ConsumerID = id,
                Units = units,
                Type = type
            };

            if (type == 1) domesticCount++;
            else commercialCount++;

            c.BaseCharge = CalculateBaseCharge(units, type);

            c.Surcharge = c.BaseCharge * 0.03;

            c.Penalty = (units > 500) ? 200 : 0;

            double totalBeforeDiscount = c.BaseCharge + c.Surcharge + c.Penalty;

            if (totalBeforeDiscount > 2000)
                c.Discount = totalBeforeDiscount * 0.05;
            else
                c.Discount = 0;

            c.FinalBill = totalBeforeDiscount - c.Discount;


            if (c.FinalBill > highestBill)
            {
                highestBill = c.FinalBill;
                highestBillConsumer = id;
            }

            totalRevenue += c.FinalBill;

            list.Add(c);
        }

        Console.WriteLine("\n===== Consumer Bills =====");

        foreach (var c in list)
        {
            string typeName = (c.Type == 1) ? "Domestic" : "Commercial";

            Console.WriteLine(
                $"{c.ConsumerID}  {typeName}  Units:{c.Units}  " +
                $"Base:{c.BaseCharge:F2}  Surcharge:{c.Surcharge:F2}  " +
                $"Penalty:{c.Penalty:F2}  Discount:{c.Discount:F2}  Final:{c.FinalBill:F2}"
            );
        }

        Console.WriteLine("\n===== Summary =====");
        Console.WriteLine($"Total Consumers: {N}");
        Console.WriteLine($"Total Revenue: ₹{totalRevenue:F2}");
        Console.WriteLine($"Highest Bill: {highestBillConsumer} ₹{highestBill:F2}");
        Console.WriteLine($"Domestic: {domesticCount}   Commercial: {commercialCount}");
    }

    static double CalculateBaseCharge(int units, int type)
    {
        double rate = 0;

        if (type == 1)
        {
            if (units <= 100) rate = 1.50;
            else if (units <= 300) rate = 2.50;
            else rate = 4.00;
        }
        else
        {
            if (units <= 200) rate = 5.00;
            else if (units <= 500) rate = 6.50;
            else rate = 8.00;
        }

        return units * rate;
    }
}
