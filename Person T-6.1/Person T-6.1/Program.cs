// See https://aka.ms/new-console-template for more information
using System;

// --- Person Class Definition ---
public class Person
{
    // Private fields
    private string _firstName;
    private string _lastName;
    private string _emailAddress;
    private DateTime _dateOfBirth;

    // Constructor
    public Person(string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        _firstName = firstName;
        _lastName = lastName;
        _emailAddress = email;
        _dateOfBirth = dateOfBirth;
    }

    // Read-only property: IsAdult (over 18)
    public bool IsAdult
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - _dateOfBirth.Year;
            // Subtract a year if the birthday hasn't happened yet this year
            if (_dateOfBirth.Date > today.AddYears(-age)) age--;
            return age >= 18;
        }
    }

    // Read-only property: SunSign (Western Zodiac)
    public string SunSign
    {
        get
        {
            int month = _dateOfBirth.Month;
            int day = _dateOfBirth.Day;
            return (month, day) switch
            {
                (1, >= 20) or (2, <= 18) => "Aquarius",
                (2, >= 19) or (3, <= 20) => "Pisces",
                (3, >= 21) or (4, <= 19) => "Aries",
                (4, >= 20) or (5, <= 20) => "Taurus",
                (5, >= 21) or (6, <= 20) => "Gemini",
                (6, >= 21) or (7, <= 22) => "Cancer",
                (7, >= 23) or (8, <= 22) => "Leo",
                (8, >= 23) or (9, <= 22) => "Virgo",
                (9, >= 23) or (10, <= 22) => "Libra",
                (10, >= 23) or (11, <= 21) => "Scorpio",
                (11, >= 22) or (12, <= 21) => "Sagittarius",
                _ => "Capricorn" // Default case for Dec 22 - Jan 19
            };
        }
    }

    // Read-only property: IsBirthDay (whether or not today is the person's birthday)
    public bool IsBirthDay
    {
        get
        {
            return _dateOfBirth.Month == DateTime.Today.Month && _dateOfBirth.Day == DateTime.Today.Day;
        }
    }

    // Read-only property: ScreenName (e.g., hode525 or haridoe052580)
    public string ScreenName
    {
        get
        {
            // Example format: First 3 letters of first name, first 2 letters of last name, MonthDayYear (MMddyyyy)
            string firstNamePart = _firstName.Substring(0, Math.Min(3, _firstName.Length)).ToLower();
            string lastNamePart = _lastName.Substring(0, Math.Min(2, _lastName.Length)).ToLower();
            string datePart = _dateOfBirth.ToString("MMddyyyy");
            return $"{firstNamePart}{lastNamePart}{datePart}";
        }
    }

    // Virtual method to display basic details (useful for testing derived classes)
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Name: {_firstName} {_lastName}");
        Console.WriteLine($"Email: {_emailAddress}");
        Console.WriteLine($"DOB: {_dateOfBirth.ToShortDateString()}");
        Console.WriteLine($"Adult: {IsAdult}, Birthday Today: {IsBirthDay}, Sun Sign: {SunSign}, Screen Name: {ScreenName}");
    }
}

// --- Employee Class (Derived from Person) ---
public class Employee : Person
{
    // Additional Property: Salary
    public double Salary { get; set; }

    // Constructor chains to the base Person constructor
    public Employee(string firstName, string lastName, string email, DateTime dateOfBirth, double salary)
        : base(firstName, lastName, email, dateOfBirth)
    {
        Salary = salary;
    }

    // Override DisplayDetails to include salary
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Salary: {Salary:C}");
    }
}

// --- HourlyEmployee Class (Derived from Person) ---
public class HourlyEmployee : Person
{
    public double HoursWorked { get; set; }
    public double PayPerHour { get; set; }

    public HourlyEmployee(string firstName, string lastName, string email, DateTime dateOfBirth, double hoursWorked, double payPerHour)
        : base(firstName, lastName, email, dateOfBirth)
    {
        HoursWorked = hoursWorked;
        PayPerHour = payPerHour;
    }

    // Read-only computed property for Total Pay for an hourly employee
    public double TotalPay => HoursWorked * PayPerHour;

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Hours Worked: {HoursWorked}, Pay Per Hour: {PayPerHour:C}");
        Console.WriteLine($"Total Pay: {TotalPay:C}");
    }
}

// --- PermanentEmployee Class (Derived from Person) ---
public class PermanentEmployee : Person
{
    public double HRA { get; set; } // Housing Rent Allowance
    public double DA { get; set; } // Dearness Allowance
    public double Tax { get; set; } // Tax rate (as a percentage, e.g., 0.10 for 10%)

    public PermanentEmployee(string firstName, string lastName, string email, DateTime dateOfBirth, double hra, double da, double tax)
        : base(firstName, lastName, email, dateOfBirth)
    {
        HRA = hra;
        DA = da;
        Tax = tax;
    }

    // These properties should likely depend on a BaseSalary property, but based on the prompt, 
    // we assume HRA and DA are absolute values and not percentages of a missing salary field.

    // Read-only computed property for TotalPay (Gross Pay)
    public double TotalPay => HRA + DA;

    // Read-only computed property for NetPay
    public double NetPay => TotalPay * (1 - Tax);

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"HRA: {HRA:C}, DA: {DA:C}, Tax Rate: {Tax:P}");
        Console.WriteLine($"Gross Pay (Total Pay): {TotalPay:C}");
        Console.WriteLine($"Net Pay (After Tax): {NetPay:C}");
    }
}

// --- Main Program Class ---
class Program
{
    static void Main(string[] args)
    {
        // Example Date: December 12, 1985 (Current Date matches task date)
        DateTime dob = new DateTime(1985, 12, 12);

        Console.WriteLine("--- Testing Employee Class Instance ---");
        Employee emp = new Employee("Jane", "Doe", "jane.doe@example.com", dob, 65000.00);
        // Test behavior by calling the read-only properties via the DisplayDetails method
        emp.DisplayDetails();

        Console.WriteLine("\n--- Testing HourlyEmployee Class Instance ---");
        HourlyEmployee hEmp = new HourlyEmployee("Bob", "Smith", "bob.smith@example.com", new DateTime(2000, 5, 25), 40.0, 25.50);
        hEmp.DisplayDetails();

        Console.WriteLine("\n--- Testing PermanentEmployee Class Instance ---");
        // Example: $3000 HRA, $2000 DA, 15% Tax Rate
        PermanentEmployee pEmp = new PermanentEmployee("Alice", "Jones", "alice.jones@example.com", new DateTime(1990, 8, 1), 3000.00, 2000.00, 0.15);
        pEmp.DisplayDetails();
    }
}
