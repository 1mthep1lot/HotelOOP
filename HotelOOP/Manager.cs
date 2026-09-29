namespace HotelOOP;

internal class Manager : Person
{
    public string Department { get; set; } = "";
    public decimal Budget { get; set; }
    public int TeamSize { get; set; }
    public decimal BonusPercentage { get; set; }
    public ManagementLevel ManagementLevel { get; set; } = ManagementLevel.Junior;

    public override string Role => $"{ManagementLevel} Manager";

    public void HoldMeeting()
    {
        Console.WriteLine($"{Name} håller ett personalmöte på hotellet.");
    }

    public void PlanBudget()
    {
        Console.WriteLine($"{Name} planerar hotellets budget.");
    }

    public override void DoWork()
    {
        Console.WriteLine($"The manager is planning and leading in the {Department} department.");
    }

    public void AssignTeam(int size)
    {
        if (size < 0)
            throw new ArgumentException("Teamstorleken kan inte vara negativ.", nameof(size));
        TeamSize = size;
    }

    public decimal CalculateBonus()
    {
        return Salary * BonusPercentage / 100m;
    }
}
