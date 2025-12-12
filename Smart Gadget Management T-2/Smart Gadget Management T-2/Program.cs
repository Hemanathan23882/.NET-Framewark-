// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;

// --- Base Class: Gadget ---
public class Gadget
{
    // Private fields
    private string _brand;
    private string _model;
    private DateTime _releaseDate;
    private double _price;

    // Constructor
    public Gadget(string brand, string model, DateTime releaseDate, double price)
    {
        _brand = brand;
        _model = model;
        _releaseDate = releaseDate;
        _price = price;
    }

    // Read-only computed property: AgeInYears
    public int AgeInYears
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - _releaseDate.Year;
            // Adjust age if the release anniversary hasn't occurred this year
            if (_releaseDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }

    // Read-only computed property: IsWarrantyValid (valid for 2 years)
    public bool IsWarrantyValid
    {
        get
        {
            return DateTime.Today <= _releaseDate.AddYears(2);
        }
    }

    // Read-only computed property: DiscountedPrice
    public double DiscountedPrice
    {
        get
        {
            if (AgeInYears > 3)
            {
                return _price * (1 - 0.12); // 12% discount
            }
            else if (AgeInYears > 1)
            {
                return _price * (1 - 0.05); // 5% discount
            }
            else
            {
                return _price; // No discount
            }
        }
    }

    // Read-only computed property: UniqueCode (First 3 letters of brand + Last 2 letters of model + Release year)
    public string UniqueCode
    {
        get
        {
            // Ensure we safely extract substrings even if the strings are short
            string brandPart = _brand.Length >= 3 ? _brand.Substring(0, 3).ToLower() : _brand.ToLower();
            string modelPart = _model.Length >= 2 ? _model.Substring(_model.Length - 2).ToLower() : _model.ToLower();
            string yearPart = _releaseDate.Year.ToString().Substring(2); // Get last two digits of the year

            return $"{brandPart}{modelPart}{yearPart}";
        }
    }

    // Helper methods to access core fields for display/derived classes
    public string Brand => _brand;
    public string Model => _model;
    public double Price => _price;

    // Virtual method to display common details
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"\n--- {Brand} {Model} (Gadget Details) ---");
        Console.WriteLine($"Price: {Price:C}");
        Console.WriteLine($"Age In Years: {AgeInYears}");
        Console.WriteLine($"Is Warranty Valid: {IsWarrantyValid}");
        Console.WriteLine($"Discounted Price: {DiscountedPrice:C}");
        Console.WriteLine($"Unique Code: {UniqueCode}");
    }
}

// --- Derived Class: Smartphone ---
public class Smartphone : Gadget
{
    // Additional properties
    public int RAM { get; set; }
    public int Storage { get; set; }
    public double CameraMP { get; set; }

    public Smartphone(string brand, string model, DateTime releaseDate, double price, int ram, int storage, double cameraMp)
        : base(brand, model, releaseDate, price)
    {
        RAM = ram;
        Storage = storage;
        CameraMP = cameraMp;
    }

    // Override DisplayDetails to include specific details
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("\n  --- Smartphone Specifics ---");
        Console.WriteLine($"  RAM: {RAM} GB");
        Console.WriteLine($"  Storage: {Storage} GB");
        Console.WriteLine($"  Camera: {CameraMP} MP");
    }
}

// --- Derived Class: Laptop ---
public class Laptop : Gadget
{
    // Additional properties
    public int RAM { get; set; }
    public string Processor { get; set; }
    public double BatteryBackupHours { get; set; }

    public Laptop(string brand, string model, DateTime releaseDate, double price, int ram, string processor, double batteryBackupHours)
        : base(brand, model, releaseDate, price)
    {
        RAM = ram;
        Processor = processor;
        BatteryBackupHours = batteryBackupHours;
    }

    // Override DisplayDetails to include specific details
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("\n  --- Laptop Specifics ---");
        Console.WriteLine($"  RAM: {RAM} GB");
        Console.WriteLine($"  Processor: {Processor}");
        Console.WriteLine($"  Battery Backup: {BatteryBackupHours} hours");
    }
}

// --- Main Program Class ---
class Program
{
    static void Main(string[] args)
    {
        // 1. Create one Smartphone object and one Laptop object.
        // Assuming current date is Dec 12, 2025.
        // Smartphone released 4 years ago (age > 3 years, 12% discount)
        Smartphone myPhone = new Smartphone("Samsung", "GalaxyS21", new DateTime(2021, 1, 29), 799.99, 12, 256, 12.0);

        // Laptop released 1.5 years ago (age > 1 year, 5% discount, warranty still valid)
        Laptop myLaptop = new Laptop("Dell", "XPS13", new DateTime(2024, 4, 15), 1200.00, 16, "Intel Core i7", 10.5);

        // 2 & 3. Display all required details (Gadget base details and specific details)
        myPhone.DisplayDetails();

        myLaptop.DisplayDetails();
    }
}

