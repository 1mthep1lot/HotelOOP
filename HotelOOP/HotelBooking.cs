namespace HotelOOP;

internal class HotelBooking
{
    public Guest Guest { get; set; }

    public int Price = 500;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int Days { get; set; }

    public void PrintInfo()
    {
        Console.WriteLine("Guest: " + Guest.Name);
        Console.WriteLine("Check In: " + StartDate);
        Console.WriteLine("Check out: " + EndDate);
        Console.WriteLine("Nights: " + Days);
        Console.WriteLine("Price: " + TotalPrice() + " KR");
        Console.WriteLine("Phone Number: " + "+46" + Guest.PhoneNumber);
        Console.WriteLine("Email: " + Guest.Email);
    }

    public HotelBooking(
        string guestName,
        DateTime startDate,
        int days,
        int phonenumber,
        string youremail
    )
    {
        Guest = new Guest(guestName, phonenumber.ToString(), youremail);

        StartDate = startDate;
        Days = days;

        EndDate = startDate.AddDays(days);
    }

    public int TotalPrice()
    {
        var totalPrice = Price * Days;
        return totalPrice;
    }

    public void Extend(int extranights)
    {
        Days += extranights;
        EndDate = StartDate.AddDays(Days);
    }
}
