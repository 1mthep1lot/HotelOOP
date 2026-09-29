namespace HotelOOP;

internal class Consultant : Person
{
    public int HourlyRate { get; set; }
    public string ConsultingFirm { get; set; } = "";
    public string Expertise { get; set; } = "";
    public TimeSpan ContractDuration { get; set; }
    public string ProjectName { get; set; } = "";
    public decimal BillableHours { get; set; }

    public override string Role => $"Consultant ({Expertise})";

    public void GiveAdvice()
    {
        Console.WriteLine(
            $"{Name} ger råd till hotellet om hur de kan förbättra sina rutiner inom området {Expertise}."
        );
    }

    public override void DoWork()
    {
        Console.WriteLine($"The consultant is offering strategic advice on {Expertise}.");
    }

    public void ExtendContract(TimeSpan extension)
    {
        ContractDuration += extension;
    }

    public void LogBillableHours(decimal hours)
    {
        if (hours <= 0)
            throw new ArgumentException("Antal timmar måste vara positivt.", nameof(hours));
        BillableHours += hours;
    }
}
