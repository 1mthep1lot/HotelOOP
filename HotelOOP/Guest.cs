namespace HotelOOP;

internal class Guest
{
    public string Name { get; set; }
    internal string PhoneNumber { get; set; }
    public string Email { get; set; }

    public Guest(string name, string phoneNumber, string email)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    internal void PrintInfo()
    {
        Console.WriteLine($"Guest: {Name}");
        Console.WriteLine($"Phone Number: {PhoneNumber}");
        Console.WriteLine($"Email: {Email}");
    }
}
