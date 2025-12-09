// See https://aka.ms/new-console-template for more information
class Employee
{
    public string EmployeeName { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal HRA { get; private set; }
    public decimal DA { get; private set; }
    public decimal GrossPay { get; private set; }
    public decimal Tax { get; private set; }
    public decimal NetPay { get; private set; }

    public Employee(string name, decimal basicSalary)
    {
        EmployeeName = name;
        BasicSalary = basicSalary;
    }

    public void CalculateNetPay()
    {
        HRA = BasicSalary * 0.15m;
        DA = BasicSalary * 0.10m;
        GrossPay = BasicSalary + HRA + DA;
        Tax = GrossPay * 0.08m;
        NetPay = GrossPay - Tax;
    }

    public void Display()
    {
        Console.WriteLine("---- Employee Salary Structure ----");
        Console.WriteLine($"Employee Name : {EmployeeName}");
        Console.WriteLine($"Basic Salary  : {BasicSalary}");
        Console.WriteLine($"HRA           : {HRA}");
        Console.WriteLine($"DA            : {DA}");
        Console.WriteLine($"Gross Pay     : {GrossPay}");
        Console.WriteLine($"Tax (8%)      : {Tax}");
        Console.WriteLine($"Net Pay       : {NetPay}");
        Console.WriteLine("-----------------------------------");
    }
}

class Stock
{
    public string StockName { get; set; }
    public string StockSymbol { get; set; }
    public double PreviousClosingPrice { get; set; }
    public double CurrentClosingPrice { get; set; }

    public Stock(string name, string symbol, double prev, double curr)
    {
        StockName = name;
        StockSymbol = symbol;
        PreviousClosingPrice = prev;
        CurrentClosingPrice = curr;
    }
    public double GetChangePercentage()
    {
        return ((CurrentClosingPrice - PreviousClosingPrice) / PreviousClosingPrice) * 100;
    }
}

class RandomHelper
{
    private static Random rnd = new Random();

    public static int randint(int a, int b)
    {
        return rnd.Next(a, b + 1);
    }

    public static double randdouble(int a, int b)
    {
        return rnd.NextDouble() * (b - a) + a;
    }
}

class Program
{
    static void Main()
    {

        Employee emp = new Employee("John Doe", 30000m);
        emp.CalculateNetPay();
        emp.Display();

        Stock s = new Stock("Apple Inc", "AAPL", 150.5, 155.75);
        Console.WriteLine($"\nStock Change Percentage: {s.GetChangePercentage():F2}%");

        Console.WriteLine($"\nRandom Integer (1-10): {RandomHelper.randint(1, 10)}");
        Console.WriteLine($"Random Double  (1-10): {RandomHelper.randdouble(1, 10):F3}");
    }
}