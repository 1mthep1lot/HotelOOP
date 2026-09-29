namespace HotelOOP;

internal class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public string EmployeeId { get; set; } = "";
    public DateTime StartDate { get; set; }
    public decimal Salary { get; set; }
    public string PhoneNumber { get; set; } = "";
    public string Email { get; set; } = "";
    public string Address { get; set; } = "";

    public virtual string Role => "Staff";

    // Metoder
    public void PrintInfo()
    {
        Console.WriteLine($"Namn: {Name}, Ålder: {Age}");
    }

    public void Introduce()
    {
        Console.WriteLine($"Hej, jag heter {Name} och är {Age} år gammal.");
    }

    public virtual void DoWork()
    {
        Console.WriteLine("The person is working at the hotel.");
    }

    public void UpdateSalary(decimal newSalary)
    {
        if (newSalary < 0)
            throw new ArgumentException("Lönen kan inte vara negativ.", nameof(newSalary));
        Salary = newSalary;
    }

    public int CalculateYearsOfService()
    {
        DateTime today = DateTime.Today;
        int years = today.Year - StartDate.Year;
        if (StartDate.Date > today.AddYears(-years))
            years--;
        return Math.Max(0, years);
    }

    public void ChangeEmployeeId(string newId)
    {
        if (string.IsNullOrWhiteSpace(newId))
            throw new ArgumentException("Anställnings-ID får inte vara tomt.", nameof(newId));
        EmployeeId = newId;
    }

    public void UpdateContactInfo(string phone, string email, string address)
    {
        PhoneNumber = phone;
        Email = email;
        Address = address;
    }
}
