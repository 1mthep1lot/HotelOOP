namespace HotelOOP;

internal class Employee : Person
{
    public string JobTitle { get; set; } = "";
    public string Department { get; set; } = "";
    public ShiftPreference ShiftPreference { get; set; } = ShiftPreference.Morning;
    public int VacationDays { get; set; } = 25;
    public decimal PerformanceRating { get; set; }

    public override string Role => JobTitle;

    public virtual void Work()
    {
        Console.WriteLine($"{Name} arbetar som {JobTitle} på {Department}-avdelningen.");
    }

    public override void DoWork()
    {
        Console.WriteLine($"The employee is completing their tasks as a {JobTitle}.");
    }

    public bool RequestVacation(int days)
    {
        if (days <= 0 || days > VacationDays)
        {
            Console.WriteLine(
                $"{Name} kan inte ta ut {days} semesterdagar (kvar: {VacationDays})."
            );
            return false;
        }
        VacationDays -= days;
        Console.WriteLine($"{Name} har tagit ut {days} semesterdagar (kvar: {VacationDays}).");
        return true;
    }

    public void ChangeShift(ShiftPreference newShift)
    {
        ShiftPreference = newShift;
    }
}
